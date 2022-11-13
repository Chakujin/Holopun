using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTypeGame : MonoBehaviour
{
    [SerializeField] private GameObject m_singlePlayerCanvas;
    // [SerializeField] private GameObject m_multiPlayerCanvas;
    [SerializeField] private GameObject m_choseTypeCanvas;

    public void PressSinglePlayer()
    {
        m_singlePlayerCanvas.SetActive(true);
        m_choseTypeCanvas.SetActive(false);
    }

    public void PressMultiplayer()
    {
        //Hay que montarlo
    }
}
