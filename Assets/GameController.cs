using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Ball;

    private enum state { player1Spawn, player2Spawn, inGame }
    private state gameState;

    // Use this for initialization
    void Start () {
        int randPlayer = Random.Range(0, 2);
        gameState = randPlayer == 0 ? state.player1Spawn : state.player2Spawn;
	}
	
	// Update is called once per frame
	void Update () {

        if(gameState == state.player1Spawn)
        {
            Ball.transform.position = Player1.transform.Find("Spawner").position;
        }
        else if (gameState == state.player2Spawn)
        {
            Ball.transform.position = Player2.transform.Find("Spawner").position;
        }

        // Start game on space press
        if (gameState != state.inGame && Input.GetKeyDown(KeyCode.Space))
        {
            if(gameState == state.player1Spawn)
            {
                Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, Random.Range(-1f, 1f)));
            }
            else
            {
                Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, Random.Range(-1f, 1f)));
            }
            gameState = state.inGame;
        }
		
	}
}
