using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns
{
    public enum PatternType { Lorenz, Circle };
    
    /// <summary>
    /// Abstract base class that visualizer patters are derived from
    /// </summary>
    public abstract class Pattern : IEnumerable
    {
        #region Properties
        /// <summary>
        /// Points of where prefabs should go
        /// </summary>
        public List<Vector3> Points { get; protected set; }
        public int Size { get; protected set; }

        /// <summary>
        /// Count of points in pattern
        /// </summary>
        public int Count
        {
            get { return Points.Count; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Chained constructor that class that parameterless constructor below
        /// </summary>
        /// <param name="size"></param>
        public Pattern(int size) : this()
        {
            Size = size;
        }

        /// <summary>
        /// Constructor if you don't care about the size of Points
        /// </summary>
        public Pattern()
        {
            Points = new List<Vector3>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add points to the points array
        /// </summary>
        public virtual void AddPoints()
        {
        }

        /// <summary>
        /// Enumerate though Vector3[] points
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return Points.GetEnumerator();
        }
        #endregion

        #region Indexer
        /// <summary>
        /// Indexer into the array of points
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Vector3 this[int i]
        {
            get { return Points[i]; }
        }
        #endregion
    }
}