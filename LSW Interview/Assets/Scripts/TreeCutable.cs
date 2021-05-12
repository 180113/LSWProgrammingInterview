﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutable : ToolHit
{
    [SerializeField] GameObject itemDrop;
    [SerializeField] int dropAmount =5;
    [SerializeField]float spread = 0.7f;

    [SerializeField] Item item ;
    [SerializeField] int itemCountInOneDrop = 1;

    public override void Hit()
    {
        while(dropAmount>0){
            dropAmount-=1;

            Vector3 position = transform.position;
            position.x += spread* Random.value - spread/2;
            position.y += spread* Random.value - spread/2;
            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
        }

        Destroy(gameObject);
    }
}
