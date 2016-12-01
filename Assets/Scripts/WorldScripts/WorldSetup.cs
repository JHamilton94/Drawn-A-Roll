using UnityEngine;
using System.Collections;

public class WorldSetup : MonoBehaviour {

    public bool setupFromEditor;

    public GameState gameState;
    public Vector2 topLeftBound;
    public Vector2 bottomRightBound;

	// Use this for initialization
	void Start () {
        if (setupFromEditor)
        {
            WorldVariables.setVariables(gameState, topLeftBound, bottomRightBound);
        }
	}
	
}
