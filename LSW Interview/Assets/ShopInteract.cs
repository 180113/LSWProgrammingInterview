using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteract : Interactable {
    [SerializeField] GameObject ShopUI;
    // Start is called before the first frame update
    public override void Interact (Character character) {
        ShopUI.SetActive(true);
    }

    
}