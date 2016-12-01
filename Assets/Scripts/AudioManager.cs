using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    #region Public Field Parameters
    // feel free to change the sampling (1024s) to 512s or 2048s.
    //public const int SampleCount = 2048;
    public int SampleCount = 1024;
    #endregion

    #region Public Static Fields
    public static float[] spectrum;
    //public static float[] spectrum = new float[SampleCount];
    //public static float[] spectrum2= new float[SampleCount];ion
    #endregion

    #region Private Fields
    AudioSource source;
    #endregion

    #region Private Methods
    /// <summary>
    /// Initializes the audio source object 
    /// and array to store audio spectrum values
    /// </summary>
    void Start()
    {
        source = GetComponent<AudioSource>();
        spectrum = new float[SampleCount];
    }

    /// <summary>
    /// Gets the current audio spectrum value
    /// </summary>
    void Update()
    {
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        //source.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        //source.GetOutputData(spectrum, 0);
        //source.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
    }
    #endregion
}
