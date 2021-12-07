using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp2;

namespace SchoolProject
{
    public partial class Form1 : Form
    {
        XmlDocument xmlauth = new XmlDocument();
        XmlDocument xmlcourses = new XmlDocument();
        XmlDocument studentData = new XmlDocument();
        XmlDocument teacherData = new XmlDocument();
        int lastId = 0;
        List<User> registeredUsers = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }


        public void loadRegisteredUsers()
        {
            xmlauth.Load("../../UserList.xml");
            xmlcourses.Load("../../CourseList.xml");

            foreach (XmlNode user in xmlauth.SelectSingleNode("Users").ChildNodes)
            {
                try
                {
                    User registeredUser = new User();
                    registeredUser.id = int.Parse(user.SelectSingleNode("id").InnerText);
                    lastId = registeredUser.id;
                    registeredUser.username = user.SelectSingleNode("username").InnerText;
                    registeredUser.password = user.SelectSingleNode("password").InnerText;
                    registeredUser.status = user.SelectSingleNode("status").InnerText;
                    registeredUser.course = user.SelectSingleNode("course").InnerText;
                    registeredUser.name = user.SelectSingleNode("name").InnerText;
                    registeredUser.lastname = user.SelectSingleNode("lastname").InnerText;
                    registeredUsers.Add(registeredUser);
                }
                catch
                {

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_confirmPasswordRegister.PasswordChar = '*';
            textBox_passwordLogin.PasswordChar = '*';
            textBox_passwordRegister.PasswordChar = '*';
            label_responseLogin.Hide();
            label_responseRegister.Hide();
            xmlcourses.Load("../../CourseList.xml");
            loadRegisteredUsers();
            label_login.Parent = pictureBox1;
            label_login.BackColor = Color.Transparent;
            label_register.Parent = pictureBox1;
            label_register.BackColor = Color.Transparent;
            label_usernameLogin.Parent = pictureBox1;
            label_usernameLogin.BackColor = Color.Transparent;
            label_passwordLogin.Parent = pictureBox1;
            label_passwordLogin.BackColor = Color.Transparent;
            label_usernameRegister.Parent = pictureBox1;
            label_usernameRegister.BackColor = Color.Transparent;
            label_nameRegister.Parent = pictureBox1;
            label_nameRegister.BackColor = Color.Transparent;
            label_lastnameRegister.Parent = pictureBox1;
            label_lastnameRegister.BackColor = Color.Transparent;
            label_passwordRegister.Parent = pictureBox1;
            label_passwordRegister.BackColor = Color.Transparent;
            label_confirmPasswordRegister.Parent = pictureBox1;
            label_confirmPasswordRegister.BackColor = Color.Transparent;
            label_statusRegister.Parent = pictureBox1;
            label_statusRegister.BackColor = Color.Transparent;
            label_additionalInformationRegister.BackColor = Color.Transparent;
            label_additionalInformationRegister.Parent = pictureBox1;
            label_responseLogin.BackColor = Color.Transparent;
            label_responseLogin.Parent = pictureBox1;
            label_responseRegister.BackColor = Color.Transparent;
            label_responseRegister.Parent = pictureBox1;
            label_authorization.BackColor = Color.Transparent;
            label_authorization.Parent = pictureBox1;

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            bool success = false;
            foreach (User user in registeredUsers)
            {
                if (user.username == textBox_usernameLogin.Text && user.password == textBox_passwordLogin.Text)
                {
                    success = true;
                    label_responseLogin.ForeColor = Color.Green;
                    label_responseLogin.Text = "Response: Logged in successfully";
                    if (user.status == "Student")
                    {
                        StudentForm stform = new StudentForm(registeredUsers, user);
                        this.Hide();
                        stform.ShowDialog();
                        this.Show();
                    }
                    if (user.status == "Teacher")
                    {
                        TeacherForm tcform = new TeacherForm(registeredUsers, user);
                        this.Hide();
                        tcform.ShowDialog();
                        this.Show();
                    }

                }
            }
            if (!success)
            {
                label_responseLogin.ForeColor = Color.Red;
                label_responseLogin.Text = "Response: Could not log in";
            }
            label_responseLogin.Show();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            bool success = true;
            foreach (User user in registeredUsers)
            {
                if (user.username == textBox_usernameRegister.Text)
                {
                    label_responseRegister.ForeColor = Color.Red;
                    label_responseRegister.Text = "Response: Username already taken";
                    success = false;
                    break;
                }
            }
            if (textBox_passwordRegister.Text != textBox_confirmPasswordRegister.Text)
            {
                label_responseRegister.ForeColor = Color.Red;
                label_responseRegister.Text = "Response: Passwords do not match";
                success = false;
            }
            if (textBox_confirmPasswordRegister.Text == string.Empty || textBox_passwordRegister.Text == string.Empty || textBox_usernameRegister.Text == string.Empty || textBox_nameRegister.Text == string.Empty || textBox_lastnameRegister.Text == string.Empty)
            {
                label_responseRegister.ForeColor = Color.Red;
                label_responseRegister.Text = "Response: Some fields are not filled";
                success = false;
            }
            if (success)
            {
                if (comboBox_statusRegister.Text == "Teacher")
                {
                    XmlElement course = xmlcourses.CreateElement("course");

                    XmlElement name = xmlcourses.CreateElement("name");
                    name.InnerText = comboBox_courseRegister.Text;
                    course.AppendChild(name);

                    XmlElement teacher = xmlcourses.CreateElement("teacher");
                    teacher.InnerText = textBox_nameRegister.Text + " " + textBox_lastnameRegister.Text;
                    course.AppendChild(teacher);

                    XmlElement students = xmlcourses.CreateElement("Students");
                    course.AppendChild(students);

                    XmlElement grades = xmlcourses.CreateElement("Grades");
                    course.AppendChild(grades);

                    xmlcourses.DocumentElement.AppendChild(course);
                    xmlcourses.Save("../../CourseList.xml");
                }
                label_responseRegister.Show();

                XmlNode newUser = xmlauth.CreateElement("user");

                XmlNode newUserId = xmlauth.CreateElement("id");
                newUserId.InnerText = (lastId + 1).ToString();
                newUser.AppendChild(newUserId);

                XmlNode newUsername = xmlauth.CreateElement("username");
                newUsername.InnerText = textBox_usernameRegister.Text;
                newUser.AppendChild(newUsername);

                XmlNode newName = xmlauth.CreateElement("name");
                newName.InnerText = textBox_nameRegister.Text;
                newUser.AppendChild(newName);

                XmlNode newLastname = xmlauth.CreateElement("lastname");
                newLastname.InnerText = textBox_lastnameRegister.Text;
                newUser.AppendChild(newLastname);

                XmlNode newPassword = xmlauth.CreateElement("password");
                newPassword.InnerText = textBox_passwordRegister.Text;
                newUser.AppendChild(newPassword);

                XmlNode newStatus = xmlauth.CreateElement("status");
                newStatus.InnerText = comboBox_statusRegister.Text;
                newUser.AppendChild(newStatus);

                XmlNode newCourse = xmlauth.CreateElement("course");
                newCourse.InnerText = comboBox_courseRegister.Text;
                newUser.AppendChild(newCourse);

                xmlauth.DocumentElement.AppendChild(newUser);
                xmlauth.Save("../../UserList.xml");
                // SQLProcedures.InsertTeacher(textBox_usernameRegister.Text, textBox_nameRegister.Text, textBox_lastnameRegister.Text, textBox_passwordRegister.Text);

            


                if (comboBox_statusRegister.Text == "Student")
                {
                    XmlNode studentid = xmlcourses.CreateElement("studentid");
                    studentid.InnerText = (lastId + 1).ToString();
                    foreach (XmlNode course in xmlcourses.DocumentElement.ChildNodes)
                    {
                        if (course.SelectSingleNode("name").InnerText == comboBox_courseRegister.Text)
                        {
                            course.SelectSingleNode("Students").AppendChild(studentid);
                        }
                    }
                    xmlcourses.Save("../../CourseList.xml");
                }

                label_responseRegister.ForeColor = Color.Green;
                label_responseRegister.Text = "Response: Registration completed";
                textBox_confirmPasswordRegister.Text = string.Empty;
                textBox_passwordRegister.Text = string.Empty;
                textBox_usernameRegister.Text = string.Empty;
                textBox_nameRegister.Text = string.Empty;
                textBox_lastnameRegister.Text = string.Empty;
                comboBox_courseRegister.Text = string.Empty;
                comboBox_statusRegister.Text = string.Empty;
                loadRegisteredUsers();
            }
            label_responseRegister.Show();
        }

        private void button_login_MouseHover(object sender, EventArgs e)
        {
        }
    }
}
