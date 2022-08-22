using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour 
{
    [Header("Item info")]
    public string ItemName;
    public string Description;
    public Sprite ItemSprite;
    public abstract void Use();
}
