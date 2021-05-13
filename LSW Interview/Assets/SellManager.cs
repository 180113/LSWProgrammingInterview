using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour {
    [SerializeField] ItemContainer inventory;

    public void SellAll () {
        for (int i = 0; i < inventory.slots.Count; i++) {
            if (inventory.slots[i].item != null) {

                if (inventory.slots[i].item.stackable) {

                    GameManager.CoinCount += inventory.slots[i].item.price * inventory.slots[i].count;
                } else {
                    GameManager.CoinCount += inventory.slots[i].item.price;
                }
            }
        }
        inventory.Clear ();

        gameObject.SetActive (false);
    }
}