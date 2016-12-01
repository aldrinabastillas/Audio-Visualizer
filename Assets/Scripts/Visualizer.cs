using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Visualizer : MonoBehaviour
{
    #region Public Fields
    public SpectrumController prefab;
    public float maxHeight; //currently 8000, previous 1024
    public int radius; //32, used in OnDrawGizmo(), not called yet
    public int maxItems; //currently 3000, previously 4000
    #endregion

    #region Private Fields
    //for the Lorenz System
    //see https://en.wikipedia.org/wiki/Lorenz_system

    //starting system state
    float x = 0.01f;
    float y = 1.0f;
    float z = 1.05f;

    //system parameters
    float sigma = 10;
    float rho = 28;
    float beta = (float)8.0 / 3.0f;
    #endregion

    void Start()
    {
        float dt = 0.01f;  //time step
        float dx = 0, dy = 0, dz = 0;

        for (int i = 0; i < maxItems; i++)
        {
            dx = (sigma * (y - x)) * dt;
            dy = (x * (rho - z) - y) * dt;
            dz = (x * y - beta * z) * dt;

            x = x + dx;
            y = y + dy;
            z = z + dz;

            var vector = new Vector3(x, y, z);
            GenerateTile(vector);
        }

    }

    /// <summary>
    /// Called for each vector created in Start()
    /// to create a new prefab object in that location
    /// </summary>
    /// <param name="vc2"></param>
    //void GenerateTile(Vector2 vc2)
    void GenerateTile(Vector3 vector)
    {
        var spawnedTile = (SpectrumController)Instantiate(prefab, vector, prefab.transform.rotation);
        //spawnedTile.maxHeight = (1+dist) * maxHeight;
        spawnedTile.maxHeight = maxHeight;
        //spawnedTile.spectrumIndex = (int)(Mathf.Round(dist/(float)radius * AudioManager.SampleCount));

        var length = vector.magnitude;
        spawnedTile.spectrumIndex = (int)(Mathf.Round(length));
    }

    /// <summary>
    /// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmos.html
    /// </summary>
    void OnDrawGizmos()
    {
        var c = Color.yellow;
        c.a = 0.2f;
        Gizmos.color = c;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}