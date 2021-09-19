using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap01 : MonoBehaviour
{
    public GameObject door;
    public GameObject triggerZone;
    public GameObject spavner;
    public GameObject spavnerCub;
    public GameObject cilling;
    public int SpawnIter=3;
    int num;
    int time = 30;
    public int SpawnDelay = 500;
    bool start = true;
    Rigidbody RB;
    // Start is called before the first frame update
    void Awake()
    {
        spavner.SetActive(false);
        RB = door.GetComponent<Rigidbody>();
        RB.isKinematic = true;
        cilling.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Work();
    }
    void Work()
    {
        if(triggerZone.GetComponent<TriggerScript>().Enter)
        {
            spavner.SetActive(true);
            RB.isKinematic = false;
            start = false;
        }
        if(!start)
        {
            if(time>-1) time--;
            num = spavnerCub.GetComponent<SpawnEnemy>().numSpawn;
            if (num<1 && time<1)
            {
                cilling.SetActive(true);
            }
        }

    }
}
