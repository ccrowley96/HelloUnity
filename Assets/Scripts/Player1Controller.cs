using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    private BoxCollider2D playerCollider;
    private enum playerState { free, wallContactTop, wallContactBottom };
    private playerState state;

    // Use this for initialization
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        state = playerState.free;
    }

    // Update is called once per frame
    void Update()
    {
        //Check for keyboard input
        if (Input.GetKey(KeyCode.S) && state != playerState.wallContactTop)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -10f));
        }
        else if (Input.GetKey(KeyCode.W) && state != playerState.wallContactBottom)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f));
        }
    }
}
