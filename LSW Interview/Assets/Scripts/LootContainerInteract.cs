using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable {
    // Start is called before the first frame update
    [SerializeField] GameObject openedContainer;
    [SerializeField] GameObject closedContainer;

    [SerializeField] GameObject particleSpawner;

    [SerializeField] int lootAmount;
    bool hasBeenOpened;
    [SerializeField] bool open;

    public override void Interact (Character character) {
        Debug.Log ("Interact Recieved");
        if (!open) {
            open = true;
            openedContainer.SetActive (true);
            closedContainer.SetActive (false);
        } else {
            open = false;
            openedContainer.SetActive (false);
            closedContainer.SetActive (true);
        }

        if(!hasBeenOpened){
            hasBeenOpened =true;
            if(particleSpawner!=null){
                particleSpawner.SetActive(true);
            }
                GameManager.CoinCount += lootAmount;
        }

    }

    
}