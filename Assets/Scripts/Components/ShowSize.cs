using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSize : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {

        x = meshFilter.mesh.bounds.size.x;
        y = meshFilter.mesh.bounds.size.y;
        z = meshFilter.mesh.bounds.size.z;
    }
}
