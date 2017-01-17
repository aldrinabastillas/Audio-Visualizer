namespace Assets.Patterns
{
    public class PatternFactory
    {
        /// <summary>
        /// Creates pattern of points for a specified PatternType.
        /// Default is a Lorenz system
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Pattern CreatePattern(PatternType type, int size)
        {
            switch (type)
            {
                case PatternType.Circle:
                    {
                        return new Circle(size);
                    }
                case PatternType.Lorenz:
                    goto default; //can't fall through cases in Mono/Unity C#
                default:
                    {
                        //see https://en.wikipedia.org/wiki/Lorenz_system
                        Lorenz lorenz = new Lorenz(size);
                        //don't encapsulate below in the constructor as you wouldn't be able
                        //to customize the Lorenz object
                        lorenz.SetState(1f, 1f, 1f); //x, y, z
                        lorenz.SetParameters(10, 28, 8 / 3, 0.01f); //sigma, rho, beta, dTime
                        lorenz.AddPoints();
                        return lorenz;
                    }
            }
        }
    }
}
