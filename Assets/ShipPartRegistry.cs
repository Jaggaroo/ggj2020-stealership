using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartRegistry
{
    public string[] catShipPartsNames = new string[] {"BrokenWhiteShip", "WhiteRockets"};
    public string[] eyeShipPartsNames = new string[] {"BrokenBlackShip", "BlackRocket"};
    public string[] commonPartsNames = new string[] {"Antenna", "Window"};
    public string[] solePartsNames = new string[] {"Energycore"};

    public Object[] catShipParts = new Object[] {};
    public Object[] eyeShipParts = new Object[] {};
    public Object[] commonParts = new Object[] {};

    private float minX;
    private float maxX;
    private float[] levelsTopPos;

    public ShipPartRegistry(float _minX, float _maxX, float[] _levelsTopPos) {
        minX = _minX;
        maxX = _maxX;
        levelsTopPos = _levelsTopPos;
    }

    public void SpawnParts() {

        foreach (string name in catShipPartsNames) {
            SpawnPart((GameObject) Resources.Load("Parts/"+name));
        }

        foreach (string name in eyeShipPartsNames) {
            SpawnPart((GameObject) Resources.Load("Parts/"+name));
        }

        foreach (string name in commonPartsNames) {
            GameObject obj = (GameObject) Resources.Load("Parts/"+name);
            SpawnPart(obj);
            SpawnPart(obj);
        }

        foreach (string name in solePartsNames) {
            SpawnPart((GameObject) Resources.Load("Parts/"+name));
        }
    }

   void SpawnPart(GameObject prefab)
    {
        Vector3 bounds = prefab.GetComponentInChildren<MeshRenderer>().bounds.size;

        float prefabWidth = bounds.x;
        float prefabHeight = bounds.y;

        float x = Random.Range(minX + prefabWidth, maxX - prefabWidth);
        float y = levelsTopPos[Mathf.RoundToInt(Random.Range(0f, 1f))] - prefabHeight;

        Vector3 pos = new Vector3(x, y, 0);

        GameObject inst = GameObject.Instantiate(prefab, pos, Quaternion.identity);
        inst.tag = "part";
        Rigidbody2D rb = inst.GetComponent<Rigidbody2D>();
        float tDir = Mathf.Ceil(Random.Range(0, 1)) * 2 - 1;

        // objInsts = objInsts.Concat(new GameObject[] { inst }).ToArray();

        rb.AddTorque(tDir * Random.Range(500, 1500));
    }
}

