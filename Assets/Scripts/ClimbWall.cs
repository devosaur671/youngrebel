using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbWall : MonoBehaviour
{

    public Transform orientation;
    private Rigidbody rb;

    bool isClimbing;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isClimbing==true) rb.AddForce(orientation.up * 500);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Climb")
        {
            isClimbing = true;
            Debug.Log("collision!");
            rb.AddForce(orientation.up * 500);
        }
    }

    private void OnCollision()
    {

        
        Debug.Log("ClimbStarted");
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if (collision.gameObject.tag == "Climb")
        {
            
            isClimbing = false;
            Debug.Log("collision end");
        }
    }

}
