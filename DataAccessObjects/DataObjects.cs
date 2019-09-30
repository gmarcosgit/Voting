using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using BusinessObjects;

namespace DataAccessObjects
{
    public class DataObjects
    {
        //public List<Students> GetStudents()
        //{
        //    var students = new List<Students>();
        //    var sb = new StringBuilder();

        //    sb.AppendLine("SELECT * from dbo.Students");

        //    using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
        //    {
        //        cmd.Connection.Open();

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                students.Add(new Students
        //                {
        //                    StudentNumber = reader["StudentNumber"].ToString(),
        //                    FirstName = reader["FirstName"].ToString(),
        //                    MI = reader["FirstName"].ToString(),
        //                    LastName = reader["LastName"].ToString(),
        //                    GradeLevel = reader["GradeLevel"].ToString(),
        //                    Section = reader["Section"].ToString(),
        //                    Gender = reader["Gender"].ToString(),
        //                    Voted = (bool)reader["Voted"],
        //                    DateTimeVoted = Convert.ToDateTime(reader["DateTimeVoted"])
        //                });
        //            }

        //        }
        //    }

        //    return students;
        //}
    }
}