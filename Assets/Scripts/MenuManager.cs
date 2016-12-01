using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Button reset;
    public Button start;
    public Button mainMenu;

    private LineManager lineManager;
    private RespawnPointBehavior respawnPoint;

    public void Start()
    {
        lineManager = GameObject.FindGameObjectWithTag("LineManager").GetComponent<LineManager>();
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint").GetComponent<RespawnPointBehavior>();
    }

    public void FixedUpdate()
    {
        if (WorldVariables.gameState == GameState.Win)
        {
            displayWinScreen();
        }
    }

    public void OnStart()
    {
        WorldVariables.gameState = GameState.Play;
        start.gameObject.SetActive(false);
        reset.gameObject.SetActive(true);
    }

    public void OnReset()
    {
        WorldVariables.gameState = GameState.Setup;
        start.gameObject.SetActive(true);
        reset.gameObject.SetActive(false);
    }

    public void OnMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void OnClear()
    {
        lineManager.clearLines();
    }

    public void OnCenter()
    {
        Camera.main.transform.position = respawnPoint.respawnLocation;
        Camera.main.transform.position += new Vector3(0,0,-10);
    }

    public void displayWinScreen()
    {

    }
    
}
