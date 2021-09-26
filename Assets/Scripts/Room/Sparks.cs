using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{
    public GameObject sparkPartic;
    public int setDelay=250;
    [SerializeField] int getDelay;
    [SerializeField] int delay;
    int DelayResetGet=10;
    int DelayReset ;
    // Start is called before the first frame update
    void Start()
    {
        delay = setDelay;
        DelayReset = DelayResetGet;
        getDelay = Random.Range(10, setDelay);
    }

    // Update is called once per frame
    void Update()
    {
        LoopPart();
    }
    void LoopPart()
    {
        if (delay == getDelay)
        {
            sparkPartic.SetActive(true);
            delay--;
        }
        else
        {
            if (delay > 0) delay--;
            else
            {
                sparkPartic.SetActive(false);
                if (DelayReset > 0)
                {
                    DelayReset--;
                }
                else
                {
                    DelayReset = DelayResetGet;
                    getDelay= Random.Range(10, setDelay);
                    delay = getDelay;//setDelay;
                }
            }
        }
    }
}
