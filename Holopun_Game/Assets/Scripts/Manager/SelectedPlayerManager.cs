using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlayerManager : MonoBehaviour
{
    public static SelectedPlayerManager instance;
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
