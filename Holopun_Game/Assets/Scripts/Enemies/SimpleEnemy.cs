using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour,IHiteable
{
    [SerializeField] private NavMeshAgent m_agent;
    [SerializeField] private List<GameObject> m_players; //If dont serializable null ref error
    private EnemiesSpawnedManager m_enemiesSpawnManager;
    [SerializeField] private GameObject m_mesh;

    [SerializeField] private BoxCollider m_collider;
    [SerializeField] private Rigidbody m_rb;

    [SerializeField]private int i_dmg;
    private bool b_findPlayer = false;
    
    //Voids
    private void Start()
    {
        m_players.AddRange(GameObject.FindGameObjectsWithTag("Player")); //Get players
        m_enemiesSpawnManager = GameObject.FindGameObjectWithTag("CrossbowGameManager").GetComponent<EnemiesSpawnedManager>();

        while (b_findPlayer == false)
        {
            int i = Random.Range(0, m_players.Count);//Take random num
            if (m_players[i].GetComponent<PlayerCorsbowGame>().Alive == true)
            {
                m_agent.destination = m_players[i].transform.position;//Find Player
                b_findPlayer = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<PlayerCorsbowGame>().TakeDamage(i_dmg);
            StartCoroutine(Die());
        }
    }

    public void Hited()//IHiteable Interface
    {
        Debug.Log("Enemy Hited");
        m_enemiesSpawnManager.UpdateEnemiesKilled(); // Update total enemies killed manager
        StartCoroutine(Die());
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
        Destroy(this);
    }
}
