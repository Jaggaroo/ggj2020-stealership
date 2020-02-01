using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    Vector3 movement;
    private float moveSpeed = 5f;

    public int playerNum;

    public float playerpositionX;
    public float playerpositionY;

    private float topGround = 6.23279f;
    private float bottomGround = -16.31625f;

    Vector2 screenBounds;
    Vector2 screenOrigo;

    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        // Debug.Log("Screenbounds: " + screenBounds);
        // Debug.Log("Update Width: " + Screen.width);
        // Debug.Log("Update Height: " + Screen.height);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnCollisionEnter(Collision collision) {
        PickUp(collision);
    }

    void PickUp(Collision collision) {
        Debug.Log("Collision " + collision.gameObject.tag);
    }

    void Move() {
        float dir = 0;
        if (playerNum == 0) {
            dir = Input.GetAxis("Horizontal");

        } else {
            dir = Input.GetAxis("HorizontalB");

        }
        playerpositionX = transform.position.x;
        playerpositionY = transform.position.y;

        //playerpositionX = transform.localPosition.x;
        //playerpositionY = transform.localPosition.y;

        // Debug.Log("Update Player: " + playerNum);
        // Debug.Log("dir: " + dir);
        // Debug.Log("Player 0 X: " + playerpositionX);
        // Debug.Log("Player 0 Y: " + playerpositionY);

        if (playerpositionX > 39f && playerpositionY > 1f)
        {
            transform.position = new Vector3(-39f, bottomGround, 0);

        }
        else if (playerpositionX > 39f && playerpositionY < 1f)
        {
            transform.position = new Vector3(-39f, topGround, 0);

        }else if (playerpositionX < -39f && playerpositionY > 1f)
        {
            transform.position = new Vector3(39f, bottomGround, 0);

        }
        else if (playerpositionX < -39f && playerpositionY < 1f)
        {
            transform.position = new Vector3(39f, topGround, 0);

        }

        movement = new Vector3(dir * moveSpeed, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
