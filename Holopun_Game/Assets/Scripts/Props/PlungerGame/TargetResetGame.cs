using UnityEngine;

public class TargetResetGame : MonoBehaviour
{
    [SerializeField] private PlungerGameReset m_Reset;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plunger")
        {
            m_Reset.PressRestart();
            other.GetComponent<PlungerScript>().ReturnSpawn();
        }
    }
}
