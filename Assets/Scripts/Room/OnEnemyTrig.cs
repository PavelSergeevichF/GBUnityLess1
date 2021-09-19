using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyTrig : MonoBehaviour
{
    public GameObject triggerZone;
    public GameObject EnemyObj;
    // Start is called before the first frame update
    void Start()
    {
        EnemyObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Work();
    }
    void Work()
    {
        if (triggerZone.GetComponent<TriggerScript>().Enter)
        {
            EnemyObj.SetActive(true);
        }

    }
}
