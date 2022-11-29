using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlungerScript : MonoBehaviour
{
    [SerializeField] Transform m_raycastPosition;
    private GameObject m_mySpawn;
    
    [Range(0,1),Min(0.1f)]
    [SerializeField] float f_rangeRaycast;

    [HideInInspector] public HighscoreEntry highscoreEntry; //Player ho take the plunger
    [SerializeField] private Collider[] myCollisions;
    [SerializeField] private AudioSource m_audioHit;

    private void Start()
    {
        m_mySpawn = transform.parent.gameObject; //Get parent
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

    //Catching the player who has Hover the plunger
    public void OnGrabPlunger(SelectEnterEventArgs args)
    {
        Debug.Log("Agarro");
        //Debug.Log(args.interactorObject.transform.root);
        highscoreEntry = args.interactorObject.transform.root.GetComponent<HighscoreEntry>();

        transform.parent = null; //Unparent from the pool objects 

        foreach (Collider coll in myCollisions)
        {
            coll.enabled = false;
        }
    }

    public void OnHoverExit()
    {
        Debug.Log("Suelto");
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
