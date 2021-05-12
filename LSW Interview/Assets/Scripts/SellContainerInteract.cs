using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellContainerInteract : Interactable
{
    public GameObject sellScreen;

    public override void Interact (Character character) {

        sellScreen.SetActive(true);


    }
}
