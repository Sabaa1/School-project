using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WindowsFormsApp2
{
    public class SQLProcedures
    {
        public static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connstr);
        public static SqlCommand cmd;
        public static SqlDataAdapter dataAdapter;
        public static DataTable SelectCourse()
        {
            cmd = new SqlCommand("SelectCourse", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }
        public static DataTable SelectHomework()
        {
            cmd = new SqlCommand("SelectHomework", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }
        public static DataTable SelectStudent()
        {
            cmd = new SqlCommand("SelectStudent", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }
        public static DataTable SelectTeacher()
        {
            cmd = new SqlCommand("SelectTeacher", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }
        public static DataTable SelectGrade()
        {
            cmd = new SqlCommand("SelectGrade", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }
        public static DataTable SelectSubmission()
        {
            cmd = new SqlCommand("SelectSubmission", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        public static void InsertCourse(string courseName)
        {
            cmd = new SqlCommand("InsertCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@course_name", SqlDbType.VarChar, (50));
            paramss[0].Value = courseName;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertStudent( string Username, string Firstname, string Lastname , string Password)
        {
            cmd = new SqlCommand("InsertStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[4];

            paramss[0] = new SqlParameter("@newusername", SqlDbType.VarChar, (50));
            paramss[0].Value = Username;

            paramss[1] = new SqlParameter("@newlastname", SqlDbType.VarChar, (50));
            paramss[1].Value = Lastname;

            paramss[2] = new SqlParameter("@newfirstname", SqlDbType.VarChar, (50));
            paramss[2].Value = Firstname;

            paramss[3] = new SqlParameter("@newpassword", SqlDbType.VarChar, (50));
            paramss[3].Value = Password;


            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertTeacher(string Username, string Firstname, string Lastname, string Password)
        {
            cmd = new SqlCommand("InsertTeacher", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[4];

            paramss[0] = new SqlParameter("@newusername", SqlDbType.VarChar, (50));
            paramss[0].Value = Username;

            paramss[1] = new SqlParameter("@newlastname", SqlDbType.VarChar, (50));
            paramss[1].Value = Lastname;

            paramss[2] = new SqlParameter("@newfirstname", SqlDbType.VarChar, (50));
            paramss[2].Value = Firstname;

            paramss[3] = new SqlParameter("@newpassword", SqlDbType.VarChar, (50));
            paramss[3].Value = Password;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertGrade( string Date , string Type, int Mark)
        {
            cmd = new SqlCommand("InsertGrade", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[3];

            paramss[0] = new SqlParameter("@newdateate", SqlDbType.VarChar, (50));
            paramss[0].Value = Date;

            paramss[1] = new SqlParameter("@newmarkark", SqlDbType.Int);
            paramss[1].Value = Mark;

            paramss[2] = new SqlParameter("@newtype", SqlDbType.VarChar, (50));
            paramss[2].Value = Type;


            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertHomework( string Title, string Description)
        {
            cmd = new SqlCommand("InsertHomework", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[2];

            paramss[0] = new SqlParameter("@newtitle", SqlDbType.VarChar, (50));
            paramss[0].Value = Title;

            paramss[1] = new SqlParameter("@newdscription", SqlDbType.VarChar, (50));
            paramss[1].Value = Title;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertSubmission( string Content)
        {
            cmd = new SqlCommand("InsertSubmission", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@newcontent", SqlDbType.VarChar, (50));
            paramss[0].Value = Content;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateCourse(int courseId, string courseName)
        {
            cmd = new SqlCommand("UpdateCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[2];

            paramss[0] = new SqlParameter("@id", SqlDbType.Int);
            paramss[0].Value = courseId;

            paramss[1] = new SqlParameter("@course_name", SqlDbType.VarChar, (50));
            paramss[1].Value = courseName;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateStudent(int StudentId ,string Username, string Firstname, string Lastname, string Password)
        {
            cmd = new SqlCommand("UpdateStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[5];

            paramss[0] = new SqlParameter("@id", SqlDbType.Int);
            paramss[0].Value = StudentId;

            paramss[1] = new SqlParameter("@newusername", SqlDbType.VarChar, (50));
            paramss[1].Value = Username;

            paramss[2] = new SqlParameter("@newlastname", SqlDbType.VarChar, (50));
            paramss[2].Value = Lastname;

            paramss[3] = new SqlParameter("@newfirstname", SqlDbType.VarChar, (50));
            paramss[3].Value = Firstname;

            paramss[4] = new SqlParameter("@newpassword", SqlDbType.VarChar, (50));
            paramss[4].Value = Password;


            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateTeacher(int TeacherId, string Username, string Firstname, string Lastname, string Password)
        {
            cmd = new SqlCommand("UpdateTeacher", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[5];


            paramss[0] = new SqlParameter("@id", SqlDbType.Int);
            paramss[0].Value = TeacherId;

            paramss[1] = new SqlParameter("@newusername", SqlDbType.VarChar, (50));
            paramss[1].Value = Username;

            paramss[2] = new SqlParameter("@newlastname", SqlDbType.VarChar, (50));
            paramss[2].Value = Lastname;

            paramss[3] = new SqlParameter("@newfirstname", SqlDbType.VarChar, (50));
            paramss[3].Value = Firstname;

            paramss[4] = new SqlParameter("@newpassword", SqlDbType.VarChar, (50));
            paramss[4].Value = Password;
            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateGrade(int GradeId, string Date, string Type, int Mark)
        {
            cmd = new SqlCommand("UpdateGrade", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[4];
            
            paramss[0] = new SqlParameter("@id", SqlDbType.VarChar, (50));
            paramss[0].Value = GradeId;

            paramss[1] = new SqlParameter("@newdateate", SqlDbType.VarChar, (50));
            paramss[1].Value = Date;

            paramss[2] = new SqlParameter("@newmarkark", SqlDbType.Int);
            paramss[2].Value = Mark;

            paramss[3] = new SqlParameter("@newtype", SqlDbType.VarChar, (50));
            paramss[3].Value = Type;


            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateHomework(int HomeworkId, string Title, string Description)
        {
            cmd = new SqlCommand("UpdateHomework", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[3];

            paramss[0] = new SqlParameter("@id", SqlDbType.VarChar, (50));
            paramss[0].Value = HomeworkId;

            paramss[1] = new SqlParameter("@newtitle", SqlDbType.VarChar, (50));
            paramss[1].Value = Title;

            paramss[2] = new SqlParameter("@newdscription", SqlDbType.VarChar, (50));
            paramss[2].Value = Title;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateSubmission(int SubmissionId, string Content)
        {
            cmd = new SqlCommand("UpdateSubmission", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[2];

            paramss[0] = new SqlParameter("@id", SqlDbType.VarChar, (50));
            paramss[0].Value = SubmissionId;

            paramss[1] = new SqlParameter("@newcontent", SqlDbType.VarChar, (50));
            paramss[1].Value = Content;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteCourse(int courseId)
        {
            cmd = new SqlCommand("DeleteCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@id", SqlDbType.Int);
            paramss[0].Value = courseId;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteStudent(int StudentId)
        {
            cmd = new SqlCommand("DeleteStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@id", SqlDbType.Int);
            paramss[0].Value = StudentId;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteTeacher(int TeacherId)
        {
            cmd = new SqlCommand("DeleteTeacher", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];


            paramss[0] = new SqlParameter("@id", SqlDbType.Int);
            paramss[0].Value = TeacherId;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteGrade(int GradeId)
        {
            cmd = new SqlCommand("DeleteGrade", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@id", SqlDbType.VarChar, (50));
            paramss[0].Value = GradeId;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteHomework(int HomeworkId)
        {
            cmd = new SqlCommand("DeleteHomework", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@id", SqlDbType.Int);
            paramss[0].Value = HomeworkId;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteSubmission(int SubmissionId)
        {
            cmd = new SqlCommand("DeletetCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@id", SqlDbType.VarChar, (50));
            paramss[0].Value = SubmissionId;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
