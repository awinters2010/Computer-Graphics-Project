namespace Graphics
{
    partial class Form1
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
            this.dFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cylinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sixSidesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNotificationArea = new System.Windows.Forms.TextBox();
            this.lblMemoryUsage = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.gbMemUsage = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plNotArea = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNotArea = new System.Windows.Forms.Label();
            this.tcRight = new System.Windows.Forms.TabControl();
            this.tpRight1 = new System.Windows.Forms.TabPage();
            this.tpRight2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.gbMemUsage.SuspendLayout();
            this.plNotArea.SuspendLayout();
            this.tcRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 62);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(206, 23);
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
            this.dFormToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // dFormToolStripMenuItem
            // 
            this.dFormToolStripMenuItem.Name = "dFormToolStripMenuItem";
            this.dFormToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.dFormToolStripMenuItem.Text = "3D Form";
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cubeToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.cylinderToolStripMenuItem,
            this.sixSidesToolStripMenuItem});
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            this.shapesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.shapesToolStripMenuItem.Text = "Shapes";
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cubeToolStripMenuItem.Text = "Cube";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.cubeToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // cylinderToolStripMenuItem
            // 
            this.cylinderToolStripMenuItem.Name = "cylinderToolStripMenuItem";
            this.cylinderToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.cylinderToolStripMenuItem.Text = "Cylinder";
            // 
            // sixSidesToolStripMenuItem
            // 
            this.sixSidesToolStripMenuItem.Name = "sixSidesToolStripMenuItem";
            this.sixSidesToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.sixSidesToolStripMenuItem.Text = "six sides";
            this.sixSidesToolStripMenuItem.Click += new System.EventHandler(this.sixSidesToolStripMenuItem_Click);
            // 
            // txtNotificationArea
            // 
            this.txtNotificationArea.Enabled = false;
            this.txtNotificationArea.Location = new System.Drawing.Point(215, 16);
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
            this.gbMemUsage.Size = new System.Drawing.Size(206, 40);
            this.gbMemUsage.TabIndex = 9;
            this.gbMemUsage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(215, 27);
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
            this.plNotArea.Controls.Add(this.txtNotificationArea);
            this.plNotArea.Location = new System.Drawing.Point(0, 467);
            this.plNotArea.Name = "plNotArea";
            this.plNotArea.Size = new System.Drawing.Size(838, 95);
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
            this.lblNotArea.Location = new System.Drawing.Point(212, 0);
            this.lblNotArea.Name = "lblNotArea";
            this.lblNotArea.Size = new System.Drawing.Size(102, 13);
            this.lblNotArea.TabIndex = 12;
            this.lblNotArea.Text = "Notification Area";
            // 
            // tcRight
            // 
            this.tcRight.Controls.Add(this.tpRight1);
            this.tcRight.Controls.Add(this.tpRight2);
            this.tcRight.Location = new System.Drawing.Point(844, 27);
            this.tcRight.Name = "tcRight";
            this.tcRight.SelectedIndex = 0;
            this.tcRight.Size = new System.Drawing.Size(281, 525);
            this.tcRight.TabIndex = 11;
            // 
            // tpRight1
            // 
            this.tpRight1.Location = new System.Drawing.Point(4, 22);
            this.tpRight1.Name = "tpRight1";
            this.tpRight1.Padding = new System.Windows.Forms.Padding(3);
            this.tpRight1.Size = new System.Drawing.Size(273, 499);
            this.tpRight1.TabIndex = 0;
            this.tpRight1.Text = "Tab 1";
            this.tpRight1.UseVisualStyleBackColor = true;
            // 
            // tpRight2
            // 
            this.tpRight2.Location = new System.Drawing.Point(4, 22);
            this.tpRight2.Name = "tpRight2";
            this.tpRight2.Padding = new System.Windows.Forms.Padding(3);
            this.tpRight2.Size = new System.Drawing.Size(273, 499);
            this.tpRight2.TabIndex = 1;
            this.tpRight2.Text = "Tab 2";
            this.tpRight2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(162)))));
            this.ClientSize = new System.Drawing.Size(1137, 562);
            this.Controls.Add(this.tcRight);
            this.Controls.Add(this.plNotArea);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbMemUsage.ResumeLayout(false);
            this.gbMemUsage.PerformLayout();
            this.plNotArea.ResumeLayout(false);
            this.plNotArea.PerformLayout();
            this.tcRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFormToolStripMenuItem;
        private System.Windows.Forms.TextBox txtNotificationArea;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cylinderToolStripMenuItem;
        private System.Windows.Forms.Label lblMemoryUsage;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.ToolStripMenuItem sixSidesToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbMemUsage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plNotArea;
        private System.Windows.Forms.TabControl tcRight;
        private System.Windows.Forms.TabPage tpRight1;
        private System.Windows.Forms.TabPage tpRight2;
        private System.Windows.Forms.Label lblNotArea;
        private System.Windows.Forms.Label label1;
    }
}

