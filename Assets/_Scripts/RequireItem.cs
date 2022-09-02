using System.Linq;
using UnityEngine;

public class RequireItem : Object
{

    [SerializeField] private string _RequireName;
    public override void Use()
    {
        Debug.Log("Use");
        ItemInfo item = ItemManager.inventory.items.FirstOrDefault(i => i.itemName == _RequireName);
        if (item != null)
        {
            ItemManager.RemoveItem(item);
            Destroy(gameObject);
        }
    }
}
