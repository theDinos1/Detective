using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : Item
{
    public GameObject[] tempArray;
    public override void Use()
    {
        Debug.Log($"Use {ItemName}");
    }
}
