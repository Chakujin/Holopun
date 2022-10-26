using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlungerScript : MonoBehaviour
{
    [SerializeField] Transform m_raycastPosition;
    [SerializeField] float f_rangeRaycast;

    public HighscoreEntry highscoreEntry;
    [SerializeField] private Collider[] myCollisions;
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
    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        //Debug.Log(args.interactorObject.transform.root);
        highscoreEntry = args.interactorObject.transform.root.GetComponent<HighscoreEntry>();
        //Debug.Log("des");
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = false;
        }
    }

    public void OnHoverExit()
    {
        //Debug.Log("Activo");
        foreach (Collider coll in myCollisions)
        {
            coll.enabled = true;
        }
    }
}
