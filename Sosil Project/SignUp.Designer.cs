namespace Sosil_Project
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPw = new System.Windows.Forms.Label();
            this.lblPwCheck = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPw = new System.Windows.Forms.TextBox();
            this.txtPwCheck = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblID.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblID.Location = new System.Drawing.Point(37, 24);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(62, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "아이디 :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(52, 57);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "이름 :";
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new System.Drawing.Point(52, 90);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(47, 15);
            this.lblPw.TabIndex = 2;
            this.lblPw.Text = "암호 :";
            // 
            // lblPwCheck
            // 
            this.lblPwCheck.AutoSize = true;
            this.lblPwCheck.Location = new System.Drawing.Point(17, 123);
            this.lblPwCheck.Name = "lblPwCheck";
            this.lblPwCheck.Size = new System.Drawing.Size(82, 15);
            this.lblPwCheck.TabIndex = 3;
            this.lblPwCheck.Text = "암호 확인 :";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("굴림", 10F);
            this.txtId.Location = new System.Drawing.Point(105, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(162, 27);
            this.txtId.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("굴림", 10F);
            this.txtName.Location = new System.Drawing.Point(105, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 27);
            this.txtName.TabIndex = 5;
            // 
            // txtPw
            // 
            this.txtPw.Font = new System.Drawing.Font("굴림", 10F);
            this.txtPw.Location = new System.Drawing.Point(105, 85);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(162, 27);
            this.txtPw.TabIndex = 6;
            // 
            // txtPwCheck
            // 
            this.txtPwCheck.Font = new System.Drawing.Font("굴림", 10F);
            this.txtPwCheck.Location = new System.Drawing.Point(105, 118);
            this.txtPwCheck.Name = "txtPwCheck";
            this.txtPwCheck.Size = new System.Drawing.Size(162, 27);
            this.txtPwCheck.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 10F);
            this.button1.Location = new System.Drawing.Point(211, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "회원가입";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 279);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPwCheck);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblPwCheck);
            this.Controls.Add(this.lblPw);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignUp";
            this.Text = "회원가입";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.Label lblPwCheck;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPw;
        private System.Windows.Forms.TextBox txtPwCheck;
        private System.Windows.Forms.Button button1;
    }
}