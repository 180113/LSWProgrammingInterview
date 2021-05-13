using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {
    [SerializeField] int purpleArmorCost;
    [SerializeField] int chainArmorCost;

    [SerializeField] GameObject purpleOverlay;
    [SerializeField] GameObject chainOverlay;

    void Update () {

        if (GameManager.CoinCount >= purpleArmorCost) {
            purpleOverlay.SetActive (false);
        } else {
            purpleOverlay.SetActive (true);
        }
        if (GameManager.CoinCount >= chainArmorCost) {
            chainOverlay.SetActive (false);
        } else {
            chainOverlay.SetActive (true);
        }

    }
    public void PurchasePurpleArmor () {

        if (GameManager.CoinCount >= purpleArmorCost)
            GameManager.instance.equipmentManager.purplePurchased = true;

        GameManager.CoinCount -= purpleArmorCost;
    }
    public void PurchaseChainArmor () {
        if (GameManager.CoinCount >= chainArmorCost) {
            GameManager.instance.equipmentManager.chainPurchased = true;
            GameManager.CoinCount -= chainArmorCost;
        }
    }
}