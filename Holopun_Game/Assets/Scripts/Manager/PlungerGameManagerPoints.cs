using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlungerGameManagerPoints : MonoBehaviour
{
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;

    // Start is called before the first frame update
    void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 0.35f; // space between templates
        //Generate Templates
        for (int i = 0; i < 10; i++) //Can change 10 by total num players
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer); //Instance template
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i); // Move template
            entryTransform.gameObject.SetActive(true);
        }
    }
}
