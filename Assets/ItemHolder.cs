using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        PickUp(GameObject.FindGameObjectWithTag("Object").GetComponent<Object>());
        
    }

    private void SpawnItem2(InputAction.CallbackContext obj)
    {
        _ItemList[0][0].Instance();
    }

    private void PickUp(Item item)
    {
        AddItemToList(item);
        item.transform.parent = transform;
        _ItemList.ForEach(item => Debug.Log(item.Count));
        Debug.Log($"ItemList Count = {_ItemList.Count}");
        item.DestroyModel();
    }
    private void Drop(Item item)
    {
        SpawnItem(item);
        _ItemList.RemoveAt(0);
        //_ItemList.ForEach(_item => _ItemList.Remove(_item));
        //Destroy(_ItemList[_CurrentIndex][0].ItemGameObject);
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
    private void SpawnItem(Item item)
    {
        item.Instance();
        item.enabled = true;
    }
    private int GetIndexOfItem(Item item)
    {
        return FindItemStackByItem(item).FindIndex(i => i == item);
    }
    private void OnEnable()
    {
        _PlayerInput.Player.DropItem.performed += SpawnItem2;
        _PlayerInput.Enable();
    }

    private void OnDisable()
    {
        
    }
}
