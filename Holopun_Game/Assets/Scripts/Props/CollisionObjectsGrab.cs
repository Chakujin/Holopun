using System.Collections.Generic;
using UnityEngine;

public class CollisionObjectsGrab : MonoBehaviour
{
    [SerializeField] private List<Collider> myCollisions;
    [SerializeField] private Rigidbody myRb;
    //Catching the player who has Hover the plunger
    public void OnHoverEntered() //XR Grab event
    {
        foreach (Collider coll in myCollisions) //enable false all collisions
        {
            coll.enabled = false;
        }
        //Use gravity false
        myRb.useGravity = false;
        myRb.isKinematic = true;
    }

    public void OnSelectExit() //XR Grab event
    {
        foreach (Collider coll in myCollisions) //enbale true all collisions
        {
            coll.enabled = true;
        }
        //Use gravity true
        myRb.useGravity = true;
        myRb.isKinematic = false;
    }
}
