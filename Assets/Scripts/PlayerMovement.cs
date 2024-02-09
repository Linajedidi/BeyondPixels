using System.Collections;
using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    public float speed = 5.0f;
    private float gravity = 20.0f;
    public float turnSpeed = 400.0f;
    public float jumpForce = 8.0f; 
    private Vector3 moveDirection;
    public string verticalInput = "Vertical";
    public string horizontalInput = "Horizontal";
    public string jumpInput = "Jump";
    private bool isJumping = false;
    private bool isGrounded = false;
    public PistolPickUp PistolPickUp;
    public GameObject BulletObject;
    public Transform BulletPoint;
    private float speedFactor ;
    public float accelerationRate;
    public GameObject GO;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        DisablePrefabAndChildren(GO);






    }



    public void DisablePrefabAndChildren(GameObject go)
    {
       
        go.SetActive(false);

        
       
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            isGrounded = true; 
            float vertical = Input.GetAxis(verticalInput);
            anim.SetFloat("AnimationPar", vertical);
            if(vertical == 0f)
            {
                speedFactor = 0.3f;
               // Debug.Log(speedFactor);
               

            }
            else
            {
                speedFactor += Time.deltaTime * accelerationRate;
                speedFactor= Mathf.Clamp(speedFactor, 0.3f,1f);
                
               // Debug.Log(speedFactor);
            }
            anim.SetFloat("SpeedFactor", speedFactor);


            moveDirection = (transform.forward * vertical * speed * speedFactor);

            if (Input.GetButtonDown(jumpInput))
            {
                
                isJumping = true;
                anim.SetBool("IsJumping", true);
            }

        }
        //Debug.Log("Before aiming");
        if (PistolPickUp != null && PistolPickUp.picked)
        {
            //Debug.Log(" aiming");

            AimShoot();
        }
        

        float turn = Input.GetAxis(horizontalInput);
        transform.RotateAround(transform.position, Vector3.up, turn * turnSpeed * Time.deltaTime);

        // Check if the player is jumping
        if (isJumping)
        {
            // Apply the jump force
            moveDirection.y = jumpForce;
            isJumping = false;
            
        }
        if (controller.velocity.y < -1)
        {
            
            anim.SetBool("IsJumping", false);
        }

        moveDirection.y -= gravity * Time.deltaTime;

        //  the character controller
        controller.Move(moveDirection * Time.deltaTime);
    }
    void AimShoot()
    {
        float turn = Input.GetAxis(horizontalInput);
        float vertical = Input.GetAxis(verticalInput);
       
        if (Input.GetMouseButton(1) && isGrounded && (vertical == 0 && turn == 0f))
        {
            Debug.Log("the Player is Aiming ");
            anim.SetBool("isAiming", true);
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("IsShooting", true);
                Debug.Log("Shooting animation ");
                Shoot();
                Debug.Log("the Player is shooting ");
            }
            else
            {
                anim.SetBool("IsShooting", false);

            }


        }
        else
        {
            anim.SetBool("isAiming", false);

        }
    }
    public void Shoot()
    {
        GameObject Bullet = Instantiate(BulletObject, BulletPoint.position, transform.rotation);

  
        if (Bullet != null)
        {
           
           Bullet.GetComponent<Rigidbody>().AddForce(BulletPoint.transform.forward * 40f, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Bullet is null.");
        }
    }

}