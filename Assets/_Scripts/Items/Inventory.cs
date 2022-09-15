using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory
{
    [HideInInspector] public ItemInfo[] items = new ItemInfo[9];
    private Image[] slots = new Image[9];

    public void InitailizeData()
    {
        foreach (ItemInfo slot in items)
        {
            int index = Array.IndexOf(items, slot);
            items[index] = null;
        }
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = GameObject.Find($"slot{i + 1}").transform.GetChild(0).GetComponent<Image>();
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
                slots[index].sprite = item.icon;
                slots[index].color = new Color(255, 255, 255, 255);

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
            slots[index].sprite = null;
            slots[index].color = new Color(255, 255, 255, 0);
        }
    }
}
