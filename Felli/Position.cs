namespace Felli
{
    /// <summary>
    /// 
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// Gets the value of X position
        /// </summary>
        /// <value> Value of X position </value>
        public int X { get; }
        
        /// <summary>
        /// Gets the value of the Y position
        /// </summary>
        /// <value> Value of Y position </value>
        public int Y { get; }

        /// <summary>
        /// Constructor to define a new position
        /// </summary>
        /// <param name="x"> Value of X position </param>
        /// <param name="y"> Value of Y position </param>
        public Position(int x, int y)
        {
            // Value in the X axis
            X = x;

            // Value in the Y axis
            Y = y;
        }

        /// <summary>
        /// Returns the default equality factor
        /// </summary>
        /// <param name="obj"> The object to be compared with </param>
        /// <returns> Returns if the equality is true </returns>
        public override bool Equals(object obj) => base.Equals(obj);
        

        /// <summary>
        /// Gets the has code of the object
        /// </summary>
        /// <returns> Returns the specific hash code of the object </returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Compares position values
        /// </summary>
        /// <param name="left"> First given position </param>
        /// <param name="right"> Second given position </param>
        /// <returns> Returns true if the positions are equal </returns>
        public static bool operator ==(Position left, Position right) 
            => left.X == right.X && left.Y == right.Y;

        /// <summary>
        /// Compares position values
        /// </summary>
        /// <param name="left"> First given position </param>
        /// <param name="right"> Second given position </param>
        /// <returns> Returns true if the positions aren't equal </returns>
        public static bool operator !=(Position left, Position right) 
            => !(left == right);

        /// <summary>
        /// Adds the values to the position
        /// </summary>
        /// <param name="pos"> Provided position </param>
        /// <returns> Returns a new position </returns>
        public static Position operator +(Position pos, (int, int) add) 
            => new Position(pos.X + add.Item1, pos.Y + add.Item2);
    }
}