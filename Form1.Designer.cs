﻿namespace MaMut_Inactive_User_Filter {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MainSelectFile = new System.Windows.Forms.Button();
            this.SecondSelectFile = new System.Windows.Forms.Button();
            this.MainFileName = new System.Windows.Forms.TextBox();
            this.SecondFileName = new System.Windows.Forms.TextBox();
            this.DeleteSelect = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.MainComparePoint = new System.Windows.Forms.ComboBox();
            this.SecondComparePoint = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EndProgram = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.WinFormRemoveButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main CSV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fjern fra CSV Data";
            // 
            // MainSelectFile
            // 
            this.MainSelectFile.Location = new System.Drawing.Point(12, 25);
            this.MainSelectFile.Name = "MainSelectFile";
            this.MainSelectFile.Size = new System.Drawing.Size(102, 23);
            this.MainSelectFile.TabIndex = 2;
            this.MainSelectFile.Text = "Select File";
            this.MainSelectFile.UseVisualStyleBackColor = true;
            this.MainSelectFile.Click += new System.EventHandler(this.MainSelectFile_Click);
            // 
            // SecondSelectFile
            // 
            this.SecondSelectFile.Location = new System.Drawing.Point(193, 25);
            this.SecondSelectFile.Name = "SecondSelectFile";
            this.SecondSelectFile.Size = new System.Drawing.Size(102, 23);
            this.SecondSelectFile.TabIndex = 3;
            this.SecondSelectFile.Text = "Select File";
            this.SecondSelectFile.UseVisualStyleBackColor = true;
            this.SecondSelectFile.Click += new System.EventHandler(this.SecondSelectFile_Click);
            // 
            // MainFileName
            // 
            this.MainFileName.BackColor = System.Drawing.SystemColors.Window;
            this.MainFileName.Location = new System.Drawing.Point(12, 54);
            this.MainFileName.Name = "MainFileName";
            this.MainFileName.ReadOnly = true;
            this.MainFileName.Size = new System.Drawing.Size(175, 20);
            this.MainFileName.TabIndex = 4;
            // 
            // SecondFileName
            // 
            this.SecondFileName.BackColor = System.Drawing.SystemColors.Window;
            this.SecondFileName.Location = new System.Drawing.Point(193, 54);
            this.SecondFileName.Name = "SecondFileName";
            this.SecondFileName.ReadOnly = true;
            this.SecondFileName.Size = new System.Drawing.Size(175, 20);
            this.SecondFileName.TabIndex = 5;
            // 
            // DeleteSelect
            // 
            this.DeleteSelect.Enabled = false;
            this.DeleteSelect.Location = new System.Drawing.Point(12, 120);
            this.DeleteSelect.Name = "DeleteSelect";
            this.DeleteSelect.Size = new System.Drawing.Size(102, 23);
            this.DeleteSelect.TabIndex = 9;
            this.DeleteSelect.Text = "Delete Select";
            this.DeleteSelect.UseVisualStyleBackColor = true;
            this.DeleteSelect.Click += new System.EventHandler(this.DeleteSelect_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainComparePoint
            // 
            this.MainComparePoint.FormattingEnabled = true;
            this.MainComparePoint.Location = new System.Drawing.Point(12, 93);
            this.MainComparePoint.Name = "MainComparePoint";
            this.MainComparePoint.Size = new System.Drawing.Size(175, 21);
            this.MainComparePoint.TabIndex = 10;
            // 
            // SecondComparePoint
            // 
            this.SecondComparePoint.FormattingEnabled = true;
            this.SecondComparePoint.Location = new System.Drawing.Point(193, 93);
            this.SecondComparePoint.Name = "SecondComparePoint";
            this.SecondComparePoint.Size = new System.Drawing.Size(175, 21);
            this.SecondComparePoint.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Main Compare Point";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Compare Point";
            // 
            // EndProgram
            // 
            this.EndProgram.Location = new System.Drawing.Point(266, 178);
            this.EndProgram.Name = "EndProgram";
            this.EndProgram.Size = new System.Drawing.Size(102, 23);
            this.EndProgram.TabIndex = 16;
            this.EndProgram.Text = "Luk Program";
            this.EndProgram.UseVisualStyleBackColor = true;
            this.EndProgram.Click += new System.EventHandler(this.EndProgram_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 149);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(356, 23);
            this.progressBar1.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Progress";
            // 
            // WinFormRemoveButton
            // 
            this.WinFormRemoveButton.Location = new System.Drawing.Point(15, 178);
            this.WinFormRemoveButton.Name = "WinFormRemoveButton";
            this.WinFormRemoveButton.Size = new System.Drawing.Size(102, 23);
            this.WinFormRemoveButton.TabIndex = 21;
            this.WinFormRemoveButton.Text = "Remover";
            this.WinFormRemoveButton.UseVisualStyleBackColor = true;
            this.WinFormRemoveButton.Click += new System.EventHandler(this.WinFormRemoveButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(229, 120);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 217);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.WinFormRemoveButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.EndProgram);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SecondComparePoint);
            this.Controls.Add(this.MainComparePoint);
            this.Controls.Add(this.DeleteSelect);
            this.Controls.Add(this.SecondFileName);
            this.Controls.Add(this.MainFileName);
            this.Controls.Add(this.SecondSelectFile);
            this.Controls.Add(this.MainSelectFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "CSV Multi Function Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MainSelectFile;
        private System.Windows.Forms.Button SecondSelectFile;
        private System.Windows.Forms.TextBox MainFileName;
        private System.Windows.Forms.TextBox SecondFileName;
        private System.Windows.Forms.Button DeleteSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox MainComparePoint;
        private System.Windows.Forms.ComboBox SecondComparePoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button EndProgram;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button WinFormRemoveButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}