using System;
using System.Windows.Forms;
using SlimDX;
using System.Threading;
using System.Drawing;
using SDX3D9 = SlimDX.Direct3D9;
using System.Collections.Generic;
using SlimDX.Direct3D9;
using System.Collections.ObjectModel;
using System.IO;

namespace Graphics
{
    public partial class MainPage : Form
    {
        //the thread that the graphics will be running in so the UI doesn't lock up.
        private Thread renderThread;

        private Result errorResult;

        private Camera camera;

        //GUI colors
        private static Color GUIBackColor = System.Drawing.Color.FromArgb(162, 162, 162);
        private static Color GUISubWindowColor = System.Drawing.Color.FromArgb(194, 194, 194);
        private static Color GUISubWindowHeaderColor = System.Drawing.Color.FromArgb(218, 218, 218);

        private VertexBuffer vBuffer;
        private IndexBuffer iBuffer;

        private Renderer renderer;

        Point p;
        bool objectSelected = false;

        private List<MeshClass> Meshes = new List<MeshClass>();

        public MainPage()
        {
            //don't touch this method. microsoft created
            InitializeComponent();

            //this method initializes the Device
            DeviceManager.CreateDevice(panel1.Handle,
                panel1.Width, panel1.Height);

            camera = new Camera();

            camera.SetView(new Vector3(0, 0, -3.5f), Vector3.Zero, Vector3.UnitY);

            DeviceManager.LocalDevice.SetRenderState(SDX3D9.RenderState.Lighting, false);

            //set GUI control attributes
            SetGui();

            panel1.Focus();

            this.KeyPress += new KeyPressEventHandler(KeyBoard);


            Configuration.EnableObjectTracking = true;

            renderer = new Renderer();
            Init();
            renderer.Shapes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Shapes_CollectionChanged);

        }

        void Shapes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            renderer.verticesCount += renderer.Shapes[e.NewStartingIndex].ShapeVertices.Length;
            renderer.indiciesCount += renderer.Shapes[e.NewStartingIndex].ShapeIndices.Length;

            List<VertexUntransformed> v = new List<VertexUntransformed>();
            List<short> i = new List<short>();

            foreach (var item in renderer.Shapes)
            {
                v.AddRange(item.ShapeVertices);
                i.AddRange(item.ShapeIndices);
            }

            vBuffer = new VertexBuffer(DeviceManager.LocalDevice, renderer.verticesCount * VertexUntransformed.VertexByteSize, Usage.Dynamic, VertexUntransformed.format, Pool.Default);
            vBuffer.Lock(0, renderer.verticesCount * VertexUntransformed.VertexByteSize, LockFlags.Discard).WriteRange(v.ToArray());
            vBuffer.Unlock();

            iBuffer = new IndexBuffer(DeviceManager.LocalDevice, renderer.indiciesCount * sizeof(short), Usage.WriteOnly, Pool.Default, true);
            iBuffer.Lock(0, renderer.indiciesCount * sizeof(short), LockFlags.Discard).WriteRange(i.ToArray());
            iBuffer.Unlock();

            DeviceManager.LocalDevice.Indices = iBuffer;
            DeviceManager.LocalDevice.SetStreamSource(0, vBuffer, 0, VertexUntransformed.VertexByteSize);
            DeviceManager.LocalDevice.VertexDeclaration = VertexUntransformed.VertexDecl;

            Console.WriteLine(Environment.WorkingSet / 1048576);

            vBuffer.Dispose();
            iBuffer.Dispose();
        }

        public void Init()
        {
            renderThread = new Thread(new ThreadStart(renderer.RenderScene));
            renderThread.Start();
        }

        #region Program Shutdown

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        public void ShutDown()
        {
            renderer.RequestShutdown();

            if (vBuffer !=null && iBuffer != null)
            {
                vBuffer.Dispose();
                iBuffer.Dispose();
            }

            VertexUntransformed.VertexDecl.Dispose();

            while (!DeviceManager.LocalDevice.Disposed)
            {
                DeviceManager.LocalDevice.EvictManagedResources();
                DeviceManager.LocalDevice.Direct3D.Dispose();
                DeviceManager.LocalDevice.Dispose();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutDown();
        }

        #endregion

        #region Shape Menu Drawing

        //adds a new cube to the screen
        private void CubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderer.Shapes)
            {
                renderer.Shapes.Add(new Cube());
                
                //there may be a better place to put this
                AddToShapeList("Cube");
            }
        }

        //adds a new triangle to the screen
        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderer.Shapes)
            {
                renderer.Shapes.Add(new Triangle());
                //there may be a better place to put this
                AddToShapeList("Triangle");
            }
        }

        #endregion

        private void KeyBoard(object sender, KeyPressEventArgs e)
        {
            SDX3D9.FillMode fm = DeviceManager.LocalDevice.GetRenderState
                <SDX3D9.FillMode>(SDX3D9.RenderState.FillMode);

            if (e.KeyChar.ToString() == Keys.F.ToString().ToLower())
            {
                fm = fm == SDX3D9.FillMode.Solid ?
                    SDX3D9.FillMode.Wireframe : SDX3D9.FillMode.Solid;
            }

            DeviceManager.LocalDevice.SetRenderState(SDX3D9.RenderState.FillMode, fm);

            if (e.KeyChar.ToString() == Keys.Z.ToString().ToLower())
            {
                camera.MoveCameraZ(1f);
            }
            Console.WriteLine(Environment.StackTrace);
        }

        /// <summary>
        /// Sets GUI Menu items and controls including width and colors
        /// </summary>
        private void SetGui()
        {
            //set colors

            //main form
            this.BackColor = GUIBackColor;

            //notification area
            plNotArea.BackColor = GUIBackColor;
            gbMemUsage.BackColor = GUISubWindowColor;
            gbCamera.BackColor = GUISubWindowColor;
            gbRotate.BackColor = GUISubWindowColor;
            gbScale.BackColor = GUISubWindowColor;
            gbShapes.BackColor = GUISubWindowColor;
            gbTranslate.BackColor = GUISubWindowColor;

            //set control sizes
            plNotArea.Width = this.Width;

            //set shape drop down list value and display members
            cboShapeList.ValueMember = "ID";
            cboShapeList.DisplayMember = "ShapeDesc";
        }

        #region "Shape DropDownList Related Methods"
        /// <summary>
        /// Adds a new shape to the shape list combo box
        /// </summary>
        public void AddToShapeList(string ShapeDesc)
        {
            //update shape count
            UpdateShapeCount();

            //create new object, set ID = shape count, set description to shape type
            ShapeListItem sliToAdd = new ShapeListItem(renderer.Shapes.Count, ShapeDesc);

            //Add object    
            cboShapeList.Items.Add(sliToAdd);
        }

        /// <summary>
        /// Updates shape count label
        /// </summary>
        public void UpdateShapeCount()
        {
            //update shape count
            lblSCnt2.Text = renderer.Shapes.Count.ToString();
        }

        private void cboShapeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShapeList.SelectedIndex != -1)
            {
                lblSS2.Text = cboShapeList.Text.ToString();
                xTranslation.Text = renderer.Shapes[cboShapeList.SelectedIndex].Position.X.ToString();
                yTranslation.Text = renderer.Shapes[cboShapeList.SelectedIndex].Position.Y.ToString();
                zTranslation.Text = renderer.Shapes[cboShapeList.SelectedIndex].Position.Z.ToString();
                xRotation.Text = renderer.Shapes[cboShapeList.SelectedIndex].Rotation.X.ToString();
                xScaling.Text = renderer.Shapes[cboShapeList.SelectedIndex].Scaling.X.ToString();
            }
        }
        #endregion

        private void btnDeleteShape_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
  
            }
            else
            {
                MessageBox.Show("Delete failed: No Shape is selected!");
            }
        }

        #region "Translation Related Methods"
        private void btnTransL_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
            //get index (id) of selected shape
            ShapeListItem sliSelected = new ShapeListItem(1, "");
            sliSelected = (ShapeListItem)cboShapeList.SelectedItem;

            renderer.Shapes[sliSelected.ID - 1].Translate(renderer.Shapes[sliSelected.ID - 1].Position.X - 1, renderer.Shapes[sliSelected.ID - 1].Position.Y, renderer.Shapes[sliSelected.ID - 1].Position.Z);
            }
            else
            {
                MessageBox.Show("Translation failed: No Shape is selected!");
            }
        }
        private void btnTransU_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
                //get index (id) of selected shape
                ShapeListItem sliSelected = new ShapeListItem(1, "");
                sliSelected = (ShapeListItem)cboShapeList.SelectedItem;

                renderer.Shapes[sliSelected.ID - 1].Translate(renderer.Shapes[sliSelected.ID - 1].Position.X, renderer.Shapes[sliSelected.ID - 1].Position.Y + 1, renderer.Shapes[sliSelected.ID - 1].Position.Z);
            }
            else
            {
                MessageBox.Show("Translation failed: No Shape is selected!");
            }
        }
        private void btnTransR_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
                //get index (id) of selected shape
                ShapeListItem sliSelected = new ShapeListItem(1, "");
                sliSelected = (ShapeListItem)cboShapeList.SelectedItem;

                renderer.Shapes[sliSelected.ID - 1].Translate(renderer.Shapes[sliSelected.ID - 1].Position.X + 1, renderer.Shapes[sliSelected.ID - 1].Position.Y, renderer.Shapes[sliSelected.ID - 1].Position.Z);
            }
            else
            {
                MessageBox.Show("Translation failed: No Shape is selected!");
            }
        }
        private void btnTransD_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
                //get index (id) of selected shape
                ShapeListItem sliSelected = new ShapeListItem(1, "");
                sliSelected = (ShapeListItem)cboShapeList.SelectedItem;

                renderer.Shapes[sliSelected.ID - 1].Translate(renderer.Shapes[sliSelected.ID - 1].Position.X, renderer.Shapes[sliSelected.ID - 1].Position.Y - 1, renderer.Shapes[sliSelected.ID - 1].Position.Z);
            }
            else
            {
                MessageBox.Show("Translation failed: No Shape is selected!");
            }
        }
        private void TransB_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
                //get index (id) of selected shape
                ShapeListItem sliSelected = new ShapeListItem(1, "");
                sliSelected = (ShapeListItem)cboShapeList.SelectedItem;

                renderer.Shapes[sliSelected.ID - 1].Translate(renderer.Shapes[sliSelected.ID - 1].Position.X, renderer.Shapes[sliSelected.ID - 1].Position.Y, renderer.Shapes[sliSelected.ID - 1].Position.Z + 1);
            }
            else
            {
                MessageBox.Show("Translation failed: No Shape is selected!");
            }
        }
        private void TransF_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
                //get index (id) of selected shape
                ShapeListItem sliSelected = new ShapeListItem(1, "");
                sliSelected = (ShapeListItem)cboShapeList.SelectedItem;

                renderer.Shapes[sliSelected.ID - 1].Translate(renderer.Shapes[sliSelected.ID - 1].Position.X, renderer.Shapes[sliSelected.ID - 1].Position.Y, renderer.Shapes[sliSelected.ID - 1].Position.Z - 1);
            }
            else
            {
                MessageBox.Show("Translation failed: No Shape is selected!");
            }
        }
        #endregion

        #region "Cameral Related Methods"
        private void btnCamL_Click(object sender, EventArgs e)
        {
            camera.MoveCameraX(-1);
        }
        private void btnCamR_Click(object sender, EventArgs e)
        {
            camera.MoveCameraX(1);
        }
        private void CamB_Click(object sender, EventArgs e)
        {
            camera.MoveCameraZ(1);
        }
        private void CamF_Click(object sender, EventArgs e)
        {
            camera.MoveCameraZ(-1);
        }
        private void btnCamU_Click(object sender, EventArgs e)
        {
            camera.MoveCameraY(1);
        }
        private void btnCamD_Click(object sender, EventArgs e)
        {
            camera.MoveCameraY(-1);
        }
        private void btnRCamL_Click(object sender, EventArgs e)
        {
            //camera.RotateCameraY(.1f);
        }
        private void btnRCamU_Click(object sender, EventArgs e)
        {
            //camera.RotateCameraZ(.1f);
        }
        private void btnRCamR_Click(object sender, EventArgs e)
        {
            //camera.RotateCameraY(-.1f);
        }
        private void btnRCamD_Click(object sender, EventArgs e)
        {
            //camera.RotateCameraZ(-.1f);
        }
        #endregion

        #region "Mesh Loading Functions"
        private void miLoadMesh_Click(object sender, EventArgs e)
        {
            ofdMesh.ShowDialog();
        }

        private void ofdMesh_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Try to read file
            try
            {
                string filename = ofdMesh.FileName;
                if (File.Exists(filename))
                {
                    //Make sure it's a .x file
                    if (filename.ToUpper().Contains(".X"))
                    {
                        //Code to load Mesh
                        System.Diagnostics.Debug.WriteLine(filename.ToString());
                        Mesh m = Mesh.FromFile(DeviceManager.LocalDevice, filename, MeshFlags.SystemMemory);
                        m.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("The file " + filename + " is not a valid .x Mesh file!");
                    }
                }
                else
                {
                    MessageBox.Show("The file " + filename + " does not exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured trying to load Mesh file!");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        private void xTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Shapes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text), float.Parse(yTranslation.Text), float.Parse(zTranslation.Text));
                }
            }
        }

        private void yTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Shapes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text), float.Parse(yTranslation.Text), float.Parse(zTranslation.Text));
                }
            }
        }

        private void zTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Shapes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text), float.Parse(yTranslation.Text), float.Parse(zTranslation.Text));
                }
            }
        }

        private void xRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Shapes[cboShapeList.SelectedIndex].Rotate(float.Parse(xRotation.Text), 0, 0);
                }
            }
        }

        private void xScaling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Shapes[cboShapeList.SelectedIndex].Scale(new Vector3(float.Parse(xScaling.Text), 1, 1));
                }
            }
        }
    }
}