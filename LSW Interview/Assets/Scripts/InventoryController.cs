using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    [SerializeField] GameObject ItemPanel;
    [SerializeField] GameObject toolbarPanel;

    void Update () {
        if (Input.GetKeyDown (KeyCode.I)) {
            ItemPanel.SetActive(!ItemPanel.activeInHierarchy);
            toolbarPanel.SetActive(!toolbarPanel.activeInHierarchy);
            
        }
    }
}