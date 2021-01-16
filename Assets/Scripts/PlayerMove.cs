using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    public float dashSpeed;
    public float maxDistance;
    bool grounded = false;
    bool dash = true;
    public BoxCollider playerCollider;
    public BoxCollider dashCollider;
    public Rigidbody rigidbody;

    public Transform player;

    void Start (){
        Physics.IgnoreLayerCollision(0,9,true);
    }
    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)&&dash){
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,-10));
            
            Vector3 moveVector = (mousepos - player.transform.position)* dashSpeed;
            moveVector.z =0;
            Debug.Log(moveVector);
 
            rigidbody.AddForce(moveVector);
            dash = false;
        }   
    }

    void FixedUpdate (){
        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");


        if(jump == 1 && grounded){
            rigidbody.AddForce(new Vector3(0,jumpSpeed,0));
            grounded = false;
        }

        
        

        Vector3 move = new Vector3(horizontal*speed,0,0);
        rigidbody.AddForce(move);
    }

    void OnCollisionEnter (Collision collision){
        
        if(collision.gameObject.layer == 8){
            grounded = true;
            dash = true;
        }
        if(collision.gameObject.layer == 9){
            dash = true;
        }

    }

    void OnTriggerEnter(Collider dashReset)
    {
        dash = true;
    }

}
