using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;       //导入网络请求模块
using System.IO;
namespace scms
{
    public partial class ForgetPwd : Form
    {
        private string emailCode = "";  // 保存发送的邮箱验证码
        private string UserEmail;        // 保存需要修改密码的邮箱
        public ForgetPwd()
        {
            InitializeComponent();
        }
        // 返回
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 发送验证码按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (RegisterWindom.IsEmail(textBoxEmail.Text))
            {
                //判断邮箱是否有效
                if (IsAbleTOSendEmailCode())
                {
                    // 一下是发送验证码的代码
                    string result = SendEmailCode(textBoxEmail.Text);
                    if (result.Length == 4)
                    {
                        emailCode = result; // 将验证码复制给全局变量
                        UserEmail = textBoxEmail.Text;  //将邮箱保存起来
                        MessageBox.Show($"成功向邮箱；{textBoxEmail.Text} 发送了长度为四的验证码。请在输入框中输入该验证码以完成验证.");
                        button1.Enabled = false;
                        button1.Text = "验证码发送成功";
                    }
                    else if (result.Length == 5)
                    {
                        MessageBox.Show($"发送验证码失败，请确认邮箱；{textBoxEmail.Text} 是否为有效的邮箱地址。");
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                }
                else
                {
                    MessageBox.Show($"邮箱；{textBoxEmail.Text} 没有在本系统中注册，您可以先去注册再登录。");
                }

            }
            else
            {
                MessageBox.Show("请输入有效的邮箱地址...");
            }
        }
        /// <summary>
        /// // 判断邮箱是否在数据库中存在
        /// </summary>
        /// <returns></returns>
        private bool IsAbleTOSendEmailCode()
        {
            bool flag;
            MyDatabase dao = new MyDatabase();
            // 拼接sql语句，判断用户名与密码
            string sql = $"select username from student where email='{textBoxEmail.Text}'";
            IDataReader dc = dao.read(sql);
            if (dc.Read())//读取数据库中的数据，一条一条的读
            {
                // 存在数据
                flag = true;
            }
            else
            {
                flag = false;
            }
            dc.Close();//数据库关闭
            dao.DaoClose();//数据库关闭
            return flag;
        }

        /// <summary>
        /// 发送验证码，
        /// </summary>
        /// <param name="email"></param>
        /// <returns>返回值如果是false，说明发送失败，如果返回值是长度为四的字符串，发明发送成功，</returns>
        public static string SendEmailCode(string email)
        {
            string url = "http://101.43.229.177/api/sendemailcode/";    //发送验证码的接口地址
            string result;  //返回值
            try
            {
                // 发起带参数的post请求
                //使用字典类型储存参数
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("email", email);
                result = Post(url, dic);
            }
            catch (Exception error)
            {
                result = error.Message;
                MessageBox.Show(error.Message);
            }
            return result;
        }
        /// <summary>
        /// 这个是封装好的方法，do noe touch this text unless you know what you are doing 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }

            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());

            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        //确定按钮
        private void button2_Click(object sender, EventArgs e)
        {
            if (emailCode == "")
            {
                MessageBox.Show("请先点击上面的按钮获取验证码。");
                return;
            }
            if (textBoxCode.Text != emailCode)
            {
                MessageBox.Show("验证码输入不正确。");
                return;
            }
            if (textBoxComPwd.Text != textBoxPwd.Text)
            {
                MessageBox.Show("两次输入的密码不正确，请重新输入。");
                textBoxComPwd.Text = null;
                return;
            }
            // 程序执行到了这里，说明可以修改密码了
            string sql = $"update student set pwd='{textBoxPwd.Text}' where email='{UserEmail}'";
            MyDatabase dao = new MyDatabase();
            int r = dao.Execute(sql);
            if (r > 0)  //修改成功
            {
                dao.DaoClose();
                MessageBox.Show("修改密码成功！现在可以去登录啦");
                this.Close();
            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("修改密码失败！");
            }
        }

        private void ForgetPwd_Load(object sender, EventArgs e)
        {
            //  最大化
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
        }
    }
}
