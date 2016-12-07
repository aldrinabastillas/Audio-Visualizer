using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Behaviors for each prefab: update size and color to music
    /// </summary>
    public class SpectrumController : MonoBehaviour
    {
        #region Public Fields
        public float responseSpeed;
        #endregion

        #region Private Fields
        private Vector3 startScale;
        #endregion

        #region Properties
        internal float maxHeight { get; set; }
        internal int spectrumIndex { get; set; }
        private Color startColor { get; set; }
        private MeshFilter startMesh { get; set; }
        #endregion

        #region Event Functions
        private void Start()
        {
            startScale = transform.localScale;
            startColor = GetComponent<Renderer>().material.color;
            startMesh = GetComponent<MeshFilter>();
        }

        private void Update()
        {
            //scale current spectrum window and given maxHeight of prefab
            var desiredScale = 1 + AudioManager.GetSpectrumValue(spectrumIndex) * maxHeight;
            //var desiredScale = AudioManager.GetSpectrumValue(spectrumIndex) / AudioManager.max * maxHeight;

            if (startMesh.name.Contains("Cylinder"))
            {
                UpdateCylinderHeight(desiredScale);
            }
            else if (startMesh.name.Contains("Cube"))
            {
                UpdateCubeHeight(desiredScale);
            }
            else
            {
                UpdateSize(desiredScale);
            }

            UpdateColor(desiredScale);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update height for cubes in z dimension
        /// </summary>
        private void UpdateCubeHeight(float scale)
        {
            //update current height to height in AudioManager
            startScale.z = Mathf.Lerp(transform.localScale.z, scale, Time.deltaTime * responseSpeed);
            transform.localScale = startScale;
        }

        /// <summary>
        /// Update height for cylinders in y dimension
        /// </summary>
        private void UpdateCylinderHeight(float scale)
        {
            //update current height to height in AudioManager
            startScale.y = Mathf.Lerp(transform.localScale.y, scale, Time.deltaTime * responseSpeed);
            transform.localScale = startScale;
        }

        /// <summary>
        /// Update size in all 3 dimensions
        /// </summary>
        private void UpdateSize(float scale)
        {
            transform.localScale = new Vector3(scale + startScale.x, scale + startScale.y, scale + startScale.z);
        }

        /// <summary>
        /// Interpolate color from starting color to shade of blue
        /// </summary>
        private void UpdateColor(float scale)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = Color.Lerp(startColor, Color.blue * Mathf.Abs(scale), Time.deltaTime);
        }
        #endregion
    }
}


