using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour
{
    public ItemInfo itemInfo;

    public abstract void Use();
}
[System.Serializable]
public class ItemInfo
{
    public string itemName;
}