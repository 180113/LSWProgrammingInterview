﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour {
    // Start is called before the first frame update
    public static ItemSpawnManager instance;

    void Awake () {
        instance = this;
    }

    [SerializeField] GameObject pickUpitemPrefab;
    public void SpawnItem (Vector3 position, Item item, int count) {
        GameObject o = Instantiate (pickUpitemPrefab, position, Quaternion.identity);
        o.GetComponent<PickupItem> ().Set (item, count);
    }
}