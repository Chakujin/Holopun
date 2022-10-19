using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    [SerializeField] Transform m_raycastPosition;
    [SerializeField] float f_rangeRaycast;

    private HighscoreEntry m_highscoreEntry;
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

    public void OnTake()
    {
        //m_highscoreEntry = 
    }
}
