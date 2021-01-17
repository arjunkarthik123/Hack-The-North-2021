using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    bool grounded = false;
    public BoxCollider collider;

    // Update is called once per frame
    void Update(){

        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");

        Vector2 move;

        if(jump == 1 && grounded){
            move = new Vector2(horizontal,jump*jumpSpeed);
            grounded = false;
        }
        else {
            move = new Vector2(horizontal,0);
        }
        

        
        transform.Translate(move*Time.deltaTime*speed);
    }

    void FixedUpdate (){
        
    }

    void OnCollisionEnter (Collision collision){
        if(collision.gameObject.layer == 8){
            grounded = true;
        }
    }
}
