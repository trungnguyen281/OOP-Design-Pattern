using SCOFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace DemoSCO
{
    public partial class DemoSCO : Form
    {
        SCOConnection connection = null;
        List<Student> students = null;
        List<Teacher> teachers = null;

        public DemoSCO()
        {
            InitializeComponent();
            connection = new SCOSqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        }

        private void DemoSCO_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                students = connection.ExecuteQuery<Student>("SELECT * FROM STUDENT");
                teachers = connection.Select<Teacher>().AllRow().Run();
                AddToCombobox(teachers);
                BidingGridViewStudent(students);
                BidingGridViewTeacher(teachers);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                if (string.IsNullOrEmpty(txtTimKiem.Text))
                    students = connection.Select<Student>().AllRow().Run();
                else
                    students = connection.Select<Student>().Where("NAME LIKE N'%" + txtTimKiem.Text.Trim() + "%'").Run();

                if (students == null || students.Count == 0)
                    MessageBox.Show("Không tìm thấy kết quả");
                else
                    BidingGridViewStudent(students);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSHS.Text) || string.IsNullOrEmpty(txtHoten.Text) || cbGVCN.SelectedIndex <= 0)
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                Student s = new Student();
                s.ID = txtMSHS.Text;
                s.Name = txtHoten.Text;
                s.TeacherID = ((ComboboxItem)cbGVCN.SelectedItem).Value;

                try
                {
                    connection.Open();
                    connection.Insert(s);
                    connection.Close();
                    DemoSCO_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSHS.Text) || string.IsNullOrEmpty(txtHoten.Text) || cbGVCN.SelectedIndex <= 0)
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                Student s = new Student();
                s.ID = txtMSHS.Text;
                s.Name = txtHoten.Text;
                s.TeacherID = ((ComboboxItem)cbGVCN.SelectedItem).Value;

                try
                {
                    connection.Open();
                    connection.Update(s);
                    connection.Close();
                    DemoSCO_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = gridHocSinh.CurrentCell.RowIndex;

            try
            {
                connection.Open();
                connection.Delete(students[selectedRowIndex]);
                connection.Close();
                DemoSCO_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddToCombobox(List<Teacher> teachers)
        {
            cbGVCN.DisplayMember = "Text";
            cbGVCN.ValueMember = "Value";

            cbGVCN.Items.Clear();

            cbGVCN.Items.Add(new ComboboxItem("-- Chọn --", ""));
            foreach (Teacher teacher in teachers)
            {
                cbGVCN.Items.Add(new ComboboxItem(teacher.Name, teacher.ID));
            }
            cbGVCN.SelectedIndex = 0;
        }

        private void BidingGridViewStudent(List<Student> students)
        {
            gridHocSinh.Rows.Clear();
            foreach (Student student in students)
            {
                int subjectCount = 0;
                if (student.Student_Subjects != null)
                    subjectCount = student.Student_Subjects.Count;
                double gpa = 0;
                if (student.Transcipt != null)
                    gpa = student.Transcipt.GPA;

                gridHocSinh.Rows.Add(student.ID, student.Name, subjectCount, gpa, student.Teacher.Name);
            }
        }

        private void BidingGridViewTeacher(List<Teacher> teachers)
        {
            gridGiaoVien.Rows.Clear();
            foreach (Teacher teacher in teachers)
            {
                gridGiaoVien.Rows.Add(teacher.ID, teacher.Name, teacher.StudentList.Count);
            }
        }

        private void gridHocSinh_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowIndex = gridHocSinh.CurrentCell.RowIndex;
            txtMSHS.Text = students[selectedRowIndex].ID;
            txtHoten.Text = students[selectedRowIndex].Name;
            for (int i = 0; i < cbGVCN.Items.Count; i++)
                if (((ComboboxItem)cbGVCN.Items[i]).Value == students[selectedRowIndex].Teacher.ID)
                    cbGVCN.SelectedIndex = i;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSHS.Text = string.Empty;
            txtHoten.Text = string.Empty;
            txtTimKiem.Text = string.Empty;
            cbGVCN.SelectedIndex = 0;
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboboxItem(string t, string v)
        {
            Text = t;
            Value = v;
        }
    }
}
