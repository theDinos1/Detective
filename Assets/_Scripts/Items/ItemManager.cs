using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private Camera _Camera;
    public static Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    void FixedUpdate()
    {
        RayCast();
    }

    private void RayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(_Camera.transform.position, _Camera.transform.forward, Color.yellow, 2f);
        if (Physics.Raycast(_Camera.transform.position, _Camera.transform.forward, out hit, 3f, _LayerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Object item;
                bool isItemnNotNull = hit.transform.TryGetComponent(out item);
                if (isItemnNotNull)
                {
                    item.Use();
                }
            }
        }
    }
    public static void Pickup(Item item)
    {
        inventory.AddItem(item.itemInfo);
        Destroy(item.gameObject);
    }
    public static void RemoveItem(ItemInfo item)
    {
        inventory.RemoveItem(item);
    }

}
