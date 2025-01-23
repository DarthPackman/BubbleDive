using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    public float boostSpeed;
    private float boosting;
    public Vector2 moveDirection;

    public InputActionReference move;
    public InputActionReference boost;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
        boosting = boost.action.ReadValue<float>();


        //CHECKING IF THE PLAYER IS BOOSTING HIMSELF.
        if (boosting != 0) {
            rb.velocity = new Vector3(0, moveDirection.y * moveSpeed * boostSpeed, moveDirection.x * moveSpeed * boostSpeed);
        } else
        {
            rb.velocity = new Vector3(0, moveDirection.y * moveSpeed, moveDirection.x * moveSpeed);
        }

        //CHANGE DIRECTION OF THE PLAYER
        if (moveDirection != Vector2.zero) { 
            transform.forward = moveDirection;
        }


        //ANIMATION CODE
        if (moveDirection.x != 0 || moveDirection.y != 0) {
            animator.SetInteger("State", 1);
        }else
        {
            animator.SetInteger("State", 0);
        }
    }

}
