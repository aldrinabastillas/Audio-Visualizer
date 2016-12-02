using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class SpectrumController : MonoBehaviour
    {
        #region Public Fields
        public float maxHeight;
        public int spectrumIndex;
        public float responseSpeed = 32;
        #endregion

        #region Private Fields
        Vector3 scale;
        float lastUpdateFrame = 0F;
        int switchNum = 0;
        #endregion

        #region Event Methods
        void Start()
        {
            scale = transform.localScale;
        }

        void Update()
        {
            UpdateHeight();
            //UpdateColor();
        }
        #endregion

        #region Private Methods
        void UpdateHeight()
        {
            //update current height to height in AudioManager
            var desiredScale = 1 + AudioManager.spectrum[spectrumIndex] * maxHeight;
            scale.z = Mathf.Lerp(transform.localScale.z, desiredScale, Time.deltaTime * responseSpeed);
            transform.localScale = scale;
        }

        void UpdateColor()
        {
            Renderer rend = GetComponent<Renderer>();
            float framePerTransition = 60;
            if (Time.frameCount - lastUpdateFrame == framePerTransition)
            {
                if(switchNum % 2 == 0)
                {
                    rend.material.color = Color.Lerp(Color.blue, Color.green, Time.deltaTime * framePerTransition);
                }
                else
                {
                    rend.material.color = Color.Lerp(Color.green, Color.blue, Time.deltaTime * framePerTransition);
                }
                switchNum++;
                lastUpdateFrame += framePerTransition;
            }
        }
        #endregion
    }
}


