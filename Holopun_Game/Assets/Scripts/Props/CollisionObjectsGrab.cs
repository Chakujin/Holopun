using System.Collections.Generic;
using UnityEngine;

public class CollisionObjectsGrab : MonoBehaviour
{
    [SerializeField] private List<Collider> myCollisions;
    //Catching the player who has Hover the plunger
    public void OnHoverEntered()
    {
        //Debug.Log("des");
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = false;
        }
    }

    public void OnSelectExit()
    {
        //Debug.Log("Activo");
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = true;
        }
    }
}
