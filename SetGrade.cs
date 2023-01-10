using System;
using System.Windows.Forms;

namespace scms
{
    public partial class SetGrade : Form
    {
        public SetGrade()
        {
            InitializeComponent();
        }
        public SetGrade(string sname,string cname,string teacher , string grade)
        {
            InitializeComponent();
            this.labelstudent.Text = sname;
            this.labelcourse.Text = cname;
            this.labelteacher.Text = teacher;
            this.textBox1.Text = grade;
            this.labelmessage.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                labelmessage.Text = "课程成绩请输入0到100之间的数字！";
                e.Handled = true;
            }
            else
            {
                labelmessage.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //保存修改
            string sql = $"update sc set grade={textBox1.Text} where sid=(select id from student where username='{labelstudent.Text}' ) and cid=(select id from course where name='{labelcourse.Text}')";
            MyDatabase dao = new MyDatabase();
            try{
                int r = dao.Execute(sql);
                if (r > 0)  //修改成功
                {
                    dao.DaoClose();
                    MessageBox.Show("设置成绩成功！");
                    this.Close();
                }
                else
                {
                    dao.DaoClose();
                    MessageBox.Show("设置成绩失败！");
                }
            }catch(Exception error)
            {
                MessageBox.Show("发生了错误；\n" + error.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
