namespace Darker.UI.Persistance
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
            this.box_message = new System.Windows.Forms.RichTextBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // box_message
            // 
            this.box_message.Location = new System.Drawing.Point(12, 12);
            this.box_message.Name = "box_message";
            this.box_message.Size = new System.Drawing.Size(968, 508);
            this.box_message.TabIndex = 0;
            this.box_message.Text = "";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(12, 526);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(295, 41);
            this.btn_load.TabIndex = 1;
            this.btn_load.Text = "LOAD";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(685, 526);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(295, 41);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(365, 540);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(0, 13);
            this.label_status.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 579);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.box_message);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox box_message;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label_status;
    }
}

