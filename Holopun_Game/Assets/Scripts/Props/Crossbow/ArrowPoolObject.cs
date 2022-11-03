using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPoolObject : MonoBehaviour
{
    [SerializeField] private int i_amount;
    [SerializeField] private GameObject ArrowPref;
    private List<GameObject> arrowsList = new List<GameObject>();

    public Vector3 v_arrowStartPosition;
    public Vector3 v_arrowStartRotation;

    // Start is called before the first frame update
    void Start()
    {
        AddArrowToPool(i_amount);

        RequestArrow();
    }

    private void AddArrowToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //Instantiate arrowss
            GameObject arrow = Instantiate(ArrowPref);
            arrow.SetActive(false);
            arrowsList.Add(arrow);
            arrow.transform.parent = transform;
            
            //Reposition Arrows
            arrow.transform.localPosition = v_arrowStartPosition;
            arrow.transform.localEulerAngles = v_arrowStartRotation;
        }
    }

    public GameObject RequestArrow()
    {
        for (int i = 0; i<arrowsList.Count; i++)
        {
            if (arrowsList[i].activeSelf)
            {
                arrowsList[i].SetActive(true);
                return arrowsList[i];
            }
        }

        AddArrowToPool(1);
        arrowsList[arrowsList.Count - 1].SetActive(true);
        return arrowsList[arrowsList.Count - 1];
    }
}