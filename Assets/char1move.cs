using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char1move : MonoBehaviour
{
    public float moveSpeed1 = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement1 = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement1 * Time.deltaTime * moveSpeed1;


    }
}
