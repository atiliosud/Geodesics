using System;

namespace Geodesics.Domain.Entities
{
    public class DistanceResponse
    {

        public DistanceResponse(double distance)
        {
            Distance = distance;
        }

        public double Distance { get => Distance; set => Distance = value; }
    }
}
