namespace DistIdProvider
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nextInArray = new System.Windows.Forms.Button();
            this.backInArray = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.firstInArray = new System.Windows.Forms.Button();
            this.lastInArray = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // nextInArray
            // 
            this.nextInArray.Location = new System.Drawing.Point(185, 25);
            this.nextInArray.Name = "nextInArray";
            this.nextInArray.Size = new System.Drawing.Size(34, 25);
            this.nextInArray.TabIndex = 1;
            this.nextInArray.Text = ">";
            this.nextInArray.UseVisualStyleBackColor = true;
            this.nextInArray.Click += new System.EventHandler(this.backInArray_Click);
            // 
            // backInArray
            // 
            this.backInArray.Location = new System.Drawing.Point(149, 25);
            this.backInArray.Name = "backInArray";
            this.backInArray.Size = new System.Drawing.Size(34, 25);
            this.backInArray.TabIndex = 2;
            this.backInArray.Text = "<";
            this.backInArray.UseVisualStyleBackColor = true;
            this.backInArray.Click += new System.EventHandler(this.nextInArray_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(245, 60);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Help";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // firstInArray
            // 
            this.firstInArray.Location = new System.Drawing.Point(114, 25);
            this.firstInArray.Name = "firstInArray";
            this.firstInArray.Size = new System.Drawing.Size(29, 25);
            this.firstInArray.TabIndex = 4;
            this.firstInArray.Text = "|<";
            this.firstInArray.UseVisualStyleBackColor = true;
            this.firstInArray.Click += new System.EventHandler(this.firstInArray_Click);
            // 
            // lastInArray
            // 
            this.lastInArray.Location = new System.Drawing.Point(225, 25);
            this.lastInArray.Name = "lastInArray";
            this.lastInArray.Size = new System.Drawing.Size(29, 25);
            this.lastInArray.TabIndex = 5;
            this.lastInArray.Text = ">|";
            this.lastInArray.UseVisualStyleBackColor = true;
            this.lastInArray.Click += new System.EventHandler(this.lastInArray_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 86);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastInArray);
            this.Controls.Add(this.firstInArray);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.backInArray);
            this.Controls.Add(this.nextInArray);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "DistId Provider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextInArray;
        private System.Windows.Forms.Button backInArray;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button firstInArray;
        private System.Windows.Forms.Button lastInArray;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

