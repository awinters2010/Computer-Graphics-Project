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
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNotificationArea = new System.Windows.Forms.TextBox();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.gbMemUsage = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plNotArea = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNotArea = new System.Windows.Forms.Label();
            this.gbShapes = new System.Windows.Forms.GroupBox();
            this.btnDeleteShape = new System.Windows.Forms.Button();
            this.lblSS2 = new System.Windows.Forms.Label();
            this.lblSS1 = new System.Windows.Forms.Label();
            this.lblSCnt2 = new System.Windows.Forms.Label();
            this.lblSCnt1 = new System.Windows.Forms.Label();
            this.cboShapeList = new System.Windows.Forms.ComboBox();
            this.lblDes1 = new System.Windows.Forms.Label();
            this.btnTransR = new System.Windows.Forms.Button();
            this.btnTransD = new System.Windows.Forms.Button();
            this.btnTransU = new System.Windows.Forms.Button();
            this.btnTransL = new System.Windows.Forms.Button();
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TransB = new System.Windows.Forms.Button();
            this.TransF = new System.Windows.Forms.Button();
            this.gbRotate = new System.Windows.Forms.GroupBox();
            this.xRotation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbScale = new System.Windows.Forms.GroupBox();
            this.xScaling = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ofdMesh = new System.Windows.Forms.OpenFileDialog();
            this.btnClearScene = new System.Windows.Forms.Button();
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
            this.miLoadMesh});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miLoadMesh
            // 
            this.miLoadMesh.Name = "miLoadMesh";
            this.miLoadMesh.Size = new System.Drawing.Size(132, 22);
            this.miLoadMesh.Text = "Load Mesh";
            this.miLoadMesh.Click += new System.EventHandler(this.miLoadMesh_Click);
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
            // txtNotificationArea
            // 
            this.txtNotificationArea.Enabled = false;
            this.txtNotificationArea.Location = new System.Drawing.Point(258, 17);
            this.txtNotificationArea.Multiline = true;
            this.txtNotificationArea.Name = "txtNotificationArea";
            this.txtNotificationArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotificationArea.Size = new System.Drawing.Size(620, 69);
            this.txtNotificationArea.TabIndex = 0;
            this.txtNotificationArea.TabStop = false;
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
            this.panel1.Size = new System.Drawing.Size(624, 433);
            this.panel1.TabIndex = 6;
            // 
            // plNotArea
            // 
            this.plNotArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.plNotArea.Controls.Add(this.label1);
            this.plNotArea.Controls.Add(this.lblNotArea);
            this.plNotArea.Controls.Add(this.gbMemUsage);
            this.plNotArea.Controls.Add(this.progressBar1);
            this.plNotArea.Controls.Add(this.txtNotificationArea);
            this.plNotArea.Location = new System.Drawing.Point(0, 467);
            this.plNotArea.Name = "plNotArea";
            this.plNotArea.Size = new System.Drawing.Size(881, 95);
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
            // lblNotArea
            // 
            this.lblNotArea.AutoSize = true;
            this.lblNotArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotArea.Location = new System.Drawing.Point(255, 1);
            this.lblNotArea.Name = "lblNotArea";
            this.lblNotArea.Size = new System.Drawing.Size(102, 13);
            this.lblNotArea.TabIndex = 12;
            this.lblNotArea.Text = "Notification Area";
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
            this.gbShapes.Size = new System.Drawing.Size(246, 142);
            this.gbShapes.TabIndex = 11;
            this.gbShapes.TabStop = false;
            this.gbShapes.Text = "Shapes";
            // 
            // btnDeleteShape
            // 
            this.btnDeleteShape.Location = new System.Drawing.Point(6, 101);
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
            this.lblSS2.Location = new System.Drawing.Point(113, 77);
            this.lblSS2.Name = "lblSS2";
            this.lblSS2.Size = new System.Drawing.Size(43, 13);
            this.lblSS2.TabIndex = 5;
            this.lblSS2.Text = "<none>";
            // 
            // lblSS1
            // 
            this.lblSS1.AutoSize = true;
            this.lblSS1.Location = new System.Drawing.Point(6, 77);
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
            // btnTransR
            // 
            this.btnTransR.Location = new System.Drawing.Point(167, 66);
            this.btnTransR.Name = "btnTransR";
            this.btnTransR.Size = new System.Drawing.Size(75, 23);
            this.btnTransR.TabIndex = 13;
            this.btnTransR.Text = "Right";
            this.btnTransR.UseVisualStyleBackColor = true;
            this.btnTransR.Click += new System.EventHandler(this.btnTransR_Click);
            // 
            // btnTransD
            // 
            this.btnTransD.Location = new System.Drawing.Point(86, 84);
            this.btnTransD.Name = "btnTransD";
            this.btnTransD.Size = new System.Drawing.Size(75, 23);
            this.btnTransD.TabIndex = 12;
            this.btnTransD.Text = "Down";
            this.btnTransD.UseVisualStyleBackColor = true;
            this.btnTransD.Click += new System.EventHandler(this.btnTransD_Click);
            // 
            // btnTransU
            // 
            this.btnTransU.Location = new System.Drawing.Point(86, 55);
            this.btnTransU.Name = "btnTransU";
            this.btnTransU.Size = new System.Drawing.Size(75, 23);
            this.btnTransU.TabIndex = 11;
            this.btnTransU.Text = "Up";
            this.btnTransU.UseVisualStyleBackColor = true;
            this.btnTransU.Click += new System.EventHandler(this.btnTransU_Click);
            // 
            // btnTransL
            // 
            this.btnTransL.Location = new System.Drawing.Point(5, 66);
            this.btnTransL.Name = "btnTransL";
            this.btnTransL.Size = new System.Drawing.Size(75, 23);
            this.btnTransL.TabIndex = 10;
            this.btnTransL.Text = "Left";
            this.btnTransL.UseVisualStyleBackColor = true;
            this.btnTransL.Click += new System.EventHandler(this.btnTransL_Click);
            // 
            // btnCamR
            // 
            this.btnCamR.Location = new System.Drawing.Point(168, 46);
            this.btnCamR.Name = "btnCamR";
            this.btnCamR.Size = new System.Drawing.Size(75, 23);
            this.btnCamR.TabIndex = 17;
            this.btnCamR.Text = "Right";
            this.btnCamR.UseVisualStyleBackColor = true;
            this.btnCamR.Click += new System.EventHandler(this.btnCamR_Click);
            // 
            // btnCamD
            // 
            this.btnCamD.Location = new System.Drawing.Point(87, 64);
            this.btnCamD.Name = "btnCamD";
            this.btnCamD.Size = new System.Drawing.Size(75, 23);
            this.btnCamD.TabIndex = 16;
            this.btnCamD.Text = "Down";
            this.btnCamD.UseVisualStyleBackColor = true;
            this.btnCamD.Click += new System.EventHandler(this.btnCamD_Click);
            // 
            // btnCamU
            // 
            this.btnCamU.Location = new System.Drawing.Point(87, 35);
            this.btnCamU.Name = "btnCamU";
            this.btnCamU.Size = new System.Drawing.Size(75, 23);
            this.btnCamU.TabIndex = 15;
            this.btnCamU.Text = "Up";
            this.btnCamU.UseVisualStyleBackColor = true;
            this.btnCamU.Click += new System.EventHandler(this.btnCamU_Click);
            // 
            // btnCamL
            // 
            this.btnCamL.Location = new System.Drawing.Point(6, 46);
            this.btnCamL.Name = "btnCamL";
            this.btnCamL.Size = new System.Drawing.Size(75, 23);
            this.btnCamL.TabIndex = 14;
            this.btnCamL.Text = "Left";
            this.btnCamL.UseVisualStyleBackColor = true;
            this.btnCamL.Click += new System.EventHandler(this.btnCamL_Click);
            // 
            // gbCamera
            // 
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
            this.gbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCamera.Location = new System.Drawing.Point(6, 28);
            this.gbCamera.Name = "gbCamera";
            this.gbCamera.Size = new System.Drawing.Size(249, 202);
            this.gbCamera.TabIndex = 18;
            this.gbCamera.TabStop = false;
            this.gbCamera.Text = "Camera Functions";
            // 
            // btnRCamL
            // 
            this.btnRCamL.Location = new System.Drawing.Point(6, 139);
            this.btnRCamL.Name = "btnRCamL";
            this.btnRCamL.Size = new System.Drawing.Size(75, 23);
            this.btnRCamL.TabIndex = 23;
            this.btnRCamL.Text = "Left";
            this.btnRCamL.UseVisualStyleBackColor = true;
            this.btnRCamL.Click += new System.EventHandler(this.btnRCamL_Click);
            // 
            // btnRCamR
            // 
            this.btnRCamR.Location = new System.Drawing.Point(168, 139);
            this.btnRCamR.Name = "btnRCamR";
            this.btnRCamR.Size = new System.Drawing.Size(75, 23);
            this.btnRCamR.TabIndex = 26;
            this.btnRCamR.Text = "Right";
            this.btnRCamR.UseVisualStyleBackColor = true;
            this.btnRCamR.Click += new System.EventHandler(this.btnRCamR_Click);
            // 
            // btnRCamU
            // 
            this.btnRCamU.Location = new System.Drawing.Point(87, 128);
            this.btnRCamU.Name = "btnRCamU";
            this.btnRCamU.Size = new System.Drawing.Size(75, 23);
            this.btnRCamU.TabIndex = 24;
            this.btnRCamU.Text = "Up";
            this.btnRCamU.UseVisualStyleBackColor = true;
            this.btnRCamU.Click += new System.EventHandler(this.btnRCamU_Click);
            // 
            // btnRCamD
            // 
            this.btnRCamD.Location = new System.Drawing.Point(87, 157);
            this.btnRCamD.Name = "btnRCamD";
            this.btnRCamD.Size = new System.Drawing.Size(75, 23);
            this.btnRCamD.TabIndex = 25;
            this.btnRCamD.Text = "Down";
            this.btnRCamD.UseVisualStyleBackColor = true;
            this.btnRCamD.Click += new System.EventHandler(this.btnRCamD_Click);
            // 
            // CamB
            // 
            this.CamB.Location = new System.Drawing.Point(6, 75);
            this.CamB.Name = "CamB";
            this.CamB.Size = new System.Drawing.Size(75, 23);
            this.CamB.TabIndex = 22;
            this.CamB.Text = "Back";
            this.CamB.UseVisualStyleBackColor = true;
            this.CamB.Click += new System.EventHandler(this.CamB_Click);
            // 
            // CamF
            // 
            this.CamF.Location = new System.Drawing.Point(168, 75);
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
            this.lblCam2.Location = new System.Drawing.Point(8, 118);
            this.lblCam2.Name = "lblCam2";
            this.lblCam2.Size = new System.Drawing.Size(45, 13);
            this.lblCam2.TabIndex = 20;
            this.lblCam2.Text = "Rotate";
            // 
            // lblCam1
            // 
            this.lblCam1.AutoSize = true;
            this.lblCam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam1.Location = new System.Drawing.Point(3, 30);
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
            this.gbTranslate.Controls.Add(this.label6);
            this.gbTranslate.Controls.Add(this.label4);
            this.gbTranslate.Controls.Add(this.label2);
            this.gbTranslate.Controls.Add(this.TransB);
            this.gbTranslate.Controls.Add(this.btnTransR);
            this.gbTranslate.Controls.Add(this.TransF);
            this.gbTranslate.Controls.Add(this.btnTransL);
            this.gbTranslate.Controls.Add(this.btnTransU);
            this.gbTranslate.Controls.Add(this.btnTransD);
            this.gbTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTranslate.Location = new System.Drawing.Point(887, 174);
            this.gbTranslate.Name = "gbTranslate";
            this.gbTranslate.Size = new System.Drawing.Size(246, 122);
            this.gbTranslate.TabIndex = 19;
            this.gbTranslate.TabStop = false;
            this.gbTranslate.Text = "Translate";
            // 
            // zTranslation
            // 
            this.zTranslation.Location = new System.Drawing.Point(185, 13);
            this.zTranslation.Name = "zTranslation";
            this.zTranslation.Size = new System.Drawing.Size(51, 20);
            this.zTranslation.TabIndex = 32;
            this.zTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zTranslation_KeyDown);
            // 
            // yTranslation
            // 
            this.yTranslation.Location = new System.Drawing.Point(100, 14);
            this.yTranslation.Name = "yTranslation";
            this.yTranslation.Size = new System.Drawing.Size(51, 20);
            this.yTranslation.TabIndex = 31;
            this.yTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.yTranslation_KeyDown);
            // 
            // xTranslation
            // 
            this.xTranslation.Location = new System.Drawing.Point(29, 13);
            this.xTranslation.Name = "xTranslation";
            this.xTranslation.Size = new System.Drawing.Size(51, 20);
            this.xTranslation.TabIndex = 30;
            this.xTranslation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xTranslation_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(164, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(83, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "X";
            // 
            // TransB
            // 
            this.TransB.Location = new System.Drawing.Point(5, 95);
            this.TransB.Name = "TransB";
            this.TransB.Size = new System.Drawing.Size(75, 23);
            this.TransB.TabIndex = 24;
            this.TransB.Text = "Back";
            this.TransB.UseVisualStyleBackColor = true;
            this.TransB.Click += new System.EventHandler(this.TransB_Click);
            // 
            // TransF
            // 
            this.TransF.Location = new System.Drawing.Point(167, 95);
            this.TransF.Name = "TransF";
            this.TransF.Size = new System.Drawing.Size(75, 23);
            this.TransF.TabIndex = 23;
            this.TransF.Text = "Forward";
            this.TransF.UseVisualStyleBackColor = true;
            this.TransF.Click += new System.EventHandler(this.TransF_Click);
            // 
            // gbRotate
            // 
            this.gbRotate.Controls.Add(this.xRotation);
            this.gbRotate.Controls.Add(this.label3);
            this.gbRotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRotate.Location = new System.Drawing.Point(887, 302);
            this.gbRotate.Name = "gbRotate";
            this.gbRotate.Size = new System.Drawing.Size(246, 122);
            this.gbRotate.TabIndex = 20;
            this.gbRotate.TabStop = false;
            this.gbRotate.Text = "Rotate";
            // 
            // xRotation
            // 
            this.xRotation.Location = new System.Drawing.Point(29, 20);
            this.xRotation.Name = "xRotation";
            this.xRotation.Size = new System.Drawing.Size(51, 20);
            this.xRotation.TabIndex = 33;
            this.xRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xRotation_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "X";
            // 
            // gbScale
            // 
            this.gbScale.Controls.Add(this.xScaling);
            this.gbScale.Controls.Add(this.label5);
            this.gbScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbScale.Location = new System.Drawing.Point(887, 430);
            this.gbScale.Name = "gbScale";
            this.gbScale.Size = new System.Drawing.Size(246, 122);
            this.gbScale.TabIndex = 20;
            this.gbScale.TabStop = false;
            this.gbScale.Text = "Scale";
            // 
            // xScaling
            // 
            this.xScaling.Location = new System.Drawing.Point(28, 21);
            this.xScaling.Name = "xScaling";
            this.xScaling.Size = new System.Drawing.Size(51, 20);
            this.xScaling.TabIndex = 34;
            this.xScaling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xScaling_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(7, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "X";
            // 
            // ofdMesh
            // 
            this.ofdMesh.Filter = "|*.x;";
            this.ofdMesh.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdMesh_FileOk);
            // 
            // btnClearScene
            // 
            this.btnClearScene.Location = new System.Drawing.Point(116, 101);
            this.btnClearScene.Name = "btnClearScene";
            this.btnClearScene.Size = new System.Drawing.Size(108, 23);
            this.btnClearScene.TabIndex = 9;
            this.btnClearScene.Text = "Clear Scene";
            this.btnClearScene.UseVisualStyleBackColor = true;
            this.btnClearScene.Click += new System.EventHandler(this.btnClearScene_Click);
            // 
            // MainPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(1137, 562);
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
        private System.Windows.Forms.TextBox txtNotificationArea;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.Label lblMemoryUsage;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.GroupBox gbMemUsage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plNotArea;
        private System.Windows.Forms.Label lblNotArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbShapes;
        private System.Windows.Forms.ComboBox cboShapeList;
        private System.Windows.Forms.Label lblDes1;
        private System.Windows.Forms.Label lblSCnt2;
        private System.Windows.Forms.Label lblSCnt1;
        private System.Windows.Forms.Label lblSS2;
        private System.Windows.Forms.Label lblSS1;
        private System.Windows.Forms.Button btnDeleteShape;
        private System.Windows.Forms.Button btnTransR;
        private System.Windows.Forms.Button btnTransD;
        private System.Windows.Forms.Button btnTransU;
        private System.Windows.Forms.Button btnTransL;
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
        private System.Windows.Forms.Button TransB;
        private System.Windows.Forms.Button TransF;
        private System.Windows.Forms.ToolStripMenuItem miLoadMesh;
        private System.Windows.Forms.OpenFileDialog ofdMesh;
        private System.Windows.Forms.Button btnRCamL;
        private System.Windows.Forms.Button btnRCamR;
        private System.Windows.Forms.Button btnRCamU;
        private System.Windows.Forms.Button btnRCamD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox zTranslation;
        private System.Windows.Forms.TextBox yTranslation;
        private System.Windows.Forms.TextBox xTranslation;
        private System.Windows.Forms.TextBox xRotation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xScaling;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClearScene;
    }
}

