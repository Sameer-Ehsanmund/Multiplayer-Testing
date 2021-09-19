using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class playerMovement : MonoBehaviour
{

    public CharacterController cc;

    Vector3 velocity;

    private float speed = 12.0f;
    private float gravity = -20.0f;
    private float jumpHeight = 3.0f;

    private bool groundedPlayer;

    PhotonView phV;

    void Start()
    {

        phV = GetComponent<PhotonView>();
    }

    void Update()
    {

        if (phV.IsMine)
        {

            groundedPlayer = cc.isGrounded;

            if (groundedPlayer && velocity.y < 0)
            {

                velocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            cc.Move(move * Time.deltaTime * speed);

            if (move != Vector3.zero)
            {

                gameObject.transform.forward = move;
            }

            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {

                velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
        }       
    }
}
