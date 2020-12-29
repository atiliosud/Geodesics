using Geodesics.Domain.Entities;
using Geodesics.Domain.Enum;
using Geodesics.Domain.Interfaces;
using System;

namespace Geodesics.Service
{
    public class DistanceService : IDistanceService
    {
        public double CalculateGeodesicCurve(DistancePoint point1, DistancePoint point2, MeasureUnit measureUnit)
        {
            var a = Geodesics.Domain.Constants.Constants.PointOriginDegrees - point2.Latitude;
            var b = Geodesics.Domain.Constants.Constants.PointOriginDegrees - point1.Latitude;
            var fi = point1.Longitude - point2.Longitude;
            var cosP = Math.Cos(DegreesToRadians(a)) * Math.Cos(DegreesToRadians(b)) +
                       Math.Sin(DegreesToRadians(a)) * Math.Sin(DegreesToRadians(b)) * Math.Cos(DegreesToRadians(fi));
            var n = RadiansToDegrees(Math.Acos(cosP));
            var d = Math.PI * n * GetEarthRadius(measureUnit) / 180;
            return d;
        }

        public double CalculatePythagoras(DistancePoint point1, DistancePoint point2, MeasureUnit measureUnit)
        {
            var x = (DegreesToRadians(point2.Longitude) - DegreesToRadians(point1.Longitude)) *
                   Math.Cos((DegreesToRadians(point1.Latitude) + DegreesToRadians(point2.Latitude)) / 2);
            var y = DegreesToRadians(point2.Latitude) - DegreesToRadians(point1.Latitude);
            var d = Math.Sqrt(x * x + y * y) * GetEarthRadius(measureUnit);
            return d;
        }

        public double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / Geodesics.Domain.Constants.Constants.HalfCircleDegrees;
        }

        public double GetEarthRadius(MeasureUnit measureUnit)
        {
            switch (measureUnit)
            {
                case MeasureUnit.Km:
                    return 6371;
                case MeasureUnit.Mile:
                    return 3959;
                default:
                    throw new ArgumentOutOfRangeException(nameof(measureUnit));
            }
        }

        public double RadiansToDegrees(double radians)
        {
            return radians * Geodesics.Domain.Constants.Constants.HalfCircleDegrees / Math.PI;
        }
    }
}
