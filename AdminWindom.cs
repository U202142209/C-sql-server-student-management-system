using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace scms
{
    public partial class AdminWindom : Form
    {
        public AdminWindom()
        {
            InitializeComponent();
        }

        private void AdminWindom_Load(object sender, EventArgs e)
        {

        }
        private int currentTable = 0;       // 0;学生  1课程  2 成绩
        private void BtnMouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(240, 240, 240);
        }
        private void BtnMouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }
        private void GetStudentsData()
        {
            dataGridView1.Columns.Clear();
            //第一列
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "id", HeaderText = "id", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "username", HeaderText = "学生姓名", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "pwd", HeaderText = "学生密码", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "email", HeaderText = "学生邮箱", CellTemplate = new DataGridViewTextBoxCell() });

            //获取数据
            dataGridView1.Rows.Clear();  //清除旧数据
            MyDatabase dao = new MyDatabase();    //实例化数据库操作类
            string sql = "select * from student";//SQL语句
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                string a, b, c, d;
                a = dc[0].ToString();
                b = dc[1].ToString();
                c = dc[2].ToString();
                d = dc[3].ToString();
                string[] table = { a, b, c, d };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
            currentTable = 0;
        }
        private void GetCourseData()
        {
            dataGridView1.Columns.Clear();
            //第一列
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "id", HeaderText = "id", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "username", HeaderText = "课程名称", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "pwd", HeaderText = "课程教师", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn() { Name = "email", HeaderText = "课程简介", CellTemplate = new DataGridViewTextBoxCell() });
            //获取数据
            dataGridView1.Rows.Clear();  //清除旧数据
            MyDatabase dao = new MyDatabase();    //实例化数据库操作类
            string sql = "select * from course";//SQL语句
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                string a, b, c, d;
                a = dc[0].ToString();
                b = dc[1].ToString();
                c = dc[2].ToString();
                d = dc[3].ToString();
                string[] table = { a, b, c, d };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
            currentTable = 1;
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
            string sql = "select * from sc";//SQL语句
            IDataReader dc = dao.read(sql);
            int i = 1;
            while (dc.Read())
            {
                string sid, cid, grade;
                sid = dc[0].ToString();
                cid = dc[1].ToString();
                grade = dc[2].ToString();
                string sname = "", cname = "", teacher = "";
                // 获取学生姓名
                IDataReader s = dao.read($"select username from student where id={sid}");
                while (s.Read())
                {
                    sname = s[0].ToString();
                }
                s.Close();
                // 获取课程名称
                IDataReader c = dao.read($"select name,teacher from course where id={cid}");
                while (c.Read())
                {
                    cname = c[0].ToString();
                    teacher = c[1].ToString();
                }
                c.Close();
                string[] table = { (i++).ToString(), sname, cname, teacher, grade };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
            currentTable = 1;
            currentTable = 3;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GetStudentsData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCourseData();
        }
        // 单元格点击事件
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //string id = dataGridView1.CurrentCell.Value.ToString();
            if (currentTable == 0)
            {
                // 学生
                string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                string name = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                string teacher = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string detail = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                students student = new students(id, name, teacher, detail);
                student.ShowDialog();
                GetStudentsData();
                
            }
            else if (currentTable == 1)
            {
                // 课程
                string id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                string name = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                string teacher = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string detail = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                AddCourse ac = new AddCourse(id, name, teacher, detail);
                ac.ShowDialog();
                GetCourseData();
            }else if (currentTable ==3)
            {
                // 成绩
                string sname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                string cname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string teacher = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                string grade = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                SetGrade sg = new SetGrade(sname,cname,teacher,grade);
                sg.ShowDialog();
                GetGrade();
            }
        }

        // 退出程序
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 成绩
        private void button2_Click(object sender, EventArgs e)
        {
            GetGrade();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //  最大化
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            ShowMessage();
        }
        // 查看使用说明
        private void button5_Click(object sender, EventArgs e)
        {
            ShowMessage();
        }
        private void ShowMessage()
        {
            string msg = "欢迎使用智慧星学生管理系统\n\n(1)点击查看学生信息按钮，可以查看所有注册本系统的学生信息，包括用户名，密码，邮箱\n(2)点击管理课程信息按钮，可以查看系统所有的课程信息，双击右侧的单元格，可以对相应的课程进行增删改查的业务操作。\n(3)点击管理学生成绩按钮，然后双击右侧的单元格，可以在弹出的窗体中对相应学生，相应课程的成绩进行修改。";
            MessageBox.Show(msg);
        }
    }
}
