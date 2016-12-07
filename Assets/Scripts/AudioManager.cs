using UnityEngine;
using System.Linq;

namespace Assets.Scripts
{ 
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        #region Public Fields
        //example sampling rates: 512s, 1024s, or 2048s.
        public int SampleCount;
        #endregion

        #region Properties 
        internal static float min { get; private set; } //min value of all points in spectrum array
        internal static float max { get; private set; } 
        private AudioSource source { get; set; }
        private static float[] spectrum { get; set; }
        #endregion

        #region Event Functions
        /// <summary>
        /// Initializes the audio source object 
        /// and array to store audio spectrum values
        /// </summary>
        private void Start()
        {
            source = GetComponent<AudioSource>();
            spectrum = new float[SampleCount];
        }

        /// <summary>
        /// Gets the current audio spectrum values 
        /// for the specified window size
        /// </summary>
        private void Update()
        {
            //source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
            source.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
            //min = spectrum.Min(m => m);
            //max = spectrum.Max(m => m);
        }
        #endregion

        #region Methods
        public static float GetSpectrumValue(int index)
        {
            return spectrum[index];
        }

        #endregion
    }

}
