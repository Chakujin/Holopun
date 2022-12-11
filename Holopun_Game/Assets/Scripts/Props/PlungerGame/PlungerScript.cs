using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlungerScript : MonoBehaviour
{
    [SerializeField] Transform m_raycastPosition;
    private GameObject m_mySpawn;
    private PlungerPool m_myPool;
    
    [Range(0,1),Min(0.1f)]
    [SerializeField] float f_rangeRaycast;

    [HideInInspector] public HighscoreEntry highscoreEntry; //Player ho take the plunger
    [SerializeField] private Collider[] myCollisions;
    [SerializeField] private AudioSource m_audioHit;

    private bool b_lastSpawned = false;

    private void Start()
    {
        m_mySpawn = transform.parent.gameObject; //Get parent
        m_myPool = m_mySpawn.GetComponent<PlungerPool>();
    }

    public bool CompareDirection()
    {
        //Start raycast
        RaycastHit hit;
        if (Physics.Raycast(m_raycastPosition.position, m_raycastPosition.forward, out hit, f_rangeRaycast))
        {
            if (hit.collider.tag == "Mesh")
            {
                return true;
            }
            Debug.Log(hit.transform.gameObject);
            Debug.DrawRay(m_raycastPosition.position, m_raycastPosition.forward, Color.green);
        }
        return false;
    }

    public void OnHoverEnter()
    {
        if (gameObject.transform.parent.tag == "PlungerSpawn")
        {
            b_lastSpawned = true;
        }
    }

    //Catching the player who has Hover the plunger
    public void OnGrabPlunger(SelectEnterEventArgs args)
    {
        highscoreEntry = args.interactorObject.transform.root.GetComponent<HighscoreEntry>();

        if(b_lastSpawned == true)
        {
            b_lastSpawned = false;
            m_myPool.RequestPlunger();
        }

        transform.parent = null; //Unparent from the pool objects 

        foreach (Collider coll in myCollisions)
        {
            coll.enabled = false;
        }
    }

    public void OnHoverExit()
    {
        //Debug.Log("Suelto");
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = true;
        }
    }

    public void ReturnSpawn()
    {
        //Take Parent
        transform.parent = m_mySpawn.transform;
       
        //Reset position
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;

        //Active collisions
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = true;
        }
        
        //Turn off gameobject
        gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        m_audioHit.Play();
    }
}
