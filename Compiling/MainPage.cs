using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;
using Resources = Graphics.Properties.Resources;

namespace Graphics
{
    public partial class MainPage : Form
    {
        #region Variables

        //the thread that the graphics will be running in so the UI doesn't lock up.
        private Thread _renderThread;
        private readonly Camera _camera;
        private readonly Renderer _renderer;

        //GUI colors
        private readonly Color _guiBackColor = Color.FromArgb(0xa2, green: 162, blue: 162);
        private readonly Color _guiSubWindowColor = Color.FromArgb(194, 194, 194);

        //to control mouse
        private bool _firstMouseMouse;
        private Point _mouseLocation;
        private const int PixelDifferential = 40;

        #endregion

        public MainPage()
        {
            //don't touch this method. microsoft created
            InitializeComponent();

            //this method initializes the Device
            DeviceManager.CreateDevice(panel1.Handle, panel1.Width, panel1.Height);

            _camera = new Camera();

            _renderer = new Renderer();
            Init();

            DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, _renderer.IsGlobalLightOn);
            DeviceManager.LocalDevice.SetRenderState(RenderState.CullMode, Cull.Counterclockwise);
            DeviceManager.LocalDevice.SetRenderState(RenderState.ZEnable, ZBufferType.UseZBuffer);
            DeviceManager.LocalDevice.SetRenderState(RenderState.NormalizeNormals, true);
            DeviceManager.LocalDevice.SetRenderState(RenderState.Ambient, Color.Gray.ToArgb());
            DeviceManager.LocalDevice.SetRenderState(RenderState.SpecularEnable, false);

            //set GUI control attributes
            SetGui();


            panel1.MouseWheel += panel1_MouseWheel;
        }

        private void Init()
        {
            _renderThread = new Thread(_renderer.RenderScene);
            _renderThread.Start();
        }

        #region Shape Menu Drawing

        //adds a new cube to the screen
        private void CubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (_renderer.Meshes)
            {
                _renderer.Meshes.Add(new MeshClass(MeshType.Cube));

                //there may be a better place to put this
                AddToShapeList("Cube", _renderer.Meshes.Count);
            }
        }

        //adds a new triangle to the screen
        private void TriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (_renderer.Meshes)
            {
                _renderer.Meshes.Add(new MeshClass(MeshType.Triangle));

                //there may be a better place to put this
                AddToShapeList("Triangle", _renderer.Meshes.Count);
            }
        }

        #endregion

        /// <summary>
        ///     Sets GUI Menu items and controls including width and colors
        /// </summary>
        private void SetGui()
        {
            //set colors

            //main form
            BackColor = _guiBackColor;

            //notification area
            gbCamera.BackColor = _guiSubWindowColor;
            gbRotate.BackColor = _guiSubWindowColor;
            gbScale.BackColor = _guiSubWindowColor;
            gbObjects.BackColor = _guiSubWindowColor;
            gbTranslate.BackColor = _guiSubWindowColor;
            gbColor.BackColor = _guiSubWindowColor;
            gbLighting.BackColor = _guiSubWindowColor;
            gbPhysics.BackColor = _guiSubWindowColor;

            //set shape drop down list value and display members
            cboShapeList.ValueMember = "ID";
            cboShapeList.DisplayMember = "ShapeDesc";

            cbPointLights.ValueMember = "ID";
            cbPointLights.DisplayMember = "ShapeDesc";
        }

        #region Shape DropDownList Related Methods

        /// <summary>
        ///     Adds a new shape to the shape list combo box
        /// </summary>
        public void AddToShapeList(string ShapeDesc, int ID)
        {
            //update shape count
            UpdateShapeCount();

            //create new object, set ID = shape count, set description to shape type
            var sliToAdd = new ShapeListItem(ID, ShapeDesc);

            //Add object    
            cboShapeList.Items.Add(sliToAdd);
            cboShapeList.SelectedIndex = cboShapeList.Items.Count - 1;
            txtRename.Text = _renderer.Meshes[cboShapeList.SelectedIndex].Name;
        }

        /// <summary>
        ///     Updates shape count label
        /// </summary>
        public void UpdateShapeCount()
        {
            //update shape count
            lblSCnt2.Text = _renderer.Meshes.Count.ToString();
        }

        /// <summary>
        ///     Updates shape index (call after remove)
        /// </summary>
        public void RenumberShapeList()
        {
            cboShapeList.Items.Clear();
            int objCounter = 1;
            foreach (MeshClass myMesh in _renderer.Meshes)
            {
                AddToShapeList(myMesh.Name, objCounter);
                objCounter++;
            }
        }

        private void cboShapeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShapeList.SelectedIndex != -1)
            {
                lblSS2.Text = cboShapeList.Text;
                xTranslation.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectPosition.X.ToString();
                yTranslation.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectPosition.Y.ToString();
                zTranslation.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectPosition.Z.ToString();
                xRotation.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectRotate.X.ToString();
                yRotation.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectRotate.X.ToString();
                zRotation.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectRotate.X.ToString();
                xScaling.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectScale.X.ToString();
                yScaling.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectScale.X.ToString();
                zScaling.Text = _renderer.Meshes[cboShapeList.SelectedIndex].ObjectScale.X.ToString();
                SetCurrentColorLabel();
                //deselect any lights
                lblSelectedLight.Text = "<none>";

                //reset name box
                txtRename.Text = _renderer.Meshes[cboShapeList.SelectedIndex].Name;
            }
        }

        #endregion

        #region Camera Related Methods

        private void btnResetCamera_Click(object sender, EventArgs e)
        {
            _camera.ResetEye();
            UpdateCameraLocation();
            UpdateCameraRotation();
        }

        private void btnCamL_Click(object sender, EventArgs e)
        {
            _camera.MoveEye(-1);
            UpdateCameraLocation();
        }

        private void btnCamR_Click(object sender, EventArgs e)
        {
            _camera.MoveEye(x: 1);
            UpdateCameraLocation();
        }

        private void CamB_Click(object sender, EventArgs e)
        {
            _camera.MoveEye(z: 1);
            UpdateCameraLocation();
        }

        private void CamF_Click(object sender, EventArgs e)
        {
            _camera.MoveEye(z: -1);
            UpdateCameraLocation();
        }

        private void btnCamU_Click(object sender, EventArgs e)
        {
            _camera.MoveEye(y: -1);
            UpdateCameraLocation();
        }

        private void btnCamD_Click(object sender, EventArgs e)
        {
            _camera.MoveEye(y: 1);
            UpdateCameraLocation();
        }

        private void btnRCamL_Click(object sender, EventArgs e)
        {
            _camera.CameraRotation = new Vector3(0, 1f, 0);
            UpdateCameraRotation();
        }

        private void btnRCamU_Click(object sender, EventArgs e)
        {
            _camera.CameraRotation = new Vector3(1f, 0, 0);
            UpdateCameraRotation();
        }

        private void btnRCamR_Click(object sender, EventArgs e)
        {
            _camera.CameraRotation = new Vector3(0, -1f, 0);
            UpdateCameraRotation();
        }

        private void btnRCamD_Click(object sender, EventArgs e)
        {
            _camera.CameraRotation = new Vector3(-1f, 0, 0);
            UpdateCameraRotation();
        }

        private void btnRCamB_Click(object sender, EventArgs e)
        {
            _camera.CameraRotation = new Vector3(0, 0, -1f);
            UpdateCameraRotation();
        }

        private void btnRCamF_Click(object sender, EventArgs e)
        {
            _camera.CameraRotation = new Vector3(0, 0, 1f);
            UpdateCameraRotation();
        }

        private void UpdateCameraLocation()
        {
            lblCamPosX.Text = _camera.Eye.X.ToString();
            lblCamPosY.Text = _camera.Eye.Y.ToString();
            lblCamPosZ.Text = _camera.Eye.Z.ToString();
        }

        private void UpdateCameraRotation()
        {
            lblCamRotX.Text = _camera.CameraRotation.X.ToString();
            lblCamRotY.Text = _camera.CameraRotation.Y.ToString();
            lblCamRotZ.Text = _camera.CameraRotation.Z.ToString();
        }

        #endregion

        #region Mesh Loading Functions

        private void miLoadMesh_Click(object sender, EventArgs e)
        {
            ofdMesh.ShowDialog();
        }

        private void ofdMesh_FileOk(object sender, CancelEventArgs e)
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
                        _renderer.Meshes.Add(new MeshClass(ofdMesh.FileName, ofdMesh.SafeFileName));

                        AddToShapeList(ofdMesh.SafeFileName, _renderer.Meshes.Count);
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
                if (File.Exists("error.txt"))
                {
                    File.AppendAllText("error.txt", ex.Message);
                }
                else
                {
                    File.WriteAllText("error.txt", ex.Message);
                }
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
                    _renderer.Meshes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text),
                                                                          float.Parse(yTranslation.Text),
                                                                          float.Parse(zTranslation.Text));
                }
            }
        }

        private void yTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text),
                                                                          float.Parse(yTranslation.Text),
                                                                          float.Parse(zTranslation.Text));
                }
            }
        }

        private void zTranslation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Translate(float.Parse(xTranslation.Text),
                                                                          float.Parse(yTranslation.Text),
                                                                          float.Parse(zTranslation.Text));
                }
            }
        }

        private void xRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Rotate(float.Parse(xRotation.Text),
                                                                       float.Parse(yRotation.Text),
                                                                       float.Parse(zRotation.Text));
                }
            }
        }

        private void yRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Rotate(float.Parse(xRotation.Text),
                                                                       float.Parse(yRotation.Text),
                                                                       float.Parse(zRotation.Text));
                }
            }
        }

        private void zRotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Rotate(float.Parse(xRotation.Text),
                                                                       float.Parse(yRotation.Text),
                                                                       float.Parse(zRotation.Text));
                }
            }
        }

        private void xScaling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Scale(new Vector3(float.Parse(xScaling.Text),
                                                                                  float.Parse(yScaling.Text),
                                                                                  float.Parse(zScaling.Text)));
                }
            }
        }

        private void yScaling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Scale(new Vector3(float.Parse(xScaling.Text),
                                                                                  float.Parse(yScaling.Text),
                                                                                  float.Parse(zScaling.Text)));
                }
            }
        }

        private void zScaling_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboShapeList.SelectedIndex != -1)
                {
                    _renderer.Meshes[cboShapeList.SelectedIndex].Scale(new Vector3(float.Parse(xScaling.Text),
                                                                                  float.Parse(yScaling.Text),
                                                                                  float.Parse(zScaling.Text)));
                }
            }
        }

        #endregion

        #region Deletion

        private void btnClearScene_Click(object sender, EventArgs e)
        {
            DialogResult =
                MessageBox.Show(
                    "Are you SURE you want to CLEAR this entire scene?\nThis includes ALL Objects and ALL Lights \nPlease select one option Yes/No",
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
                catch (Exception ex)
                {
                    //handle exception
                    MessageBox.Show("Clear Scene failed: An error has occured!");
                    if (File.Exists("error.txt"))
                    {
                        File.AppendAllText("error.txt", ex.Message);
                    }
                    else
                    {
                        File.WriteAllText("error.txt", ex.Message);
                    }
                }
            }
        }

        private void btnDeleteShape_Click(object sender, EventArgs e)
        {
            if (lblSS2.Text != "<none>")
            {
                DialogResult =
                    MessageBox.Show("Are you SURE you want to Delete this object!? \n Please select one option Yes/No",
                                    "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DialogResult == DialogResult.Yes)
                {
                    //code to remove shape
                    if (cboShapeList.SelectedIndex != -1)
                    {
                        lock (_renderer.Meshes)
                        {
                            _renderer.Meshes[cboShapeList.SelectedIndex].Dispose();
                            _renderer.Meshes.RemoveAt(cboShapeList.SelectedIndex);
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
            lock (_renderer.Lights)
            {
                _renderer.Lights.ForEach(light => light.Dispose());
                _renderer.Lights.Clear();
            }

            //Code to clear scene
            lock (_renderer.Meshes)
            {
                _renderer.Meshes.ForEach(mesh => mesh.Dispose());
                _renderer.Meshes.Clear();
                cboShapeList.Items.Clear();
            }

            if (_renderer.Terrian != null)
            {
                _renderer.Terrian.Dispose();
                _renderer.Terrian = null;
            }
        }

        //on shutdown this method is called. it stoppeds the thread and releases the resources and graphics card
        private void ShutDown()
        {
            _renderer.RequestShutdown();

            if (!CustomVertex.VertexPositionColor.VertexDecl.Disposed)
            {
                CustomVertex.VertexPositionColor.VertexDecl.Dispose();
            }
            if (!CustomVertex.VertexPositionNormalColor.VertexDecl.Disposed)
            {
                CustomVertex.VertexPositionNormalColor.VertexDecl.Dispose();
            }

            while (!DeviceManager.LocalDevice.Disposed && !_renderThread.IsAlive)
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

        #region Physics

        private void cbGravity_CheckedChanged(object sender, EventArgs e)
        {
            _renderer.Gravity = cbGravity.Checked;
        }

        #endregion

        #region Texture Loading Functions

        private void loadTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdTexture.ShowDialog();
        }

        private void ofdTexture_FileOk(object sender, CancelEventArgs e)
        {
            //Try to read file
            try
            {
                if (File.Exists(ofdTexture.FileName))
                {
                    //Make sure it's a texture file type, this should be good enough
                    if (ofdTexture.FileName.ToUpper().Contains(".BMP") || ofdTexture.FileName.ToUpper().Contains(".DDS") ||
                        ofdTexture.FileName.ToUpper().Contains(".JPG"))
                    {
                        //Code to load Texture
                        foreach (MeshClass myMesh in _renderer.Meshes)
                        {
                            if (myMesh.IsShapeObject) myMesh.ApplyTextureMesh(ofdMesh.FileName, ofdMesh.SafeFileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The file " + ofdTexture.FileName +
                                        " is not a valid .bmp, .dds, or .jpg Texture file!");
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
                if (File.Exists("error.txt"))
                {
                    File.AppendAllText("error.txt", ex.Message);
                }
                else
                {
                    File.WriteAllText("error.txt", ex.Message);
                }
            }
        }

        #endregion

        #region Validation

        private void xTranslation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(xTranslation);
        }

        private void yTranslation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(yTranslation);
        }

        private void zTranslation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(zTranslation);
        }

        private void xRotation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(xRotation);
        }

        private void yRotation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(yRotation);
        }

        private void zRotation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(zRotation);
        }

        private void xScaling_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(xScaling);
        }

        private void yScaling_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(yScaling);
        }

        private void zScaling_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(zScaling);
        }

        private void xTranslation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(xTranslation, string.Empty);
        }

        private void yTranslation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(yTranslation, string.Empty);
        }

        private void zTranslation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(zTranslation, string.Empty);
        }

        private void xRotation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(xRotation, string.Empty);
        }

        private void yRotation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(yRotation, string.Empty);
        }

        private void zRotation_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(zRotation, string.Empty);
        }

        private void xScaling_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(xScaling, string.Empty);
        }

        private void yScaling_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(yScaling, string.Empty);
        }

        private void zScaling_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(zScaling, string.Empty);
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
                epMain.SetError(TextBoxToVal, "You must provide a valid integer!");
            }
            return cancel;
        }

        private void txtLightLocX_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(txtLightLocX, string.Empty);
        }

        private void txtLightLocY_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(txtLightLocY, string.Empty);
        }

        private void txtLightLocZ_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(txtLightLocZ, string.Empty);
        }

        private void txtLightDirectionX_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(txtLightDirectionX, string.Empty);
        }

        private void txtLightDirectionY_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(txtLightDirectionY, string.Empty);
        }

        private void txtLightDirectionZ_Validated(object sender, EventArgs e)
        {
            //Control has validated, clear any error message.
            epMain.SetError(txtLightDirectionZ, string.Empty);
        }

        private void txtLightLocX_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(txtLightLocX);
        }

        private void txtLightLocY_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(txtLightLocY);
        }

        private void txtLightLocZ_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(txtLightLocZ);
        }

        private void txtLightDirectionX_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(txtLightDirectionX);
        }

        private void txtLightDirectionY_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(txtLightDirectionY);
        }

        private void txtLightDirectionZ_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = validateTextBoxIsInt(txtLightDirectionZ);
        }

        #endregion

        #region Mouse Events

        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Update the camera z based upon the mouse wheel scrolling.
            _camera.MoveEye(z: (e.Delta/120*-1));
            UpdateCameraLocation();
        }

        private void panel1_MouseEnter(Object sender, EventArgs e)
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

        #region Color

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //set object color

                //code to remove shape
                if (cboShapeList.SelectedIndex != -1)
                {
                    lock (_renderer.Meshes)
                    {
                        if (_renderer.Meshes[cboShapeList.SelectedIndex].IsShapeObject)
                        {
                            _renderer.Meshes[cboShapeList.SelectedIndex].ApplyColor(colorDialog1.Color);
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
            lblObjectColor.Text = _renderer.Meshes[cboShapeList.SelectedIndex].MeshColor;
        }

        #endregion

        #region Lights

        /// <summary>
        ///     Updates light count label
        /// </summary>
        public void UpdateLightCount()
        {
            //update shape count
            lblLightCnt.Text = _renderer.Lights.Count.ToString();
        }

        private void ckbxGlobalLights_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxGlobalLights.Checked)
            {
                _renderer.IsGlobalLightOn = false;
                DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, _renderer.IsGlobalLightOn);
            }
            else
            {
                _renderer.IsGlobalLightOn = true;
                DeviceManager.LocalDevice.SetRenderState(RenderState.Lighting, _renderer.IsGlobalLightOn);
            }
        }

        private void addPointLightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Code to add new point light
            var newLight = new LightClass(LightType.Point);
            newLight.Position = new Vector3(0, 0, 0);
            _renderer.Lights.Add(newLight);

            AddLightToDropDown(_renderer.Lights.Count, "Point");
            UpdateLightCount();
        }

        private void addDirectionalLightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //code to add new directional light
            var newLight = new LightClass(LightType.Directional);
            newLight.Direction = new Vector3(0, 0, 0);
            _renderer.Lights.Add(newLight);

            AddLightToDropDown(_renderer.Lights.Count, "Directional");
            UpdateLightCount();
        }

        private void AddLightToDropDown(int ID, string LightType)
        {
            // code to add new light to light drop down list
            var sliToAdd = new ShapeListItem(ID, LightType);

            //Add object
            cbPointLights.Items.Add(sliToAdd);
            cbPointLights.SelectedIndex = cbPointLights.Items.Count - 1;
        }

        private void cbPointLights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPointLights.SelectedIndex != -1)
            {
                lblSelectedLight.Text = cbPointLights.Text;
                txtLightLocX.Text = _renderer.Lights[cbPointLights.SelectedIndex].Position.X.ToString();
                txtLightLocX.Text = _renderer.Lights[cbPointLights.SelectedIndex].Position.Y.ToString();
                txtLightLocX.Text = _renderer.Lights[cbPointLights.SelectedIndex].Position.Z.ToString();

                txtLightDirectionX.Text = _renderer.Lights[cbPointLights.SelectedIndex].Direction.X.ToString();
                txtLightDirectionY.Text = _renderer.Lights[cbPointLights.SelectedIndex].Direction.Y.ToString();
                txtLightDirectionZ.Text = _renderer.Lights[cbPointLights.SelectedIndex].Direction.Z.ToString();

                cbLightOnOff.Checked = _renderer.Lights[cbPointLights.SelectedIndex].IsLightEnabled;
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

        private void cbLightOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (!_renderer.Lights.Any() || cbPointLights.SelectedIndex == -1)
            {
                return;
            }

            _renderer.Lights[cbPointLights.SelectedIndex].LightOnOff(cbPointLights.SelectedIndex);
            cbLightOnOff.Checked = _renderer.Lights[cbPointLights.SelectedIndex].IsLightEnabled;
        }

        private void btnDeleteLight_Click(object sender, EventArgs e)
        {
            if (lblSelectedLight.Text != @"<none>")
            {
                DialogResult =
                    MessageBox.Show(Resources.MainPage_btnDeleteLight_Click_,
                                    @"Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (DialogResult == DialogResult.Yes)
                {
                    //code to remove light
                    if (cbPointLights.SelectedIndex != -1)
                    {
                        lock (_renderer.Lights)
                        {
                            _renderer.Lights[cbPointLights.SelectedIndex].Dispose();
                            _renderer.Lights.RemoveAt(cbPointLights.SelectedIndex);
                            cbPointLights.Items.RemoveAt(cbPointLights.SelectedIndex);
                            UpdateLightCount();
                            RenumberLightList();
                            //deselect any lights
                            lblSelectedLight.Text = "<none>";
                            cbPointLights.SelectedIndex = cbPointLights.Items.Count - 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Adds a new light to the shape list combo box
        /// </summary>
        public void AddToLightList(string ShapeDesc, int ID)
        {
            //update light count
            UpdateLightCount();

            //create new object, set ID = light count, set description to shape type
            var sliToAdd = new ShapeListItem(ID, ShapeDesc);

            //Add object    
            cbPointLights.Items.Add(sliToAdd);
            cbPointLights.SelectedIndex = cbPointLights.Items.Count - 1;
        }

        /// <summary>
        ///     Updates lights index (call after remove)
        /// </summary>
        public void RenumberLightList()
        {
            cbPointLights.Items.Clear();
            int objCounter = 1;
            foreach (LightClass myLight in _renderer.Lights)
            {
                AddToLightList(myLight.Type, objCounter);
                objCounter++;
            }
        }

        #endregion

        #region WireFrame

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

        #region Terrain

        private void randomTerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _renderer.Terrian = new Terrain();
        }

        private void removeTerrainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_renderer.Terrian != null)
            {
                _renderer.Terrian.Dispose();
                _renderer.Terrian = null;
            }
        }

        #endregion

        #region Light Movement

        private void txtLightLocX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    _renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(
                        new Vector3(float.Parse(txtLightLocX.Text), float.Parse(txtLightLocY.Text),
                                    float.Parse(txtLightLocZ.Text)));
                }
            }
        }

        private void txtLightLocY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    _renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(
                        new Vector3(float.Parse(txtLightLocX.Text), float.Parse(txtLightLocY.Text),
                                    float.Parse(txtLightLocZ.Text)));
                }
            }
        }

        private void txtLightLocZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    _renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(
                        new Vector3(float.Parse(txtLightLocX.Text), float.Parse(txtLightLocY.Text),
                                    float.Parse(txtLightLocZ.Text)));
                }
            }
        }

        private void txtLightDirectionX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    _renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(
                        new Vector3(float.Parse(txtLightDirectionX.Text), float.Parse(txtLightDirectionY.Text),
                                    float.Parse(txtLightDirectionZ.Text)));
                }
            }
        }

        private void txtLightDirectionY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    _renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(
                        new Vector3(float.Parse(txtLightDirectionX.Text), float.Parse(txtLightDirectionY.Text),
                                    float.Parse(txtLightDirectionZ.Text)));
                }
            }
        }

        private void txtLightDirectionZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbPointLights.SelectedIndex != -1)
                {
                    _renderer.Lights[cbPointLights.SelectedIndex].GlobalLightTranslation(
                        new Vector3(float.Parse(txtLightDirectionX.Text), float.Parse(txtLightDirectionY.Text),
                                    float.Parse(txtLightDirectionZ.Text)));
                }
            }
        }

        #endregion

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (cboShapeList.SelectedIndex != -1)
            {
                //rename
                _renderer.Meshes[cboShapeList.SelectedIndex].Name = txtRename.Text;
                RenumberShapeList();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //get previous mouse location
            var prevX = _mouseLocation.X;
            int PrevY = _mouseLocation.Y;

            if (e.Button == MouseButtons.Left)
            {
                float DeltaX = e.X - prevX;
                float DeltaY = e.Y - PrevY;

                if (_firstMouseMouse == false)
                {
                    DeltaX = 0;
                    DeltaY = 0;
                    _firstMouseMouse = true;
                }

                _camera.MoveEye(DeltaX/PixelDifferential, -DeltaY/PixelDifferential);

                //save current mouse location
                _mouseLocation.X = e.X;
                _mouseLocation.Y = e.Y;

                lblCamPosX.Text = ((int) _camera.Eye.X).ToString();
                lblCamPosY.Text = ((int) _camera.Eye.Y).ToString();
                lblCamPosZ.Text = ((int) _camera.Eye.Z).ToString();
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            _mouseLocation.X = 0;
            _mouseLocation.Y = 0;
            _firstMouseMouse = false;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _firstMouseMouse = false;
        }
    }
}