using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Assets.Patterns;

namespace Assets.Scripts
{
    public class Visualizer : MonoBehaviour
    {
        #region Public Fields
        public SpectrumController prefab;
        public float maxHeight; //currently 8000, previous 1024
        public int radius; //32, used in OnDrawGizmo(), not called yet
        public int maxItems; //currently 3000, previously 4000
        #endregion

        #region Private Fields
        private GameObject folder;
        #endregion

        #region Event Methods
        void Start()
        {
            //see https://en.wikipedia.org/wiki/Lorenz_system
            //starting system state
            float x = 0.01f;
            float y = 1.0f;
            float z = 1.05f;

            //system parameters
            float sigma = 10;
            float rho = 28;
            float beta = (float)8.0 / 3.0f;
            float dt = 0.01f;

            Lorenz lorenz = new Lorenz(maxItems);
            lorenz.SetState(x, y, z);
            lorenz.SetParameters(sigma, rho, beta, dt);
            lorenz.AddPoints();

            //Create top folder for each prefab
            folder = new GameObject("Lorenz Prefabs (" + maxItems + ")");
            folder.transform.SetParent(transform);

            //Generate prefab at each point
            foreach(Vector3 point in lorenz)
            {
                GeneratePrefab(point);
            }
        }

        /// <summary>
        /// Isn't currently getting called
        /// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmos.html
        /// </summary>
        void OnDrawGizmos()
        {
            var c = Color.yellow;
            c.a = 0.2f;
            Gizmos.color = c;

            Gizmos.DrawWireSphere(transform.position, radius);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Called for each vector created in Start()
        /// to create a new prefab object in that location
        /// </summary>
        /// <param name="vc2"></param>
        void GeneratePrefab(Vector3 vector)
        {
            var spawnedTile = (SpectrumController)Instantiate(prefab, vector, prefab.transform.rotation);
            //spawnedTile.maxHeight = (1+dist) * maxHeight;
            spawnedTile.maxHeight = maxHeight;
            //spawnedTile.spectrumIndex = (int)(Mathf.Round(dist/(float)radius * AudioManager.SampleCount));

            var length = vector.magnitude;
            spawnedTile.spectrumIndex = (int)(Mathf.Round(length));

            //file new prefab in folder
            spawnedTile.transform.SetParent(folder.transform);
        }
        #endregion 
    }
}

