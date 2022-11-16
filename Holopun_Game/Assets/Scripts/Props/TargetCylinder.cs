using UnityEngine;

public class TargetCylinder : MonoBehaviour
{
    private PlungerGameManagerPoints m_myManagerPoints;
    [SerializeField] private ParticleSystem m_particleSystem;
    [SerializeField] private int i_points;
    private void Awake()
    {
        m_myManagerPoints = GameObject.FindGameObjectWithTag("PlungerGameManager").GetComponent<PlungerGameManagerPoints>();
    }

    [SerializeField] private Renderer m_renderer;
    private bool b_hited = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plunger" && b_hited == false)
        {
            GameObject myObject = other.gameObject; // Take plunger enter

            if(myObject.GetComponent<PlungerScript>().CompareDirection() == true)
            {
                AddPoints(myObject.GetComponent<PlungerScript>().highscoreEntry);//Get player ho has drop the plunger
                PlungerInside(myObject);
            }
        }
    }

    private void PlungerInside(GameObject plunger)
    {
        //Reset positions to add fixed
        plunger.transform.parent = transform;
        plunger.transform.localPosition = Vector3.zero;
        plunger.transform.localEulerAngles = transform.localEulerAngles;

        //Ennable false movement
        Rigidbody rb = plunger.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        b_hited = true;

        //Change Alpha color to 100% alpha
        Color color = m_renderer.material.color;
        color.a = 0;
        m_renderer.material.color = color;

        m_myManagerPoints.UpdateScoreborad(); //Updatea el scoreboard (Alomejor solo haverlo al final del juego)
        m_particleSystem.Play();
    }
    private void AddPoints(HighscoreEntry playerHighscore)
    {
        playerHighscore.score = + i_points;
    }
}
