using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LineBehavior : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector2> vertices;

    public Material material;
    public LineType lineType;

    public void Start()
    {

    }

    
    public void addVertex(Vector2 vertex)
    {
        //update list of vertices
        vertices.Add(vertex);

        //update linerenderer
        lineRenderer.SetVertexCount(vertices.Count);
        List<Vector3> vertices3 = new List<Vector3>();
        foreach (Vector2 selectedVertex in vertices)
        {
            vertices3.Add(MiscHelperFuncs.convertToVec3(selectedVertex));
        }
        lineRenderer.SetPositions(vertices3.ToArray());

        //add new edge collider

        if (vertices.Count > 1)
        {
            EdgeCollider2D newCollider = gameObject.AddComponent<EdgeCollider2D>();
            newCollider.points = new Vector2[] { vertices[vertices.Count - 2], vertex };
        }
    }

    public void setupLine()
    {
        vertices = new List<Vector2>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(0);
        lineRenderer.SetWidth(0.1f, 0.1f);
        lineRenderer.material = material;
    }
}
