using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char1move : MonoBehaviour
{
    public float moveSpeed = 5f;

    public int playerNum;

    Vector2 screenBounds;
    Vector2 screenOrigo;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Player: " + playerNum);
        //Debug.Log(screenBounds);
        Debug.Log("Width: " + Screen.width);
        Debug.Log("Height: " + Screen.height);

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        Debug.Log(screenBounds);

    }

    // Update is called once per frame
    void Update()
    {
        float dir = 0;
        if (playerNum == 0) {
            dir = Input.GetAxis("Horizontal");
        } else {
            dir = Input.GetAxis("HorizontalB");
        }

        Vector3 movement = new Vector3(dir, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //Vector3 pos = transform.position;
        //if (pos.x > screenBounds.x)
        //{
        //    transform.position = new Vector3(screenBounds.x, pos.y, 0);
        //}

    }
}
