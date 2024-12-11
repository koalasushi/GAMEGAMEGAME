using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private CharacterController characterController;
    public float gravity = 90;
    public float jumpSpeed = 15;
    public float Speed = 5f;
    Vector3 moveVelocity;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        if(characterController.isGrounded){
            moveVelocity = new Vector3(Speed * hInput, 0, Speed * vInput);
            if(Input.GetButton("Jump")){
                moveVelocity.y = jumpSpeed;
            }
        }

        moveVelocity.y -= gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);

        if(hInput > 0){
            gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else if(hInput < 0){
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
