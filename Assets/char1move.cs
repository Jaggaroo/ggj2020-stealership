using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char1move : MonoBehaviour
{
    public float moveSpeed = 5f;

    public int playerNum;
    public float moveSpeed1 = 5f;

    Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    Vector2 screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerNum);
        Debug.Log(screenBounds);
    }

    // Update is called once per frame
    void Update()
    {
        float dir = 0;
        if (playerNum == 0) {
            dir = Input.GetAxis("Horizontal");
            Debug.Log(dir);
        } else {
            // if (Input.GetKeyDown(KeyCode.A)) {
            //     dir = -1;
            // } else if (Input.GetKeyDown(KeyCode.D)) {
            //     dir = 1;
            // }
            dir = Input.GetAxis("HorizontalB");
        }

        //Vector3 movement1 = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement1 * Time.deltaTime * moveSpeed1;

        //else if (pos.x < screenOrigo.x)
        //{
        //    transform.position = screenOrigo.x;
        //}
        //else if (pos.y > screenBounds.y || pos.y < screenOrigo.y)
        //{
        //    DoStuff();
        //}

        Vector3 movement = new Vector3(dir, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //Vector3 pos = transform.position;
        //if (pos.x > screenBounds.x)
        //{
        //    transform.position = new Vector3(screenBounds.x, pos.y, 0);
        //}

    }
}
