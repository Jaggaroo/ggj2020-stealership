using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class loadScene : MonoBehaviour
{
    public float topColliderBottomPos;

    private float[] levelsTopPos;

    private ShipPartRegistry registry;

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

        registry = new ShipPartRegistry(bottomLeftEdgeVector.x, topRightEdgeVector.x, levelsTopPos);

        registry.SpawnParts();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
