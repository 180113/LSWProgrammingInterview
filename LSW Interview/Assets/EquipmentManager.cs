using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] GameObject Purple;
    [SerializeField] GameObject Chain;
    [SerializeField] GameObject None;

    public bool purplePurchased,chainPurchased;

    void Update() {
        if(purplePurchased){
            Purple.SetActive(true);

        }else{
            Purple.SetActive(false);

        }
        if(chainPurchased){
            Chain.SetActive(true);
        }else{

            Chain.SetActive(false);
        }
    }
}
