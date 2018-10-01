// Code grabbed from https://docs.unity3d.com/2017.3/Documentation/ScriptReference/MeshFilter-sharedMesh.html
// The code helped me to understand how sharing the mesh data works in Unity
// I removed the code responsible for scaling my meshes permanetly as proof of concept
// because that scares me.

using UnityEngine;
using System.Collections;

public class SharedMesh : MonoBehaviour
{
    //public float scaleFactor = 2;
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;
        //int p = 0;
        //while (p < vertices.Length)
        //{
        //    p++;
        //}
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}