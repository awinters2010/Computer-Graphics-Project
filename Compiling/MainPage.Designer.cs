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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoadMesh = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.gbMemUsage = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plNotArea = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbShapes = new System.Windows.Forms.GroupBox();
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
            this.xRotation = new System.Windows.Forms.TextBox();
            this.lblxRotate = new System.Windows.Forms.Label();
            this.gbScale = new System.Windows.Forms.GroupBox();
            this.xScaling = new System.Windows.Forms.TextBox();
            this.lblxScale = new System.Windows.Forms.Label();
            this.ofdMesh = new System.Windows.Forms.OpenFileDialog();
            this.yRotation = new System.Windows.Forms.TextBox();
            this.zRotation = new System.Windows.Forms.TextBox();
            this.lblzRotate = new System.Windows.Forms.Label();
            this.lblyRotate = new System.Windows.Forms.Label();
            this.yScaling = new System.Windows.Forms.TextBox();
            this.lblyScale = new System.Windows.Forms.Label();
            this.zScaling = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.lblCamTitleZPos = new System.Windows.Forms.Label();
            this.lblCamTitleYPos = new System.Windows.Forms.Label();
            this.lblCamTitleXPos = new System.Windows.Forms.Label();
            this.lblCamTitleZRot = new System.Windows.Forms.Label();
            this.lblCamTitleYRot = new System.Windows.Forms.Label();
            this.lblCamTitleXRot = new System.Windows.Forms.Label();
            this.lblCamXPos = new System.Windows.Forms.Label();
            this.lblCamYPos = new System.Windows.Forms.Label();
            this.lblCamZPos = new System.Windows.Forms.Label();
            this.lblCamZRot = new System.Windows.Forms.Label();
            this.lblCamYRot = new System.Windows.Forms.Label();
            this.lblCamXRot = new System.Windows.Forms.Label();
            this.lblCamLocationTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gbMemUsage.SuspendLayout();
            this.plNotArea.SuspendLayout();
            this.gbShapes.SuspendLayout();
            this.gbCamera.SuspendLayout();
            this.gbTranslate.SuspendLayout();
            this.gbRotate.SuspendLayout();
            this.gbScale.SuspendLayout();
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
            this.shapesToolStripMenuItem});
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
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miLoadMesh
            // 
            this.miLoadMesh.Name = "miLoadMesh";
            this.miLoadMesh.Size = new System.Drawing.Size(152, 22);
            this.miLoadMesh.Text = "Load Mesh";
            this.miLoadMesh.Click += new System.EventHandler(this.miLoadMesh_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.panel1.Size = new System.Drawing.Size(624, 534);
            this.panel1.TabIndex = 6;
            // 
            // plNotArea
            // 
            this.plNotArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.plNotArea.Controls.Add(this.label1);
            this.plNotArea.Controls.Add(this.gbMemUsage);
            this.plNotArea.Controls.Add(this.progressBar1);
            this.plNotArea.Location = new System.Drawing.Point(0, 467);
            this.plNotArea.Name = "plNotArea";
            this.plNotArea.Size = new System.Drawing.Size(255, 95);
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
            // gbShapes
            // 
            this.gbShapes.Controls.Add(this.btnClearScene);
            this.gbShapes.Controls.Add(this.btnDeleteShape);
            this.gbShapes.Controls.Add(this.lblSS2);
            this.gbShapes.Controls.Add(this.lblSS1);
            this.gbShapes.Controls.Add(this.lblSCnt2);
            this.gbShapes.Controls.Add(this.lblSCnt1);
            this.gbShapes.Controls.Add(this.cboShapeList);
            this.gbShapes.Controls.Add(this.lblDes1);
            this.gbShapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShapes.Location = new System.Drawing.Point(887, 26);
            this.gbShapes.Name = "gbShapes";
            this.gbShapes.Size = new System.Drawing.Size(246, 115);
            this.gbShapes.TabIndex = 11;
            this.gbShapes.TabStop = false;
            this.gbShapes.Text = "Shapes";
            // 
            // btnClearScene
            // 
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
            this.btnDeleteShape.Location = new System.Drawing.Point(12, 87);
            this.btnDeleteShape.Name = "btnDeleteShape";
            this.btnDeleteShape.Size = new System.Drawing.Size(98, 23);
            this.btnDeleteShape.TabIndex = 8;
            this.btnDeleteShape.Text = "Delete Shape";
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
            this.lblSS1.Location = new System.Drawing.Point(6, 71);
            this.lblSS1.Name = "lblSS1";
            this.lblSS1.Size = new System.Drawing.Size(101, 13);
            this.lblSS1.TabIndex = 4;
            this.lblSS1.Text = "Selected Shape:";
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
            this.lblDes1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDes1.Location = new System.Drawing.Point(6, 24);
            this.lblDes1.Name = "lblDes1";
            this.lblDes1.Size = new System.Drawing.Size(67, 13);
            this.lblDes1.TabIndex = 0;
            this.lblDes1.Text = "Shape List";
            // 
            // btnCamR
            // 
            this.btnCamR.Location = new System.Drawing.Point(168, 38);
            this.btnCamR.Name = "btnCamR";
            this.btnCamR.Size = new System.Drawing.Size(75, 23);
            this.btnCamR.TabIndex = 17;
            this.btnCamR.Text = "Right";
            this.btnCamR.UseVisualStyleBackColor = true;
            this.btnCamR.Click += new System.EventHandler(this.btnCamR_Click);
            // 
            // btnCamD
            // 
            this.btnCamD.Location = new System.Drawing.Point(87, 56);
            this.btnCamD.Name = "btnCamD";
            this.btnCamD.Size = new System.Drawing.Size(75, 23);
            this.btnCamD.TabIndex = 16;
            this.btnCamD.Text = "Down";
            this.btnCamD.UseVisualStyleBackColor = true;
            this.btnCamD.Click += new System.EventHandler(this.btnCamD_Click);
            // 
            // btnCamU
            // 
            this.btnCamU.Location = new System.Drawing.Point(87, 27);
            this.btnCamU.Name = "btnCamU";
            this.btnCamU.Size = new System.Drawing.Size(75, 23);
            this.btnCamU.TabIndex = 15;
            this.btnCamU.Text = "Up";
            this.btnCamU.UseVisualStyleBackColor = true;
            this.btnCamU.Click += new System.EventHandler(this.btnCamU_Click);
            // 
            // btnCamL
            // 
            this.btnCamL.Location = new System.Drawing.Point(6, 38);
            this.btnCamL.Name = "btnCamL";
            this.btnCamL.Size = new System.Drawing.Size(75, 23);
            this.btnCamL.TabIndex = 14;
            this.btnCamL.Text = "Left";
            this.btnCamL.UseVisualStyleBackColor = true;
            this.btnCamL.Click += new System.EventHandler(this.btnCamL_Click);
            // 
            // gbCamera
            // 
            this.gbCamera.Controls.Add(this.label2);
            this.gbCamera.Controls.Add(this.lblCamLocationTitle);
            this.gbCamera.Controls.Add(this.lblCamZRot);
            this.gbCamera.Controls.Add(this.lblCamYRot);
            this.gbCamera.Controls.Add(this.lblCamXRot);
            this.gbCamera.Controls.Add(this.lblCamZPos);
            this.gbCamera.Controls.Add(this.lblCamYPos);
            this.gbCamera.Controls.Add(this.lblCamXPos);
            this.gbCamera.Controls.Add(this.lblCamTitleZRot);
            this.gbCamera.Controls.Add(this.lblCamTitleYRot);
            this.gbCamera.Controls.Add(this.lblCamTitleXRot);
            this.gbCamera.Controls.Add(this.btnRCamL);
            this.gbCamera.Controls.Add(this.btnRCamR);
            this.gbCamera.Controls.Add(this.lblCamTitleZPos);
            this.gbCamera.Controls.Add(this.btnRCamU);
            this.gbCamera.Controls.Add(this.lblCamTitleYPos);
            this.gbCamera.Controls.Add(this.btnRCamD);
            this.gbCamera.Controls.Add(this.lblCamTitleXPos);
            this.gbCamera.Controls.Add(this.CamB);
            this.gbCamera.Controls.Add(this.CamF);
            this.gbCamera.Controls.Add(this.lblCam2);
            this.gbCamera.Controls.Add(this.lblCam1);
            this.gbCamera.Controls.Add(this.btnCamL);
            this.gbCamera.Controls.Add(this.btnCamR);
            this.gbCamera.Controls.Add(this.btnCamU);
            this.gbCamera.Controls.Add(this.btnCamD);
            this.gbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCamera.Location = new System.Drawing.Point(6, 28);
            this.gbCamera.Name = "gbCamera";
            this.gbCamera.Size = new System.Drawing.Size(249, 217);
            this.gbCamera.TabIndex = 18;
            this.gbCamera.TabStop = false;
            this.gbCamera.Text = "Camera Functions";
            this.gbCamera.Enter += new System.EventHandler(this.gbCamera_Enter);
            // 
            // btnRCamL
            // 
            this.btnRCamL.Location = new System.Drawing.Point(6, 147);
            this.btnRCamL.Name = "btnRCamL";
            this.btnRCamL.Size = new System.Drawing.Size(75, 23);
            this.btnRCamL.TabIndex = 23;
            this.btnRCamL.Text = "Left";
            this.btnRCamL.UseVisualStyleBackColor = true;
            this.btnRCamL.Click += new System.EventHandler(this.btnRCamL_Click);
            // 
            // btnRCamR
            // 
            this.btnRCamR.Location = new System.Drawing.Point(168, 147);
            this.btnRCamR.Name = "btnRCamR";
            this.btnRCamR.Size = new System.Drawing.Size(75, 23);
            this.btnRCamR.TabIndex = 26;
            this.btnRCamR.Text = "Right";
            this.btnRCamR.UseVisualStyleBackColor = true;
            this.btnRCamR.Click += new System.EventHandler(this.btnRCamR_Click);
            // 
            // btnRCamU
            // 
            this.btnRCamU.Location = new System.Drawing.Point(87, 136);
            this.btnRCamU.Name = "btnRCamU";
            this.btnRCamU.Size = new System.Drawing.Size(75, 23);
            this.btnRCamU.TabIndex = 24;
            this.btnRCamU.Text = "Up";
            this.btnRCamU.UseVisualStyleBackColor = true;
            this.btnRCamU.Click += new System.EventHandler(this.btnRCamU_Click);
            // 
            // btnRCamD
            // 
            this.btnRCamD.Location = new System.Drawing.Point(87, 165);
            this.btnRCamD.Name = "btnRCamD";
            this.btnRCamD.Size = new System.Drawing.Size(75, 23);
            this.btnRCamD.TabIndex = 25;
            this.btnRCamD.Text = "Down";
            this.btnRCamD.UseVisualStyleBackColor = true;
            this.btnRCamD.Click += new System.EventHandler(this.btnRCamD_Click);
            // 
            // CamB
            // 
            this.CamB.Location = new System.Drawing.Point(6, 67);
            this.CamB.Name = "CamB";
            this.CamB.Size = new System.Drawing.Size(75, 23);
            this.CamB.TabIndex = 22;
            this.CamB.Text = "Back";
            this.CamB.UseVisualStyleBackColor = true;
            this.CamB.Click += new System.EventHandler(this.CamB_Click);
            // 
            // CamF
            // 
            this.CamF.Location = new System.Drawing.Point(168, 67);
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
            this.lblCam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam2.Location = new System.Drawing.Point(8, 126);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(45, 13);
            this.lblCam2.TabIndex = 20;
            this.lblCam2.Text = "Rotate";
            // 
            // lblCam1
            // 
            this.lblCam1.AutoSize = true;
            this.lblCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam1.Location = new System.Drawing.Point(3, 22);
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
            this.gbTranslate.Location = new System.Drawing.Point(887, 223);
            this.gbTranslate.Name = "gbTranslate";
            this.gbTranslate.Size = new System.Drawing.Size(246, 47);
            this.gbTranslate.TabIndex = 19;
            this.gbTranslate.TabStop = false;
            this.gbTranslate.Text = "Translate";
            // 
            // zTranslation
            // 
            this.zTranslation.Location = new System.Drawing.Point(185, 15);
            this.zTranslation.Name = "zTranslation";
            this.zTranslation.Size = new System.Drawing.Size(51, 20);
            this.zTranslation.TabIndex = 32;
            this.zTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zTranslation_KeyDown);
            // 
            // yTranslation
            // 
            this.yTranslation.Location = new System.Drawing.Point(107, 16);
            this.yTranslation.Name = "yTranslation";
            this.yTranslation.Size = new System.Drawing.Size(51, 20);
            this.yTranslation.TabIndex = 31;
            this.yTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yTranslation_KeyDown);
            // 
            // xTranslation
            // 
            this.xTranslation.Location = new System.Drawing.Point(29, 15);
            this.xTranslation.Name = "xTranslation";
            this.xTranslation.Size = new System.Drawing.Size(51, 20);
            this.xTranslation.TabIndex = 30;
            this.xTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xTranslation_KeyDown);
            // 
            // lblzTranslate
            // 
            this.lblzTranslate.AutoSize = true;
            this.lblzTranslate.Enabled = false;
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
            this.gbRotate.Location = new System.Drawing.Point(887, 276);
            this.gbRotate.Name = "gbRotate";
            this.gbRotate.Size = new System.Drawing.Size(246, 48);
            this.gbRotate.TabIndex = 20;
            this.gbRotate.TabStop = false;
            this.gbRotate.Text = "Rotate";
            // 
            // xRotation
            // 
            this.xRotation.Location = new System.Drawing.Point(29, 15);
            this.xRotation.Name = "xRotation";
            this.xRotation.Size = new System.Drawing.Size(51, 20);
            this.xRotation.TabIndex = 33;
            this.xRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xRotation_KeyDown);
            // 
            // lblxRotate
            // 
            this.lblxRotate.AutoSize = true;
            this.lblxRotate.Enabled = false;
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
            this.gbScale.Location = new System.Drawing.Point(887, 330);
            this.gbScale.Name = "gbScale";
            this.gbScale.Size = new System.Drawing.Size(246, 54);
            this.gbScale.TabIndex = 20;
            this.gbScale.TabStop = false;
            this.gbScale.Text = "Scale";
            // 
            // xScaling
            // 
            this.xScaling.Location = new System.Drawing.Point(30, 17);
            this.xScaling.Name = "xScaling";
            this.xScaling.Size = new System.Drawing.Size(51, 20);
            this.xScaling.TabIndex = 34;
            this.xScaling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xScaling_KeyDown);
            // 
            // lblxScale
            // 
            this.lblxScale.AutoSize = true;
            this.lblxScale.Enabled = false;
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
            // yRotation
            // 
            this.yRotation.Location = new System.Drawing.Point(107, 14);
            this.yRotation.Name = "yRotation";
            this.yRotation.Size = new System.Drawing.Size(51, 20);
            this.yRotation.TabIndex = 34;
            // 
            // zRotation
            // 
            this.zRotation.Location = new System.Drawing.Point(187, 14);
            this.zRotation.Name = "zRotation";
            this.zRotation.Size = new System.Drawing.Size(51, 20);
            this.zRotation.TabIndex = 35;
            // 
            // lblzRotate
            // 
            this.lblzRotate.AutoSize = true;
            this.lblzRotate.Enabled = false;
            this.lblzRotate.Location = new System.Drawing.Point(172, 21);
            this.lblzRotate.Name = "lblzRotate";
            this.lblzRotate.Size = new System.Drawing.Size(15, 13);
            this.lblzRotate.TabIndex = 34;
            this.lblzRotate.Text = "Z";
            // 
            // lblyRotate
            // 
            this.lblyRotate.AutoSize = true;
            this.lblyRotate.Enabled = false;
            this.lblyRotate.Location = new System.Drawing.Point(89, 22);
            this.lblyRotate.Name = "lblyRotate";
            this.lblyRotate.Size = new System.Drawing.Size(15, 13);
            this.lblyRotate.TabIndex = 33;
            this.lblyRotate.Text = "Y";
            // 
            // yScaling
            // 
            this.yScaling.Location = new System.Drawing.Point(107, 17);
            this.yScaling.Name = "yScaling";
            this.yScaling.Size = new System.Drawing.Size(51, 20);
            this.yScaling.TabIndex = 35;
            // 
            // lblyScale
            // 
            this.lblyScale.AutoSize = true;
            this.lblyScale.Enabled = false;
            this.lblyScale.Location = new System.Drawing.Point(86, 24);
            this.lblyScale.Name = "lblyScale";
            this.lblyScale.Size = new System.Drawing.Size(15, 13);
            this.lblyScale.TabIndex = 36;
            this.lblyScale.Text = "Y";
            // 
            // zScaling
            // 
            this.zScaling.Location = new System.Drawing.Point(187, 15);
            this.zScaling.Name = "zScaling";
            this.zScaling.Size = new System.Drawing.Size(51, 20);
            this.zScaling.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(166, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Z";
            // 
            // gbColor
            // 
            this.gbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbColor.Location = new System.Drawing.Point(887, 147);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(246, 70);
            this.gbColor.TabIndex = 39;
            this.gbColor.TabStop = false;
            this.gbColor.Text = "Color";
            // 
            // lblCamTitleZPos
            // 
            this.lblCamTitleZPos.AutoSize = true;
            this.lblCamTitleZPos.Enabled = false;
            this.lblCamTitleZPos.Location = new System.Drawing.Point(196, 96);
            this.lblCamTitleZPos.Name = "lblCamTitleZPos";
            this.lblCamTitleZPos.Size = new System.Drawing.Size(15, 13);
            this.lblCamTitleZPos.TabIndex = 42;
            this.lblCamTitleZPos.Text = "Z";
            // 
            // lblCamTitleYPos
            // 
            this.lblCamTitleYPos.AutoSize = true;
            this.lblCamTitleYPos.Enabled = false;
            this.lblCamTitleYPos.Location = new System.Drawing.Point(158, 96);
            this.lblCamTitleYPos.Name = "lblCamTitleYPos";
            this.lblCamTitleYPos.Size = new System.Drawing.Size(15, 13);
            this.lblCamTitleYPos.TabIndex = 41;
            this.lblCamTitleYPos.Text = "Y";
            // 
            // lblCamTitleXPos
            // 
            this.lblCamTitleXPos.AutoSize = true;
            this.lblCamTitleXPos.Enabled = false;
            this.lblCamTitleXPos.Location = new System.Drawing.Point(120, 96);
            this.lblCamTitleXPos.Name = "lblCamTitleXPos";
            this.lblCamTitleXPos.Size = new System.Drawing.Size(15, 13);
            this.lblCamTitleXPos.TabIndex = 40;
            this.lblCamTitleXPos.Text = "X";
            // 
            // lblCamTitleZRot
            // 
            this.lblCamTitleZRot.AutoSize = true;
            this.lblCamTitleZRot.Enabled = false;
            this.lblCamTitleZRot.Location = new System.Drawing.Point(196, 191);
            this.lblCamTitleZRot.Name = "lblCamTitleZRot";
            this.lblCamTitleZRot.Size = new System.Drawing.Size(15, 13);
            this.lblCamTitleZRot.TabIndex = 48;
            this.lblCamTitleZRot.Text = "Z";
            // 
            // lblCamTitleYRot
            // 
            this.lblCamTitleYRot.AutoSize = true;
            this.lblCamTitleYRot.Enabled = false;
            this.lblCamTitleYRot.Location = new System.Drawing.Point(158, 191);
            this.lblCamTitleYRot.Name = "lblCamTitleYRot";
            this.lblCamTitleYRot.Size = new System.Drawing.Size(15, 13);
            this.lblCamTitleYRot.TabIndex = 47;
            this.lblCamTitleYRot.Text = "Y";
            // 
            // lblCamTitleXRot
            // 
            this.lblCamTitleXRot.AutoSize = true;
            this.lblCamTitleXRot.Enabled = false;
            this.lblCamTitleXRot.Location = new System.Drawing.Point(120, 191);
            this.lblCamTitleXRot.Name = "lblCamTitleXRot";
            this.lblCamTitleXRot.Size = new System.Drawing.Size(15, 13);
            this.lblCamTitleXRot.TabIndex = 46;
            this.lblCamTitleXRot.Text = "X";
            // 
            // lblCamXPos
            // 
            this.lblCamXPos.AutoSize = true;
            this.lblCamXPos.Location = new System.Drawing.Point(141, 96);
            this.lblCamXPos.Name = "lblCamXPos";
            this.lblCamXPos.Size = new System.Drawing.Size(11, 13);
            this.lblCamXPos.TabIndex = 52;
            this.lblCamXPos.Text = "-";
            // 
            // lblCamYPos
            // 
            this.lblCamYPos.AutoSize = true;
            this.lblCamYPos.Location = new System.Drawing.Point(179, 96);
            this.lblCamYPos.Name = "lblCamYPos";
            this.lblCamYPos.Size = new System.Drawing.Size(11, 13);
            this.lblCamYPos.TabIndex = 53;
            this.lblCamYPos.Text = "-";
            // 
            // lblCamZPos
            // 
            this.lblCamZPos.AutoSize = true;
            this.lblCamZPos.Location = new System.Drawing.Point(217, 96);
            this.lblCamZPos.Name = "lblCamZPos";
            this.lblCamZPos.Size = new System.Drawing.Size(11, 13);
            this.lblCamZPos.TabIndex = 54;
            this.lblCamZPos.Text = "-";
            // 
            // lblCamZRot
            // 
            this.lblCamZRot.AutoSize = true;
            this.lblCamZRot.Location = new System.Drawing.Point(217, 250);
            this.lblCamZRot.Name = "lblCamZRot";
            this.lblCamZRot.Size = new System.Drawing.Size(11, 13);
            this.lblCamZRot.TabIndex = 57;
            this.lblCamZRot.Text = "-";
            // 
            // lblCamYRot
            // 
            this.lblCamYRot.AutoSize = true;
            this.lblCamYRot.Location = new System.Drawing.Point(179, 191);
            this.lblCamYRot.Name = "lblCamYRot";
            this.lblCamYRot.Size = new System.Drawing.Size(11, 13);
            this.lblCamYRot.TabIndex = 56;
            this.lblCamYRot.Text = "-";
            // 
            // lblCamXRot
            // 
            this.lblCamXRot.AutoSize = true;
            this.lblCamXRot.Location = new System.Drawing.Point(141, 191);
            this.lblCamXRot.Name = "lblCamXRot";
            this.lblCamXRot.Size = new System.Drawing.Size(11, 13);
            this.lblCamXRot.TabIndex = 55;
            this.lblCamXRot.Text = "-";
            // 
            // lblCamLocationTitle
            // 
            this.lblCamLocationTitle.AutoSize = true;
            this.lblCamLocationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamLocationTitle.Location = new System.Drawing.Point(8, 96);
            this.lblCamLocationTitle.Name = "lblCamLocationTitle";
            this.lblCamLocationTitle.Size = new System.Drawing.Size(106, 13);
            this.lblCamLocationTitle.TabIndex = 58;
            this.lblCamLocationTitle.Text = "Camera Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Camera Rotation:";
            // 
            // MainPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(1137, 562);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbScale);
            this.Controls.Add(this.gbRotate);
            this.Controls.Add(this.gbTranslate);
            this.Controls.Add(this.gbCamera);
            this.Controls.Add(this.gbShapes);
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
            this.gbShapes.ResumeLayout(false);
            this.gbShapes.PerformLayout();
            this.gbCamera.ResumeLayout(false);
            this.gbCamera.PerformLayout();
            this.gbTranslate.ResumeLayout(false);
            this.gbTranslate.PerformLayout();
            this.gbRotate.ResumeLayout(false);
            this.gbRotate.PerformLayout();
            this.gbScale.ResumeLayout(false);
            this.gbScale.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbShapes;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCamLocationTitle;
        private System.Windows.Forms.Label lblCamZRot;
        private System.Windows.Forms.Label lblCamYRot;
        private System.Windows.Forms.Label lblCamXRot;
        private System.Windows.Forms.Label lblCamZPos;
        private System.Windows.Forms.Label lblCamYPos;
        private System.Windows.Forms.Label lblCamXPos;
        private System.Windows.Forms.Label lblCamTitleZRot;
        private System.Windows.Forms.Label lblCamTitleYRot;
        private System.Windows.Forms.Label lblCamTitleXRot;
        private System.Windows.Forms.Label lblCamTitleZPos;
        private System.Windows.Forms.Label lblCamTitleYPos;
        private System.Windows.Forms.Label lblCamTitleXPos;
    }
}

