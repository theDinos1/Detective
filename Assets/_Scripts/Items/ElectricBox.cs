using System;
using System.Linq;
using UnityEngine;

public class ElectricBox : RequireItem
{
    [SerializeField] private string _TimeLineSceneName;
    [SerializeField] private float _TimeLineSceneDurations;
    public override void Use()
    {
        ItemInfo[] items = GameSceneManager.instance.gameData.inventory.items;
        foreach (ItemInfo item in items)
        {
            if (item != null)
            {
                if (item.itemName == _RequireName)
                {
                    //ItemManager.RemoveItem(item);
                    Debug.Log($"Use {_RequireName}");
                    GameSceneManager.instance.LoadScene(_TimeLineSceneName, _TimeLineSceneDurations);
                }
            }
        }

    }
}
