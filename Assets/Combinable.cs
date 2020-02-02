using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Combinable : MonoBehaviour
{
    public string prefabName;

    public GameObject inst;
    public string[] canBeCombinedWith;

    public Combination combination = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (combination != null)   {
            combination.Update();
        }
    }

    public void TryCombine(GameObject other) {
        Combinable combinable = other.GetComponent<Combinable>();

        if (canBeCombinedWith.Contains(combinable.prefabName)) {
            combination = new Combination();
            combination.Add(inst);
            combination.Add(other);

            // // MakeUnmovable(inst);
            // // MakeUnmovable(other);
            // SetPositions(inst, other);
        }
    }

    public bool IsCombined() {
        return combination != null;
    }
}
