using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPhysics : MonoBehaviour
{

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity.y<0){
            rigidbody.velocity += Vector3.up*Physics2D.gravity.y*(fallMultiplier-1)*Time.deltaTime;
        }
        else if (rigidbody.velocity.y>0 && !Input.GetButtonDown("Jump")){
            rigidbody.velocity += Vector3.up*Physics2D.gravity.y*(lowJumpMultiplier-1)*Time.deltaTime;
        }
    }
}
