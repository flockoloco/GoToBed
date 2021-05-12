using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationMenu : MonoBehaviour
{
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        var verts = mesh.vertices;
        for(int i = 0; i < 2; i++)
        {
            var orig = verts[i];
            verts[i] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) + 10f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
