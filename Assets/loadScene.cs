using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class loadScene : MonoBehaviour
{
    public float topColliderBottomPos;

    private float[] levelsTopPos;

    private GameObject[] objInsts = new GameObject[] {};

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;

        Vector2 topRightEdgeVector =
            cam.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 bottomLeftEdgeVector =
            cam.ViewportToWorldPoint(new Vector2(0, 0));
        levelsTopPos =
            new float[2] { topRightEdgeVector.y, topColliderBottomPos };

        Object[] prefabs =
            Resources.LoadAll("Parts");

        Debug.Log("Parts count " + prefabs.Length)    ;

        foreach (GameObject _prefab in prefabs) {
            GameObject prefab = (GameObject) _prefab;
            
            Debug.Log("Prefab " + prefab);
            SpawnPart(prefab, bottomLeftEdgeVector.x, topRightEdgeVector.x);
        }
    }

    void SpawnPart(GameObject prefab, float minX, float maxX)
    {
        Vector3 bounds = prefab.GetComponent<Renderer>().bounds.size;
        float prefabWidth = bounds.x;
        float prefabHeight = bounds.y;

        float x = Random.Range(minX + prefabWidth, maxX - prefabWidth);
        float y = levelsTopPos[Mathf.RoundToInt(Random.Range(0f, 1f))] - prefabHeight;

        Vector3 pos = new Vector3(x, y, transform.position.z - 1);

        // Debug.Log("HW " + height + " " + width);
        // Debug.Log("X span " + (bottomLeftEdgeVector.x + prefabWidth / 2) + " " + topRightEdgeVector.x);
        // Debug.Log("Random pos init " + x + " " + y);
        // Debug.Log("Start pos toWorld " + pos.x + " " + pos.y + " " + pos.z + " " + prefabHeight + " " + prefabWidth);
        // Debug.Log(pos.x);
        // Debug.Log(pos.y);

        GameObject inst = Instantiate(prefab, pos, Quaternion.identity);
        Rigidbody2D rb = inst.GetComponent<Rigidbody2D>();
        float tDir = Mathf.Ceil(Random.Range(0, 1)) * 2 - 1;

        objInsts = objInsts.Concat(new GameObject[] { inst }).ToArray();

        pos = inst.transform.position;
        // Debug.Log("AfterInst pos toWorld " + pos.x + " " + pos.y + " " + pos.z);
        rb.AddTorque(tDir * Random.Range(500, 1500));
    }

    // Update is called once per frame
    void Update()
    {
        // float z = transform.position.z;
        // Debug.Log("BG z " + z);
        // foreach (GameObject inst in objInsts) {
        //     Vector3 pos = inst.transform.position;
        //     inst.transform.position = new Vector3(pos.x, pos.y, -1);
        //     pos = inst.transform.position;
        //     Debug.Log(inst + " position is " + pos.x + " " + pos.y + " " + pos.z);
        // }
    }
}
