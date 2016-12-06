using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Behaviors for each prefab, like update size to music
    /// </summary>
    public class SpectrumController : MonoBehaviour
    {
        #region Public Fields
        public float responseSpeed; //set to 20 
        #endregion

        #region Internal Fields
        //Used in Visualizer.GeneratePrefab()
        internal float maxHeight;
        internal int spectrumIndex;
        #endregion  

        #region Private Fields
        private Vector3 startScale;
        private Color startColor;
        #endregion

        #region Event Functions
        private void Start()
        {
            startScale = transform.localScale;
            startColor = GetComponent<Renderer>().material.color;
        }

        private void Update()
        {
            //scale to max value in the current spectrum window and given max height of prefab
            var desiredScale = 1 + AudioManager.GetSpectrumValue(spectrumIndex) * maxHeight;
            //UpdateSize(desiredScale);
            UpdateHeight(desiredScale);
            UpdateColor(desiredScale);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update height for blocks
        /// </summary>
        private void UpdateHeight(float scale)
        {
            //update current height to height in AudioManager
            startScale.z = Mathf.Lerp(transform.localScale.z, scale, Time.deltaTime * responseSpeed);
            transform.localScale = startScale;
        }

        /// <summary>
        /// Update size in all 3 dimensions for sphere 
        /// </summary>
        private void UpdateSize(float scale)
        {
            transform.localScale = new Vector3(scale + startScale.x, scale + startScale.y, scale + startScale.z);
        }

        /// <summary>
        /// Playing around with color code
        /// </summary>
        private void UpdateColor(float scale)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.Lerp(startColor, Color.blue * Mathf.Abs(scale), Time.deltaTime);
        }
        #endregion
    }
}


