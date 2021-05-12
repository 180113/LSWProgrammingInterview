using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int CoinCount{ get{return PlayerPrefs.GetInt("CoinCount");}set {PlayerPrefs.SetInt("CoinCount",value);} }




    void Awake() {
        instance = this;
    }
    public GameObject player;
    public ItemContainer inventoryContainer;

    public ItemDragAndDropController dragAndDropController;

    public DialogueSstem dialogueController;

    public EquipmentManager equipmentManager;

    void Start() {
        PlayerPrefs.SetInt("CoinCount",0);
    }

//add cooins incrementally
/*     public void IncrementCoins(){
        GameManager.CoinCount++;
    } */
}
