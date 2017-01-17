using UnityEngine;

namespace Assets.Patterns
{
    public class Circle : Pattern
    {
        #region Properties
        private int MaxRadius = 40;
        #endregion

        #region Constructor
        public Circle(int radius) : base()
        {
            Size = (radius <= MaxRadius) ? radius : MaxRadius;
            AddPoints();
        }
        #endregion

        #region Methods
        /// <summary>
        // Adds a vector to the Points list (in the base class) for each coordinate
        /// </summary>
        public override void AddPoints()
        {
            int radius = this.Size;
            for (int x = -1 * radius; x <= radius; x++)
            {
                for (int z = -1 * radius; z <= radius; z++)
                {
                    var point = new Vector3(x, 0, z);
                    //only generate point if within radius of circle
                    if (point.sqrMagnitude < Mathf.Pow(radius, 2)) 
                    {
                        Points.Add(point);
                    }
                }
            }
        }
        #endregion
    }
}
