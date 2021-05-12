using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class CharacterController2D : MonoBehaviour {
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 2f;
    Vector2 movementVector;
    public Vector2 lastMovementVector;

    public bool purpleArmor;

    public bool chainArmor;
    Animator animator;
    public bool moving;

    void Awake () {
        rigidbody2D = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update () {
        float horizontal = Input.GetAxisRaw ("Horizontal");
        float vertical = Input.GetAxisRaw ("Vertical");

        movementVector = new Vector2 (horizontal, vertical);
        Move ();
        animator.SetFloat ("horizontal", horizontal);
        animator.SetFloat ("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool ("moving", moving);
        if (horizontal != 0 || vertical != 0) {
            lastMovementVector = new Vector2 (horizontal, vertical).normalized;
        }
        animator.SetFloat ("lastHorizontal", horizontal);
        animator.SetFloat ("lastVertical", vertical);
    }
    void Move () {
        rigidbody2D.velocity = movementVector * speed * Time.deltaTime;
    }

    public void EquipPurple () {
        purpleArmor = true;
        chainArmor = false;
        animator.SetBool ("Purple", purpleArmor);
        animator.SetBool ("Chain", chainArmor);
    }

    public void EquipChain () {
        chainArmor = true;
        purpleArmor = false;
        animator.SetBool ("Chain", chainArmor);
        animator.SetBool ("Purple", purpleArmor);
    }

    public void Deequip () {
        chainArmor = false;
        purpleArmor = false;
        animator.SetBool ("Chain", chainArmor);
        animator.SetBool ("Purple", purpleArmor);
    }

}