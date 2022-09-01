using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera camera;
    [SerializeField] private Inventory inventory;
    void FixedUpdate()
    {
        RayCast();
    }

    private void RayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Item item; 
                bool isItemnNotNull = hit.transform.TryGetComponent(out item);
                if(isItemnNotNull) Pickup(item);
            }
        }
    }

    private void Pickup(Item item)
    {
        Debug.Log($"Pick up {item.itemName}.");
        inventory.AddItem(item);
        item.DestroyModel();
    }
}
