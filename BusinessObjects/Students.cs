﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessObjects
{
    public class Students
    {
        public int StudentNumber { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string MI { get; set; }

        public string LastName { get; set; }

        public int GradeLevel { get; set; }

        public string Section { get; set; }

        public string Gender { get; set; }

        public bool Voted { get; set; }

        public DateTime DateTimeVoted { get; set; }

        public string Password { get; set; }

    }
}