using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostRing : MonoBehaviour
{
    public float boostForce;
    public Transform orientation;
    public Collider otherr;
    Vector3 a;

    public bool delayedForward;
    public bool forward = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && forward)
        {
            other.GetComponent<Rigidbody>().velocity = a;
            other.GetComponent<Rigidbody>().AddForce(orientation.forward * boostForce);
        }
        if (other.CompareTag("Player") && delayedForward){
            other.GetComponent<Rigidbody>().AddForce(orientation.up * boostForce);
            otherr = other;
            Invoke("Delay", .1f);
        }
        if (other.CompareTag("Player") && !forward)
            other.GetComponent<Rigidbody>().AddForce(orientation.up * boostForce);
    }

    private void Delay()
    {
        otherr.GetComponent<Rigidbody>().AddForce(orientation.up * boostForce);
    }
}
