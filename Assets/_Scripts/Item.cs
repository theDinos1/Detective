using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public void DestroyModel()
    {
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<Renderer>());
    }
}
