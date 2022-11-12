using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnRotation : MonoBehaviour
{
    [Range(0,50)]
    [SerializeField] private int i_speed;

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y + i_speed * Time.deltaTime,0);
    }
}
