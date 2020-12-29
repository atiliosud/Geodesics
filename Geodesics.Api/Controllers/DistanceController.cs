using System;
using Geodesics.Domain.Entities;
using Geodesics.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Geodesics.Service;
using Geodesics.Domain.Interfaces;

namespace Geodesics.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistanceController : ControllerBase
    {

        private readonly IDistanceService _distanceService;

        public DistanceController(IDistanceService distanceService) =>
            _distanceService = distanceService;

        /// <summary>
        /// Retrieves the distance between the provided points.
        /// </summary>
        /// <response code="200">Distance successfully calculated.</response>
        /// <response code="400">Latitude or longitude of any of the given points is out of range.</response>
        /// <response code="500">Unexpected server exception.</response>
        [HttpGet]
        [Route("{distanceMethod}/{measureUnit}")]
        public ActionResult<DistanceResponse> Get(DistanceMethod distanceMethod, MeasureUnit measureUnit,
            [FromQuery] double point1Latitude, [FromQuery] double point1Longitude,
            [FromQuery] double point2Latitude, [FromQuery] double point2Longitude)
        {
            var point1 = new DistancePoint(point1Longitude, point1Latitude);
            var point2 = new DistancePoint(point2Longitude, point2Latitude);
            try
            {
                switch (distanceMethod)
                {
                    case DistanceMethod.GeodesicCurve:
                        return new ActionResult<DistanceResponse>(new DistanceResponse(_distanceService.CalculateGeodesicCurve(point1, point2, measureUnit)));
                    case DistanceMethod.Pythagoras:
                        return new ActionResult<DistanceResponse>(new DistanceResponse(_distanceService.CalculatePythagoras(point1, point2, measureUnit)));
                    default:
                        throw new ArgumentOutOfRangeException(nameof(distanceMethod), distanceMethod, null);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
