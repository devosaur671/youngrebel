using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public delegate void Notify();

public class EvntHndlr : MonoBehaviour
{
    public static void Main()
    {
        somebusiness bl = new somebusiness();
        bl.AnyKeyPressed += bl_reaction;
    }

    public static void bl_reaction()
    {
        Debug.Log("Its Ok!");
    }
}
