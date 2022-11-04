using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowScript : MonoBehaviour
{
    private XRGrabInteractable myGrab;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider myColl;
    public bool shoted = false;
    private ArrowPoolObject m_arrowPool;
    
    private Transform startParentPos;
    [SerializeField] private int i_forceImpulse;

    private void Start()
    {
        myGrab = GetComponent<XRGrabInteractable>();
        myGrab.interactionManager = GameObject.FindGameObjectWithTag("InteractionManager")
            .GetComponent<XRInteractionManager>();

        m_arrowPool = transform.parent.GetComponent<ArrowPoolObject>();

        startParentPos = transform.parent;
    }

    public void DesactiveCollisions() //Called when grab arrow
    {
        m_arrowPool.RequestArrow();    //Request Arrow
        transform.parent = null;

        myColl.enabled = false;
        myColl.isTrigger = true;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void ActiveCollisions() //Callen when shot the arrow
    {
        myColl.enabled = true;
        myColl.isTrigger = false;
        rb.useGravity = true;
        rb.isKinematic = false;

        shoted = true;

        Vector3 myforward = new Vector3(0,1,0);

        rb.AddForce(myforward * i_forceImpulse, ForceMode.Impulse);
    }

    public void DropArrow()
    {
        Debug.Log("Drop Arrow");
        myColl.isTrigger = false;
        myColl.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void CollisionWithSomething()
    {
        gameObject.SetActive(false);
        transform.parent = startParentPos; //Return to pool

        //Reset position
        transform.position = m_arrowPool.v_arrowStartPosition;
        transform.eulerAngles = m_arrowPool.v_arrowStartRotation;

        shoted = false;   //Enable bool
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IHiteable>() != null)//If have Ihitable interface
        {
            collision.gameObject.GetComponent<IHiteable>();//Use interface
        }
        CollisionWithSomething();
        Debug.Log(collision.gameObject);
    }
}
