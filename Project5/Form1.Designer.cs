namespace Project5
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
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.showMeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transpositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCPos = new System.Windows.Forms.Label();
            this.labelCTarget = new System.Windows.Forms.Label();
            this.labelCUp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTz = new System.Windows.Forms.Label();
            this.labelTy = new System.Windows.Forms.Label();
            this.labelTx = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rotateCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(12, 41);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1040, 768);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMeshToolStripMenuItem,
            this.transpositionToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.rotateCameraToolStripMenuItem,
            this.cameraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1364, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showMeshToolStripMenuItem
            // 
            this.showMeshToolStripMenuItem.Name = "showMeshToolStripMenuItem";
            this.showMeshToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.showMeshToolStripMenuItem.Text = "Show Mesh";
            this.showMeshToolStripMenuItem.Click += new System.EventHandler(this.showMeshToolStripMenuItem_Click);
            // 
            // transpositionToolStripMenuItem
            // 
            this.transpositionToolStripMenuItem.Checked = true;
            this.transpositionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.transpositionToolStripMenuItem.Name = "transpositionToolStripMenuItem";
            this.transpositionToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.transpositionToolStripMenuItem.Text = "Transposition";
            this.transpositionToolStripMenuItem.Click += new System.EventHandler(this.transpositionToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.rotationToolStripMenuItem.Text = "Rotation";
            this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionToolStripMenuItem,
            this.cameraToolStripMenuItem1,
            this.upToolStripMenuItem});
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.cameraToolStripMenuItem.Text = "Camera";
            // 
            // positionToolStripMenuItem
            // 
            this.positionToolStripMenuItem.Name = "positionToolStripMenuItem";
            this.positionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.positionToolStripMenuItem.Text = "Position";
            this.positionToolStripMenuItem.Click += new System.EventHandler(this.positionToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem1
            // 
            this.cameraToolStripMenuItem1.Name = "cameraToolStripMenuItem1";
            this.cameraToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cameraToolStripMenuItem1.Text = "Traget";
            this.cameraToolStripMenuItem1.Click += new System.EventHandler(this.cameraToolStripMenuItem1_Click);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.upToolStripMenuItem.Text = "Up";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1058, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Camera coordinates:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1058, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "cPos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1058, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "cTarget";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1058, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "cUp";
            // 
            // labelCPos
            // 
            this.labelCPos.AutoSize = true;
            this.labelCPos.Location = new System.Drawing.Point(1108, 69);
            this.labelCPos.Name = "labelCPos";
            this.labelCPos.Size = new System.Drawing.Size(31, 13);
            this.labelCPos.TabIndex = 6;
            this.labelCPos.Text = "cPos";
            // 
            // labelCTarget
            // 
            this.labelCTarget.AutoSize = true;
            this.labelCTarget.Location = new System.Drawing.Point(1108, 92);
            this.labelCTarget.Name = "labelCTarget";
            this.labelCTarget.Size = new System.Drawing.Size(31, 13);
            this.labelCTarget.TabIndex = 7;
            this.labelCTarget.Text = "cPos";
            // 
            // labelCUp
            // 
            this.labelCUp.AutoSize = true;
            this.labelCUp.Location = new System.Drawing.Point(1108, 114);
            this.labelCUp.Name = "labelCUp";
            this.labelCUp.Size = new System.Drawing.Size(31, 13);
            this.labelCUp.TabIndex = 8;
            this.labelCUp.Text = "cPos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1058, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Transposition coordinates:";
            // 
            // labelTz
            // 
            this.labelTz.AutoSize = true;
            this.labelTz.Location = new System.Drawing.Point(1108, 220);
            this.labelTz.Name = "labelTz";
            this.labelTz.Size = new System.Drawing.Size(31, 13);
            this.labelTz.TabIndex = 15;
            this.labelTz.Text = "cPos";
            // 
            // labelTy
            // 
            this.labelTy.AutoSize = true;
            this.labelTy.Location = new System.Drawing.Point(1108, 198);
            this.labelTy.Name = "labelTy";
            this.labelTy.Size = new System.Drawing.Size(31, 13);
            this.labelTy.TabIndex = 14;
            this.labelTy.Text = "cPos";
            // 
            // labelTx
            // 
            this.labelTx.AutoSize = true;
            this.labelTx.Location = new System.Drawing.Point(1108, 175);
            this.labelTx.Name = "labelTx";
            this.labelTx.Size = new System.Drawing.Size(31, 13);
            this.labelTx.TabIndex = 13;
            this.labelTx.Text = "cPos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1058, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1058, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Ty";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1058, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Tx";
            // 
            // rotateCameraToolStripMenuItem
            // 
            this.rotateCameraToolStripMenuItem.Name = "rotateCameraToolStripMenuItem";
            this.rotateCameraToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.rotateCameraToolStripMenuItem.Text = "Rotate Camera";
            this.rotateCameraToolStripMenuItem.Click += new System.EventHandler(this.rotateCameraToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 821);
            this.Controls.Add(this.labelTz);
            this.Controls.Add(this.labelTy);
            this.Controls.Add(this.labelTx);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelCUp);
            this.Controls.Add(this.labelCTarget);
            this.Controls.Add(this.labelCPos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Canvas);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1380, 860);
            this.MinimumSize = new System.Drawing.Size(1380, 860);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transpositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMeshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCPos;
        private System.Windows.Forms.Label labelCTarget;
        private System.Windows.Forms.Label labelCUp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTz;
        private System.Windows.Forms.Label labelTy;
        private System.Windows.Forms.Label labelTx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem rotateCameraToolStripMenuItem;
    }
}

