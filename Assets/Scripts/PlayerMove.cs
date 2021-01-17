using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    bool grounded = false;
<<<<<<< Updated upstream
    public BoxCollider collider;

    // Update is called once per frame
    void Update(){

=======
    private bool dash = true;
    public BoxCollider playerCollider;
    public BoxCollider dashCollider;
    public Rigidbody rigidbody;
    public float dashTime;
    private float timeDashed;
    bool test=false;
    public Animator anim;

    public Transform player;

    void Start (){
        Physics.IgnoreLayerCollision(0,9,true);
    }
    // Update is called once per frame
    void Update(){
 

        if (Input.GetKeyDown(KeyCode.Mouse0) && dash)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            timeDashed = Time.realtimeSinceStartup;
      
            Vector3 moveVector = (mousepos - player.transform.position) * dashSpeed;
            rigidbody.drag = 10;
            moveVector.z = 0;

            rigidbody.AddForce(moveVector);
            dash = false;
        }

        if (Time.realtimeSinceStartup - timeDashed >= dashTime)
        {
            rigidbody.drag = 1;
        }

 

    }

    void FixedUpdate (){

>>>>>>> Stashed changes
        float horizontal = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");

        Vector2 move;

        if(jump == 1 && grounded){
            move = new Vector2(horizontal,jump*jumpSpeed);
            grounded = false;
        }
<<<<<<< Updated upstream
        else {
            move = new Vector2(horizontal,0);
        }
        

        
        transform.Translate(move*Time.deltaTime*speed);
=======
        if (horizontal != 0)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
        rigidbody.velocity = new Vector2(horizontal*speed,rigidbody.velocity.y);

>>>>>>> Stashed changes
    }

    void FixedUpdate (){
        
    }

    void OnCollisionEnter (Collision collision){
        if(collision.gameObject.layer == 8){
            grounded = true;
        }
    }
<<<<<<< Updated upstream
=======

    void OnTriggerEnter(Collider dashReset)
    {
        test = true;
        dash = true;
    
    }

>>>>>>> Stashed changes
}
