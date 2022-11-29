using UnityEngine;

public class TargetCylinder : MonoBehaviour
{
    private PlungerGameManagerPoints m_myManagerPoints;

    [SerializeField] private AudioSource m_audio;
    [SerializeField] private ParticleSystem m_particleSystem;
    [SerializeField] private int i_points;
    [SerializeField] private Renderer m_renderer;
    [SerializeField] private Collider m_collider;

    private GameObject myPlunger;

    private void Awake()
    {
        m_myManagerPoints = GameObject.FindGameObjectWithTag("PlungerGameManager").GetComponent<PlungerGameManagerPoints>();
    }

    private void OnEnable()
    {
        PlungerGameReset.RestartGameCallback += RestartGame;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plunger")
        {
            GameObject myObject = other.gameObject; // Take plunger enter

            if(myObject.GetComponent<PlungerScript>().CompareDirection() == true)
            {
                AddPoints(myObject.GetComponent<PlungerScript>().highscoreEntry);//Get player ho has drop the plunger

                //Off collider trigger
                m_collider.enabled = false;
                
                PlungerInside(myObject);
            }
        }
    }

    private void PlungerInside(GameObject plunger)
    {
        myPlunger = plunger;
        //Reset positions to add fixed
        myPlunger.transform.parent = transform;
        myPlunger.transform.localPosition = Vector3.zero;
        myPlunger.transform.localEulerAngles = transform.localEulerAngles;

        //Ennable false movement
        Rigidbody rb = myPlunger.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        //Change Alpha color to 100% alpha
        Color color = m_renderer.material.color;
        color.a = 0;
        m_renderer.material.color = color;

        m_myManagerPoints.UpdateScoreborad(); //Updatea el scoreboard (Alomejor solo haverlo al final del juego)
        
        m_particleSystem.Play();// FX
        m_audio.Play();
    }
    private void AddPoints(HighscoreEntry playerHighscore)
    {
        playerHighscore.score = + i_points;
    }

    private void RestartGame()
    {
        //Change Alpha color to 0% alpha
        Color color = m_renderer.material.color;
        color.a = 255;
        m_renderer.material.color = color;

        //Quit plunger
        myPlunger.GetComponent<PlungerScript>().ReturnSpawn();

        //On collider trigger
        m_collider.enabled = true;
    }
}
