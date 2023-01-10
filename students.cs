using System;
using System.Windows.Forms;

namespace scms
{
    public partial class students : Form
    {
        public students()
        {
            InitializeComponent();
        }
        private string ID;
        public students(string id, string name, string teacher, string detail)
        {
            InitializeComponent();
            this.textBoxName.Text = name;
            this.textBoxPassword.Text = teacher;
            this.textBoxYouxiang.Text= detail;
            this.ID =id;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void students_Load(object sender, EventArgs e)
        {

        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"insert into student values ('{textBoxName.Text.Trim()}','{textBoxPassword.Text.Trim()}','{textBoxYouxiang.Text.Trim()}')";
            MyDatabase dao = new MyDatabase();
            try
            {
                int r = dao.Execute(sql);
                if (r > 0)  //添加成功
                {
                    dao.DaoClose();
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
                else
                {
                    dao.DaoClose();
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("发生了错误；" + error.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update student set username='{textBoxName.Text.Trim()}',pwd='{textBoxPassword.Text.Trim()}',email='{textBoxYouxiang.Text.Trim()}' where id={ID}";
            MyDatabase dao = new MyDatabase();
            int r = dao.Execute(sql);
            if (r > 0)  //修改成功
            {
                dao.DaoClose();
                MessageBox.Show("修改数据成功！");
                this.Close();
            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("修改失败！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("确认删除吗？删除后将不可恢复！！", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)   //确认删除
                {
                    string sql = $"delete from student where id= {ID}";
                    MyDatabase dao = new MyDatabase();
                    int r = dao.Execute(sql);
                    if (r > 0)
                    {
                        dao.DaoClose();
                        MessageBox.Show("删除当前行内容成功！", "Tip Message");
                        this.Close();
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

