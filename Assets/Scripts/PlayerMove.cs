using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    bool grounded = false;
    public BoxCollider collider;
    public Rigidbody rigidbody;

    // Update is called once per frame
    void Update(){

        
    }

    void FixedUpdate (){
        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");


        if(jump == 1 && grounded){
            Debug.Log("LUL");
            rigidbody.AddForce(new Vector3(0,jumpSpeed,0));
            grounded = false;
        }
        
        

        Vector3 move = new Vector3(horizontal*speed,0,0);
        rigidbody.AddForce(move);
    }

    void OnCollisionEnter (Collision collision){
        
        if(collision.gameObject.layer == 8){
            grounded = true;
        }
    }
}
