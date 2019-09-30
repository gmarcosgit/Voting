using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using BusinessObjects;
using DataAccessObjects;

namespace DataAccessObjects
{
    public class StudentDAO
    {
        //public bool AddStudents(Students student)
        //{
        //    var sb = new StringBuilder();
        //    var result = 0;
        //    //var userInfo = GetUser(Students);

        //    sb.AppendLine("INSERT INTO dbo.Students (StudentNumber,FirstName,MI,LastName,GradeLevel,Section,Gender)");
        //    sb.AppendLine(string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", user.UserType, user.Name, user.LastName, user.UserName, user.Password, user.Position));

        //    using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
        //    {
        //        cmd.Connection.Open();
        //        result = cmd.ExecuteNonQuery();
        //    }
            
        //    return result > 0;
        //}
        public bool InsertStudent(Students student)
        {
            var sb = new StringBuilder();
            var result = 0;

            sb.AppendLine(
                "INSERT INTO dbo.Students (StudentNumber,FirstName,MI,LastName,GradeLevel,Section,Gender,Password) " +
                "VALUES (@StudentNumber,@FirstName,@MI,@LastName,@GradeLevel,@Section,@Gender,@Password)");

            using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
            {
                cmd.Connection.Open();

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@MI", student.MI);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@GradeLevel", student.GradeLevel);
                cmd.Parameters.AddWithValue("@Section", student.Section);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                //cmd.Parameters.AddWithValue("@Password", student.Password);

                result = cmd.ExecuteNonQuery();
                
            }
            return result > 0;
        }

        public List<Students> GetStudents()
        {
            var student = new List<Students>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * from dbo.Students");

            using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
            {
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        student.Add(new Students
                        {
                            StudentNumber = Convert.ToInt32(reader["StudentNumber"]),
                            FirstName = reader["FirstName"].ToString(),
                            MI = reader["MI"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            GradeLevel = Convert.ToInt32(reader["GradeLevel"]),
                            Section = reader["Section"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Voted = (bool)reader["Voted"],
                            DateTimeVoted = (DateTime)reader["DateTimeVoted"],
                            FullName = reader["FullName"].ToString(),
                            Password = (reader["Password"].ToString()),
                        });
                    }

                }
            }

            return student;
        }
        public List<Candidates> GetAllCandidates()
        {
            var candidates = new List<Candidates>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * from dbo.Candidates");

            using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
            {
                cmd.Connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        candidates.Add(new Candidates
                        {
                            StudentNumber = Convert.ToInt32(reader["StudentNumber"]),
                            FirstName = reader["FirstName"].ToString(),
                            MI = reader["MI"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            GradeLevel = Convert.ToInt32(reader["GradeLevel"]),
                            Section = reader["Section"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Position = reader["Position"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            SchoolYear = reader["SchoolYear"].ToString(),
                        });
                    }
                }
            }
            return candidates;
        }

        public bool InsertCandidateStudent(Candidates candidate)
        {
            var sb = new StringBuilder();
            var result = 0;

            sb.AppendLine(
                "INSERT INTO dbo.Candidates (StudentNumber,FirstName,MI,LastName,GradeLevel,Section,Gender,Position,SchoolYear) " +
                "VALUES (@StudentNumber,@FirstName,@MI,@LastName,@GradeLevel,@Section,@Gender,@Position,@SchoolYear)");

            using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
            {
                cmd.Connection.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@StudentNumber", candidate.StudentNumber);
                cmd.Parameters.AddWithValue("@FirstName", candidate.FirstName);
                cmd.Parameters.AddWithValue("@MI", candidate.MI);
                cmd.Parameters.AddWithValue("@LastName", candidate.LastName);
                cmd.Parameters.AddWithValue("@GradeLevel", candidate.GradeLevel);
                cmd.Parameters.AddWithValue("@Section", candidate.Section);
                cmd.Parameters.AddWithValue("@Gender", candidate.Gender);
                cmd.Parameters.AddWithValue("@Position", candidate.Position);
                cmd.Parameters.AddWithValue("@SchoolYear", candidate.SchoolYear);

                result = cmd.ExecuteNonQuery();
            }
            return result > 0;
        }

        public bool RemoveCandidate(Candidates candidates)
        {
            bool result = false;
            var sb = new StringBuilder();

            sb.AppendLine("DELETE FROM dbo.Candidates WHERE StudentNumber = @StudentNumber");

            using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
            {
                cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@StudentNumber", candidates.StudentNumber));

                result = cmd.ExecuteNonQuery() > 0;
                cmd.Connection.Close();
            }
            return result;
        }

        public bool ChangePic(byte[] pic, Candidates candidate)
        {
            //var userInfo = new User();
            var sb = new StringBuilder();
            var results = 0;

            sb.AppendLine("UPDATE dbo.Users SET Picture = (@IMG) WHERE StudentNumber = @StudentNumber");

            using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
            {
                cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@IMG", pic));
                cmd.Parameters.AddWithValue("@StudentNumber", candidate.StudentNumber);

                //using (var r = cmd.ExecuteReader())
                //{
                //    while (r.Read())
                //    {
                //        //candidate.F = r["Name"].ToString();
                //        //candidate.UserName = r["Username"].ToString();
                //        //candidate.Password = r["Password"].ToString();
                //    }
                //}

                results = cmd.ExecuteNonQuery();
            }
            return results > 0;
        }

        //public Students InsertCustomer(Students cust)
        //{
        //    var sb = new StringBuilder();

        //    sb.AppendLine("INSERT INTO dbo.CustomerInfo(Name,Age,Gender)");
        //    sb.AppendLine(string.Format("OUTPUT INSERTED.CustomerNumber VALUES ('{0}', '{1}', '{2}');", cust.FirstName, cust.Age, cust.Gender));

        //    using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
        //    {
        //        cmd.Connection.Open();
        //        cust.StudentNumber = (int)cmd.ExecuteScalar();
        //    }

        //    return cust;
        //}
    }
}