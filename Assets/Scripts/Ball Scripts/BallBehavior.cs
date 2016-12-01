using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {

    public RespawnPointBehavior respawnPoint;

    private Rigidbody2D rb;
    private CircleCollider2D col;
    

    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint").GetComponent<RespawnPointBehavior>();


        /*GameObject[] noDrawZones = GameObject.FindGameObjectsWithTag("NoDrawZone");
        foreach (GameObject noDrawZone in noDrawZones)
        {
            Debug.Log("HERE");
            Physics2D.IgnoreCollision(noDrawZone.GetComponent<BoxCollider2D>(), col);
        }*/
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (WorldVariables.gameState == GameState.Setup)
        {
            rb.isKinematic = true;
            respawn();
        }else if (WorldVariables.gameState == GameState.Win)
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }


	}

    private void respawn()
    {
        transform.position = MiscHelperFuncs.convertToVec3(respawnPoint.respawnLocation);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        WorldVariables.gameState = GameState.Win;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "NoDrawZone")
        {
            Physics2D.IgnoreCollision(col, collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
