using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;
    public float boostSpeed;

    public Vector2 moveDirection;
    private float boosting;

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

        if(boosting != 0)
        {
            rb.velocity = new Vector3(0, moveDirection.y * moveSpeed * boostSpeed, moveDirection.x * moveSpeed * boostSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0, moveDirection.y * moveSpeed, moveDirection.x * moveSpeed);
        }

        if(moveDirection != Vector2.zero)
        {
            animator.SetInteger("State", 1);

            if(boosting != 0)
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
