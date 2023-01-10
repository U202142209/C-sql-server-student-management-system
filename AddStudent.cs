using System;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;
namespace scms
{
    public partial class LoginWindom : Form
    {
        private bool haveReadIntroduction =true;
        // 窗体的构造方法
        public LoginWindom()
        {
            InitializeComponent();
        }
        // 判断是否登录成功
        public bool login()
        {
            if (radioButtonStudent.Checked)//学生登录选项
            {
                MyDatabase dao = new MyDatabase();
                // 拼接sql语句，判断用户名与密码
                string sql = $"select * from student where pwd='{textBoxPwd.Text}' and (username='{textBoxUsername.Text}' )";
                IDataReader dc = dao.read(sql);
                if (dc.Read())//读取数据库中的数据，一条一条的读
                {
                    return true;
                }
                else
                {
                    return false;
                }
                dc.Close();//数据库关闭
                dao.DaoClose();//数据库关闭
            }
            else if (radioButtonAdmin.Checked)  //管理员登录选项
            {
                MyDatabase dao = new MyDatabase();
                string sql = $"select * from admin where username='{textBoxUsername.Text}' and pwd='{textBoxPwd.Text}' ";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
                dao.DaoClose(); //关闭数据库连接
            }
            return true;
        }
        // 登录按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && haveReadIntroduction)
            {
                if (textBoxPwd.Text != null && textBoxUsername.Text != null)
                {
                    // 输入框不能为空值
                    bool ret = login();     // 判断数据库中是否有登录的数据
                    if (radioButtonStudent.Checked && ret)
                    {
                        //学生登录成功！
                        MessageBox.Show("登录成功！");
                        this.Hide();
                        // 在这下面添加学生登录之后的代码，打开另一个窗体等
                        StudentWindom sw = new StudentWindom(textBoxUsername.Text);
                        sw.ShowDialog();
                        Application.Exit();     //结束应用程序
                    }
                    else if (radioButtonAdmin.Checked && ret)
                    {
                        //管理员登录成功
                        MessageBox.Show("管理员账户登录成功！");
                        this.Hide();
                        // 在这下面添加管理员登录之后的代码，打开另一个窗体等
                        AdminWindom aw = new AdminWindom();
                        aw.ShowDialog();
                        Application.Exit();     //结束应用程序
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不正确，请重新输入...");
                        textBoxPwd.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("请 阅读 并同意智慧星学生选课管理系统使用说明！！！");
            }
        }
        // 注册
        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (checkBox1.Checked && haveReadIntroduction)
            {
                RegisterWindom rw = new RegisterWindom();
                rw.ShowDialog();
            }
            else
            {
                MessageBox.Show("请 阅读 并同意智慧星学生选课管理系统使用说明！！！");
            }
        }
        // 找回密码
        private void linkLabelForgetPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (checkBox1.Checked && haveReadIntroduction)
            {
                ForgetPwd fw = new ForgetPwd();
                fw.ShowDialog();
            }
            else
            {
                MessageBox.Show("请 阅读 并同意智慧星学生选课管理系统使用说明！！！");
            }
        }
        // 使用说明
        private void linkLabelIntroduction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            haveReadIntroduction = true;
            // 打开连接
            string url = "http://101.43.229.177/article/?nid=202212121825538714";
            System.Diagnostics.Process.Start(url);
            linkLabelIntroduction.LinkVisited = true;  //链接是否被访问过,仅能代码来实现
        }
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 加载窗体
        private void LoginWindom_Load(object sender, EventArgs e)
        {

            //  最大化
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
        }



        // 加密字符串
        public static string encryptKey = "Oyea";    //定义密钥
        /// 加密字符串  
        /// <param name="str">要加密的字符串</param> 
        /// <returns>加密后的字符串</returns> 
        public static string Encrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象  
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥   
            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串 
            MemoryStream MStream = new MemoryStream(); //实例化内存流对象     
            //使用内存流实例化加密流对象  
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);  //向加密流中写入数据     
            CStream.FlushFinalBlock();              //释放加密流     
            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串 
        }


        /// 解密字符串  
        /// <param name="str">要解密的字符串</param> 
        /// <returns>解密后的字符串</returns> 
        public static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   
            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥   
            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串 
            MemoryStream MStream = new MemoryStream(); //实例化内存流对象
            //使用内存流实例化解密流对象      
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            CStream.Write(data, 0, data.Length);      //向解密流中写入数据    
            CStream.FlushFinalBlock();               //释放解密流     
            return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串 
        }
    }
}
