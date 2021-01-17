using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float dashSpeed;
    bool grounded = false;
    bool dash = true;
    public BoxCollider collider;
    public Rigidbody rigidbody;

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray.direction);
            rigidbody.AddForce(ray.direction * dashSpeed);
            dash = false;
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");


        if (jump == 1 && grounded)
        {
            rigidbody.AddForce(new Vector3(0, jumpSpeed, 0));
            grounded = false;
        }





        Vector3 move = new Vector3(horizontal * speed, 0, 0);
        rigidbody.AddForce(move);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 8)
        {
            grounded = true;
            dash = true;
        }

    }
}
