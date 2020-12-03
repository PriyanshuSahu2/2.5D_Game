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
    [SerializeField] float JumpForce = .5f;
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
    [SerializeField] float scaleOverTime =1;
    private bool canJump = true;
    private AudioSource audio;
    [SerializeField] AudioClip[] audioClips;
    RaycastHit hit;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
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
            JumpForce+=increasJumpForceOverTime*Time.deltaTime;
            scaleOverTime -= 0.5f * Time.deltaTime;
            transform.localScale = new Vector3(1, scaleOverTime, 1);
            if(!audio.isPlaying)
                audio.PlayOneShot(audioClips[0]);



        }
        if(JumpForce >= MaxJumpForce && isGrounded)
        {

            
            float tempX = horizontal * Speed;
            float tempY = MaxJumpForce;
            scaleOverTime = 1;
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(tempX * 1.5f, tempY);
            JumpForce = .5f;
           
        }
        if(Input.GetKeyUp(KeyCode.Space) && isGrounded && JumpForce <= MaxJumpForce)
        {
            audio.PlayOneShot(audioClips[1]);
            scaleOverTime = 1;
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(horizontal * Speed * 1.5f, JumpForce);
            JumpForce = .5f;
            
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
