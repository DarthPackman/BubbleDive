using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    public float boostSpeed;

    private Vector2 moveDirection;
    private Vector3 movementDirection;
    private float boosting;
    private float tempBoost;
    public float rotationSpeed;
    public float resetRotationSpeed;

    public InputActionReference move;
    public InputActionReference boost;

    public Animator animator;

    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
        boosting = boost.action.ReadValue<float>();

        if (boosting != 0)
        {
            tempBoost = boostSpeed;
        }
        else
        {
            tempBoost = 1f;
        }

        movementDirection = new Vector3(0, moveDirection.y, moveDirection.x);
        movementDirection.Normalize();

        transform.Translate(movementDirection * moveSpeed * tempBoost * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (transform.rotation != Quaternion.Euler(0, 0, 0))
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), resetRotationSpeed * Time.deltaTime);
        }


        if (moveDirection != Vector2.zero)
        {
            animator.SetInteger("State", 1);

            if (boosting != 0)
            {
                animator.SetInteger("State", 2);
            }
        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }
}
