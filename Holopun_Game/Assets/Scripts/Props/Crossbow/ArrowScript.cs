using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider myColl;
    
    public Transform startParentPos;
    public void DesactiveCollisions()
    {
        myColl.enabled = false;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void ActiveCollisions()
    {
        myColl.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;

        rb.AddForce(transform.forward * 20, ForceMode.Impulse);
    }

    private void CollisionWithSomething()
    {
        //PoolObjects
        //Return pos
        //Transfrom Attach cadera
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IHiteable>() != null)//If have Ihitable interface
        {
            collision.gameObject.GetComponent<IHiteable>();//Use interface
        }
        CollisionWithSomething();
    }
}
