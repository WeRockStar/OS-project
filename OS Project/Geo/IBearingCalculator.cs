namespace NExtra.Geo
{

    public interface IBearingCalculator
    {
        /// <summary>
        /// Calculate the bearing between two positions.
        /// </summary>
        double CalculateBearing(Position position1, Position position2);
    }
}
