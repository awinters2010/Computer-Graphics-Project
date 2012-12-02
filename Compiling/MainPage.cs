using System;
using System.Windows.Forms;
using SlimDX;
using System.Linq;
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
        private Camera camera;
        private Renderer renderer;

        //GUI colors
        private static Color GUIBackColor = System.Drawing.Color.FromArgb(162, 162, 162);
        private static Color GUISubWindowColor = System.Drawing.Color.FromArgb(194, 194, 194);
        private static Color GUISubWindowHeaderColor = System.Drawing.Color.FromArgb(218, 218, 218);

        Point p;
        bool objectSelected = false;

        //to control mouse startng location for 
        bool FirstMouseMouse = false;

        const int PixelDifferential = 20;

        #endregion

        public MainPage()
        {
            //don't touch this method. microsoft created
            InitializeComponent();

            //this method initializes the Device
            DeviceManager.CreateDevice(panel1.Handle, panel1.Width, panel1.Height);

            camera = new Camera();

            renderer = new Renderer();
            Init();

            DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, renderer.IsGlobalLightOn);
            DeviceManager.LocalDevice.SetRenderState(RenderState.CullMode, Cull.Counterclockwise);
            DeviceManager.LocalDevice.SetRenderState(RenderState.ZEnable, ZBufferType.UseZBuffer);
            DeviceManager.LocalDevice.SetRenderState(RenderState.NormalizeNormals, true);
            DeviceManager.LocalDevice.SetRenderState(RenderState.Ambient, Color.Gray.ToArgb());
            DeviceManager.LocalDevice.SetRenderState(RenderState.SpecularEnable, false);

            //set GUI control attributes
            SetGui();

            
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);

            Configuration.EnableObjectTracking = true;

            panel1.Focus();
            Console.WriteLine(panel1.Focused);
            Console.WriteLine(panel1.PointToScreen(MousePosition));
            if (panel1.Focused)
            {
                
                p = panel1.PointToScreen(MousePosition);
            }
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
                AddToShapeList("Cube", renderer.Meshes.Count);
            }
        }

        //adds a new triangle to the screen
        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (renderer.Meshes)
            {
                renderer.Meshes.Add(new MeshClass(MeshType.Triangle));

                //there may be a better place to put this
                AddToShapeList("Triangle", renderer.Meshes.Count);
            }
        }

        #endregion

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
            gbColor.BackColor = GUISubWindowColor;
            gbLighting.BackColor = GUISubWindowColor;
            gbPhysics.BackColor = GUISubWindowColor;

            //set shape drop down list value and display members
            cboShapeList.ValueMember = "ID";
            cboShapeList.DisplayMember = "ShapeDesc";

            cbPointLights.ValueMember = "ID";
            cbPointLights.DisplayMember = "ShapeDesc";
        }

        #region "Shape DropDownList Related Methods"

        /// <summary>
        /// Adds a new shape to the shape list combo box
        /// </summary>
        public void AddToShapeList(string ShapeDesc, int ID)
        {
            //update shape count
            UpdateShapeCount();

            //create new object, set ID = shape count, set description to shape type
            ShapeListItem sliToAdd = new ShapeListItem(ID, ShapeDesc);

            //Add object    
            cboShapeList.Items.Add(sliToAdd);
            cboShapeList.SelectedIndex = cboShapeList.Items.Count - 1;
            txtRename.Text = renderer.Meshes[cboShapeList.SelectedIndex].Name;
        }

        /// <summary>
        /// Updates shape count label
        /// </summary>
        public void UpdateShapeCount()
        {
            //update shape count
            lblSCnt2.Text = renderer.Meshes.Count.ToString();
        }

        /// <summary>
        /// Updates shape index (call after remove)
        /// </summary>
        public void RenumberShapeList()
        {
            cboShapeList.Items.Clear();
            int objCounter = 1;
            foreach (MeshClass myMesh in renderer.Meshes)
            {
                AddToShapeList(myMesh.Name, objCounter);
                objCounter++;
            }
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
                SetCurrentColorLabel();
                //deselect any lights
                lblSelectedLight.Text = "<none>";

                //reset name box
                txtRename.Text = renderer.Meshes[cboShapeList.SelectedIndex].Name;
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
            camera.MoveEye(y: -1);
            UpdateCameraLocation();
        }
        private void btnCamD_Click(object sender, EventArgs e)
        {
            camera.MoveEye(y: 1);
            UpdateCameraLocation();
        }
        private void btnRCamL_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(0, 1f, 0);
            UpdateCameraRotation();
        }
        private void btnRCamU_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(1f, 0, 0);
            UpdateCameraRotation();
        }
        private void btnRCamR_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(0, -1f, 0);
            UpdateCameraRotation();
        }
        private void btnRCamD_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(-1f, 0, 0);
            UpdateCameraRotation();
        }
        private void btnRCamB_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(0, 0, -1f);
            UpdateCameraRotation();
        }
        private void btnRCamF_Click(object sender, EventArgs e)
        {
            camera.CameraRotation = new Vector3(0, 0, 1f);
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

                        AddToShapeList(ofdMesh.SafeFileName, renderer.Meshes.Count);
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
            DialogResult = MessageBox.Show("Are you SURE you want to CLEAR this entire scene?\nThis includes ALL Objects and ALL Lights \nPlease select one option Yes/No",
                                "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    ClearScene();
                    UpdateShapeCount();
                    UpdateLightCount();
                    txtRename.Text = "";
                    
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
                            RenumberShapeList();
                            lblSS2.Text = "<none>";
                            txtRename.Text = "";
                            cboShapeList.SelectedIndex = -1;
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

        private void ClearScene()
        {
            lock (renderer.Lights)
            {
                renderer.Lights.ForEach(light => light.Dispose());
                renderer.Lights.Clear();
            }

            //Code to clear scene
            lock (renderer.Meshes)
            {
                renderer.Meshes.ForEach(mesh => mesh.Dispose());
                renderer.Meshes.Clear();
                cboShapeList.Items.Clear();
            }

            if (renderer.Terrian != null)
            {
                renderer.Terrian.Dispose();
                renderer.Terrian = null;
            }
        }

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        private void ShutDown()
        {
            renderer.RequestShutdown();

            if (!CustomVertex.VertexPositionColor.VertexDecl.Disposed)
            {
                CustomVertex.VertexPositionColor.VertexDecl.Dispose();
            }
            if (!CustomVertex.VertexPositionNormalColor.VertexDecl.Disposed)
            {
                CustomVertex.VertexPositionNormalColor.VertexDecl.Dispose();
            }

            while (!DeviceManager.LocalDevice.Disposed && !renderThread.IsAlive)
            {
                DeviceManager.LocalDevice.EvictManagedResources();
                DeviceManager.LocalDevice.Direct3D.Dispose();
                DeviceManager.LocalDevice.Dispose();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearScene();
            ShutDown();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region "Physics"
        private void cbGravity_CheckedChanged(object sender, EventArgs e)
        {
            renderer.Gravity = cbGravity.Checked;
        }
        #endregion

        #region "Texture Loading Functions"
        private void loadTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdTexture.ShowDialog();
        }
        private void ofdTexture_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Try to read file
            try
            {
                if (File.Exists(ofdTexture.FileName))
                {
                    //Make sure it's a texture file type, this should be good enough
                    if (ofdTexture.FileName.ToUpper().Contains(".BMP") || ofdTexture.FileName.ToUpper().Contains(".DDS") || ofdTexture.FileName.ToUpper().Contains(".JPG"))
                    {
                        //Code to load Texture
                        foreach (MeshClass myMesh in renderer.Meshes)
                        {
                            if (myMesh.IsShapeObject) myMesh.ApplyTextureMesh(ofdMesh.FileName, ofdMesh.SafeFileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file " + ofdTexture.FileName + " is not a valid .bmp, .dds, or .jpg Texture file!");
                    }
                }
                else
                {
                    MessageBox.Show("The file " + ofdTexture.FileName + " does not exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured trying to load Texture file!");
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region "Validation"
        private void xTranslation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.xTranslation);
        }
        private void yTranslation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.yTranslation);
        }
        private void zTranslation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.zTranslation);
        }
        private void xRotation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.xRotation);
        }
        private void yRotation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.yRotation);
        }
        private void zRotation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.zRotation);
        }
        private void xScaling_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.xScaling);
        }
        private void yScaling_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.yScaling);
        }
        private void zScaling_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.zScaling);
        }
        private void xTranslation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.xTranslation, string.Empty);
        }
        private void yTranslation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.yTranslation, string.Empty);
        }
        private void zTranslation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.zTranslation, string.Empty);
        }
        private void xRotation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.xRotation, string.Empty);
        }
        private void yRotation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.yRotation, string.Empty);
        }
        private void zRotation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.zRotation, string.Empty);
        }
        private void xScaling_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.xScaling, string.Empty);
        }
        private void yScaling_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.yScaling, string.Empty);
        }
        private void zScaling_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.zScaling, string.Empty);
        }
        private bool validateTextBoxIsInt(TextBox TextBoxToVal)
        {
            bool cancel = false;
            int number = -1;
            if (int.TryParse(TextBoxToVal.Text, out number))
            {
                //it's a number, this control passes validation.
                cancel = false;
            }
            else
            {
                //This control has failed validation: text box is not a number
                cancel = true;
                this.epMain.SetError(TextBoxToVal, "You must provide a valid integer!");
            }
            return cancel;
        }
        #endregion

        #region "Mouse Events"
        private void panel1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //// Update the mouse path with the mouse information
            //Point mouseDownLocation = new Point(e.X, e.Y);

            //string eventString = null;
            //switch (e.Button)
            //{
            //    case MouseButtons.Left:
            //        eventString = "L";
            //        Console.WriteLine("x " + e.X + " y " + e.Y);
            //        break;
            //    case MouseButtons.Right:
            //        break;
            //    case MouseButtons.Middle:
            //        break;
            //    case MouseButtons.None:
            //        break;
            //}

            //if (eventString != null)
            //{
            //    //use mouseDownLocation for x and y coordinate
            //    //example
            //    //MessageBox.Show("X - " + mouseDownLocation.X.ToString() + " Y - " + mouseDownLocation.Y.ToString());

            //}
            //else
            //{
            //    //Left mouse button was not clicked
            //}
            //panel1.Focus();
        }
        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Update the camera z based upon the mouse wheel scrolling.
            camera.MoveEye(z: (e.Delta / 120 * -1));
            UpdateCameraLocation();

        }
        private void panel1_MouseEnter(Object sender, System.EventArgs e)
        {
            panel1.Focus();
        }
        private void xTranslation_MouseUp(object sender, MouseEventArgs e)
        {
            xTranslation.SelectAll();
        }
        private void yTranslation_MouseUp(object sender, MouseEventArgs e)
        {
            yTranslation.SelectAll();
        }
        private void zTranslation_MouseUp(object sender, MouseEventArgs e)
        {
            zTranslation.SelectAll();
        }
        private void xRotation_MouseUp(object sender, MouseEventArgs e)
        {
            xRotation.SelectAll();
        }
        private void yRotation_MouseUp(object sender, MouseEventArgs e)
        {
            yRotation.SelectAll();
        }
        private void zRotation_MouseUp(object sender, MouseEventArgs e)
        {
            zRotation.SelectAll();
        }
        private void xScaling_MouseUp(object sender, MouseEventArgs e)
        {
            xScaling.SelectAll();
        }
        private void yScaling_MouseUp(object sender, MouseEventArgs e)
        {
            yScaling.SelectAll();
        }
        private void zScaling_MouseUp(object sender, MouseEventArgs e)
        {
            zScaling.SelectAll();
        }
        #endregion

        #region "Color"
        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //set object color

                //code to remove shape
                if (cboShapeList.SelectedIndex != -1)
                {
                    lock (renderer.Meshes)
                    {
                        if (renderer.Meshes[cboShapeList.SelectedIndex].IsShapeObject)
                        {
                            renderer.Meshes[cboShapeList.SelectedIndex].ApplyColor(colorDialog1.Color);
                        }
                    }
                    //update color label
                    SetCurrentColorLabel();
                }
                else
                {
                    MessageBox.Show("Please select an object!");
                }
            }
        }
        private void SetCurrentColorLabel()
        {
            lblObjectColor.Text = renderer.Meshes[cboShapeList.SelectedIndex].MeshColor;
        }
        #endregion

        #region "Lights"
        /// <summary>
        /// Updates light count label
        /// </summary>
        public void UpdateLightCount()
        {
            //update shape count
            lblLightCnt.Text = renderer.Lights.Count.ToString();
        }
        private void btnAddPointLight_Click(object sender, EventArgs e)
        {
            //Code to add new point light
            int x, y, z;

            x = Convert.ToInt32(txtLightLocX.Text);
            y = Convert.ToInt32(txtLightLocY.Text);
            z = Convert.ToInt32(txtLightLocZ.Text);

            LightClass newLight = new LightClass(LightType.Point);
            newLight.Position = new Vector3(x,y,z);
            renderer.Lights.Add(newLight);
            
            AddLightToDropDown(renderer.Lights.Count, "Point");
        }

        private void btnAddDirectionalLight_Click(object sender, EventArgs e)
        {
            //code to add new directional light
            int x, y, z;

            x = Convert.ToInt32(txtLightDirectionX.Text);
            y = Convert.ToInt32(txtLightDirectionY.Text);
            z = Convert.ToInt32(txtLightDirectionZ.Text);

            LightClass newLight = new LightClass(LightType.Directional);
            //newLight.Position = new Vector3(0, 0, 0);
            newLight.Direction = new Vector3(0,0,0);
            renderer.Lights.Add(newLight);

            AddLightToDropDown(renderer.Lights.Count, "Directional");
        }

        private void AddLightToDropDown(int ID, string LightType)
        {
            // code to add new light to light drop down list
            ShapeListItem sliToAdd = new ShapeListItem(ID, LightType);

            //Add object
            
            cbPointLights.Items.Add(sliToAdd);
            cbPointLights.SelectedIndex = cbPointLights.Items.Count - 1;
        }

        private void cbPointLights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPointLights.SelectedIndex != -1)
            {
                    lblSelectedLight.Text = cbPointLights.Text.ToString();
                    txtLightLocX.Text = renderer.Lights[cbPointLights.SelectedIndex].Position.X.ToString();
                    txtLightLocX.Text = renderer.Lights[cbPointLights.SelectedIndex].Position.Y.ToString();
                    txtLightLocX.Text = renderer.Lights[cbPointLights.SelectedIndex].Position.Z.ToString();

                    txtLightDirectionX.Text = renderer.Lights[cbPointLights.SelectedIndex].Direction.X.ToString();
                    txtLightDirectionY.Text = renderer.Lights[cbPointLights.SelectedIndex].Direction.Y.ToString();
                    txtLightDirectionZ.Text = renderer.Lights[cbPointLights.SelectedIndex].Direction.Z.ToString();

                    cbLightOnOff.Checked = renderer.Lights[cbPointLights.SelectedIndex].IsLightEnabled;
                    //SetCurrentColorLabel();
                    
            }
        }
        private void txtLightDirectionX_MouseUp(object sender, MouseEventArgs e)
        {
            txtLightDirectionX.SelectAll();
        }
        private void txtLightDirectionY_MouseUp(object sender, MouseEventArgs e)
        {
            txtLightDirectionY.SelectAll();
        }
        private void txtLightDirectionZ_MouseUp(object sender, MouseEventArgs e)
        {
            txtLightDirectionZ.SelectAll();
        }
        private void txtLightLocX_MouseUp(object sender, MouseEventArgs e)
        {
            txtLightLocX.SelectAll();
        }
        private void txtLightLocY_MouseUp(object sender, MouseEventArgs e)
        {
            txtLightLocY.SelectAll();
        }
        private void txtLightLocZ_MouseUp(object sender, MouseEventArgs e)
        {
            txtLightLocZ.SelectAll();
        }
        #endregion

        #region "WireFrame"
        private void cbWireFrame_CheckedChanged(object sender, EventArgs e)
        {
            //code for changing objects into wireframe

            if (cbWireFrame.Checked)
            {
                DeviceManager.LocalDevice.SetRenderState(RenderState.FillMode, FillMode.Wireframe);
            }
            else
            {
                DeviceManager.LocalDevice.SetRenderState(RenderState.FillMode, FillMode.Solid);
            }
        }
        #endregion

        private void randomTerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderer.Terrian = new Terrain();
        }

        private void removeTerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (renderer.Terrian != null)
            {
                renderer.Terrian.Dispose();
                renderer.Terrian = null;
            }
        }
        private void ckbxGlobalLights_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxGlobalLights.Checked)
            {
                renderer.IsGlobalLightOn = false;
                DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, renderer.IsGlobalLightOn);
            }
            else
            {
                renderer.IsGlobalLightOn = true;
                DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, renderer.IsGlobalLightOn);
            }
        }
        private void txtLightLocX_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.txtLightLocX, string.Empty);
        }

        private void txtLightLocY_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.txtLightLocY, string.Empty);
        }

        private void txtLightLocZ_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.txtLightLocZ, string.Empty);
        }

        private void txtLightDirectionX_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.txtLightDirectionX, string.Empty);
        }

        private void txtLightDirectionY_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.txtLightDirectionY, string.Empty);
        }

        private void txtLightDirectionZ_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            this.epMain.SetError(this.txtLightDirectionZ, string.Empty);
        }

        private void txtLightLocX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.txtLightLocX);
        }

        private void txtLightLocY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.txtLightLocY);
        }

        private void txtLightLocZ_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.txtLightLocZ);
        }

        private void txtLightDirectionX_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.txtLightDirectionX);
        }

        private void txtLightDirectionY_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.txtLightDirectionY);
        }

        private void txtLightDirectionZ_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(this.txtLightDirectionZ);
        }

        private void addPointLightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Code to add new point light
            LightClass newLight = new LightClass(LightType.Point);
            newLight.Position = new Vector3(0, 0, 0);
            renderer.Lights.Add(newLight);

            AddLightToDropDown(renderer.Lights.Count, "Point");
            UpdateLightCount();
        }

        private void addDirectionalLightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //code to add new directional light
            LightClass newLight = new LightClass(LightType.Directional);
            newLight.Direction = new Vector3(0, 0, 0);
            renderer.Lights.Add(newLight);

            AddLightToDropDown(renderer.Lights.Count, "Directional");
            UpdateLightCount();
        }

        private void txtLightLocX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(new Vector3(float.Parse(txtLightLocX.Text), float.Parse(txtLightLocY.Text), float.Parse(txtLightLocZ.Text)));
                }
            }
        }

        private void txtLightLocY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(new Vector3(float.Parse(txtLightLocX.Text), float.Parse(txtLightLocY.Text), float.Parse(txtLightLocZ.Text)));
                }
            }
        }

        private void txtLightLocZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(new Vector3(float.Parse(txtLightLocX.Text), float.Parse(txtLightLocY.Text), float.Parse(txtLightLocZ.Text)));
                }
            }
        }

        private void txtLightDirectionX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(new Vector3(float.Parse(txtLightDirectionX.Text), float.Parse(txtLightDirectionY.Text), float.Parse(txtLightDirectionZ.Text)));
                }
            }
        }

        private void txtLightDirectionY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(new Vector3(float.Parse(txtLightDirectionX.Text), float.Parse(txtLightDirectionY.Text), float.Parse(txtLightDirectionZ.Text)));
                }
            }
        }

        private void txtLightDirectionZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(new Vector3(float.Parse(txtLightDirectionX.Text), float.Parse(txtLightDirectionY.Text), float.Parse(txtLightDirectionZ.Text)));
                }
            }
        }

        private void cbLightOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (!renderer.Lights.Any() || cbPointLights.SelectedIndex == -1)
            {
                return;
            }

            renderer.Lights[cbPointLights.SelectedIndex].LightOnOff(cbPointLights.SelectedIndex);
            cbLightOnOff.Checked = renderer.Lights[cbPointLights.SelectedIndex].IsLightEnabled;
        }

        private void btnDeleteLight_Click(object sender, EventArgs e)
        {
            if (this.lblSelectedLight.Text != "<none>")
            {
                DialogResult = MessageBox.Show("Are you SURE you want to Delete this Light!? \n Please select one option Yes/No",
                                              "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DialogResult == DialogResult.Yes)
                {
                    //code to remove light
                    if (this.cbPointLights.SelectedIndex != -1)
                    {
                        lock (renderer.Lights)
                        {
                            renderer.Lights[cbPointLights.SelectedIndex].Dispose();
                            renderer.Lights.RemoveAt(cbPointLights.SelectedIndex);
                            cbPointLights.Items.RemoveAt(cbPointLights.SelectedIndex);
                            UpdateLightCount();
                            RenumberLightList();
                            //deselect any lights
                            lblSelectedLight.Text = "<none>";
                            cbPointLights.SelectedIndex = cbPointLights.Items.Count -1;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Adds a new light to the shape list combo box
        /// </summary>
        public void AddToLightList(string ShapeDesc, int ID)
        {
            //update light count
            UpdateLightCount();

            //create new object, set ID = light count, set description to shape type
            ShapeListItem sliToAdd = new ShapeListItem(ID, ShapeDesc);

            //Add object    
            this.cbPointLights.Items.Add(sliToAdd);
            cbPointLights.SelectedIndex = cbPointLights.Items.Count - 1;
        }


        /// <summary>
        /// Updates lights index (call after remove)
        /// </summary>
        public void RenumberLightList()
        {
            this.cbPointLights.Items.Clear();
            int objCounter = 1;
            foreach (LightClass myLight in renderer.Lights)
            {
                AddToLightList(myLight.Type, objCounter);
                objCounter++;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (cboShapeList.SelectedIndex != -1)
            {
                //rename
                renderer.Meshes[cboShapeList.SelectedIndex].Name = txtRename.Text;
                RenumberShapeList();

            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //get previous mouse location
            int PrevX = p.X;
            int PrevY = p.Y;

            if (e.Button == MouseButtons.Left)
            {
                float DeltaX = e.X - PrevX;
                float DeltaY = e.Y - PrevY;

                if (FirstMouseMouse == false)
                {
                    DeltaX = 0;
                    DeltaY = 0;
                    FirstMouseMouse = true;
                }

                //Console.WriteLine("x " + DeltaX.ToString() + " y " + DeltaY.ToString());
                camera.MoveEye(DeltaX / PixelDifferential, -DeltaY / PixelDifferential);

                //save current mouse location
                p.X = e.X;
                p.Y = e.Y;

                lblCamPosX.Text = ((int)camera.Eye.X).ToString();
                lblCamPosY.Text = ((int)camera.Eye.Y).ToString();
                lblCamPosZ.Text = ((int)camera.Eye.Z).ToString();
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            p.X = 0;
            p.Y = 0;
            FirstMouseMouse = false;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            FirstMouseMouse = false;
        }


    }
}