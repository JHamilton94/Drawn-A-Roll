using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineManager : MonoBehaviour {

    private List<GameObject> lines;
    public GameObject newLine;
    private LineBehavior newLineBehavior;

    public GameObject linePrefab;

    // Use this for initialization
    void Start () {
        lines = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void addVertext(Vector2 newVert)
    {
        newLineBehavior.addVertex(newVert);
    }

    public void clearLines()
    {
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
        lines.Clear();
    }

    public void startNewLine(LineType lineType)
    {
        newLine = (GameObject)Instantiate(linePrefab);

        newLineBehavior = newLine.GetComponent<LineBehavior>();
        newLineBehavior.setupLine();
    }

    public void saveLine()
    {
        lines.Add(newLine);
        newLine = null;
    }

    public bool isLineNull()
    {
        if (newLine == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnDrawGizmos()
    {
        
    }
}
