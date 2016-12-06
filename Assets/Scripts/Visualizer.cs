using Assets.Patterns;
using UnityEngine;

namespace Assets.Scripts
{
    public class Visualizer : MonoBehaviour
    {
        #region Public Fields
        public SpectrumController prefab;
        public int maxHeight;
        public int maxItems; 
        #endregion

        #region Properties
        private GameObject folder { get; set; }
        #endregion

        #region Event Functions
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
                GeneratePrefab(point, maxHeight);
                GeneratePrefab(point, -1 * maxHeight);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called for each vector created in Start() to create a new prefab object in that location
        /// </summary>
        /// <param name="vector"></param>
        void GeneratePrefab(Vector3 vector, int height)
        {
            var prefab = (SpectrumController)Instantiate(this.prefab, vector, this.prefab.transform.rotation);
            prefab.maxHeight = height;

            var length = vector.magnitude;
            prefab.spectrumIndex = (int)(Mathf.Round(length));
            prefab.GetComponent<Renderer>().material.color = new Color(0, length, length, 0.5f);
            //prefab.spectrumIndex = (int)(Mathf.Round(dist/(float)radius * AudioManager.SampleCount));
            //prefab.spectrumIndex = (int)Vector3.Distance(new Vector3(.01f, 1, 1.05f), vector);

            //file new prefab in folder
            prefab.transform.SetParent(folder.transform);
        }
        #endregion 
    }
}

