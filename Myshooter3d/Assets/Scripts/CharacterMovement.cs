using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CapsuleCollider capsuleCollider;    
    public Transform CameraTransform;
    public CharacterStatus characterStatus;

    public Animator animator;

    public float vertical;
    public float horizontal;
    public float moveAmount;
    public float rotationSpeed;
    public float jumpForce = 2f;
    Rigidbody rbody;
    //public bool isGrounded;
    public Transform groundChekerTransform;
    public LayerMask groundLayer;

    public Vector3 rotationDirection;
    public Vector3 moveDirection;


    /* void OnCollisionEnter()
    {
        isGrounded=true;
    }*/
    public void MoveUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));
        

        Vector3 moveDir = CameraTransform.forward * vertical;
        moveDir+=CameraTransform.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        rotationDirection=CameraTransform.forward;
        RotationNormal();
        //characterStatus.isGround=Ground();
       /* if (Input.GetKeyDown(KeyCode.Space) )
        {
            Jump();
           // isGrounded = false;
           GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }*/



    }

    /*public void Jump()
    {
        if (Physics.Raycast(groundChekerTransform.position, Vector3.down, 10f, groundLayer))
        {
            rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else

        {
            Debug.Log("text");
        }
    }*/
    /*private void Update()
    {

       
       /* if (Input.GetButtonDown("Jump"))
        {

            rbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }*/
    
    public void RotationNormal()
    {
        if(!characterStatus.isAiming)
        {
            rotationDirection = moveDirection;
        }

        Vector3 targetDir = rotationDirection;
        targetDir.y = 0;
        if(targetDir==Vector3.zero)
            targetDir=transform.forward;


        Quaternion lookDir=Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, rotationSpeed);
        transform.rotation = targetRot;
    }

    public bool Ground()
    {
        Vector3 origin=transform.position;
        origin.y += 0.6f;
        Vector3 dir = -Vector3.up;
        float dis = 0.7f;
        RaycastHit hit;
        if(Physics.Raycast(origin, dir, out hit,dis))
        {
            Vector3 tp=hit.point;
            transform.position = tp;
            return true;
        }

        return false;
    }
}
