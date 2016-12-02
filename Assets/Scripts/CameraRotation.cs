using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class CameraRotation : MonoBehaviour
    {
        #region Public Fields
        public Vector3 axis = Vector3.up;
        public float rotationsPerSecond = 0.5f;
        #endregion;

        #region Event Methods
        void Update()
        {
            var angle = 360 * rotationsPerSecond * Time.deltaTime;
            transform.Rotate(axis, angle);
        }
        #endregion
    }
}


