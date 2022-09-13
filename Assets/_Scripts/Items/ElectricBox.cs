using System;
using System.Linq;
using UnityEngine;

public class ElectricBox : RequireItem
{
    [SerializeField] private string _TimeLineSceneName;
    public override void Use()
    {
        ItemInfo[] items = ItemManager.inventory.items;
        foreach (ItemInfo item in items)
        {
            if(item != null)
            {
                if(item.itemName == _RequireName)
                {
                    ItemManager.RemoveItem(items.FirstOrDefault(i => i.itemName == _RequireName));
                    Debug.Log($"Use {_RequireName}");
                    // TODO: load timeline 1
                }
            }
        }      

    }
}
