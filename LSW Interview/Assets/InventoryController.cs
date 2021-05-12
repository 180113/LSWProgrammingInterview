using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    [SerializeField] GameObject ItemPanel;

    void Update () {
        if (Input.GetKeyDown (KeyCode.I)) {
            ItemPanel.SetActive(!ItemPanel.activeInHierarchy);
        }
    }
}