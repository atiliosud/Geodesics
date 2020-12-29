using Geodesics.Domain.Entities;
using Geodesics.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geodesics.Domain.Interfaces
{
    public interface IDistanceService
    {
        double CalculateGeodesicCurve(DistancePoint point1, DistancePoint point2, MeasureUnit measureUnit);
        double DegreesToRadians(double degrees);
        double RadiansToDegrees(double radians);
        double GetEarthRadius(MeasureUnit measureUnit);
        double CalculatePythagoras(DistancePoint point1, DistancePoint point2, MeasureUnit measureUnit);
    }
}
