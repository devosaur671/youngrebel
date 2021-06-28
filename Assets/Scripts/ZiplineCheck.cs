using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineCheck : MonoBehaviour
{
    Rigidbody rb;
    Vector3 stop;
    bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Zipline")
        //{
           
        //    Debug.Log("zipline check!");
        //    check = true;
        //}
    }
    private void OnCollisionStay(Collision collision)
    {
        //if (collision.gameObject.tag == "Zipline")
        //{
        //    Debug.Log("zipline connected!");
        //   // GetComponent<Rigidbody>().useGravity = false;
        //}
    }
}

