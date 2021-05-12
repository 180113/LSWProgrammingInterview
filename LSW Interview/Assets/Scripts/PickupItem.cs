﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count =1;
    void Awake() {
        player = GameManager.instance.player.transform;
    }

    void Update () {
        ttl -= Time.deltaTime;
        if(ttl<0){Destroy(gameObject);}

        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickUpDistance){
            return;
        }
        transform.position =Vector3.MoveTowards(transform.position,player.position,speed*Time.deltaTime);

        if (distance <0.1f){
            
            //how to add an item to the inventory
            if(GameManager.instance.inventoryContainer != null){
                GameManager.instance.inventoryContainer.Add(item,count);
            }else{
                Debug.LogWarning("No Inventory Container attached to the game manager");
            }
            Destroy(gameObject);
        }
    }
}