using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class InputInterpreter : MonoBehaviour {
    public float lineDetail;

    private float timeSinceLastVertex;
    private LineManager lineManager;
    private GraphicRaycaster mainMenuGR;
    //private GraphicRaycaster respawnGR;

    private bool overMenu;
    private Vector2 originalPosition;

    // Use this for initialization
    void Start () {
        timeSinceLastVertex = 0;
        mainMenuGR = GameObject.FindGameObjectWithTag("Main Menu").GetComponentInChildren<GraphicRaycaster>();
        //respawnGR = GameObject.FindGameObjectWithTag("RespawnPoint").GetComponentInChildren<GraphicRaycaster>();
        lineManager = GetComponent<LineManager>();
        originalPosition = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void Update () {

        //Menu Hover Checker
        overMenu = overMenus();
        
        //Line drawing input
        if (Input.GetButtonDown("draw") && !overMenu)
        {
            lineManager.startNewLine(LineType.Normal);
        }

        if (Input.GetButton("draw"))
        {
            if (overMenu)
            {
                lineManager.saveLine();
            }
            timeSinceLastVertex += Time.deltaTime;
        }
        else
        {
            timeSinceLastVertex = 0;
        }
        
        if (timeSinceLastVertex > lineDetail && !overMenu)
        {
            if (lineManager.isLineNull())
            {
                lineManager.startNewLine(LineType.Normal);
            }
            lineManager.addVertext(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            timeSinceLastVertex = 0;
        }
        

        if (Input.GetButtonUp("draw"))
        {
            lineManager.saveLine();
        }

        //Camera Controls
        if (Input.GetButtonDown("dragCamera"))
        {
            originalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetButton("dragCamera"))
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 difference = originalPosition - newPosition;
            Camera.main.transform.Translate(difference);
        }

        if (Input.GetAxis("MouseScrollWheel") < 0)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + WorldVariables.MOUSE_SCROLL_CONSTANT;
        }
        if (Input.GetAxis("MouseScrollWheel") > 0)
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize - WorldVariables.MOUSE_SCROLL_CONSTANT;
        }
    }

    private bool overMenus()
    {
        PointerEventData ped = new PointerEventData(null);
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();

        mainMenuGR.Raycast(ped, results);
        if (results.Count > 0)
        {
            return true;
        }

        results = new List<RaycastResult>();

        /*respawnGR.Raycast(ped, results);
        if(results.Count > 0)
        {
            return true;
        }
        */
        return Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0,0,1), 20);
        
    }
}
