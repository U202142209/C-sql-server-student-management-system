
namespace scms
{
    partial class LoginWindom
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.radioButtonStudent = new System.Windows.Forms.RadioButton();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.linkLabelIntroduction = new System.Windows.Forms.LinkLabel();
            this.linkLabelForgetPwd = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(224, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("宋体", 11F);
            this.textBoxUsername.Location = new System.Drawing.Point(334, 118);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(309, 28);
            this.textBoxUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.Location = new System.Drawing.Point(224, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Font = new System.Drawing.Font("宋体", 11F);
            this.textBoxPwd.Location = new System.Drawing.Point(334, 175);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.PasswordChar = '*';
            this.textBoxPwd.Size = new System.Drawing.Size(309, 28);
            this.textBoxPwd.TabIndex = 4;
            // 
            // radioButtonStudent
            // 
            this.radioButtonStudent.AutoSize = true;
            this.radioButtonStudent.Checked = true;
            this.radioButtonStudent.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButtonStudent.Location = new System.Drawing.Point(312, 234);
            this.radioButtonStudent.Name = "radioButtonStudent";
            this.radioButtonStudent.Size = new System.Drawing.Size(110, 24);
            this.radioButtonStudent.TabIndex = 5;
            this.radioButtonStudent.TabStop = true;
            this.radioButtonStudent.Text = "学生登录";
            this.radioButtonStudent.UseVisualStyleBackColor = true;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButtonAdmin.Location = new System.Drawing.Point(478, 234);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(130, 24);
            this.radioButtonAdmin.TabIndex = 6;
            this.radioButtonAdmin.Text = "管理员登录";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.Location = new System.Drawing.Point(529, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabelRegister
            // 
            this.linkLabelRegister.AutoSize = true;
            this.linkLabelRegister.Font = new System.Drawing.Font("宋体", 12F);
            this.linkLabelRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelRegister.Location = new System.Drawing.Point(308, 303);
            this.linkLabelRegister.Name = "linkLabelRegister";
            this.linkLabelRegister.Size = new System.Drawing.Size(169, 20);
            this.linkLabelRegister.TabIndex = 8;
            this.linkLabelRegister.TabStop = true;
            this.linkLabelRegister.Text = "没有账号？去注册";
            this.linkLabelRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegister_LinkClicked);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.checkBox1.Location = new System.Drawing.Point(186, 385);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 24);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "我已阅读并同意";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // linkLabelIntroduction
            // 
            this.linkLabelIntroduction.AutoSize = true;
            this.linkLabelIntroduction.Font = new System.Drawing.Font("宋体", 12F);
            this.linkLabelIntroduction.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelIntroduction.Location = new System.Drawing.Point(363, 385);
            this.linkLabelIntroduction.Name = "linkLabelIntroduction";
            this.linkLabelIntroduction.Size = new System.Drawing.Size(309, 20);
            this.linkLabelIntroduction.TabIndex = 10;
            this.linkLabelIntroduction.TabStop = true;
            this.linkLabelIntroduction.Text = "智慧星学生选课管理系统使用说明";
            this.linkLabelIntroduction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelIntroduction_LinkClicked);
            // 
            // linkLabelForgetPwd
            // 
            this.linkLabelForgetPwd.AutoSize = true;
            this.linkLabelForgetPwd.Font = new System.Drawing.Font("宋体", 12F);
            this.linkLabelForgetPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelForgetPwd.Location = new System.Drawing.Point(157, 303);
            this.linkLabelForgetPwd.Name = "linkLabelForgetPwd";
            this.linkLabelForgetPwd.Size = new System.Drawing.Size(109, 20);
            this.linkLabelForgetPwd.TabIndex = 11;
            this.linkLabelForgetPwd.TabStop = true;
            this.linkLabelForgetPwd.Text = "忘记密码？";
            this.linkLabelForgetPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForgetPwd_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::scms.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(466, 92);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(693, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "退出程序";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // LoginWindom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabelForgetPwd);
            this.Controls.Add(this.linkLabelIntroduction);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.linkLabelRegister);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButtonAdmin);
            this.Controls.Add(this.radioButtonStudent);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginWindom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智慧星学生选课系统登录页面";
            this.Load += new System.EventHandler(this.LoginWindom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.RadioButton radioButtonStudent;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabelRegister;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.LinkLabel linkLabelIntroduction;
        private System.Windows.Forms.LinkLabel linkLabelForgetPwd;
        private System.Windows.Forms.Label label3;
    }
}

