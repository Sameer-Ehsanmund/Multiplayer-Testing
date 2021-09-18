using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController cc;

    Vector3 direction;

    [SerializeField] private float speed;

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            cc.SimpleMove(direction * speed * Time.deltaTime);
        }

        if (direction.magnitude <= 0.1f)
        {

            cc.SimpleMove(direction * speed * Time.deltaTime);
        }
    }
}
