using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char1move : MonoBehaviour
{
    public float moveSpeed = 5f;

    public int playerNum;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerNum);
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

        Vector3 movement = new Vector3(dir, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
