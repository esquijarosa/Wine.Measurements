using Wine.Measurements.Common.Data;
using Wine.Measurements.Common.Models;

namespace Wine.Measurements.Common.Extesions;

internal static class ValidationExtensions
{
    internal static void ValidateUser(this IUserRepository _, User user)
    {
        if (user == null) throw new ArgumentNullException("user");

        if (Guid.Empty.Equals(user.UserId)) throw new ArgumentException("UserId");

        if (string.IsNullOrWhiteSpace(user.UserName)) throw new ArgumentException("UserName");

        if (string.IsNullOrWhiteSpace(user.PasswordHash)) throw new ArgumentException("PasswordHash");

        if (string.IsNullOrWhiteSpace(user.FullName)) throw new ArgumentException("FullName");
    }

    internal static void ValidateLoginData(this IUserRepository _, string userName, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentException(userName);

        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException(passwordHash);
    }

    internal static void ValidateMeasurement(this IMeasurementsRepository _, Measurement measurement)
    {
        if (measurement == null) throw new ArgumentNullException("measurement");

        if (measurement.Year <= 0) throw new ArgumentException("Year");

        if (measurement.VarietyId <= 0) throw new ArgumentException("Variety");

        if (measurement.TypeId <= 0) throw new ArgumentException("Type");

        if (measurement.Graduation < 0) throw new ArgumentException("Graduation");

        if (measurement.PH <= 0) throw new ArgumentException("PH");

        if (string.IsNullOrWhiteSpace(measurement.Color)) throw new ArgumentException("Color");

        if (string.IsNullOrWhiteSpace(measurement.RecordedBy)) throw new ArgumentException("RecordedBy");
    }
}
