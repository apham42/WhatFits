using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DTOs.ContentDTOs;
using Whatfits.DataAccess.Gateways.ContentGateways;
using Xunit;

namespace Workout.Test
{
    public class GetWorkoutTest
    {
        WorkoutLogGateway test = new WorkoutLogGateway();

        [Fact]
        public void GetWorkouts()
        {
            List<WorkoutLogDTO> container = new List<WorkoutLogDTO>();
            container.AddRange(test.GetWorkouts("Latmay"));
            //container = test.GetWorkouts("Latmay").ToList<WorkoutLogDTO>();
            bool hasSomething = !container.Any();
            Assert.True(hasSomething);
        }
    }
}
