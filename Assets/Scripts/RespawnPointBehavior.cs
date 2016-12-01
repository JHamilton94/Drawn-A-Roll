using UnityEngine;
using System.Collections;

public class RespawnPointBehavior : MonoBehaviour {

    public Vector2 respawnLocation;

	// Use this for initialization
	void Start () {
        respawnLocation = transform.position;
	}
}
