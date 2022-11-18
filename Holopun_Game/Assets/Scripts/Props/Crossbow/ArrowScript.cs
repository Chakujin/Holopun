using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowScript : MonoBehaviour
{
    private XRGrabInteractable myGrab;

    [SerializeField] private GameObject m_Trail;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider myColl;
    public bool shoted = false;
    private ArrowPoolObject m_arrowPool;
    
    private Transform startParentPos;
    [SerializeField] private int i_forceImpulse;

    public GameObject playerShot;

    [HideInInspector] public bool arrowCharged = false;

    //Event
    public delegate void ChangeArrowCharged();
    public event ChangeArrowCharged ChangeArrowChargedCallback;

    private void Start()
    {
        myGrab = GetComponent<XRGrabInteractable>();
        myGrab.interactionManager = GameObject.FindGameObjectWithTag("InteractionManager")
            .GetComponent<XRInteractionManager>();

        m_arrowPool = transform.parent.GetComponent<ArrowPoolObject>();

        startParentPos = transform.parent;
    }

    public void DesactiveCollisions() //Called when grab arrow (event) and charge crossbow
    {
        if (arrowCharged == true)
        {
            if(ChangeArrowChargedCallback != null)
            {
                ChangeArrowChargedCallback.Invoke(); //Send messaje to crossbow quit arrow and change machine state
            }
            arrowCharged = false;
        }
        else //Is not charged
        {
            Debug.Log("Flechita");
            m_arrowPool.RequestArrow();
        }
        transform.parent = null;

        //Collisions and Physics
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
        m_Trail.SetActive(true); //Active trail FX

        rb.AddForce(transform.right * i_forceImpulse, ForceMode.Acceleration);
        ChangeArrowChargedCallback.Invoke();
    }

    public void DropArrow()
    {
        myColl.isTrigger = false;
        myColl.enabled = true;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IHiteable>() != null)//If have Ihitable interface
        {
            collision.gameObject.GetComponent<IHiteable>().Hited(playerShot);//Use interface
        }
        CollisionWithSomething();
        //Debug.Log(collision.gameObject);
    }

    private void CollisionWithSomething()
    {
        transform.parent = startParentPos; //Return to pool

        //Active trigger
        myColl.isTrigger = true;
        rb.isKinematic = true;
        rb.useGravity = false;

        //Reset position
        transform.localPosition = m_arrowPool.v_arrowStartPosition;
        transform.localEulerAngles = m_arrowPool.v_arrowStartRotation;

        gameObject.SetActive(false);

        shoted = false;   //Enable bool
        m_Trail.SetActive(false); //Desactive trail FX
    }
}
