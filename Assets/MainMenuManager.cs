using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnLevelSelect(int level)
    {
        Debug.Log("Level " + level);
        Application.LoadLevel("Level " + level);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
