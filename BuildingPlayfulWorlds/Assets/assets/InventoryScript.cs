using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    public GameObject[] Inventory = new GameObject[3];

    public void AddItem(GameObject item)

    {
        bool itemAdded = false;

        //find first open slot in inventory
        for (int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] == null)   //=empty slot
            {
                Inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                item.SendMessage("DoInteraction");       //Do something with the object
                break;
            }
        }

        //inventory full
        if (!itemAdded)
        {
            Debug.Log("Inverntory is full - Item not added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < Inventory.Length; i++)  //inventory
        {
            if (Inventory[i] = item)
            {
                return true;    //found item in inventory
            }
        }
        //item not found
        return false;
    }
}
