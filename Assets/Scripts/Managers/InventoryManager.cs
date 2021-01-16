using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, MyGameManager
{
    private Dictionary<string, int> Items;
    public string equippedItem { get; private set; }
    public StatusManager status
    {
        get; private set;
    }

    // Start is called before the first frame update
    public void Startup()
    {
        Debug.Log(" starting Inventory Manager: ");
        Items = new Dictionary<string, int>();
        status = StatusManager.Started;

    }

    public void AddItem(string name)
    {
        if (Items.ContainsKey(name))
        {
            Items[name]++;
        }
        else
            Items[name] = 1;

        ShowItems();
    }

    private void ShowItems()
    {
        string items = "Items : ";
        foreach (KeyValuePair<string, int> item in Items)
        {
            items += item.Key + "(" + item.Value + ") ";
        }
        Debug.Log(items);

    }

    //return all the type of item in the dictionary 
    public List<string> GetItems()
    {
        List<string> list = new List<string>(Items.Keys);
        return list;
    }

    //return the number of that item in the Inventory
    public int GetItemCount(string name)
    {
        if (Items.ContainsKey(name))
            return Items[name];
        return 0;
    }
     //call the func to equip a specefic item 
    public bool EquipItem(string name)
    {
        if( Items.ContainsKey(name) && equippedItem!=name )
        {
            equippedItem = name;
            Debug.Log("item equipped : " + name);
            return true;
        }

        equippedItem = null;
        Debug.Log("Unequipped");
        return false;

    }
}
