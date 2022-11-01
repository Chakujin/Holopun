using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPoolObject : MonoBehaviour
{
    [SerializeField] private int i_amount;
    [SerializeField] private GameObject ArrowPref;
    private List<GameObject> arrowsList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        AddArrowToPool(i_amount);
    }

    private void AddArrowToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject arrow = Instantiate(ArrowPref);
            arrow.SetActive(false);
            arrowsList.Add(arrow);
            arrow.transform.parent = transform;
        }
    }

    public GameObject RquestArrow()
    {
        for (int i = 0; i<arrowsList.Count; i++)
        {
            if (arrowsList[i].activeSelf)
            {
                arrowsList[i].SetActive(true);
                return arrowsList[i];
            }
        }

        return null;
    }
}