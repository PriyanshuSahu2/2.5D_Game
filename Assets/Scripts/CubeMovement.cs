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
    [SerializeField] float maxFallingSpeed = 40f;
    [HideInInspector]
    [SerializeField] float direction;
    [SerializeField] LayerMask ground;
    [HideInInspector]
    [SerializeField] Animator anim;
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

        isGrounded = Physics.Raycast(GroundChecker.position, Vector3.down, 1f, ground);
        Debug.DrawRay(GroundChecker.position * 1f, Vector3.down, Color.red);
        horizontal = Input.GetAxis("Horizontal");
        ApplyMovement();
        Jump();
        if(!isGrounded && Input.GetAxis("Horizontal") != 0f)
        {
            if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            transform.Translate(horizontal * Time.deltaTime * Speed, 0, 0, Space.World);
        }
    }

    private void ApplyMovement() //----Applying Movement---//
    {
        Debug.Log($"Space:{Input.GetKey(KeyCode.Space)}");
        if( !Input.GetKey(KeyCode.Space) && isGrounded)
        {
            if (horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            transform.Translate(horizontal * Time.deltaTime * Speed, 0, 0, Space.World);
        }
        
    }

    void Jump() //------Jump---//
    {
        
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            
            JumpForce += 20;
            Debug.Log($"JumpFOrce{JumpForce}");
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {

            if (JumpForce >= MaxJumpForce)
            {
                JumpForce = MaxJumpForce;
            }

            rb.AddForce(transform.up * JumpForce);

        


            if(Input.GetAxis("Horizontal") != 0f)
            {
                if (horizontal > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
                if (horizontal < 0)
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                }
            }
            
            
            //   rb.AddForce(new Vector3(500f, JumpForce, 0));
            // rb.AddRelativeForce(transform.up * JumpForce);
            
            JumpForce = MinJumpForce;
        }
        if (rb.velocity.y < -0.9f)
        {
            Physics.gravity = new Vector3(0, -9.81f * maxFallingSpeed, 0); ;
        }
        else if (rb.velocity.y >= 0f)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
        /*IEnumerator mov()
        {
            Debug.Log("waiting");
            yield return new WaitForSeconds(2f);
            transform.Translate(horizontal * Time.deltaTime * Speed, 0, 0, Space.World);
        }*/
    }
}
