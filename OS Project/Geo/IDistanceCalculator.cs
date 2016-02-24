namespace NExtra.Geo
{

    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculate the distance between two positions.
        /// </summary>
        double CalculateDistance(Position position1, Position position2, DistanceUnit distanceUnit);
    }
}
