using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class ItemHolder : MonoBehaviour
{
    private List<List<Item>> _ItemList;
    private StarterAssetsAction _PlayerInput;
    private InputAction inputAction;
    private int _CurrentIndex = 0;
    private int _PreviousIndex;

    private void Awake()
    {
        _PlayerInput = new StarterAssetsAction();
    }
    void Start()
    {
        _ItemList = new List<List<Item>>();
        GameObject[] itemsGO = GameObject.FindGameObjectsWithTag("Object");
        itemsGO.ToList().ForEach(itemGO =>
        {
            PickUp(itemGO.GetComponent<Item>());
        });
        
    }

    private void PickUp(Item item)
    {
        AddItemToList(item);
        Destroy(item.gameObject);
        Debug.Log($"Pick up {item.ItemName}");
    }
    private void AddItemToList(Item item)
    {
        if (IsItemAlreadyExist(item))
        {
            FindItemStackByItem(item).Add(item);
        }
        else
        {
            AddNewItemStack(item);
        }
        
    }
    private bool IsItemAlreadyExist(Item item)
    {
        return _ItemList.Contains(_ItemList.Find(x => x.Find(x => x.ItemName == item.ItemName)));
    }
    private List<Item> FindItemStackByItem(Item item)
    {
        return _ItemList.Find(x => x.Find(x => x.ItemName == item.ItemName));
    }
    private void AddNewItemStack(Item item)
    {
        List<Item> list = new List<Item>();
        list.Add(item);
        _ItemList.Add(list);
    }
    private int GetIndexOfItem(Item item)
    {
        return FindItemStackByItem(item).FindIndex(i => i == item);
    }
    private void OnEnable()
    {
        //_PlayerInput.Player.DropItem.performed += Action;
        _PlayerInput.Enable();
    }

    private void OnDisable()
    {
        _PlayerInput.Disable();
    }

}
