﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class SecurityAnswers
    {
        public SecurityAnswers()
        {

        }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public string[] Answer { get; set; }
    }
}