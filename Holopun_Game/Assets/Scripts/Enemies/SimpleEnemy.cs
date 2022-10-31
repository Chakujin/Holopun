using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour,IHiteable
{
    [SerializeField] private NavMeshAgent m_agent;
    [SerializeField] private List<GameObject> m_players; //If dont serializable null ref error
    [SerializeField] private GameObject m_mesh;

    [SerializeField] private BoxCollider m_collider;
    [SerializeField] private Rigidbody m_rb;
    
    //Voids
    private void Start()
    {
        m_players.AddRange(GameObject.FindGameObjectsWithTag("Player")); //Get players
        int i = Random.Range(0,m_players.Count);//Take random num
        m_agent.destination = m_players[i].transform.position;//Find Player
    }
    public void Hited()//IHiteable Interface
    {
        Debug.Log("Enemy Hited");
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
