using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char2move : MonoBehaviour
{
    public float moveSpeed2 = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement2 = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement2 * Time.deltaTime * moveSpeed2;


    }
}
