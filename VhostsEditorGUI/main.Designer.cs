﻿namespace VhostsEditorGUI
{
    partial class main
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
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.ResetApache = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vhostsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(323, 44);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(83, 23);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(323, 73);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(83, 23);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(323, 102);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(83, 23);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            //this.Delete.Click += new System.EventHandler(this.Delete_Click_1);
            // 
            // ResetApache
            // 
            this.ResetApache.Location = new System.Drawing.Point(323, 151);
            this.ResetApache.Name = "ResetApache";
            this.ResetApache.Size = new System.Drawing.Size(83, 23);
            this.ResetApache.TabIndex = 3;
            this.ResetApache.Text = "ResetApache";
            this.ResetApache.UseVisualStyleBackColor = true;
            this.ResetApache.Click += new System.EventHandler(this.ResetApache_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // vhostsListBox
            // 
            this.vhostsListBox.FormattingEnabled = true;
            this.vhostsListBox.Location = new System.Drawing.Point(12, 40);
            this.vhostsListBox.Name = "vhostsListBox";
            this.vhostsListBox.Size = new System.Drawing.Size(284, 134);
            this.vhostsListBox.TabIndex = 4;
            this.vhostsListBox.SelectedIndexChanged += new System.EventHandler(this.vhostsListBox_SelectedIndexChanged);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 196);
            this.Controls.Add(this.vhostsListBox);
            this.Controls.Add(this.ResetApache);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Add);
            this.Name = "main";
            this.Text = "VhostsEditor 0.1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button ResetApache;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListBox vhostsListBox;
    }
}

