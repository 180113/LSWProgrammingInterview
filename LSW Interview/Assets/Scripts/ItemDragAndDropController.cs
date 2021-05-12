using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour {

    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject ItemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    void Start () {
        itemSlot = new ItemSlot ();
        iconTransform = ItemIcon.GetComponent<RectTransform> ();
        itemIconImage = ItemIcon.GetComponent<Image> ();
    }

    void Update () {
        if (ItemIcon.activeInHierarchy) {
            iconTransform.position = Input.mousePosition;
            if (Input.GetMouseButton (0)) {
                if (EventSystem.current.IsPointerOverGameObject () == false) {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                    worldPosition.z = 0;
                    ItemSpawnManager.instance.SpawnItem (worldPosition, itemSlot.item, itemSlot.count);
                    itemSlot.Clear();
                    ItemIcon.SetActive(false);
                }
            }
        }
    }

    internal void onClick (ItemSlot itemSlot) {
        if (this.itemSlot.item == null) {
            this.itemSlot.Copy (itemSlot);

            itemSlot.Clear ();
            Debug.Log ("clear");

        } else {
            Item item = itemSlot.item;
            Debug.Log (item);
            int count = itemSlot.count;

            itemSlot.Copy (this.itemSlot);
            this.itemSlot.Set (item, count);

        }
        UpdateIcon ();
    }

    private void UpdateIcon () {

        if (itemSlot.item == null) {
            Debug.Log ("item Placed in empty");
            ItemIcon.SetActive (false);
        } else {
            ItemIcon.SetActive (true);
            itemIconImage.sprite = itemSlot.item.Icon;
        }
    }
}