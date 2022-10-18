using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlungerGameManagerPoints : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    [SerializeField] private List<HighscoreEntry> highscoreEntryList; //List highscores enters
    private List<Transform> highscoreEntryTransformList;

    // Start is called before the first frame update
    void Awake()
    {
        UpdateScoreborad();
    }
    public void UpdateScoreborad()
    {
        entryTemplate.gameObject.SetActive(false);
        highscoreEntryList = new List<HighscoreEntry>();//
        highscoreEntryTransformList = new List<Transform>();

        //Sort entry list by score
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = 0; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highcoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 0.35f; // space between templates

        Transform entryTransform = Instantiate(entryTemplate, container); //Instance template
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count); // Move template
        entryTransform.gameObject.SetActive(true);

        //Generate temporaly random scores
        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ST";
                break;
            case 3:
                rankString = "3ST";
                break;
        }

        entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = rankString;

        string name = highcoreEntry.name;
        entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;

        int score = highcoreEntry.score;
        entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();

        transformList.Add(entryTransform);
    }
    /*
     * Respresents a single score entry
     */
    private class HighscoreEntry
    {
        public int score;
        public string name;
        
    }
}
