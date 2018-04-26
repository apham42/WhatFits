using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whatfits.DataAccess.DataTransferObjects.CoreDTOs;
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
            UsernameDTO u = new UsernameDTO
            {
                Username = "asdf"
            };
            container.AddRange(test.GetWorkouts(u));
            //container = test.GetWorkouts("Latmay").ToList<WorkoutLogDTO>();
            bool hasSomething = !container.Any();
            Assert.True(hasSomething);
        }
    }
}
