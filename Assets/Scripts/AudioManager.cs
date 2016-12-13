using UnityEngine;

namespace Assets.Scripts
{ 
	/// <summary>
	/// Gets audio's spectrum data from an AudioSource component
	/// and saves it to an array the size of a given sample rate
	/// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        #region Fields
		/// <summary>
		/// The size of the spectrum window.
		/// Example sampling rates: 512, 1024, or 2048 samples/second.
		/// </summary>
        public int SampleRate;
        #endregion

        #region Properties
		/// <summary>
		/// AudioSource component in Unity editor
		/// </summary>
        private AudioSource source { get; set; }

		/// <summary>
		/// The sampling window where the audio values are stored
		/// </summary>
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
            spectrum = new float[SampleRate];
        }

        /// <summary>
        /// Gets the current audio spectrum values 
        /// for the specified window size
        /// </summary>
        private void Update()
        {
            source.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        }
        #endregion

        #region Methods
		/// <summary>
		/// Returns audio spectrum value at specified index in window
		/// </summary>
        public static float GetSpectrumValue(int index)
        {
			if (index >= 0 && index < spectrum.Length) {
				return spectrum [index];
			} else {
				return 0f;
			}
        }
        #endregion
    }
}