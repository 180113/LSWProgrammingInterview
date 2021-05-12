using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable {
    [SerializeField] DialogueContainer dialogue;
    
    [SerializeField] GameObject StoreUI;
    public override void Interact (Character character) {
        GameManager.instance.dialogueController.Initialize (dialogue);
    }
}