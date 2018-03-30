using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public InventoryScript inventory;
    public GameObject holdingWand;
    
	
	// Update is called once per frame
    void Update()  
    {
        //edit, projectsettings, input = e key
        if (Input.GetButtonDown("interact") && currentInterObj)
        {
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }
                if (currentInterObjScript.ableToChop)   //if you can chop it and need the axe
                {
                    //check to see if you got the axe to chop it
                    if (inventory.FindItem (currentInterObjScript.itemNeeded))
                    {
                    //we have the axe
                    //code to add the wand to inventory
                    inventory.AddItem(currentInterObjScript.wand);
                    //holdingWand.SendMessage("ShowInteraction");
                    holdingWand.SetActive(true);
                    }
                    //else
                   // {
                    //let wizard say you need the axe
                   // }
                }
            
        }
    }

    //in trigger you can interact
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();  //get script from item
        }
    }

    //out of trigger you can not interact
    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag ("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}

//16.01
