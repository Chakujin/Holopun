using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour,IHiteable
{
    [SerializeField] private NavMeshAgent m_agent;
    [SerializeField] private List<GameObject> m_playersList; //If dont serializable null ref error
    private GameObject m_selectedPlayer;

    private EnemiesSpawnedManager m_enemiesSpawnManager;
    [SerializeField] private GameObject m_mesh;

    [SerializeField] private BoxCollider m_collider;
    [SerializeField] private Rigidbody m_rb;

    [SerializeField]private int i_dmg;
    private bool b_findPlayer = false;
    
    //Voids
    private void Start()
    {
        m_playersList.AddRange(GameObject.FindGameObjectsWithTag("Player")); //Get players
        m_enemiesSpawnManager = GameObject.FindGameObjectWithTag("CrossbowGameManager").GetComponent<EnemiesSpawnedManager>();

        m_agent.speed = CrossbowGameManager.enemySpeed;

        CrossbowGameManager.FinishGameCallback += FinishGame;

        FindPlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //Attack player
        {
            gameObject.GetComponent<PlayerCorsbowGame>().TakeDamage(i_dmg);
            StartCoroutine(Die());
        }
    }

    //FindPlayer
    private void FindPlayer()
    {
        while (b_findPlayer == false)
        {
            int i = Random.Range(0, m_playersList.Count);//Take random num
            if (m_playersList[i].GetComponent<PlayerCorsbowGame>().Alive == true)
            {
                m_selectedPlayer = m_playersList[i];
                m_agent.destination = m_selectedPlayer.transform.position;//Find Player

                m_selectedPlayer.GetComponent<PlayerCorsbowGame>().PlayerDieCallback += PlayerFindedDie; // Subscribe to the event current player

                b_findPlayer = true;
            }
        }
    }

    private void PlayerFindedDie()
    {
        m_selectedPlayer.GetComponent<PlayerCorsbowGame>().PlayerDieCallback -= PlayerFindedDie; //Unsubscrube the event 
        
        b_findPlayer = false;
        FindPlayer(); //Find new player
    }

    //Hits
    public void Hited(GameObject playerHitMe)//IHiteable Interface
    {
        Debug.Log("Enemy Hited");
        playerHitMe.GetComponentInParent<HighscoreEntry>().score++; // Get highscore player and update

        m_enemiesSpawnManager.UpdateEnemiesKilled(); // Update total enemies killed manager
        StartCoroutine(Die());
    }

    private void FinishGame()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator Die()
    {
        //Make Static mesh
        m_collider.enabled = false;
        m_rb.isKinematic = true;
        m_rb.useGravity = false;
        m_agent.velocity = Vector3.zero;

        m_mesh.SetActive(false);
        //FX
        //Audio
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
