using UnityEngine;
using System.Collections;

public static class WorldVariables {

    public static void setVariables(GameState gameState, Vector2 topLeftBound, Vector2 bottomRightBound) {
        WorldVariables.gameState = gameState;

        WorldVariables.topLeftBound = topLeftBound;
        WorldVariables.bottomRightBound = bottomRightBound;
            
    }

	public static GameState gameState;

    public static Vector2 topLeftBound;
    public static Vector2 bottomRightBound;

    public static float MOUSE_SCROLL_CONSTANT = 0.5f;

    public static int level;
}
