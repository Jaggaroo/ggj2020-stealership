using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    public float timeBetweenPickUpDrop = 0.25f;
    public float throwForceY = 7;
    public float throwForceX = 3;

    private float movementDir = 0;
    private float moveSpeed = 5f;

    public int playerNum;

    public float playerpositionX;
    public float playerpositionY;

    private float topGround = 6.23279f;
    private float bottomGround = -16.31625f;

    private Vector2 screenBounds;
    private Vector2 screenOrigo;

    private GameObject pickedUpObj;
    private GameObject lastPickedUpObj;
    private bool pickupButton;
    private float nextPickDropUpTime;
    private bool canPickUp = true;
    private bool canDrop = false;

    void Start()
    {
        nextPickDropUpTime = Time.time + timeBetweenPickUpDrop;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenOrigo = Camera.main.ScreenToWorldPoint(Vector2.zero);

        // Debug.Log("Screenbounds: " + screenBounds);
        // Debug.Log("Update Width: " + Screen.width);
        // Debug.Log("Update Height: " + Screen.height);

    }

    // Update is called once per frame
    void Update()
    {
        RegisterPickDrop();

        Move();
        DragPickedObj();
        DropPickedObj();
    }

    void OnCollisionStay2D(Collision2D collision) {
        PickUp(collision);
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (pickedUpObj == null && collision.gameObject == lastPickedUpObj) {
            canPickUp = true;
            Debug.Log("Can pick up");
        }
    }

    void RegisterPickDrop() {
        if (Time.time >= nextPickDropUpTime && Input.GetButton("Fire1")) {
            pickupButton = true;
            Debug.Log("Space press registered");
            nextPickDropUpTime = Time.time + timeBetweenPickUpDrop;
        }
    }

    void PickUp(Collision2D collision) {
        // Debug.Log("Collision " + collision.gameObject.tag);
        if (collision.gameObject.tag == "part" && canPickUp && pickupButton) {
            canPickUp = false;
            pickupButton = false;

            Debug.Log("PickUp");
            pickedUpObj = collision.gameObject;
            Collider2D pCol = pickedUpObj.GetComponent<Collider2D>();
            pCol.enabled = false;
            pickedUpObj.transform.position += new Vector3(0, 2, 0);

            canDrop = true;
        }
    }

    void DragPickedObj() {
        if (pickedUpObj != null) {
            Vector3 objPos = pickedUpObj.transform.position;
            Vector3 charPos = transform.position;
            objPos = new Vector3(charPos.x - 1, charPos.y + 2, objPos.z);
            pickedUpObj.transform.position = objPos;
        }
    }

    void DropPickedObj() {
        if (pickedUpObj != null) {
            if ((pickupButton && canDrop) || pickedUpObj.GetComponent<Combinable>().IsCombined()) {
                pickupButton = false;
                lastPickedUpObj = pickedUpObj;

                Debug.Log("Drop");
                GameObject toThrow = pickedUpObj;

                Rigidbody2D rb = toThrow.GetComponent<Rigidbody2D>();
                float throwDir = Mathf.Sign(movementDir) * -1;
                rb.AddForce(new Vector2(Random.Range(0, throwForceX) * throwDir, throwForceY), ForceMode2D.Impulse);

                pickedUpObj = null;
                
                Collider2D pCol = toThrow.GetComponent<Collider2D>();
                pCol.enabled = true;

                canDrop = false;
            }
        }
    }

    void Move() {
        float movementDir = 0;
        if (playerNum == 0) {
            movementDir = Input.GetAxis("Horizontal");

        } else {
            movementDir = Input.GetAxis("HorizontalB");

        }
        playerpositionX = transform.position.x;
        playerpositionY = transform.position.y;

        //playerpositionX = transform.localPosition.x;
        //playerpositionY = transform.localPosition.y;

        // Debug.Log("Update Player: " + playerNum);
        // Debug.Log("dir: " + dir);
        // Debug.Log("Player 0 X: " + playerpositionX);
        // Debug.Log("Player 0 Y: " + playerpositionY);

        if (playerpositionX > 37f && playerpositionY > 1f)
        {
            transform.position = new Vector3(-37f, bottomGround, 0);

        }
        else if (playerpositionX > 37f && playerpositionY < 1f)
        {
            transform.position = new Vector3(-37f, topGround, 0);

        }else if (playerpositionX < -37f && playerpositionY > 1f)
        {
            transform.position = new Vector3(37f, bottomGround, 0);

        }
        else if (playerpositionX < -37f && playerpositionY < 1f)
        {
            transform.position = new Vector3(37f, topGround, 0);

        }

        Vector3 movement = new Vector3(movementDir * moveSpeed, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
