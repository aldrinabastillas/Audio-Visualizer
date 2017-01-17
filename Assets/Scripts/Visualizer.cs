using Assets.Patterns;
using UnityEngine;

namespace Assets.Scripts
{
	[RequireComponent(typeof(AudioSource))]
    public class Visualizer : MonoBehaviour
    {
        #region Fields
        public PrefabBehaviour prefab;
        public PatternType type;
        public int maxHeight;
		public int size; //Used as radius for Circle and maxPoints for Lorenz
        public float responseSpeed;
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
			//Create Pattern using PatternFactory class
            Pattern pattern = PatternFactory.CreatePattern(type, size); //type selected from dropdown in Unity editor
            
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
        /// Called for each vector created in Start() to create a new prefab object in that location
        /// </summary>
        /// <param name="vector"></param>
        private void GeneratePrefab(Vector3 vector, int height)
        {
            var prefab = (PrefabBehaviour)Instantiate(this.prefab, vector, this.prefab.transform.rotation);

			//sets up height, location, and color
			prefab.SetupPrefab(height, vector.magnitude, responseSpeed);
            
            //file new prefab in folder
            prefab.transform.SetParent(folder.transform);
        }
        #endregion 
    }
}