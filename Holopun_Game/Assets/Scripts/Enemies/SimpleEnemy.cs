using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class SimpleEnemy : MonoBehaviour,IHiteable
{
    [SerializeField] private NavMeshAgent m_agent;
    [SerializeField] private List<GameObject> m_playersList; //If dont serializable null ref error
    private GameObject m_selectedPlayer;

    private EnemiesSpawnedManager m_enemiesSpawnManager;
    [SerializeField] private GameObject m_mesh;

    [SerializeField] private BoxCollider m_collider;

    [SerializeField]private int i_dmg;
    private bool b_findPlayer = false;
    private bool b_finishGame = false;

    [SerializeField] private VisualEffect m_explosionVFX;
    [SerializeField] private AudioSource m_audioSource;

    //Voids
    private void Start()
    {
        m_playersList.AddRange(GameObject.FindGameObjectsWithTag("Player")); //Get players
        m_enemiesSpawnManager = GameObject.FindGameObjectWithTag("EnemiesManager").GetComponent<EnemiesSpawnedManager>();

        m_agent.speed = CrossbowGameManager.enemySpeed;

        CrossbowGameManager.FinishGameCallback += FinishGame;

        FindPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //Attack player
        {
            collision.gameObject.GetComponentInParent<PlayerCorsbowGame>().TakeDamage(i_dmg); //Collision with the player
            
            if(b_finishGame == false)
            {
                Debug.Log("Se temrino");
                StartCoroutine(Die());
            }
        }
    }

    private void FixedUpdate()
    {
        FindPlayer();
    }

    //FindPlayer
    private void FindPlayer()
    {
        if (b_findPlayer == false) //Enemy dont find player and start try find
        {
            int i = Random.Range(0, m_playersList.Count);//Take random num players
            
            if (m_playersList[i].GetComponentInParent<PlayerCorsbowGame>().Alive == true) //If random player taked is alive
            {
                m_selectedPlayer = m_playersList[i]; //Add alive player

                m_selectedPlayer.GetComponentInParent<PlayerCorsbowGame>().PlayerDieCallback += PlayerFindedDie; // Subscribe to the event current player

                b_findPlayer = true; //Finded Player
            }
        }
        if (m_agent != null)
        {
            m_agent.destination = m_selectedPlayer.transform.position; //Find Player
        }
        else
        {
            Debug.Log("Player Borrado player");
        }
    }

    private void PlayerFindedDie()
    {
        m_selectedPlayer.GetComponentInParent<PlayerCorsbowGame>().PlayerDieCallback -= PlayerFindedDie; //Unsubscrube the event 
        
        b_findPlayer = false;
        FindPlayer(); //Find new player
    }

    //Hits
    public void Hited(GameObject playerHitMe)//IHiteable Interface
    {
        playerHitMe.GetComponent<HighscoreEntry>().score++; // Get highscore player and update

        m_enemiesSpawnManager.UpdateEnemiesKilled(); // Update total enemies killed manager
        StartCoroutine(Die());
    }

    private void FinishGame()
    {
        b_finishGame = true;
        m_selectedPlayer.GetComponentInParent<PlayerCorsbowGame>().PlayerDieCallback -= PlayerFindedDie;
        Destroy(gameObject);
    }

    private IEnumerator Die()
    {
        //Make Static mesh
        m_collider.enabled = false;
        m_agent.velocity = Vector3.zero;

        m_mesh.SetActive(false);

        //FX
        m_explosionVFX.Play();
        m_audioSource.Play();
        //Audio
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
