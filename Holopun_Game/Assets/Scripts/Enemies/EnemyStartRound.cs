using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyStartRound : MonoBehaviour,IHiteable
{
    [SerializeField] private GameObject m_mesh;
    [SerializeField] private Collider[] m_collisions;
    [SerializeField] private CrossbowGameManager m_gameManager;
    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private VisualEffect m_explosionVFX;

    // Start is called before the first frame update
    private void OnEnable()
    {
        m_mesh.SetActive(true);
        foreach (Collider collider in m_collisions)
        {
            collider.enabled = true;
        }
    }

    public void Hited(GameObject player)
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
        m_explosionVFX.Play();  //FX
        m_audioSource.Play();   //Sound
        yield return new WaitForSeconds(1f);
        m_gameManager.StartRoundCrossbowGame();
        this.gameObject.SetActive(false);
    }
}
