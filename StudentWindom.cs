using System;
using System.Data;
using System.Windows.Forms;

namespace scms
{
    public partial class StudentWindom : Form
    {
        public StudentWindom()
        {
            InitializeComponent();
        }

        public StudentWindom(string username)
        {
            InitializeComponent();
            labelMain.Text = $"欢迎 {username} 登录智慧星学生选课管理系统";
            this.username=username;
        }
        private int currentTable = 0;
        private string username="赵维嘉";
        private void StudentWindom_Load(object sender, EventArgs e)
        {
            //  最大化
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            ShowTips();//使用说明
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetGrade();
        }

        //获取成绩
        private void GetGrade()
        {
            dataGridView1.Columns.Clear();
            //第一列
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "id", HeaderText = "序号", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "username", HeaderText = "学生姓名", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "pwd", HeaderText = "课程名称", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "teacher", HeaderText = "授课老师", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "email", HeaderText = "成绩", CellTemplate = new DataGridViewTextBoxCell() });
            //获取数据
            dataGridView1.Rows.Clear();  //清除旧数据
            MyDatabase dao = new MyDatabase();    //实例化数据库操作类

            //string sql = "select * from sc ";//SQL语句
            string sql = $"select username,name,teacher,grade from sc,student,course where student.username='{this.username}' and student.id=sc.sid and course.id=sc.cid and grade is not null  ";//SQL语句
            IDataReader dc = dao.read(sql);
            int i = 1;
            while (dc.Read())
            {
                string sname = "", cname = "", teacher = "" ,grade="";
                sname=dc[0].ToString();
                cname=dc[1].ToString();
                teacher=dc[2].ToString();
                grade=dc[3].ToString();
                string[] table = { (i++).ToString(), sname, cname, teacher, grade };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
            currentTable = 2;
        }
        //退出程序
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // 使用说明
        private void button4_Click(object sender, EventArgs e)
        {
            ShowTips();
        }
        // 选课中心
        private void GetCourseCenter()
        {
            dataGridView1.Columns.Clear();
            //第一列
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "id", HeaderText = "序号", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "username", HeaderText = "课程名称", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "pwd", HeaderText = "课程教师", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "email", HeaderText = "课程简介", CellTemplate = new DataGridViewTextBoxCell() });
            //获取数据
            dataGridView1.Rows.Clear();  //清除旧数据
            MyDatabase dao = new MyDatabase();    //实例化数据库操作类
            string sql = $"select name,teacher,detail from course where course.id not in (select distinct cid from sc,student where student.username='{username}' and student.id=sc.sid )";//SQL语句
            try
            {
                IDataReader dc = dao.read(sql);
                int i = 1;
                while (dc.Read())
                {
                    string a, b, c, d;
                    a = i.ToString();
                    b = dc[0].ToString();
                    c = dc[1].ToString();
                    d = dc[2].ToString();
                    string[] table = { a, b, c, d };
                    dataGridView1.Rows.Add(table);
                    i++;
                }
                dc.Close();
                dao.DaoClose();
                currentTable = 1;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetCourseCenter();
          
        }
        // 查看选择课程
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            //第一列
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "id", HeaderText = "序号", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "username", HeaderText = "课程名称", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "pwd", HeaderText = "课程教师", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "email", HeaderText = "课程简介", CellTemplate = new DataGridViewTextBoxCell() });
            //获取数据
            dataGridView1.Rows.Clear();  //清除旧数据
            MyDatabase dao = new MyDatabase();    //实例化数据库操作类
            string sql = $"select name,teacher,detail from sc,student,course where student.username='{this.username}' and student.id=sc.sid and course.id=sc.cid ";//SQL语句
            try
            {
                IDataReader dc = dao.read(sql);
                int i = 1;
                while (dc.Read())
                {
                    string a, b, c, d;
                    a = i.ToString();
                    b = dc[0].ToString();
                    c = dc[1].ToString();
                    d = dc[2].ToString();
                    string[] table = { a, b, c, d };
                    dataGridView1.Rows.Add(table);
                    i++;
                }
                dc.Close();
                dao.DaoClose();
                currentTable = 2;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
        }

        private void ShowTips()
        {
            string message = "智慧星学生管理系统使用说明:\n\n 1.点击选课中心按钮，可以查看系统中你还没有选择的课程，并且，你可以双击右侧的单元格进行课程的选择。\n 2.点击查看选择课程按钮，可以查看你已经选择学习的课程。\n 3.点击成绩查询按钮，可以查看已经被系统管理员给出分数的课程信息。 \n 4.点击使用说明按钮，可以查看智慧星学生成绩管理系统学生端的使用说明。 ";
            MessageBox.Show(message);
        }

        // 单元格点击事件
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string id = dataGridView1.CurrentCell.Value.ToString();
            if (currentTable == 1)
            {
                // 学生
                string cname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                string teacher = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string detail = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                xuanke xk = new xuanke(username,cname,teacher,detail);
                xk.ShowDialog();
                GetCourseCenter();
            }
        }
    }
}
