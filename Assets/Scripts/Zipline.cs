using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    public Transform end;
    private float busy;
    bool dist;
 
    void Start()
    {
    }
    void Update()
    {
    }
    IEnumerator MoveObject(Collider other)
    {
        Vector3 b = end.transform.position;
        dist = false;
        
        while (dist == false)
        {
            Debug.Log("edem");
            dist = Vector3.Distance(other.gameObject.transform.position, b) <= 2f;
            other.gameObject.transform.position = Vector3.Lerp(other.gameObject.transform.position, b, Time.deltaTime);
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.velocity = Vector3.zero;
            yield return null;
        }
        other.enabled = true;
        dist = false;
        Debug.Log(dist);
        other.attachedRigidbody.useGravity = true;
        yield return null;

    }
    private void OnTriggerEnter(Collider other)
    {
        dist = false;
        StartCoroutine(MoveObject(other));
        Debug.Log(dist);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(dist);
        dist = false;
        GetComponent<Collider>().enabled = true;
    }
}
