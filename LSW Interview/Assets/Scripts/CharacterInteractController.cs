using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour {
    CharacterController2D character;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeReference] HighlightController highlightController;

    Character charData;
    Rigidbody2D rb2D;

    void Awake () {
        character = GetComponent<CharacterController2D> ();
        rb2D = GetComponent<Rigidbody2D> ();
        charData = GetComponent<Character> ();
    }
    void Update () {
        Check ();

        if (Input.GetMouseButtonDown (1)) {
            Interact ();
            Debug.Log ("button Pressed");
        }
    }

    void Check () {
        Vector2 position = rb2D.position + character.lastMovementVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll (position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders) {
            Interactable hit = c.GetComponent<Interactable> ();
            if (hit != null) {
                highlightController.Highlight (hit.gameObject);
                return;

            }
        }
        highlightController.Hide();
    }
    void Interact () {
        Vector2 position = rb2D.position + character.lastMovementVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll (position, sizeOfInteractableArea);
        foreach (Collider2D c in colliders) {
            Interactable interact = c.GetComponent<Interactable> ();
            if (interact != null) {
                interact.Interact (charData);
                break;

            }
        }
    }
}