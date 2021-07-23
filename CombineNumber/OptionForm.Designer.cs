
namespace CombineNumber
{
    partial class OptionForm
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
            this.hardBtn = new System.Windows.Forms.Button();
            this.normalBtn = new System.Windows.Forms.Button();
            this.easyBtn = new System.Windows.Forms.Button();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.describe = new System.Windows.Forms.Label();
            this.describeLabel = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hardBtn
            // 
            this.hardBtn.BackColor = System.Drawing.Color.White;
            this.hardBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hardBtn.Location = new System.Drawing.Point(502, 239);
            this.hardBtn.Name = "hardBtn";
            this.hardBtn.Size = new System.Drawing.Size(80, 30);
            this.hardBtn.TabIndex = 12;
            this.hardBtn.Text = "hard";
            this.hardBtn.UseVisualStyleBackColor = false;
            this.hardBtn.Click += new System.EventHandler(this.hardBtn_Click);
            // 
            // normalBtn
            // 
            this.normalBtn.BackColor = System.Drawing.Color.White;
            this.normalBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.normalBtn.Location = new System.Drawing.Point(416, 239);
            this.normalBtn.Name = "normalBtn";
            this.normalBtn.Size = new System.Drawing.Size(80, 30);
            this.normalBtn.TabIndex = 11;
            this.normalBtn.Text = "normal";
            this.normalBtn.UseVisualStyleBackColor = false;
            this.normalBtn.Click += new System.EventHandler(this.normalBtn_Click);
            // 
            // easyBtn
            // 
            this.easyBtn.BackColor = System.Drawing.Color.White;
            this.easyBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.easyBtn.Location = new System.Drawing.Point(330, 239);
            this.easyBtn.Name = "easyBtn";
            this.easyBtn.Size = new System.Drawing.Size(80, 30);
            this.easyBtn.TabIndex = 10;
            this.easyBtn.Text = "easy";
            this.easyBtn.UseVisualStyleBackColor = false;
            this.easyBtn.Click += new System.EventHandler(this.easyBtn_Click);
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerNameTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.playerNameTextBox.Location = new System.Drawing.Point(330, 292);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(248, 29);
            this.playerNameTextBox.TabIndex = 9;
            this.playerNameTextBox.TextChanged += new System.EventHandler(this.playerNameTextBox_TextChanged);
            // 
            // describe
            // 
            this.describe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.describe.AutoSize = true;
            this.describe.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.describe.Location = new System.Drawing.Point(203, 292);
            this.describe.Name = "describe";
            this.describe.Size = new System.Drawing.Size(104, 21);
            this.describe.TabIndex = 8;
            this.describe.Text = "player name";
            // 
            // describeLabel
            // 
            this.describeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.describeLabel.AutoSize = true;
            this.describeLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.describeLabel.Location = new System.Drawing.Point(231, 242);
            this.describeLabel.Name = "describeLabel";
            this.describeLabel.Size = new System.Drawing.Size(76, 21);
            this.describeLabel.TabIndex = 7;
            this.describeLabel.Text = "difficulty";
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(60, 30);
            this.backBtn.TabIndex = 18;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.hardBtn);
            this.Controls.Add(this.normalBtn);
            this.Controls.Add(this.easyBtn);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.describe);
            this.Controls.Add(this.describeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CombineNumber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hardBtn;
        private System.Windows.Forms.Button normalBtn;
        private System.Windows.Forms.Button easyBtn;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Label describe;
        private System.Windows.Forms.Label describeLabel;
        private System.Windows.Forms.Button backBtn;
    }
}