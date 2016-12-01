using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Visualizer : MonoBehaviour
{
    public SpectrumController prefab;
    public float maxHeight = 1024;
    public int radius = 32;

    //List<Vector2> generationList = new List<Vector2>();
    List<Vector3> generationList = new List<Vector3>();

    float x = 0.01f;
    float y = 1.0f;
    float z = 1.05f;

    float a = 10;
    float b = 28;
    float c = (float)8.0 / 3.0f;

    void Start()
    {
        float dt = 0.01f;
        float dx = 0, dy = 0, dz = 0;

        for(int i = 0; i < 4000; i++) { 
            dx = (a * (y - x)) * dt;
            dy = (x * (b - z) - y) * dt;
            dz = (x * y - c * z) * dt;

            x = x + dx;
            y = y + dy;
            z = z + dz;

            var vector = new Vector3(x, y, z);
            GenerateTile(vector);
            generationList.Add(vector);
        }



        //var radiusSq = radius * radius;
        //for (int y = -radius; y < radius; y++)
        //{
        //    for (int x = -radius; x < radius; x++)
        //    {
        //        var p = new Vector2(x, y);
        //        if (p.sqrMagnitude < radiusSq) //creates a circle of blocks
        //        {
        //            GenerateTile(p);
        //            //generationList.Add(p);
        //        }
        //    }
        //}

        //StartCoroutine("Generate");
    }

    /// <summary>
    /// Called by StartCoroutine in Start()
    /// </summary>
    //void Generate()
    //{
    //    Vector2 currentVector;

    //    //randomly iterates through list of blocks made in Start() 
    //    // and generates a tile
    //    while (generationList.Count != 0)
    //    {
    //        //for (var i = 0; i < 10; ++i) {
    //        currentVector = generationList[Random.Range(0, generationList.Count)];
    //        GenerateTile(currentVector);
    //        generationList.Remove(currentVector);
    //    }
    //}

    /// <summary>
    /// Called by Generate()
    /// </summary>
    /// <param name="vc2"></param>
    //void GenerateTile(Vector2 vc2)
    void GenerateTile(Vector3 pos)
    {
        // change the vc2 to vc3 and move it to the center
        //Vector3 pos = new Vector3(vc2.x, -maxHeight, vc2.y);
        //Vector3 pos = new Vector3(vc2.x, 0, vc2.y);
        var dist = pos.magnitude;
        //var dist = vc2.magnitude;

        var spawnedTile = (SpectrumController)Instantiate(prefab, pos, prefab.transform.rotation);
        //spawnedTile.maxHeight = (1+dist) * maxHeight;
        spawnedTile.maxHeight = maxHeight;
        //spawnedTile.spectrumIndex = (int)(Mathf.Round(dist/(float)radius * AudioManager.SampleCount));
        spawnedTile.spectrumIndex = (int)(Mathf.Round(dist));
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