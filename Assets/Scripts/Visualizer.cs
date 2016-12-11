using Assets.Patterns;
using UnityEngine;

namespace Assets.Scripts
{
	[RequireComponent(typeof(AudioSource))]
    public class Visualizer : MonoBehaviour
    {
        #region Public Fields
        public PrefabBehaviour prefab;
        public int maxHeight;
        public PatternType type;
		public int size; //Used as radius for Circle and maxPoints for Lorenz
        #endregion

        #region Properties
		/// <summary>
		/// Folder to organize prefabs under
		/// </summary>
        private GameObject folder { get; set; }
        #endregion

        #region Event Functions
		/// <summary>
		/// Creates prefabs in the given pattern
		/// </summary>
        void Start()
        {
			//Create pattern
            Pattern pattern = CreatePattern(type); //type selected from dropdown in Unity edtior
            
            //Create folder to file each prefab in
            folder = new GameObject(type.ToString() + " Prefabs (" + pattern.Count + ")");
            folder.transform.SetParent(transform);

            //Generate a prefab facing up and down at each point
            foreach (Vector3 point in pattern)
            {
                GeneratePrefab(point, maxHeight);
                GeneratePrefab(point, -1 * maxHeight);
            }
        }

        /// <summary>
        /// Close application if escape key is pressed
        /// </summary>
        void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates pattern of points for a specified PatternType.
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
            var prefab = (PrefabBehaviour)Instantiate(this.prefab, vector, this.prefab.transform.rotation);

			//sets up height, location, and color
			prefab.SetupPrefab (height, vector.magnitude);
            
            //file new prefab in folder
            prefab.transform.SetParent(folder.transform);
        }
        #endregion 
    }
}