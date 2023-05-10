using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> inventory = new List<InventorySlot>(); 

    public void AddItem(ItemObject item, int ammount) 
    {
        bool hasItem = false;
        for (int i = 0; i < inventory.Count; i++) 
        {
            if (inventory[i].item == item) 
            {
                inventory[i].AddAmmount(ammount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem) 
        {
            inventory.Add(new InventorySlot(item, ammount));
        }
    }
}

[System.Serializable]
public class InventorySlot 
{
    public ItemObject item;
    public int ammount;
    public InventorySlot(ItemObject item, int ammount ) 
    {
        this.item = item;
        this.ammount = ammount;
    }
    public void AddAmmount(int value) 
    {
        ammount += value;
    }
}
