using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ItemSlot {
    public Item item;
    public int count;

    public void Copy (ItemSlot slot) {
        item = slot.item;
        count = slot.count;

    }
    public void Set (Item _item, int _count) {
        Debug.Log("Item Set");
        Debug.Log($"_item {_item}");
        item = _item;
        Debug.Log($"item {item}");
        count = _count;

    }

    public void Clear () {
        item = null;
        count = 0;
    }

}

[CreateAssetMenu (menuName = "Data/Itemcontainer")]
public class ItemContainer : ScriptableObject {

    public List<ItemSlot> slots;

    public void Add (Item item, int count = 1) {
        if (item.stackable == true) {

            ItemSlot itemSlot = slots.Find (x => x.item == item);
            if (itemSlot != null) {
                itemSlot.count += count;
            } else {
                itemSlot = slots.Find (x => x.item == null);
                if (itemSlot != null) {
                    itemSlot.item = item;
                    itemSlot.count += count;
                }
            }

        } else {
            // add nonstackable item
            ItemSlot itemSlot = slots.Find (x => x.item == null);
            if (itemSlot != null) {
                itemSlot.item = item;
            }
        }
    }
    public void Clear(){
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].item =null;
            slots[i].count = 0;
        }
    }

}