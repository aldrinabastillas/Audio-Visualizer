using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Rotates the camera around a given axis at a given rotation rate
    /// </summary>
    public class CameraRotation : MonoBehaviour
    {
        #region Public Fields
        public Vector3 axis;
        public float rotationsPerSecond;
        #endregion;

        #region Event Functions
        void Update()
        {
            var angle = 360 * rotationsPerSecond * Time.deltaTime;
            transform.Rotate(axis, angle);
        }
        #endregion
    }
}