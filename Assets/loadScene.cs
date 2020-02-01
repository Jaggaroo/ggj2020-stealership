using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScene : MonoBehaviour
{
    public GameObject prefab;

    public float topColliderBottomPos;

    private float[] levelsTopPos;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;

        Vector2 topRightEdgeVector = cam.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 bottomLeftEdgeVector = cam.ViewportToWorldPoint(new Vector2(0,0));
        levelsTopPos = new float[2] {topRightEdgeVector.y, topColliderBottomPos};

        SpawnPart(prefab, bottomLeftEdgeVector.x, topRightEdgeVector.x);
    }

    void SpawnPart(GameObject prefab, float minX, float maxX) {
        float prefabWidth = prefab.GetComponent<Renderer>().bounds.size.x;

        float x = Random.Range(minX + prefabWidth / 2, maxX - prefabWidth / 2);
        float y = levelsTopPos[Mathf.RoundToInt(Random.Range(0f,1f))];

        Vector3 pos = new Vector3(x,y,transform.position.z);

        // Debug.Log("HW " + height + " " + width);
        // Debug.Log("X span " + (bottomLeftEdgeVector.x + prefabWidth / 2) + " " + topRightEdgeVector.x);
        // Debug.Log("Random pos init " + x + " " + y);
        // Debug.Log("Random pos toWorld " + pos.x + " " + pos.y + " " + pos.z);
        // Debug.Log(pos.x);
        // Debug.Log(pos.y);
        
        GameObject inst = Instantiate(prefab, pos, Quaternion.identity);
        Rigidbody2D rb = inst.GetComponent<Rigidbody2D>();
        float tDir = Mathf.Ceil(Random.Range(0, 1)) * 2 - 1;
        rb.AddTorque(tDir * Random.Range(150, 600));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
