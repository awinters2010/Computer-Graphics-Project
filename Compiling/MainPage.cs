using System;
using System.Windows.Forms;
using SlimDX;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using SlimDX.Direct3D9;
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

        private Renderer renderer;

        Point p;
        bool objectSelected = false;

        public MainPage()
        {
            //don't touch this method. microsoft created
            InitializeComponent();

            //this method initializes the Device
            DeviceManager.CreateDevice(panel1.Handle, panel1.Width, panel1.Height);

            camera = new Camera();

            camera.SetView(new Vector3(0, 0, -3.5f), Vector3.Zero, Vector3.UnitY);

            DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, false);

            //set GUI control attributes
            SetGui();

            panel1.Focus();

            this.KeyPress += new KeyPressEventHandler(KeyBoard);

            Configuration.EnableObjectTracking = true;

            renderer = new Renderer();
            Init();
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
                //renderer.Meshes.Add(new Mesh());

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
            FillMode fm = DeviceManager.LocalDevice.GetRenderState
                <FillMode>(RenderState.FillMode);

            if (e.KeyChar.ToString() == Keys.F.ToString().ToLower())
            {
                fm = fm == FillMode.Solid ?
                    FillMode.Wireframe : FillMode.Solid;
            }

            DeviceManager.LocalDevice.SetRenderState(RenderState.FillMode, fm);

            if (e.KeyChar.ToString() == Keys.Z.ToString().ToLower())
            {
                camera.MoveCameraZ(1f);
            }
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
                  DialogResult = MessageBox.Show("Are you SURE you want to Delete this shape!? \n Please select one option Yes/No",
                                                "Conditional", MessageBoxButtons.YesNo,  MessageBoxIcon.Information);

                  if (DialogResult == DialogResult.Yes)
                  {
                      //code to remove shape
                  }
                  else
                  {
                      //do nothing
                  }
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
            SetCameraPosition();
        }
        private void btnCamR_Click(object sender, EventArgs e)
        {
            camera.MoveCameraX(1);
            SetCameraPosition();
        }
        private void CamB_Click(object sender, EventArgs e)
        {
            camera.MoveCameraZ(1);
            SetCameraPosition();
        }
        private void CamF_Click(object sender, EventArgs e)
        {
            camera.MoveCameraZ(-1);
            SetCameraPosition();
        }
        private void btnCamU_Click(object sender, EventArgs e)
        {
            camera.MoveCameraY(1);
            SetCameraPosition();
        }
        private void btnCamD_Click(object sender, EventArgs e)
        {
            camera.MoveCameraY(-1);
            SetCameraPosition();
        }
        private void btnRCamL_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(new Vector3(0,1,0));
        }
        private void btnRCamU_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(new Vector3(0,0,1));
        }
        private void btnRCamR_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(new Vector3(0,-1,0));
        }
        private void btnRCamD_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(new Vector3(0,0,-1));
        }
        /// <summary>
        /// Enters the camera's current position into GUI labels
        /// </summary>
        private void SetCameraPosition()
        {
            Vector3 cameraLocation = camera.CameraPosition();
            lblCamXPos.Text = cameraLocation.X.ToString();
            lblCamYPos.Text = cameraLocation.Y.ToString();
            lblCamZPos.Text = cameraLocation.Z.ToString();
        }
        /// <summary>
        /// Enters the camera's current position into GUI labels
        /// </summary>
        private void SetCameraRotation()
        {
            //lblCamXRot.Text = 
            //lblCamYRot.Text =
            //lblCamZRot.Text =
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
                string file = ofdMesh.FileName;
                string fileName = ofdMesh.SafeFileName;
                Console.WriteLine(ofdMesh.SafeFileName);
                if (File.Exists(file))
                {
                    //Make sure it's a .x file
                    if (file.ToUpper().Contains(".X"))
                    {
                        //Code to load Mesh
                        Console.WriteLine(file.ToString());
                        renderer.Meshes.Add(new MeshClass(file, fileName));
                    }
                    else
                    {
                        MessageBox.Show("The file " + file + " is not a valid .x Mesh file!");
                    }
                }
                else
                {
                    MessageBox.Show("The file " + file + " does not exist!");
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

        private void btnClearScene_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you SURE you want to CLEAR this entire scene?\n Please select one option Yes/No",
                                "Conditional", MessageBoxButtons.YesNo,  MessageBoxIcon.Information);
            
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    //Code to clear scene
                }
                catch (Exception ex)
                {
                    //handle exception
                }
                finally
                {
                    MessageBox.Show("Clear Scene failed: An error has occured!");
                }
            }
            else
            {
                //do nothing
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gbCamera_Enter(object sender, EventArgs e)
        {

        }

    }
}