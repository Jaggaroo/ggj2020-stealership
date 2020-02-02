using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Combination
{
    private GameObject[] objects = new GameObject[] {};

    public void Add(GameObject obj) {
        Combinable combinable = obj.GetComponent<Combinable>();
        combinable.combination = this;

        objects = objects.Concat(new GameObject[] {obj}).ToArray();
        MakeUnmovable(obj);
    }

    void MakeUnmovable(GameObject obj) {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    public void Update() {
        if (objects.Length > 1) {
            SetPositions();
        }
    }

    void SetPositions() {
        GameObject first = objects[0];
        Vector3 fp = first.transform.position;

        // Debug.Log("First position " + fp.x);

        float zOffset = -10f;
        foreach (GameObject other in objects.Skip(1)) {
            other.transform.position = fp;
            other.transform.position += new Vector3(0,0,zOffset);
            zOffset += -10f;

            // Debug.Log("Other position " + other.transform.position.x);
        }
    }
}
