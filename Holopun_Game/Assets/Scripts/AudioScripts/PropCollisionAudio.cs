using UnityEngine;

public class PropCollisionAudio : MonoBehaviour
{
    [SerializeField] private AudioSource m_audioSource;
    private void OnCollisionEnter(Collision collision)
    {
        m_audioSource.Play();
    }
}
