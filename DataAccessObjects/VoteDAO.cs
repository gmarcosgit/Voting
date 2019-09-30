using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class VoteDAO
    {
        public List<VoteData> GetAllVoteData(string position)
        {
            var votedata = new List<VoteData>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * from dbo.VoteData WHERE Position = @Position");

            using (var cmd = new SqlCommand(sb.ToString(), DBHelper.SQLConnection))
            {
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("Position", position);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        votedata.Add(new VoteData
                        {
                            StudentNumber = Convert.ToInt32(reader["StudentNumber"]),
                            FirstName = reader["FirstName"].ToString(),
                            MI = reader["MI"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            GradeLevel = Convert.ToInt32(reader["GradeLevel"]),
                            Section = reader["Section"].ToString(),
                            CandidateStudentNumber = Convert.ToInt32(reader["CandidateStudentNumber"]),
                            Position = reader["Position"].ToString(),
                            DateTimeVoted = (DateTime)reader["DateTimeVoted"],
                            FullName = reader["FullName"].ToString(),
                        });
                    }
                }
            }
            return votedata;
        }
    }
}
