using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
   public class DataConstants
    {

        public static List<string> GradeLevel
        {
            get
            {
                return new List<string>
                {
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12"
                };
            }
        }
        public static List<string> Grade7Section
        {
            get
            {
                return new List<string>
                {
                    "St. Anthony",
                    "St. Jude",
                    "Service/Server",
                    "Others"

                };
            }
        }

        public static List<string> Position
        {
            get
            {
                return new List<string>
                {
                    "President",
                    "Vice-President",
                    "Secretary",
                    "Treasurer",
                    "Auditor",
                    "Business Manager",
                    "Public Information Officer"
                };
            }
        }
    }
}
