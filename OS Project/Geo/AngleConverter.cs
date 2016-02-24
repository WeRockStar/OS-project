using System;

namespace NExtra.Geo
{

    public class AngleConverter : IAngleConverter
    {
        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        public double ConvertDegreesToRadians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        public double ConvertRadiansToDegrees(double radians)
        {
            return 180.0 * radians / Math.PI;
        }
    }
}
