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
        #region Variables

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

        #endregion

        public MainPage()
        {
            //don't touch this method. microsoft created
            InitializeComponent();

            //this method initializes the Device
            DeviceManager.CreateDevice(panel1.Handle, panel1.Width, panel1.Height);

            camera = new Camera();

            DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, false);
            DeviceManager.LocalDevice.SetRenderState(RenderState.CullMode, Cull.Counterclockwise);
            DeviceManager.LocalDevice.SetRenderState(RenderState.ZEnable, ZBufferType.UseZBuffer);


            //set GUI control attributes
            SetGui();

            panel1.Focus();

            this.KeyPress += new KeyPressEventHandler(KeyBoard);

            Configuration.EnableObjectTracking = true;

            renderer = new Renderer();
            Init();
        }

        private void Init()
        {
            renderThread = new Thread(new ThreadStart(renderer.RenderScene));
            renderThread.Start();
        }

        #region Shape Menu Drawing

        //adds a new cube to the screen
        private void CubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderer.Meshes)
            {
                renderer.Meshes.Add(new MeshClass(MeshType.Cube));
                //renderer.Meshes.Add(new Mesh());

                //there may be a better place to put this
                AddToShapeList("Cube");
            }
        }

        //adds a new triangle to the screen
        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderer.Meshes)
            {
                renderer.Meshes.Add(new MeshClass(MeshType.Triangle));

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
                fm = fm == FillMode.Solid ? FillMode.Wireframe : FillMode.Solid;
            }

            DeviceManager.LocalDevice.SetRenderState(RenderState.FillMode, fm);

            if (e.KeyChar.ToString() == Keys.Z.ToString().ToLower())
            {
                camera.MoveEye(z: 1f);
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
            gbObjects.BackColor = GUISubWindowColor;
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
            ShapeListItem sliToAdd = new ShapeListItem(renderer.Meshes.Count, ShapeDesc);

            Console.WriteLine(sliToAdd.ToString());

            //Add object    
            cboShapeList.Items.Add(sliToAdd);
        }

        /// <summary>
        /// Updates shape count label
        /// </summary>
        public void UpdateShapeCount()
        {
            //update shape count
            lblSCnt2.Text = renderer.Meshes.Count.ToString();
        }

        private void cboShapeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShapeList.SelectedIndex != -1)
            {
                lblSS2.Text = cboShapeList.Text.ToString();
                xTranslation.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectPosition.X.ToString();
                yTranslation.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectPosition.Y.ToString();
                zTranslation.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectPosition.Z.ToString();
                xRotation.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectRotate.X.ToString();
                yRotation.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectRotate.X.ToString();
                zRotation.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectRotate.X.ToString();
                xScaling.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectScale.X.ToString();
                yScaling.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectScale.X.ToString();
                zScaling.Text = renderer.Meshes[cboShapeList.SelectedIndex].ObjectScale.X.ToString();
            }
        }

        #endregion

        #region Camera Related Methods

        private void btnResetCamera_Click(object sender, EventArgs e)
        {
            camera.ResetEye();
            UpdateCameraLocation();
            UpdateCameraRotation();
        }
        private void btnCamL_Click(object sender, EventArgs e)
        {
            camera.MoveEye(x: -1);
            UpdateCameraLocation();
        }
        private void btnCamR_Click(object sender, EventArgs e)
        {
            camera.MoveEye(x: 1);
            UpdateCameraLocation();
        }
        private void CamB_Click(object sender, EventArgs e)
        {
            camera.MoveEye(z: 1);
            UpdateCameraLocation();
        }
        private void CamF_Click(object sender, EventArgs e)
        {
            camera.MoveEye(z: -1);
            UpdateCameraLocation();
        }
        private void btnCamU_Click(object sender, EventArgs e)
        {
            camera.MoveEye(y: 1);
            UpdateCameraLocation();
        }
        private void btnCamD_Click(object sender, EventArgs e)
        {
            camera.MoveEye(y: -1);
            UpdateCameraLocation();
        }
        private void btnRCamL_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(0, 1, 0);
            UpdateCameraRotation();
        }
        private void btnRCamU_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(1f, 0, 0);
            UpdateCameraRotation();
        }
        private void btnRCamR_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(0, -1, 0);
            UpdateCameraRotation();
        }
        private void btnRCamD_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(-1f, 0, 0);
            UpdateCameraRotation();
        }
        private void UpdateCameraLocation()
        {
            lblCamPosX.Text = camera.Eye.X.ToString();
            lblCamPosY.Text = camera.Eye.Y.ToString();
            lblCamPosZ.Text = camera.Eye.Z.ToString();
        }
        private void UpdateCameraRotation()
        {
            lblCamRotX.Text = camera.CameraRotation.X.ToString();
            lblCamRotY.Text = camera.CameraRotation.Y.ToString();
            lblCamRotZ.Text = camera.CameraRotation.Z.ToString();
        }

        #endregion

        #region Mesh Loading Functions

        private void miLoadMesh_Click(object sender, EventArgs e)
        {
            ofdMesh.ShowDialog();
        }

        private void ofdMesh_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Try to read file
            try
            {
                if (File.Exists(ofdMesh.FileName))
                {
                    //Make sure it's a .x file
                    if (ofdMesh.FileName.ToUpper().Contains(".X") || ofdMesh.FileName.ToLower().Contains(".x"))
                    {
                        //Code to load Mesh
                        renderer.Meshes.Add(new MeshClass(ofdMesh.FileName, ofdMesh.SafeFileName));

                        AddToShapeList(ofdMesh.SafeFileName);
                    }
                    else
                    {
                        MessageBox.Show("The file " + ofdMesh.FileName + " is not a valid .x Mesh file!");
                    }
                }
                else
                {
                    MessageBox.Show("The file " + ofdMesh.FileName + " does not exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured trying to load Mesh file!");
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Shape Movement

        private void xTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text), float.Parse(yTranslation.Text), float.Parse(zTranslation.Text));
                }
            }
        }

        private void yTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text), float.Parse(yTranslation.Text), float.Parse(zTranslation.Text));
                }
            }
        }

        private void zTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text), float.Parse(yTranslation.Text), float.Parse(zTranslation.Text));
                }
            }
        }

        private void xRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Rotate(float.Parse(xRotation.Text), float.Parse(yRotation.Text), float.Parse(zRotation.Text));
                }
            }
        }

        private void yRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Rotate(float.Parse(xRotation.Text), float.Parse(yRotation.Text), float.Parse(zRotation.Text));
                }
            }
        }

        private void zRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Rotate(float.Parse(xRotation.Text), float.Parse(yRotation.Text), float.Parse(zRotation.Text));
                }
            }
        }

        private void xScaling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Scale(new Vector3(float.Parse(xScaling.Text), float.Parse(yScaling.Text), float.Parse(zScaling.Text)));
                }
            }
        }

        private void yScaling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Scale(new Vector3(float.Parse(xScaling.Text), float.Parse(yScaling.Text), float.Parse(zScaling.Text)));
                }
            }
        }

        private void zScaling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    renderer.Meshes[cboShapeList.SelectedIndex].Scale(new Vector3(float.Parse(xScaling.Text), float.Parse(yScaling.Text), float.Parse(zScaling.Text)));
                }
            }
        }

        #endregion

        #region Deletion

        private void btnClearScene_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you SURE you want to CLEAR this entire scene?\n Please select one option Yes/No",
                                "Conditional", MessageBoxButtons.YesNo,  MessageBoxIcon.Information);
            
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    //Code to clear scene
                    lock (renderer.Meshes)
                    {
                        renderer.Meshes.ForEach(mesh => mesh.Dispose());
                        renderer.Meshes.Clear();
                        cboShapeList.Items.Clear();
                        UpdateShapeCount();
                    }
                }
                catch (Exception)
                {
                    //handle exception
                    MessageBox.Show("Clear Scene failed: An error has occured!");
                }
            }
        }

        private void btnDeleteShape_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
                DialogResult = MessageBox.Show("Are you SURE you want to Delete this object!? \n Please select one option Yes/No",
                                              "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DialogResult == DialogResult.Yes)
                {
                    //code to remove shape
                    if (cboShapeList.SelectedIndex != -1)
                    {
                        lock (renderer.Meshes)
                        {
                            renderer.Meshes[cboShapeList.SelectedIndex].Dispose();
                            renderer.Meshes.RemoveAt(cboShapeList.SelectedIndex);
                            cboShapeList.Items.RemoveAt(cboShapeList.SelectedIndex);
                            UpdateShapeCount();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Delete failed: No Object is selected!");
            }
        }

        #endregion

        #region Program Shutdown

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        private void ShutDown()
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion 
    }
}