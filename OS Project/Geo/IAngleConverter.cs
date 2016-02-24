namespace NExtra.Geo
{

    public interface IAngleConverter
    {
        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        double ConvertDegreesToRadians(double degrees);

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        double ConvertRadiansToDegrees(double radians);
    }
}