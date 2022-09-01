using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public Item[] items = new Item[9];
    [SerializeField] Text[] slots = new Text[9];
    private int index = 0;

    public void AddItem(Item item)
    {
        if (index < items.Length)
        {
            foreach (Item slot in items)
            {
                if (slot == null)
                {
                    int index = Array.IndexOf(items, slot);
                    items[index] = item;
                    slots[index].text = item.itemName;
                    break;
                }
            }
        }
    }
    public void RemoveItem(Item item)
    {
        if (Array.Exists(items, i => i == item))
        {
            int index = Array.IndexOf(items, item);
            items[index] = null;
            slots[index].text = null;
        }
    }
}
