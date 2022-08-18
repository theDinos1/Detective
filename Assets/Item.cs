using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour 
{
    public string ItemName;
    public string Description;
    [Header("Prefab")]
    public GameObject ItemPrefab;
    [HideInInspector]
    public GameObject Model;

    private void Start()
    {
        ItemPrefab = gameObject;
    }
    public abstract void Use();
    public abstract void Instance();
    public abstract void DestroyModel();
}
