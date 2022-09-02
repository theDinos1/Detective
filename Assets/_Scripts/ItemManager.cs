using System;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera camera;
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
        Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.yellow, 2f);
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 3f, layerMask))
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
