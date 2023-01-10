using System;
using System.Data;
using System.Windows.Forms;

namespace scms
{
    public partial class xuanke : Form
    {
        public xuanke()
        {
            InitializeComponent();
        }
        private string username = "";
        public xuanke(string username, string cname, string teacher, string detail)
        {
            InitializeComponent();
            this.lcoursename.Text = cname;
            this.lteacher.Text = teacher;
            this.ldetail.Text = detail;
            this.username = username;
        }

        private void xuanke_Load(object sender, EventArgs e)
        {

        }
        // 返回
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 选课
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("你确定要选择这门课吗，选择后将不可退选！请三思。", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)   //确认
                {
                    // 查询学号，课程号
                    MyDatabase dao = new MyDatabase();    //实例化数据库操作类
                    string sql = $"select id from student where username='{username}'";//SQL语句
                    IDataReader dc = dao.read(sql);
                    string sid = "0", cid = "0";
                    while (dc.Read())
                    {
                        sid = dc[0].ToString();
                    }

                    dao = new MyDatabase();    //实例化数据库操作类
                    sql = $"select id from course where name='{lcoursename.Text}'";//SQL语句
                    dc = dao.read(sql);
                    while (dc.Read())
                    {
                        cid = dc[0].ToString();
                    }
                    // 插入数据
                    sql = $"insert into sc(sid,cid) values ('{sid}','{cid}')";
                    dao = new MyDatabase();
                    int r = dao.Execute(sql);
                    if (r > 0)  //添加成功
                    {
                        dao.DaoClose();
                        MessageBox.Show("选课成功！你可以去查看选择课程按钮里面查看此课程。");
                        this.Close();
                    }
                    else
                    {
                        dao.DaoClose();
                        MessageBox.Show("选课失败！");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("出错了;\n" + error.Message);
                return;
            }
        }
    }
}
