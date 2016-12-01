using UnityEngine;
using System.Collections;

public class SpectrumController : MonoBehaviour
{
    #region Public Fields
    public float maxHeight;
    public int spectrumIndex;
    public float responseSpeed = 32;
    #endregion

    #region Private Fields
    Vector3 scale;
    #endregion

    #region Private Methods
    void Start()
    {
        scale = transform.localScale;
    }

    void Update()
    {
        //update current height to height in AudioManager
        var desiredScale = 1 + AudioManager.spectrum[spectrumIndex] * maxHeight;
        scale.z = Mathf.Lerp(transform.localScale.z, desiredScale, Time.deltaTime * responseSpeed);
        transform.localScale = scale;
    }
    #endregion
}