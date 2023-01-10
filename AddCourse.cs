using System;
using System.Windows.Forms;
namespace scms
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }
        private string ID;
        public AddCourse(string id, string name, string teacher, string detail)
        {
            InitializeComponent();
            this.textBoxName.Text = name;
            this.textBoxTeacher.Text = teacher;
            this.richTextBox1.Text = detail;
            this.ID = id;
        }
        //插入新数据
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = $"insert into course values ('{textBoxName.Text.Trim()}','{textBoxTeacher.Text.Trim()}','{richTextBox1.Text.Trim()}')";
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

        // 保存修改
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update course set name='{textBoxName.Text.Trim()}',teacher='{textBoxTeacher.Text.Trim()}',detail='{richTextBox1.Text.Trim()}' where id={ID}";
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
        // 返回
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 删除
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("确认删除吗？删除后将不可恢复！！", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)   //确认删除
                {
                    string sql = $"delete from course where id= {ID}";
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

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
