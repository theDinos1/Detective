using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private LayerMask _LayerMask;
    [SerializeField] private Camera _Camera;
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
            UIHUD.Instance.ShowAlertText("PRESS E TO interact");
            if (Input.GetKey(KeyCode.E))
            {
                Object item;
                bool isItemnNotNull = hit.transform.TryGetComponent(out item);
                if (isItemnNotNull)
                {
                    item.Use();
                }
            }
        }
        else
        {
            UIHUD.Instance.HideAlertText();
        }
    }
    public static void Pickup(Item item)
    {
        GameSceneManager.instance.gameData.inventory.AddItem(item.itemInfo);
        Destroy(item.gameObject);
    }
    public static void RemoveItem(ItemInfo item)
    {
        GameSceneManager.instance.gameData.inventory.RemoveItem(item);
    }

}
