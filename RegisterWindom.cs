using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace scms
{
    public partial class RegisterWindom : Form
    {
        public RegisterWindom()
        {
            InitializeComponent();
        }
        // 使用正则表达式，判断邮箱是否有效
        public static bool IsEmail(string inputData)
        {
            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");
            //w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样  	
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        // 注册前检测注册的 信息是否有效，用户名不为空，邮箱有效，两次输入的密码一致
        private bool IsDataAvailable()
        {
            if (textBoxUsername.Text != null && IsEmail(textBoxEmail.Text) && (textBoxpwd.Text == textBoxcompwd.Text))
            {
                return true;
            }
            return false;
        }
        // 注册
        private void button1_Click(object sender, EventArgs e)
        {
            // 调用之前定义好的函数，判断数据格式是否正确
            if (IsDataAvailable())
            {
                string sql = $"insert into student(username,pwd,email) values('{textBoxUsername.Text}','{textBoxpwd.Text}','{textBoxEmail.Text}') ";
                MyDatabase dao = new MyDatabase();
                try
                {
                    int r = dao.Execute(sql);
                    if (r > 0)  //添加成功
                    {
                        dao.DaoClose();
                        MessageBox.Show($"注册成功！\n\n（1）您注册的用户名是；{textBoxUsername.Text}\n（2）您使用的注册邮箱是；{textBoxEmail.Text}");
                        this.Close();
                    }
                    else
                    {
                        dao.DaoClose();
                        MessageBox.Show("注册失败！可能的原因是；\n\n（1）您的用户名已经被注册过了\n（2）您的邮箱已经被注册过了\n");
                    }
                }catch (Exception error)
                {
                    MessageBox.Show($"注册失败！可能的原因是；\n\n（1）您的用户名已经被注册过了\n（2）您的邮箱已经被注册过了\n（3）{error.Message}");
                }
                
            }
            else
            {
                string msg = "温馨提示，请确保；\n（1）用户名不能为空值\n（2）请输入有效的邮箱地址\n（3）两次输入的密码必须一致\n";
                MessageBox.Show(msg);
            }
        }
        // 清除输入框的所有内容
        private void ClearFields()
        {
            this.textBoxUsername.Text = null;
            this.textBoxEmail.Text = null;
            this.textBoxcompwd.Text = null;
            this.textBoxpwd.Text = null;
        }
        // 返回
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterWindom_Load(object sender, EventArgs e)
        {
            //  最大化
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
        }
    }
}
