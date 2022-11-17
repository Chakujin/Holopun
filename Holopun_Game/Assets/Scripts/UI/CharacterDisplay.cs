using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    [Header("Data")]
    /*[HideInInspector]*/public List<CharacterData> characterData;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI m_playerName;
    [SerializeField] private GameObject CharacterSpawn;
    
    [SerializeField]private int i_currentSelected;
    private GameObject currentPlayer;
    [SerializeField] private SelectedPlayerManager m_selectedmanager;

    public void PassDatas(CharacterData[] data)
    {
        characterData.Clear(); //Clean data level

        characterData.AddRange(data);
        
        i_currentSelected = 0;
        UpdateCharacter();
    }

    public void PressRigth()
    {
        if (characterData != null)
        {
            Debug.Log("Press Rigth");
            i_currentSelected++;//Update current num
            if (i_currentSelected > characterData.Count -1)//If is bigger than max length list retur 0
            {
                i_currentSelected = 0;
                UpdateCharacter();
            }
            else
            {
                UpdateCharacter();
            }
        }
    }

    public void PressLeft()
    {
        if (characterData != null)
        {
            i_currentSelected--;//Update current num
            if (i_currentSelected < 0)//If current num is -1 go to max num list
            {
                i_currentSelected = characterData.Count -1; //Take max num list
                UpdateCharacter();
            }
            else
            {
                UpdateCharacter();
            }
        }
    }

    private void UpdateCharacter()
    {
        m_selectedmanager.SetCharacter(characterData[i_currentSelected].playerIngame);//Pass player to manager
        m_playerName.text = characterData[i_currentSelected].playerName; // Pass name

        if (currentPlayer != null)
        {
            Destroy(currentPlayer.gameObject);//Delete last Character
        }
        currentPlayer = Instantiate(characterData[i_currentSelected].characterSelect, CharacterSpawn.transform);//Instantiate new character
    }
}
