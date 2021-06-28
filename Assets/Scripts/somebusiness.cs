using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Notify();
public class somebusiness : MonoBehaviour
{
    public event Notify AnyKeyPressed;
    void Update()
    {
        if (Input.anyKey)
        {

            Debug.Log("keypressed");
            OnProcessCompleted();
        } 
    }
    public void OnProcessCompleted()
    {
        Debug.Log("OPC");
        AnyKeyPressed?.Invoke();
    }
}
