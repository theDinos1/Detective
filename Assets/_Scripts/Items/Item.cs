
public class Item : Object
{
    public override void Use()
    {
        ItemManager.Pickup(this);
    }
}
