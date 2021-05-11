using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rb2D;
    [SerializeField] float offsetDistance =1f;
    [SerializeField] float sizeOfInteractableArea =1.2f;

    void Awake() {
        character = GetComponent<CharacterController2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)){
            UseTool();
        }
    }
    void UseTool()
    {
        Vector2 position =  rb2D.position+ character.lastMovementVector *offsetDistance;

        Collider2D[]colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        foreach(Collider2D c in colliders){
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit!=null){
                hit.Hit();
                break;

            }
        }
    }
}
