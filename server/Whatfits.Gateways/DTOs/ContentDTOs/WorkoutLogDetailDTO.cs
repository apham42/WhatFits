using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.Models.Interfaces;

namespace Whatfits.DataAccess.DTOs.ContentDTOs
{
    public class WorkoutLogDetailDTO
    {
        public string WorkoutType { get; set; }
        public string Date_Time { get; set; }

        public string CardioType { get; set; }
        public double Distance { get; set; }
        public string Time { get; set; }

        public string LiftingType { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
