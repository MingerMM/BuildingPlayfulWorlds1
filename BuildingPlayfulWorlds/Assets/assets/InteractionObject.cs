using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventory;      //true means object can be stored in inventory
    public bool ableToChop;     //locked in tutorial
    public GameObject itemNeeded;
    public GameObject wand;

    public void DoInteraction()
    {
        //picked up and putted in inventory
        gameObject.SetActive(false);
    }

    //public void ShowInteraction()
  //  {
  //      gameObject.SetActive(true);
  //  }
}
