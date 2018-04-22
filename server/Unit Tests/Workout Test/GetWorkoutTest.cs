//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Whatfits.DataAccess.DTOs.ContentDTOs;
//using Whatfits.DataAccess.Gateways.ContentGateways;
//using Xunit;

//namespace Workout.Test
//{
//    public class GetWorkoutTest
//    {
//        WorkoutLogGateway test = new WorkoutLogGateway();

//        [Fact]
//        public void GetWorkouts()
//        {
//            bool what = false;
//            IEnumerable<WorkoutLogDTO> container = new List<WorkoutLogDTO>();
//            container = test.GetWorkouts("amay");
//            if(container.Any())
//            {
//                what = true;
//            }
//            Assert.True(what);
//        }
//    }
//}
