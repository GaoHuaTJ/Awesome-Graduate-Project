namespace 毕业设计
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.运行图生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行图会长ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行图生成ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 运行图生成ToolStripMenuItem
            // 
            this.运行图生成ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.运行图会长ToolStripMenuItem});
            this.运行图生成ToolStripMenuItem.Name = "运行图生成ToolStripMenuItem";
            this.运行图生成ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.运行图生成ToolStripMenuItem.Text = "运行图生成";
            // 
            // 运行图会长ToolStripMenuItem
            // 
            this.运行图会长ToolStripMenuItem.Name = "运行图会长ToolStripMenuItem";
            this.运行图会长ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.运行图会长ToolStripMenuItem.Text = "运行图绘制";
            this.运行图会长ToolStripMenuItem.Click += new System.EventHandler(this.运行图绘制ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 运行图生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行图会长ToolStripMenuItem;
    }
}