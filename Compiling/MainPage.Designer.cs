namespace Graphics
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoadMesh = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPointLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDirectionalLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTerrainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.gbMemUsage = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plNotArea = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbObjects = new System.Windows.Forms.GroupBox();
            this.btnClearScene = new System.Windows.Forms.Button();
            this.btnDeleteShape = new System.Windows.Forms.Button();
            this.lblSS2 = new System.Windows.Forms.Label();
            this.lblSS1 = new System.Windows.Forms.Label();
            this.lblSCnt2 = new System.Windows.Forms.Label();
            this.lblSCnt1 = new System.Windows.Forms.Label();
            this.cboShapeList = new System.Windows.Forms.ComboBox();
            this.lblDes1 = new System.Windows.Forms.Label();
            this.btnCamR = new System.Windows.Forms.Button();
            this.btnCamD = new System.Windows.Forms.Button();
            this.btnCamU = new System.Windows.Forms.Button();
            this.btnCamL = new System.Windows.Forms.Button();
            this.gbCamera = new System.Windows.Forms.GroupBox();
            this.btnRCamB = new System.Windows.Forms.Button();
            this.btnRCamF = new System.Windows.Forms.Button();
            this.btnResetCamera = new System.Windows.Forms.Button();
            this.lblCamRotZ = new System.Windows.Forms.Label();
            this.lblCamRotY = new System.Windows.Forms.Label();
            this.lblCamRotX = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCamPosZ = new System.Windows.Forms.Label();
            this.lblCamPosY = new System.Windows.Forms.Label();
            this.lblCamPosX = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRCamL = new System.Windows.Forms.Button();
            this.btnRCamR = new System.Windows.Forms.Button();
            this.btnRCamU = new System.Windows.Forms.Button();
            this.btnRCamD = new System.Windows.Forms.Button();
            this.CamB = new System.Windows.Forms.Button();
            this.CamF = new System.Windows.Forms.Button();
            this.lblCam2 = new System.Windows.Forms.Label();
            this.lblCam1 = new System.Windows.Forms.Label();
            this.gbTranslate = new System.Windows.Forms.GroupBox();
            this.zTranslation = new System.Windows.Forms.TextBox();
            this.yTranslation = new System.Windows.Forms.TextBox();
            this.xTranslation = new System.Windows.Forms.TextBox();
            this.lblzTranslate = new System.Windows.Forms.Label();
            this.lblyTranslate = new System.Windows.Forms.Label();
            this.lblxTranslate = new System.Windows.Forms.Label();
            this.gbRotate = new System.Windows.Forms.GroupBox();
            this.lblzRotate = new System.Windows.Forms.Label();
            this.zRotation = new System.Windows.Forms.TextBox();
            this.lblyRotate = new System.Windows.Forms.Label();
            this.yRotation = new System.Windows.Forms.TextBox();
            this.xRotation = new System.Windows.Forms.TextBox();
            this.lblxRotate = new System.Windows.Forms.Label();
            this.gbScale = new System.Windows.Forms.GroupBox();
            this.zScaling = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.yScaling = new System.Windows.Forms.TextBox();
            this.lblyScale = new System.Windows.Forms.Label();
            this.xScaling = new System.Windows.Forms.TextBox();
            this.lblxScale = new System.Windows.Forms.Label();
            this.ofdMesh = new System.Windows.Forms.OpenFileDialog();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.lblObjectColor = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.gbPhysics = new System.Windows.Forms.GroupBox();
            this.cbWireFrame = new System.Windows.Forms.CheckBox();
            this.cbGravity = new System.Windows.Forms.CheckBox();
            this.gbLighting = new System.Windows.Forms.GroupBox();
            this.lblLightCount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtLightRange = new System.Windows.Forms.TextBox();
            this.txtLightDirectionZ = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtLightDirectionY = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtLightDirectionX = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtLightLocZ = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSelectedLight = new System.Windows.Forms.Label();
            this.txtLightLocY = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbPointLights = new System.Windows.Forms.ComboBox();
            this.txtLightLocX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblLights2 = new System.Windows.Forms.Label();
            this.lblLights1 = new System.Windows.Forms.Label();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.ofdTexture = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ckbxGlobalLights = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.gbMemUsage.SuspendLayout();
            this.plNotArea.SuspendLayout();
            this.gbObjects.SuspendLayout();
            this.gbCamera.SuspendLayout();
            this.gbTranslate.SuspendLayout();
            this.gbRotate.SuspendLayout();
            this.gbScale.SuspendLayout();
            this.gbColor.SuspendLayout();
            this.gbPhysics.SuspendLayout();
            this.gbLighting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 62);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(246, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.shapesToolStripMenuItem,
            this.lightsToolStripMenuItem,
            this.terrainToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1137, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLoadMesh,
            this.loadTextureToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miLoadMesh
            // 
            this.miLoadMesh.Name = "miLoadMesh";
            this.miLoadMesh.Size = new System.Drawing.Size(142, 22);
            this.miLoadMesh.Text = "Load Mesh";
            this.miLoadMesh.Click += new System.EventHandler(this.miLoadMesh_Click);
            // 
            // loadTextureToolStripMenuItem
            // 
            this.loadTextureToolStripMenuItem.Name = "loadTextureToolStripMenuItem";
            this.loadTextureToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.loadTextureToolStripMenuItem.Text = "Load Texture";
            this.loadTextureToolStripMenuItem.Click += new System.EventHandler(this.loadTextureToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cubeToolStripMenuItem,
            this.triangleToolStripMenuItem});
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            this.shapesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.shapesToolStripMenuItem.Text = "Shapes";
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.cubeToolStripMenuItem.Text = "Cube";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.CubeToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.TriangleToolStripMenuItem_Click);
            // 
            // lightsToolStripMenuItem
            // 
            this.lightsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPointLightToolStripMenuItem,
            this.addDirectionalLightToolStripMenuItem});
            this.lightsToolStripMenuItem.Name = "lightsToolStripMenuItem";
            this.lightsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.lightsToolStripMenuItem.Text = "Lights";
            // 
            // addPointLightToolStripMenuItem
            // 
            this.addPointLightToolStripMenuItem.Name = "addPointLightToolStripMenuItem";
            this.addPointLightToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addPointLightToolStripMenuItem.Text = "Add Point Light";
            this.addPointLightToolStripMenuItem.Click += new System.EventHandler(this.addPointLightToolStripMenuItem_Click);
            // 
            // addDirectionalLightToolStripMenuItem
            // 
            this.addDirectionalLightToolStripMenuItem.Name = "addDirectionalLightToolStripMenuItem";
            this.addDirectionalLightToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addDirectionalLightToolStripMenuItem.Text = "Add Directional Light";
            this.addDirectionalLightToolStripMenuItem.Click += new System.EventHandler(this.addDirectionalLightToolStripMenuItem_Click);
            // 
            // terrainToolStripMenuItem
            // 
            this.terrainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomTerrainToolStripMenuItem,
            this.removeTerrainToolStripMenuItem});
            this.terrainToolStripMenuItem.Name = "terrainToolStripMenuItem";
            this.terrainToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.terrainToolStripMenuItem.Text = "Terrain";
            // 
            // randomTerrainToolStripMenuItem
            // 
            this.randomTerrainToolStripMenuItem.Name = "randomTerrainToolStripMenuItem";
            this.randomTerrainToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.randomTerrainToolStripMenuItem.Text = "Random Terrain";
            this.randomTerrainToolStripMenuItem.Click += new System.EventHandler(this.randomTerrainToolStripMenuItem_Click);
            // 
            // removeTerrainToolStripMenuItem
            // 
            this.removeTerrainToolStripMenuItem.Name = "removeTerrainToolStripMenuItem";
            this.removeTerrainToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.removeTerrainToolStripMenuItem.Text = "Remove Terrain";
            this.removeTerrainToolStripMenuItem.Click += new System.EventHandler(this.removeTerrainToolStripMenuItem_Click);
            // 
            // lblMemoryUsage
            // 
            this.lblMemoryUsage.AutoSize = true;
            this.lblMemoryUsage.Enabled = false;
            this.lblMemoryUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemoryUsage.Location = new System.Drawing.Point(11, 16);
            this.lblMemoryUsage.Name = "lblMemoryUsage";
            this.lblMemoryUsage.Size = new System.Drawing.Size(12, 13);
            this.lblMemoryUsage.TabIndex = 7;
            this.lblMemoryUsage.Text = "x";
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Enabled = false;
            this.lblMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMem.Location = new System.Drawing.Point(114, 16);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(12, 13);
            this.lblMem.TabIndex = 8;
            this.lblMem.Text = "x";
            // 
            // gbMemUsage
            // 
            this.gbMemUsage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.gbMemUsage.Controls.Add(this.lblMemoryUsage);
            this.gbMemUsage.Controls.Add(this.lblMem);
            this.gbMemUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMemUsage.Location = new System.Drawing.Point(3, 16);
            this.gbMemUsage.Name = "gbMemUsage";
            this.gbMemUsage.Size = new System.Drawing.Size(246, 40);
            this.gbMemUsage.TabIndex = 9;
            this.gbMemUsage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(259, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(20);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(624, 524);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            // 
            // plNotArea
            // 
            this.plNotArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.plNotArea.Controls.Add(this.label1);
            this.plNotArea.Controls.Add(this.gbMemUsage);
            this.plNotArea.Controls.Add(this.progressBar1);
            this.plNotArea.Location = new System.Drawing.Point(0, 467);
            this.plNotArea.Name = "plNotArea";
            this.plNotArea.Size = new System.Drawing.Size(255, 85);
            this.plNotArea.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Memory Usage (MB)";
            // 
            // gbObjects
            // 
            this.gbObjects.Controls.Add(this.btnClearScene);
            this.gbObjects.Controls.Add(this.btnDeleteShape);
            this.gbObjects.Controls.Add(this.lblSS2);
            this.gbObjects.Controls.Add(this.lblSS1);
            this.gbObjects.Controls.Add(this.lblSCnt2);
            this.gbObjects.Controls.Add(this.lblSCnt1);
            this.gbObjects.Controls.Add(this.cboShapeList);
            this.gbObjects.Controls.Add(this.lblDes1);
            this.gbObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbObjects.Location = new System.Drawing.Point(887, 26);
            this.gbObjects.Name = "gbObjects";
            this.gbObjects.Size = new System.Drawing.Size(246, 115);
            this.gbObjects.TabIndex = 11;
            this.gbObjects.TabStop = false;
            this.gbObjects.Text = "Objects";
            // 
            // btnClearScene
            // 
            this.btnClearScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearScene.Location = new System.Drawing.Point(128, 87);
            this.btnClearScene.Name = "btnClearScene";
            this.btnClearScene.Size = new System.Drawing.Size(108, 23);
            this.btnClearScene.TabIndex = 9;
            this.btnClearScene.Text = "Clear Scene";
            this.btnClearScene.UseVisualStyleBackColor = true;
            this.btnClearScene.Click += new System.EventHandler(this.btnClearScene_Click);
            // 
            // btnDeleteShape
            // 
            this.btnDeleteShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteShape.Location = new System.Drawing.Point(12, 87);
            this.btnDeleteShape.Name = "btnDeleteShape";
            this.btnDeleteShape.Size = new System.Drawing.Size(98, 23);
            this.btnDeleteShape.TabIndex = 8;
            this.btnDeleteShape.Text = "Delete Object";
            this.btnDeleteShape.UseVisualStyleBackColor = true;
            this.btnDeleteShape.Click += new System.EventHandler(this.btnDeleteShape_Click);
            // 
            // lblSS2
            // 
            this.lblSS2.AutoSize = true;
            this.lblSS2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSS2.Location = new System.Drawing.Point(113, 71);
            this.lblSS2.Name = "lblSS2";
            this.lblSS2.Size = new System.Drawing.Size(43, 13);
            this.lblSS2.TabIndex = 5;
            this.lblSS2.Text = "<none>";
            // 
            // lblSS1
            // 
            this.lblSS1.AutoSize = true;
            this.lblSS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSS1.Location = new System.Drawing.Point(6, 71);
            this.lblSS1.Name = "lblSS1";
            this.lblSS1.Size = new System.Drawing.Size(102, 13);
            this.lblSS1.TabIndex = 4;
            this.lblSS1.Text = "Selected Object:";
            // 
            // lblSCnt2
            // 
            this.lblSCnt2.AutoSize = true;
            this.lblSCnt2.Location = new System.Drawing.Point(172, 24);
            this.lblSCnt2.Name = "lblSCnt2";
            this.lblSCnt2.Size = new System.Drawing.Size(0, 13);
            this.lblSCnt2.TabIndex = 3;
            // 
            // lblSCnt1
            // 
            this.lblSCnt1.AutoSize = true;
            this.lblSCnt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSCnt1.Location = new System.Drawing.Point(128, 24);
            this.lblSCnt1.Name = "lblSCnt1";
            this.lblSCnt1.Size = new System.Drawing.Size(44, 13);
            this.lblSCnt1.TabIndex = 2;
            this.lblSCnt1.Text = "Count:";
            // 
            // cboShapeList
            // 
            this.cboShapeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShapeList.FormattingEnabled = true;
            this.cboShapeList.Location = new System.Drawing.Point(9, 40);
            this.cboShapeList.Name = "cboShapeList";
            this.cboShapeList.Size = new System.Drawing.Size(233, 21);
            this.cboShapeList.TabIndex = 1;
            this.cboShapeList.SelectedIndexChanged += new System.EventHandler(this.cboShapeList_SelectedIndexChanged);
            // 
            // lblDes1
            // 
            this.lblDes1.AutoSize = true;
            this.lblDes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDes1.Location = new System.Drawing.Point(6, 24);
            this.lblDes1.Name = "lblDes1";
            this.lblDes1.Size = new System.Drawing.Size(68, 13);
            this.lblDes1.TabIndex = 0;
            this.lblDes1.Text = "Object List";
            // 
            // btnCamR
            // 
            this.btnCamR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamR.Location = new System.Drawing.Point(168, 69);
            this.btnCamR.Name = "btnCamR";
            this.btnCamR.Size = new System.Drawing.Size(75, 23);
            this.btnCamR.TabIndex = 17;
            this.btnCamR.Text = "Right";
            this.btnCamR.UseVisualStyleBackColor = true;
            this.btnCamR.Click += new System.EventHandler(this.btnCamR_Click);
            // 
            // btnCamD
            // 
            this.btnCamD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamD.Location = new System.Drawing.Point(87, 87);
            this.btnCamD.Name = "btnCamD";
            this.btnCamD.Size = new System.Drawing.Size(75, 23);
            this.btnCamD.TabIndex = 16;
            this.btnCamD.Text = "Down";
            this.btnCamD.UseVisualStyleBackColor = true;
            this.btnCamD.Click += new System.EventHandler(this.btnCamD_Click);
            // 
            // btnCamU
            // 
            this.btnCamU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamU.Location = new System.Drawing.Point(87, 58);
            this.btnCamU.Name = "btnCamU";
            this.btnCamU.Size = new System.Drawing.Size(75, 23);
            this.btnCamU.TabIndex = 15;
            this.btnCamU.Text = "Up";
            this.btnCamU.UseVisualStyleBackColor = true;
            this.btnCamU.Click += new System.EventHandler(this.btnCamU_Click);
            // 
            // btnCamL
            // 
            this.btnCamL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamL.Location = new System.Drawing.Point(6, 69);
            this.btnCamL.Name = "btnCamL";
            this.btnCamL.Size = new System.Drawing.Size(75, 23);
            this.btnCamL.TabIndex = 14;
            this.btnCamL.Text = "Left";
            this.btnCamL.UseVisualStyleBackColor = true;
            this.btnCamL.Click += new System.EventHandler(this.btnCamL_Click);
            // 
            // gbCamera
            // 
            this.gbCamera.Controls.Add(this.btnRCamB);
            this.gbCamera.Controls.Add(this.btnRCamF);
            this.gbCamera.Controls.Add(this.btnResetCamera);
            this.gbCamera.Controls.Add(this.lblCamRotZ);
            this.gbCamera.Controls.Add(this.lblCamRotY);
            this.gbCamera.Controls.Add(this.lblCamRotX);
            this.gbCamera.Controls.Add(this.label7);
            this.gbCamera.Controls.Add(this.label8);
            this.gbCamera.Controls.Add(this.label9);
            this.gbCamera.Controls.Add(this.lblCamPosZ);
            this.gbCamera.Controls.Add(this.lblCamPosY);
            this.gbCamera.Controls.Add(this.lblCamPosX);
            this.gbCamera.Controls.Add(this.label6);
            this.gbCamera.Controls.Add(this.label5);
            this.gbCamera.Controls.Add(this.label4);
            this.gbCamera.Controls.Add(this.label3);
            this.gbCamera.Controls.Add(this.label2);
            this.gbCamera.Controls.Add(this.btnRCamL);
            this.gbCamera.Controls.Add(this.btnRCamR);
            this.gbCamera.Controls.Add(this.btnRCamU);
            this.gbCamera.Controls.Add(this.btnRCamD);
            this.gbCamera.Controls.Add(this.CamB);
            this.gbCamera.Controls.Add(this.CamF);
            this.gbCamera.Controls.Add(this.lblCam2);
            this.gbCamera.Controls.Add(this.lblCam1);
            this.gbCamera.Controls.Add(this.btnCamL);
            this.gbCamera.Controls.Add(this.btnCamR);
            this.gbCamera.Controls.Add(this.btnCamU);
            this.gbCamera.Controls.Add(this.btnCamD);
            this.gbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCamera.Location = new System.Drawing.Point(6, 28);
            this.gbCamera.Name = "gbCamera";
            this.gbCamera.Size = new System.Drawing.Size(249, 267);
            this.gbCamera.TabIndex = 18;
            this.gbCamera.TabStop = false;
            this.gbCamera.Text = "Camera Functions";
            // 
            // btnRCamB
            // 
            this.btnRCamB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCamB.Location = new System.Drawing.Point(6, 212);
            this.btnRCamB.Name = "btnRCamB";
            this.btnRCamB.Size = new System.Drawing.Size(75, 23);
            this.btnRCamB.TabIndex = 43;
            this.btnRCamB.Text = "Z - Neg";
            this.btnRCamB.UseVisualStyleBackColor = true;
            this.btnRCamB.Click += new System.EventHandler(this.btnRCamB_Click);
            // 
            // btnRCamF
            // 
            this.btnRCamF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCamF.Location = new System.Drawing.Point(168, 212);
            this.btnRCamF.Name = "btnRCamF";
            this.btnRCamF.Size = new System.Drawing.Size(75, 23);
            this.btnRCamF.TabIndex = 42;
            this.btnRCamF.Text = "Z - Pos";
            this.btnRCamF.UseVisualStyleBackColor = true;
            this.btnRCamF.Click += new System.EventHandler(this.btnRCamF_Click);
            // 
            // btnResetCamera
            // 
            this.btnResetCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCamera.Location = new System.Drawing.Point(67, 22);
            this.btnResetCamera.Name = "btnResetCamera";
            this.btnResetCamera.Size = new System.Drawing.Size(118, 23);
            this.btnResetCamera.TabIndex = 41;
            this.btnResetCamera.Text = "Reset Camera";
            this.btnResetCamera.UseVisualStyleBackColor = true;
            this.btnResetCamera.Click += new System.EventHandler(this.btnResetCamera_Click);
            // 
            // lblCamRotZ
            // 
            this.lblCamRotZ.AutoSize = true;
            this.lblCamRotZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamRotZ.Location = new System.Drawing.Point(211, 241);
            this.lblCamRotZ.Name = "lblCamRotZ";
            this.lblCamRotZ.Size = new System.Drawing.Size(11, 13);
            this.lblCamRotZ.TabIndex = 40;
            this.lblCamRotZ.Text = "-";
            // 
            // lblCamRotY
            // 
            this.lblCamRotY.AutoSize = true;
            this.lblCamRotY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamRotY.Location = new System.Drawing.Point(177, 241);
            this.lblCamRotY.Name = "lblCamRotY";
            this.lblCamRotY.Size = new System.Drawing.Size(11, 13);
            this.lblCamRotY.TabIndex = 39;
            this.lblCamRotY.Text = "-";
            // 
            // lblCamRotX
            // 
            this.lblCamRotX.AutoSize = true;
            this.lblCamRotX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamRotX.Location = new System.Drawing.Point(130, 241);
            this.lblCamRotX.Name = "lblCamRotX";
            this.lblCamRotX.Size = new System.Drawing.Size(11, 13);
            this.lblCamRotX.TabIndex = 38;
            this.lblCamRotX.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(196, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(156, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(111, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "X";
            // 
            // lblCamPosZ
            // 
            this.lblCamPosZ.AutoSize = true;
            this.lblCamPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamPosZ.Location = new System.Drawing.Point(211, 133);
            this.lblCamPosZ.Name = "lblCamPosZ";
            this.lblCamPosZ.Size = new System.Drawing.Size(11, 13);
            this.lblCamPosZ.TabIndex = 34;
            this.lblCamPosZ.Text = "-";
            // 
            // lblCamPosY
            // 
            this.lblCamPosY.AutoSize = true;
            this.lblCamPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamPosY.Location = new System.Drawing.Point(174, 133);
            this.lblCamPosY.Name = "lblCamPosY";
            this.lblCamPosY.Size = new System.Drawing.Size(11, 13);
            this.lblCamPosY.TabIndex = 33;
            this.lblCamPosY.Text = "-";
            // 
            // lblCamPosX
            // 
            this.lblCamPosX.AutoSize = true;
            this.lblCamPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamPosX.Location = new System.Drawing.Point(130, 133);
            this.lblCamPosX.Name = "lblCamPosX";
            this.lblCamPosX.Size = new System.Drawing.Size(11, 13);
            this.lblCamPosX.TabIndex = 32;
            this.lblCamPosX.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(196, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(156, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(111, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Camera Rotation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Camera Position:";
            // 
            // btnRCamL
            // 
            this.btnRCamL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCamL.Location = new System.Drawing.Point(6, 184);
            this.btnRCamL.Name = "btnRCamL";
            this.btnRCamL.Size = new System.Drawing.Size(75, 23);
            this.btnRCamL.TabIndex = 23;
            this.btnRCamL.Text = "Left";
            this.btnRCamL.UseVisualStyleBackColor = true;
            this.btnRCamL.Click += new System.EventHandler(this.btnRCamL_Click);
            // 
            // btnRCamR
            // 
            this.btnRCamR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCamR.Location = new System.Drawing.Point(168, 184);
            this.btnRCamR.Name = "btnRCamR";
            this.btnRCamR.Size = new System.Drawing.Size(75, 23);
            this.btnRCamR.TabIndex = 26;
            this.btnRCamR.Text = "Right";
            this.btnRCamR.UseVisualStyleBackColor = true;
            this.btnRCamR.Click += new System.EventHandler(this.btnRCamR_Click);
            // 
            // btnRCamU
            // 
            this.btnRCamU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCamU.Location = new System.Drawing.Point(87, 173);
            this.btnRCamU.Name = "btnRCamU";
            this.btnRCamU.Size = new System.Drawing.Size(75, 23);
            this.btnRCamU.TabIndex = 24;
            this.btnRCamU.Text = "Up";
            this.btnRCamU.UseVisualStyleBackColor = true;
            this.btnRCamU.Click += new System.EventHandler(this.btnRCamU_Click);
            // 
            // btnRCamD
            // 
            this.btnRCamD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCamD.Location = new System.Drawing.Point(87, 202);
            this.btnRCamD.Name = "btnRCamD";
            this.btnRCamD.Size = new System.Drawing.Size(75, 23);
            this.btnRCamD.TabIndex = 25;
            this.btnRCamD.Text = "Down";
            this.btnRCamD.UseVisualStyleBackColor = true;
            this.btnRCamD.Click += new System.EventHandler(this.btnRCamD_Click);
            // 
            // CamB
            // 
            this.CamB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CamB.Location = new System.Drawing.Point(6, 98);
            this.CamB.Name = "CamB";
            this.CamB.Size = new System.Drawing.Size(75, 23);
            this.CamB.TabIndex = 22;
            this.CamB.Text = "Back";
            this.CamB.UseVisualStyleBackColor = true;
            this.CamB.Click += new System.EventHandler(this.CamB_Click);
            // 
            // CamF
            // 
            this.CamF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CamF.Location = new System.Drawing.Point(168, 98);
            this.CamF.Name = "CamF";
            this.CamF.Size = new System.Drawing.Size(75, 23);
            this.CamF.TabIndex = 21;
            this.CamF.Text = "Forward";
            this.CamF.UseVisualStyleBackColor = true;
            this.CamF.Click += new System.EventHandler(this.CamF_Click);
            // 
            // lblCam2
            // 
            this.lblCam2.AutoSize = true;
            this.lblCam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam2.Location = new System.Drawing.Point(8, 163);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(45, 13);
            this.lblCam2.TabIndex = 20;
            this.lblCam2.Text = "Rotate";
            // 
            // lblCam1
            // 
            this.lblCam1.AutoSize = true;
            this.lblCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam1.Location = new System.Drawing.Point(3, 53);
            this.lblCam1.Name = "lblCam1";
            this.lblCam1.Size = new System.Drawing.Size(38, 13);
            this.lblCam1.TabIndex = 19;
            this.lblCam1.Text = "Move";
            // 
            // gbTranslate
            // 
            this.gbTranslate.Controls.Add(this.zTranslation);
            this.gbTranslate.Controls.Add(this.yTranslation);
            this.gbTranslate.Controls.Add(this.xTranslation);
            this.gbTranslate.Controls.Add(this.lblzTranslate);
            this.gbTranslate.Controls.Add(this.lblyTranslate);
            this.gbTranslate.Controls.Add(this.lblxTranslate);
            this.gbTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTranslate.Location = new System.Drawing.Point(887, 198);
            this.gbTranslate.Name = "gbTranslate";
            this.gbTranslate.Size = new System.Drawing.Size(246, 43);
            this.gbTranslate.TabIndex = 19;
            this.gbTranslate.TabStop = false;
            this.gbTranslate.Text = "Translate";
            // 
            // zTranslation
            // 
            this.zTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zTranslation.Location = new System.Drawing.Point(185, 15);
            this.zTranslation.MaxLength = 4;
            this.zTranslation.Name = "zTranslation";
            this.zTranslation.Size = new System.Drawing.Size(37, 20);
            this.zTranslation.TabIndex = 32;
            this.zTranslation.Text = "0";
            this.zTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zTranslation_KeyDown);
            this.zTranslation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zTranslation_MouseUp);
            this.zTranslation.Validating += new System.ComponentModel.CancelEventHandler(this.zTranslation_Validating);
            this.zTranslation.Validated += new System.EventHandler(this.zTranslation_Validated);
            // 
            // yTranslation
            // 
            this.yTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yTranslation.Location = new System.Drawing.Point(107, 16);
            this.yTranslation.MaxLength = 4;
            this.yTranslation.Name = "yTranslation";
            this.yTranslation.Size = new System.Drawing.Size(37, 20);
            this.yTranslation.TabIndex = 31;
            this.yTranslation.Text = "0";
            this.yTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yTranslation_KeyDown);
            this.yTranslation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yTranslation_MouseUp);
            this.yTranslation.Validating += new System.ComponentModel.CancelEventHandler(this.yTranslation_Validating);
            this.yTranslation.Validated += new System.EventHandler(this.yTranslation_Validated);
            // 
            // xTranslation
            // 
            this.xTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xTranslation.Location = new System.Drawing.Point(29, 15);
            this.xTranslation.MaxLength = 4;
            this.xTranslation.Name = "xTranslation";
            this.xTranslation.Size = new System.Drawing.Size(37, 20);
            this.xTranslation.TabIndex = 30;
            this.xTranslation.Text = "0";
            this.xTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xTranslation_KeyDown);
            this.xTranslation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xTranslation_MouseUp);
            this.xTranslation.Validating += new System.ComponentModel.CancelEventHandler(this.xTranslation_Validating);
            this.xTranslation.Validated += new System.EventHandler(this.xTranslation_Validated);
            // 
            // lblzTranslate
            // 
            this.lblzTranslate.AutoSize = true;
            this.lblzTranslate.Enabled = false;
            this.lblzTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblzTranslate.Location = new System.Drawing.Point(166, 22);
            this.lblzTranslate.Name = "lblzTranslate";
            this.lblzTranslate.Size = new System.Drawing.Size(15, 13);
            this.lblzTranslate.TabIndex = 29;
            this.lblzTranslate.Text = "Z";
            // 
            // lblyTranslate
            // 
            this.lblyTranslate.AutoSize = true;
            this.lblyTranslate.Enabled = false;
            this.lblyTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblyTranslate.Location = new System.Drawing.Point(89, 23);
            this.lblyTranslate.Name = "lblyTranslate";
            this.lblyTranslate.Size = new System.Drawing.Size(15, 13);
            this.lblyTranslate.TabIndex = 27;
            this.lblyTranslate.Text = "Y";
            // 
            // lblxTranslate
            // 
            this.lblxTranslate.AutoSize = true;
            this.lblxTranslate.Enabled = false;
            this.lblxTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblxTranslate.Location = new System.Drawing.Point(7, 22);
            this.lblxTranslate.Name = "lblxTranslate";
            this.lblxTranslate.Size = new System.Drawing.Size(15, 13);
            this.lblxTranslate.TabIndex = 25;
            this.lblxTranslate.Text = "X";
            // 
            // gbRotate
            // 
            this.gbRotate.Controls.Add(this.lblzRotate);
            this.gbRotate.Controls.Add(this.zRotation);
            this.gbRotate.Controls.Add(this.lblyRotate);
            this.gbRotate.Controls.Add(this.yRotation);
            this.gbRotate.Controls.Add(this.xRotation);
            this.gbRotate.Controls.Add(this.lblxRotate);
            this.gbRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRotate.Location = new System.Drawing.Point(887, 250);
            this.gbRotate.Name = "gbRotate";
            this.gbRotate.Size = new System.Drawing.Size(246, 43);
            this.gbRotate.TabIndex = 20;
            this.gbRotate.TabStop = false;
            this.gbRotate.Text = "Rotate";
            // 
            // lblzRotate
            // 
            this.lblzRotate.AutoSize = true;
            this.lblzRotate.Enabled = false;
            this.lblzRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblzRotate.Location = new System.Drawing.Point(172, 21);
            this.lblzRotate.Name = "lblzRotate";
            this.lblzRotate.Size = new System.Drawing.Size(15, 13);
            this.lblzRotate.TabIndex = 34;
            this.lblzRotate.Text = "Z";
            // 
            // zRotation
            // 
            this.zRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zRotation.Location = new System.Drawing.Point(187, 14);
            this.zRotation.MaxLength = 4;
            this.zRotation.Name = "zRotation";
            this.zRotation.Size = new System.Drawing.Size(37, 20);
            this.zRotation.TabIndex = 35;
            this.zRotation.Text = "0";
            this.zRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zRotation_KeyDown);
            this.zRotation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zRotation_MouseUp);
            this.zRotation.Validating += new System.ComponentModel.CancelEventHandler(this.zRotation_Validating);
            this.zRotation.Validated += new System.EventHandler(this.zRotation_Validated);
            // 
            // lblyRotate
            // 
            this.lblyRotate.AutoSize = true;
            this.lblyRotate.Enabled = false;
            this.lblyRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblyRotate.Location = new System.Drawing.Point(89, 22);
            this.lblyRotate.Name = "lblyRotate";
            this.lblyRotate.Size = new System.Drawing.Size(15, 13);
            this.lblyRotate.TabIndex = 33;
            this.lblyRotate.Text = "Y";
            // 
            // yRotation
            // 
            this.yRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yRotation.Location = new System.Drawing.Point(107, 14);
            this.yRotation.MaxLength = 4;
            this.yRotation.Name = "yRotation";
            this.yRotation.Size = new System.Drawing.Size(37, 20);
            this.yRotation.TabIndex = 34;
            this.yRotation.Text = "0";
            this.yRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yRotation_KeyDown);
            this.yRotation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yRotation_MouseUp);
            this.yRotation.Validating += new System.ComponentModel.CancelEventHandler(this.yRotation_Validating);
            this.yRotation.Validated += new System.EventHandler(this.yRotation_Validated);
            // 
            // xRotation
            // 
            this.xRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xRotation.Location = new System.Drawing.Point(29, 15);
            this.xRotation.MaxLength = 4;
            this.xRotation.Name = "xRotation";
            this.xRotation.Size = new System.Drawing.Size(37, 20);
            this.xRotation.TabIndex = 33;
            this.xRotation.Text = "0";
            this.xRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xRotation_KeyDown);
            this.xRotation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xRotation_MouseUp);
            this.xRotation.Validating += new System.ComponentModel.CancelEventHandler(this.xRotation_Validating);
            this.xRotation.Validated += new System.EventHandler(this.xRotation_Validated);
            // 
            // lblxRotate
            // 
            this.lblxRotate.AutoSize = true;
            this.lblxRotate.Enabled = false;
            this.lblxRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblxRotate.Location = new System.Drawing.Point(7, 22);
            this.lblxRotate.Name = "lblxRotate";
            this.lblxRotate.Size = new System.Drawing.Size(15, 13);
            this.lblxRotate.TabIndex = 26;
            this.lblxRotate.Text = "X";
            // 
            // gbScale
            // 
            this.gbScale.Controls.Add(this.zScaling);
            this.gbScale.Controls.Add(this.label10);
            this.gbScale.Controls.Add(this.yScaling);
            this.gbScale.Controls.Add(this.lblyScale);
            this.gbScale.Controls.Add(this.xScaling);
            this.gbScale.Controls.Add(this.lblxScale);
            this.gbScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbScale.Location = new System.Drawing.Point(887, 302);
            this.gbScale.Name = "gbScale";
            this.gbScale.Size = new System.Drawing.Size(246, 43);
            this.gbScale.TabIndex = 20;
            this.gbScale.TabStop = false;
            this.gbScale.Text = "Scale";
            // 
            // zScaling
            // 
            this.zScaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zScaling.Location = new System.Drawing.Point(187, 15);
            this.zScaling.MaxLength = 4;
            this.zScaling.Name = "zScaling";
            this.zScaling.Size = new System.Drawing.Size(37, 20);
            this.zScaling.TabIndex = 37;
            this.zScaling.Text = "0";
            this.zScaling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zScaling_KeyDown);
            this.zScaling.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zScaling_MouseUp);
            this.zScaling.Validating += new System.ComponentModel.CancelEventHandler(this.zScaling_Validating);
            this.zScaling.Validated += new System.EventHandler(this.zScaling_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(166, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Z";
            // 
            // yScaling
            // 
            this.yScaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yScaling.Location = new System.Drawing.Point(107, 17);
            this.yScaling.MaxLength = 4;
            this.yScaling.Name = "yScaling";
            this.yScaling.Size = new System.Drawing.Size(37, 20);
            this.yScaling.TabIndex = 35;
            this.yScaling.Text = "0";
            this.yScaling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yScaling_KeyDown);
            this.yScaling.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yScaling_MouseUp);
            this.yScaling.Validating += new System.ComponentModel.CancelEventHandler(this.yScaling_Validating);
            this.yScaling.Validated += new System.EventHandler(this.yScaling_Validated);
            // 
            // lblyScale
            // 
            this.lblyScale.AutoSize = true;
            this.lblyScale.Enabled = false;
            this.lblyScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblyScale.Location = new System.Drawing.Point(86, 24);
            this.lblyScale.Name = "lblyScale";
            this.lblyScale.Size = new System.Drawing.Size(15, 13);
            this.lblyScale.TabIndex = 36;
            this.lblyScale.Text = "Y";
            // 
            // xScaling
            // 
            this.xScaling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xScaling.Location = new System.Drawing.Point(30, 17);
            this.xScaling.MaxLength = 4;
            this.xScaling.Name = "xScaling";
            this.xScaling.Size = new System.Drawing.Size(37, 20);
            this.xScaling.TabIndex = 34;
            this.xScaling.Text = "0";
            this.xScaling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xScaling_KeyDown);
            this.xScaling.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xScaling_MouseUp);
            this.xScaling.Validating += new System.ComponentModel.CancelEventHandler(this.xScaling_Validating);
            this.xScaling.Validated += new System.EventHandler(this.xScaling_Validated);
            // 
            // lblxScale
            // 
            this.lblxScale.AutoSize = true;
            this.lblxScale.Enabled = false;
            this.lblxScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblxScale.Location = new System.Drawing.Point(9, 24);
            this.lblxScale.Name = "lblxScale";
            this.lblxScale.Size = new System.Drawing.Size(15, 13);
            this.lblxScale.TabIndex = 34;
            this.lblxScale.Text = "X";
            // 
            // ofdMesh
            // 
            this.ofdMesh.Filter = "|*.x;";
            this.ofdMesh.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdMesh_FileOk);
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.lblObjectColor);
            this.gbColor.Controls.Add(this.label11);
            this.gbColor.Controls.Add(this.btnSelectColor);
            this.gbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbColor.Location = new System.Drawing.Point(887, 147);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(246, 45);
            this.gbColor.TabIndex = 39;
            this.gbColor.TabStop = false;
            this.gbColor.Text = "Color";
            // 
            // lblObjectColor
            // 
            this.lblObjectColor.AutoSize = true;
            this.lblObjectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjectColor.Location = new System.Drawing.Point(96, 23);
            this.lblObjectColor.Name = "lblObjectColor";
            this.lblObjectColor.Size = new System.Drawing.Size(43, 13);
            this.lblObjectColor.TabIndex = 11;
            this.lblObjectColor.Text = "<none>";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Object Color:";
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectColor.Location = new System.Drawing.Point(170, 19);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(66, 23);
            this.btnSelectColor.TabIndex = 0;
            this.btnSelectColor.Text = "Select";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // gbPhysics
            // 
            this.gbPhysics.Controls.Add(this.ckbxGlobalLights);
            this.gbPhysics.Controls.Add(this.cbWireFrame);
            this.gbPhysics.Controls.Add(this.cbGravity);
            this.gbPhysics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPhysics.Location = new System.Drawing.Point(6, 301);
            this.gbPhysics.Name = "gbPhysics";
            this.gbPhysics.Size = new System.Drawing.Size(246, 95);
            this.gbPhysics.TabIndex = 40;
            this.gbPhysics.TabStop = false;
            this.gbPhysics.Text = "Environment";
            // 
            // cbWireFrame
            // 
            this.cbWireFrame.AutoSize = true;
            this.cbWireFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWireFrame.Location = new System.Drawing.Point(9, 50);
            this.cbWireFrame.Name = "cbWireFrame";
            this.cbWireFrame.Size = new System.Drawing.Size(126, 17);
            this.cbWireFrame.TabIndex = 1;
            this.cbWireFrame.Text = "Wireframe On/Off";
            this.cbWireFrame.UseVisualStyleBackColor = true;
            this.cbWireFrame.CheckedChanged += new System.EventHandler(this.cbWireFrame_CheckedChanged);
            // 
            // cbGravity
            // 
            this.cbGravity.AutoSize = true;
            this.cbGravity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGravity.Location = new System.Drawing.Point(9, 26);
            this.cbGravity.Name = "cbGravity";
            this.cbGravity.Size = new System.Drawing.Size(109, 17);
            this.cbGravity.TabIndex = 0;
            this.cbGravity.Text = "Gravity On/Off";
            this.cbGravity.UseVisualStyleBackColor = true;
            this.cbGravity.CheckedChanged += new System.EventHandler(this.cbGravity_CheckedChanged);
            // 
            // gbLighting
            // 
            this.gbLighting.Controls.Add(this.lblLightCount);
            this.gbLighting.Controls.Add(this.label20);
            this.gbLighting.Controls.Add(this.label18);
            this.gbLighting.Controls.Add(this.label19);
            this.gbLighting.Controls.Add(this.txtLightRange);
            this.gbLighting.Controls.Add(this.txtLightDirectionZ);
            this.gbLighting.Controls.Add(this.label15);
            this.gbLighting.Controls.Add(this.txtLightDirectionY);
            this.gbLighting.Controls.Add(this.label16);
            this.gbLighting.Controls.Add(this.txtLightDirectionX);
            this.gbLighting.Controls.Add(this.label17);
            this.gbLighting.Controls.Add(this.txtLightLocZ);
            this.gbLighting.Controls.Add(this.label12);
            this.gbLighting.Controls.Add(this.lblSelectedLight);
            this.gbLighting.Controls.Add(this.txtLightLocY);
            this.gbLighting.Controls.Add(this.label13);
            this.gbLighting.Controls.Add(this.cbPointLights);
            this.gbLighting.Controls.Add(this.txtLightLocX);
            this.gbLighting.Controls.Add(this.label14);
            this.gbLighting.Controls.Add(this.lblLights2);
            this.gbLighting.Controls.Add(this.lblLights1);
            this.gbLighting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLighting.Location = new System.Drawing.Point(887, 351);
            this.gbLighting.Name = "gbLighting";
            this.gbLighting.Size = new System.Drawing.Size(246, 201);
            this.gbLighting.TabIndex = 41;
            this.gbLighting.TabStop = false;
            this.gbLighting.Text = "Lights";
            // 
            // lblLightCount
            // 
            this.lblLightCount.AutoSize = true;
            this.lblLightCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLightCount.Location = new System.Drawing.Point(128, 23);
            this.lblLightCount.Name = "lblLightCount";
            this.lblLightCount.Size = new System.Drawing.Size(44, 13);
            this.lblLightCount.TabIndex = 10;
            this.lblLightCount.Text = "Count:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(7, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "Selected Light:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 185);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 51;
            this.label18.Text = "Range:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 53;
            this.label19.Text = "Location:";
            // 
            // txtLightRange
            // 
            this.txtLightRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightRange.Location = new System.Drawing.Point(60, 178);
            this.txtLightRange.MaxLength = 4;
            this.txtLightRange.Name = "txtLightRange";
            this.txtLightRange.Size = new System.Drawing.Size(37, 20);
            this.txtLightRange.TabIndex = 52;
            this.txtLightRange.Text = "0";
            this.txtLightRange.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtLightRange_MouseUp);
            // 
            // txtLightDirectionZ
            // 
            this.txtLightDirectionZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightDirectionZ.Location = new System.Drawing.Point(185, 148);
            this.txtLightDirectionZ.MaxLength = 4;
            this.txtLightDirectionZ.Name = "txtLightDirectionZ";
            this.txtLightDirectionZ.Size = new System.Drawing.Size(37, 20);
            this.txtLightDirectionZ.TabIndex = 49;
            this.txtLightDirectionZ.Text = "0";
            this.txtLightDirectionZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtLightDirectionZ_MouseUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(164, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 50;
            this.label15.Text = "Z";
            // 
            // txtLightDirectionY
            // 
            this.txtLightDirectionY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightDirectionY.Location = new System.Drawing.Point(105, 150);
            this.txtLightDirectionY.MaxLength = 4;
            this.txtLightDirectionY.Name = "txtLightDirectionY";
            this.txtLightDirectionY.Size = new System.Drawing.Size(37, 20);
            this.txtLightDirectionY.TabIndex = 47;
            this.txtLightDirectionY.Text = "0";
            this.txtLightDirectionY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtLightDirectionY_MouseUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(84, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 13);
            this.label16.TabIndex = 48;
            this.label16.Text = "Y";
            // 
            // txtLightDirectionX
            // 
            this.txtLightDirectionX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightDirectionX.Location = new System.Drawing.Point(28, 150);
            this.txtLightDirectionX.MaxLength = 4;
            this.txtLightDirectionX.Name = "txtLightDirectionX";
            this.txtLightDirectionX.Size = new System.Drawing.Size(37, 20);
            this.txtLightDirectionX.TabIndex = 45;
            this.txtLightDirectionX.Text = "0";
            this.txtLightDirectionX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtLightDirectionX_MouseUp);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 157);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 13);
            this.label17.TabIndex = 46;
            this.label17.Text = "X";
            // 
            // txtLightLocZ
            // 
            this.txtLightLocZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightLocZ.Location = new System.Drawing.Point(187, 105);
            this.txtLightLocZ.MaxLength = 4;
            this.txtLightLocZ.Name = "txtLightLocZ";
            this.txtLightLocZ.Size = new System.Drawing.Size(37, 20);
            this.txtLightLocZ.TabIndex = 43;
            this.txtLightLocZ.Text = "0";
            this.txtLightLocZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtLightLocZ_MouseUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(166, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Z";
            // 
            // lblSelectedLight
            // 
            this.lblSelectedLight.AutoSize = true;
            this.lblSelectedLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedLight.Location = new System.Drawing.Point(101, 70);
            this.lblSelectedLight.Name = "lblSelectedLight";
            this.lblSelectedLight.Size = new System.Drawing.Size(43, 13);
            this.lblSelectedLight.TabIndex = 14;
            this.lblSelectedLight.Text = "<none>";
            // 
            // txtLightLocY
            // 
            this.txtLightLocY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightLocY.Location = new System.Drawing.Point(102, 107);
            this.txtLightLocY.MaxLength = 4;
            this.txtLightLocY.Name = "txtLightLocY";
            this.txtLightLocY.Size = new System.Drawing.Size(37, 20);
            this.txtLightLocY.TabIndex = 41;
            this.txtLightLocY.Text = "0";
            this.txtLightLocY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtLightLocY_MouseUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(86, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "Y";
            // 
            // cbPointLights
            // 
            this.cbPointLights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPointLights.FormattingEnabled = true;
            this.cbPointLights.Location = new System.Drawing.Point(9, 39);
            this.cbPointLights.Name = "cbPointLights";
            this.cbPointLights.Size = new System.Drawing.Size(233, 21);
            this.cbPointLights.TabIndex = 12;
            this.cbPointLights.SelectedIndexChanged += new System.EventHandler(this.cbPointLights_SelectedIndexChanged);
            // 
            // txtLightLocX
            // 
            this.txtLightLocX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightLocX.Location = new System.Drawing.Point(30, 107);
            this.txtLightLocX.MaxLength = 4;
            this.txtLightLocX.Name = "txtLightLocX";
            this.txtLightLocX.Size = new System.Drawing.Size(37, 20);
            this.txtLightLocX.TabIndex = 39;
            this.txtLightLocX.Text = "0";
            this.txtLightLocX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtLightLocX_MouseUp);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "X";
            // 
            // lblLights2
            // 
            this.lblLights2.AutoSize = true;
            this.lblLights2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLights2.Location = new System.Drawing.Point(6, 134);
            this.lblLights2.Name = "lblLights2";
            this.lblLights2.Size = new System.Drawing.Size(162, 13);
            this.lblLights2.TabIndex = 11;
            this.lblLights2.Text = "Point At: (Directional Only):";
            // 
            // lblLights1
            // 
            this.lblLights1.AutoSize = true;
            this.lblLights1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLights1.Location = new System.Drawing.Point(6, 23);
            this.lblLights1.Name = "lblLights1";
            this.lblLights1.Size = new System.Drawing.Size(59, 13);
            this.lblLights1.TabIndex = 10;
            this.lblLights1.Text = "Light List";
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // ofdTexture
            // 
            this.ofdTexture.Filter = "|*.bmp;*.dds;*.jpg;";
            this.ofdTexture.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdTexture_FileOk);
            // 
            // ckbxGlobalLights
            // 
            this.ckbxGlobalLights.AutoSize = true;
            this.ckbxGlobalLights.Checked = true;
            this.ckbxGlobalLights.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbxGlobalLights.Location = new System.Drawing.Point(9, 72);
            this.ckbxGlobalLights.Name = "ckbxGlobalLights";
            this.ckbxGlobalLights.Size = new System.Drawing.Size(143, 17);
            this.ckbxGlobalLights.TabIndex = 2;
            this.ckbxGlobalLights.Text = "Global Lights On/Off";
            this.ckbxGlobalLights.UseVisualStyleBackColor = true;
            this.ckbxGlobalLights.CheckedChanged += new System.EventHandler(this.ckbxGlobalLights_CheckedChanged);
            // 
            // MainPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(1137, 562);
            this.Controls.Add(this.gbLighting);
            this.Controls.Add(this.gbPhysics);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbScale);
            this.Controls.Add(this.gbRotate);
            this.Controls.Add(this.gbTranslate);
            this.Controls.Add(this.gbCamera);
            this.Controls.Add(this.gbObjects);
            this.Controls.Add(this.plNotArea);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.Text = "Computer Graphics - Term Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbMemUsage.ResumeLayout(false);
            this.gbMemUsage.PerformLayout();
            this.plNotArea.ResumeLayout(false);
            this.plNotArea.PerformLayout();
            this.gbObjects.ResumeLayout(false);
            this.gbObjects.PerformLayout();
            this.gbCamera.ResumeLayout(false);
            this.gbCamera.PerformLayout();
            this.gbTranslate.ResumeLayout(false);
            this.gbTranslate.PerformLayout();
            this.gbRotate.ResumeLayout(false);
            this.gbRotate.PerformLayout();
            this.gbScale.ResumeLayout(false);
            this.gbScale.PerformLayout();
            this.gbColor.ResumeLayout(false);
            this.gbColor.PerformLayout();
            this.gbPhysics.ResumeLayout(false);
            this.gbPhysics.PerformLayout();
            this.gbLighting.ResumeLayout(false);
            this.gbLighting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.Label lblMemoryUsage;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.GroupBox gbMemUsage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plNotArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbObjects;
        private System.Windows.Forms.ComboBox cboShapeList;
        private System.Windows.Forms.Label lblDes1;
        private System.Windows.Forms.Label lblSCnt2;
        private System.Windows.Forms.Label lblSCnt1;
        private System.Windows.Forms.Label lblSS2;
        private System.Windows.Forms.Label lblSS1;
        private System.Windows.Forms.Button btnDeleteShape;
        private System.Windows.Forms.Button btnCamR;
        private System.Windows.Forms.Button btnCamD;
        private System.Windows.Forms.Button btnCamU;
        private System.Windows.Forms.Button btnCamL;
        private System.Windows.Forms.GroupBox gbCamera;
        private System.Windows.Forms.Label lblCam1;
        private System.Windows.Forms.Button CamB;
        private System.Windows.Forms.Button CamF;
        private System.Windows.Forms.Label lblCam2;
        private System.Windows.Forms.GroupBox gbTranslate;
        private System.Windows.Forms.GroupBox gbRotate;
        private System.Windows.Forms.GroupBox gbScale;
        private System.Windows.Forms.ToolStripMenuItem miLoadMesh;
        private System.Windows.Forms.OpenFileDialog ofdMesh;
        private System.Windows.Forms.Button btnRCamL;
        private System.Windows.Forms.Button btnRCamR;
        private System.Windows.Forms.Button btnRCamU;
        private System.Windows.Forms.Button btnRCamD;
        private System.Windows.Forms.Label lblzTranslate;
        private System.Windows.Forms.Label lblyTranslate;
        private System.Windows.Forms.Label lblxTranslate;
        private System.Windows.Forms.TextBox zTranslation;
        private System.Windows.Forms.TextBox yTranslation;
        private System.Windows.Forms.TextBox xTranslation;
        private System.Windows.Forms.TextBox xRotation;
        private System.Windows.Forms.Label lblxRotate;
        private System.Windows.Forms.TextBox xScaling;
        private System.Windows.Forms.Label lblxScale;
        private System.Windows.Forms.Button btnClearScene;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblzRotate;
        private System.Windows.Forms.TextBox zRotation;
        private System.Windows.Forms.Label lblyRotate;
        private System.Windows.Forms.TextBox yRotation;
        private System.Windows.Forms.TextBox zScaling;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox yScaling;
        private System.Windows.Forms.Label lblyScale;
        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.Label lblCamRotZ;
        private System.Windows.Forms.Label lblCamRotY;
        private System.Windows.Forms.Label lblCamRotX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCamPosZ;
        private System.Windows.Forms.Label lblCamPosY;
        private System.Windows.Forms.Label lblCamPosX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResetCamera;
        private System.Windows.Forms.GroupBox gbPhysics;
        private System.Windows.Forms.CheckBox cbGravity;
        private System.Windows.Forms.GroupBox gbLighting;
        private System.Windows.Forms.Button btnRCamB;
        private System.Windows.Forms.Button btnRCamF;
        private System.Windows.Forms.ErrorProvider epMain;
        private System.Windows.Forms.ToolStripMenuItem loadTextureToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdTexture;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblObjectColor;
        private System.Windows.Forms.Label lblLights2;
        private System.Windows.Forms.Label lblLights1;
        private System.Windows.Forms.ComboBox cbPointLights;
        private System.Windows.Forms.ToolStripMenuItem lightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPointLightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDirectionalLightToolStripMenuItem;
        private System.Windows.Forms.Label lblSelectedLight;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtLightDirectionZ;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtLightDirectionY;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtLightDirectionX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtLightLocZ;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLightLocY;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLightLocX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLightRange;
        private System.Windows.Forms.Label lblLightCount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbWireFrame;
        private System.Windows.Forms.ToolStripMenuItem terrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomTerrainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTerrainToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckbxGlobalLights;
    }
}

