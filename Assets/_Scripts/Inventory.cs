using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public ItemInfo[] items = new ItemInfo[9];
    [SerializeField] Text[] slots = new Text[9];

    private void Start()
    {
        foreach (ItemInfo slot in items)
        {
            int index = Array.IndexOf(items, slot);
            items[index] = null;
        }
    }
    public void AddItem(ItemInfo item)
    {
        foreach (ItemInfo slot in items)
        {
            if (slot == null)
            {
                int index = Array.IndexOf(items, slot);
                items[index] = item;
                slots[index].text = item.itemName;
                Debug.Log(items[index].itemName);
                break;
            }
        }
    }
    public void RemoveItem(ItemInfo item)
    {
        if (Array.Exists(items, i => i == item))
        {
            int index = Array.IndexOf(items, item);
            items[index] = null;
            slots[index].text = null;
        }
    }
}
