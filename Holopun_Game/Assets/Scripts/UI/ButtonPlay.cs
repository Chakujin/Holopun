using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    private SelectedPlayerManager m_manager;
    private void Start()
    {
        m_manager = GameObject.FindGameObjectWithTag("SelectedPlayer").GetComponent<SelectedPlayerManager>();
    }
    public void PressPlay()
    {
        m_manager.LoadLevel();
    }
}
