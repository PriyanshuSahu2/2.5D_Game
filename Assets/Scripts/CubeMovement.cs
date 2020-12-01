using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class CubeMovement : MonoBehaviour
{

    #region
    [SerializeField] float Speed = 3f;
    [HideInInspector]
    [SerializeField] Rigidbody rb;
    [HideInInspector]
    [SerializeField]float horizontal;
    [SerializeField] float JumpForce;
    [SerializeField] float MinJumpForce = 200f;
    [SerializeField] float MaxJumpForce = 600f;
    [HideInInspector]
    [SerializeField] bool isGrounded;
    [SerializeField] float distanceFromGround = 1f;
    [SerializeField] Transform GroundChecker;
    [SerializeField] Transform GroundChecker1;
    [SerializeField] Transform GroundChecker2;
    [SerializeField] float maxFallingSpeed = 40f;
    [SerializeField] float increasJumpForceOverTime = 0.7f;
    [HideInInspector]
    [SerializeField] float direction;
    [SerializeField] LayerMask ground;
    [HideInInspector]
    [SerializeField] Animator anim;
    private bool canJump = true;
    RaycastHit hit;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsGrouned();

        if (isGrounded && Input.GetKey(KeyCode.Space)== false)
        {
            rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
        }
        if(Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        {
            JumpForce+=increasJumpForceOverTime;
        }
        if(JumpForce >= 20f && isGrounded)
        {
            float tempX = horizontal * Speed;
            float tempY = MaxJumpForce;           
            rb.velocity = new Vector2(tempX, tempY);
            JumpForce = 0f;
        }
        if(Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(horizontal * Speed, JumpForce);
            JumpForce = 0f;
        }
    }

    private bool IsGrouned()
    {
        Debug.DrawRay(GroundChecker.position, Vector3.down);
        Debug.DrawRay(GroundChecker1.position, Vector3.down);
        Debug.DrawRay(GroundChecker2.position, Vector3.down);
        if (Physics.Raycast(GroundChecker.position, Vector3.down, 1f) || Physics.Raycast(GroundChecker1.position, Vector3.down, 1f) || Physics.Raycast(GroundChecker2.position, Vector3.down, 1f))
        {
            return true;
        }
        else
            return false;
    }
}
