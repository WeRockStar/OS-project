namespace NExtra.Geo
{

    public interface IRhumbBearingCalculator
    {
        /// <summary>
        /// Calculate the rhumb bearing between two positions.
        /// </summary>
        double CalculateRhumbBearing(Position position1, Position position2);
    }
}
