using System.Collections.Generic;
using UnityEngine;

public class CollisionObjectsGrab : MonoBehaviour
{
    [SerializeField] private List<Collider> myCollisions;
    [SerializeField] private Rigidbody myRb;
    //Catching the player who has Hover the plunger
    public void OnHoverEntered()
    {
        //Debug.Log("des");
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = false;
        }
        myRb.useGravity = false;
        myRb.isKinematic = true;
    }

    public void OnSelectExit()
    {
        //Debug.Log("Activo");
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = true;
        }
        myRb.useGravity = true;
        myRb.isKinematic = false;
    }
}
