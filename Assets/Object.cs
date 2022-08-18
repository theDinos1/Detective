using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : Item
{
    public GameObject[] tempArray;
    private void Start()
    {
        Instance();
    }
    public override void Use()
    {
        Debug.Log($"Use {ItemName}");
    }
    public override void Instance()
    {
        var Model = Instantiate(Resources.Load($"Prefabs/{ItemName}")) as GameObject;
        Model.transform.parent = transform;
        Model.transform.position = transform.position;
    }

    public override void DestroyModel()
    {
        Debug.Log($"Child Count {transform.childCount}");
    }
}
