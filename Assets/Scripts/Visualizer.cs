using Assets.Patterns;
using UnityEngine;

namespace Assets.Scripts
{
    public class Visualizer : MonoBehaviour
    {
        #region Public Fields
        public SpectrumController prefab;
        public int maxHeight;
        public PatternType type;
        public int size = 3000; //Radius for Circle, maxPoints for Lorenz
        #endregion

        #region Properties
        private GameObject folder { get; set; }
        #endregion

        #region Event Functions
        void Start()
        {
            //Create pattern
            Pattern pattern = CreatePattern(type);
            
            //Create top folder for each prefab
            folder = new GameObject(type.ToString() + " Prefabs (" + pattern.Count + ")");
            folder.transform.SetParent(transform);

            //Generate a prefab facing up and down at each point
            foreach (Vector3 point in pattern)
            {
                GeneratePrefab(point, maxHeight);
                GeneratePrefab(point, -1 * maxHeight);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates pattern of a specified type
        /// Default is a Lorenz system
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private Pattern CreatePattern(PatternType type)
        {
            switch (type)
            {
                case PatternType.Circle:
                    {
                        int radius = (size <= 40) ? size : 40;
                        Circle circle = new Circle(radius);
                        circle.AddPoints();
                        return circle;
                    }
                case PatternType.Lorenz:
                    goto default; //can't fall through in C# Mono
                default:
                    {
                        //see https://en.wikipedia.org/wiki/Lorenz_system
                        Lorenz lorenz = new Lorenz(size);
                        lorenz.SetState(1f, 1f, 1f);
                        lorenz.SetParameters(10, 28, 8 / 3, 0.01f);
                        lorenz.AddPoints();
                        return lorenz;
                    }
            }
        }

        /// <summary>
        /// Called for each vector created in Start() to create a new prefab object in that location
        /// </summary>
        /// <param name="vector"></param>
        private void GeneratePrefab(Vector3 vector, int height)
        {
            var prefab = (SpectrumController)Instantiate(this.prefab, vector, this.prefab.transform.rotation);
            prefab.maxHeight = height;

            //set location in audio spectrum window based on vector magnitude
            var length = vector.magnitude;
            prefab.spectrumIndex = (int)(Mathf.Round(length));

            //prefab.spectrumIndex = count;
            //prefab.spectrumIndex = (int)(Mathf.Round(dist/(float)radius * AudioManager.SampleCount));
            //prefab.spectrumIndex = (int)Vector3.Distance(new Vector3(.01f, 1, 1.05f), vector);

            //set starting color based on vector magnitude
            prefab.GetComponent<Renderer>().material.color = new Color(0, length % 1, length % 1, 0.5f);
            
            //file new prefab in folder
            prefab.transform.SetParent(folder.transform);
        }
        #endregion 
    }
}

