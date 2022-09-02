using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Object
{
    public override void Use()
    {
        ItemManager.Pickup(this);
    }
}
