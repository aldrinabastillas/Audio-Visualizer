using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Patterns
{
    //see https://en.wikipedia.org/wiki/Lorenz_system
    public class Lorenz : IEnumerable
    {
        #region Private Properties
        private Vector3[] points { get; set; }

        //starting system state
        private float x { get; set; }
        private float y { get; set; }
        private float z { get; set; }

        //system parameters
        private float sigma { get; set; }
        private float rho { get; set; }
        private float beta { get; set; }
        private float dt { get; set; }
        #endregion

        #region Constructor 
        public Lorenz(int numPoints)
        {
            points = new Vector3[numPoints];
        }
        #endregion

        #region Public Builder Methods
        /// <summary>
        /// Coordinates for the starting state
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void SetState(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sigma"></param>
        /// <param name="rho"></param>
        /// <param name="beta"></param>
        /// <param name="dt"></param>
        public void SetParameters(float sigma, float rho, float beta, float dt)
        {
            this.sigma = sigma;
            this.rho = rho;
            this.beta = beta;
            this.dt = dt;
        }

        /// <summary>
        /// Adds to Vector3[] points for each coordinate
        /// </summary>
        public void AddPoints()
        {
            float dx = 0, dy = 0, dz = 0;

            for (int i = 0; i < points.Length; i++)
            {
                dx = (sigma * (y - x)) * dt;
                dy = (x * (rho - z) - y) * dt;
                dz = (x * y - beta * z) * dt;

                x = x + dx;
                y = y + dy;
                z = z + dz;

                points[i] = new Vector3(x, y, z);
            }
        }

        /// <summary>
        /// Enumerate though Vector3[] points
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return points.GetEnumerator();
        }
        #endregion
    }
}
