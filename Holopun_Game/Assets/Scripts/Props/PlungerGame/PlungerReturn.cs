using UnityEngine;

public class PlungerReturn : MonoBehaviour
{
    [SerializeField] private GameObject m_plungerPool;
    [SerializeField] private GameObject m_playerSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plunger")
        {
            ReturnPlunger(other.gameObject);
        }
        if (other.gameObject.GetComponentInParent<Transform>().parent.tag == "Player")
        {
            ReturnPlayer(other.gameObject);
        }
    }

    private void ReturnPlunger(GameObject plunger)
    {
        Debug.Log("PlungerWater");
        plunger.transform.parent = m_plungerPool.transform;

        plunger.transform.position = Vector3.zero;
        plunger.transform.localEulerAngles = Vector3.zero;

        plunger.SetActive(false);
    }

    private void ReturnPlayer(GameObject obj)
    {
        obj.transform.localPosition = m_playerSpawn.transform.localPosition;
    }
}
