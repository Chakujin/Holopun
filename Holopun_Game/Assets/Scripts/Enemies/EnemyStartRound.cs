using System.Collections;
using UnityEngine;

public class EnemyStartRound : MonoBehaviour,IHiteable
{
    [SerializeField] private GameObject m_mesh;
    [SerializeField] private Collider[] m_collisions;
    [SerializeField] private CrossbowGameManager m_gameManager;

    // Start is called before the first frame update
    private void OnEnable()
    {
        m_mesh.SetActive(true);
        foreach (Collider collider in m_collisions)
        {
            collider.enabled = true;
        }
    }

    public void Hited()
    {
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        //Enable Mesh
        m_mesh.SetActive(false);
        foreach (Collider collider in m_collisions)
        {
            collider.enabled = false;
        }
        //FX
        //Sound
        yield return new WaitForSeconds(1f);
        m_gameManager.StartRoundCrossbowGame();
        this.gameObject.SetActive(false);
    }
}
