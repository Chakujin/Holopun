using System.Collections.Generic;
using UnityEngine;

public class PlungerPool : MonoBehaviour
{
    [SerializeField] private int i_amount;
    [SerializeField] private GameObject PlungerPref;
    public List<GameObject> plungersList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        AddPlungerToPool(i_amount);

        RequestPlunger();
    }

    private void AddPlungerToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //Instantiate arrowss
            GameObject plunger = Instantiate(PlungerPref);
            plungersList.Add(plunger);
            plunger.transform.parent = transform;
            plunger.transform.localPosition = Vector3.zero;
            plunger.transform.localEulerAngles = Vector3.zero;

            plunger.SetActive(false);
        }
    }

    public GameObject RequestPlunger()
    {
        for (int i = 0; i < plungersList.Count; i++)
        {
            if (!plungersList[i].activeSelf)
            {
                plungersList[i].SetActive(true);
                return plungersList[i];
            }
        }

        AddPlungerToPool(1);
        plungersList[plungersList.Count - 1].SetActive(true);
        return plungersList[plungersList.Count - 1];
    }
}
