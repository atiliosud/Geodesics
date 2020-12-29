using Flunt.Notifications;
using Flunt.Validations;
using System;


namespace Geodesics.Domain.Entities
{
    public class DistancePoint:Notifiable
    {
        public DistancePoint(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            AddNotifications(
                ValidateMinLatitude(Latitude),
                ValidateMaxLatitude(latitude),
                ValidateMinLongitude(longitude),
                ValidateMaxLongitude(longitude)
                );

            if (Valid)
            {
                Latitude = latitude;
                Longitude = longitude;
            }
        }

        public double Latitude { get => Latitude; set => Latitude = value; }
        public double Longitude { get => Longitude; set => Longitude = value; }

        private Contract ValidateMinLatitude(double latitude) =>
            new Contract()
                .IsLowerOrEqualsThan(latitude, -90, nameof(latitude), "Latitude não deve ser menor que -90.");

        private Contract ValidateMaxLatitude(double latitude) =>
            new Contract()
                .IsGreaterThan(latitude, 90, nameof(latitude), "Latitude não deve ser maior que 90.");

        private Contract ValidateMinLongitude(double longitude) =>
            new Contract()
                .IsLowerOrEqualsThan(longitude, -180, nameof(longitude), "longitude não deve ser menor que -180.");

        private Contract ValidateMaxLongitude(double longitude) =>
            new Contract()
                .IsGreaterThan(longitude, 180, nameof(longitude), "longitude não deve ser maior que 180.");
    }
}
