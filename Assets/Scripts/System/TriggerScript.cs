using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool Stay = false;
    public bool Exit = false;
    public bool Enter = false;
    public bool onNameObj = true;
    public string nameOrTag;
    public int setDelay = 3;
    [SerializeField] int delayS = 3;
    [SerializeField] int delayEN = 3;
    [SerializeField] int delayEX = 3;
    private void Start()
    {
        delayS = setDelay;
        delayEN = setDelay;
        delayEX = setDelay;
    }
    private void Update()
    {
        ResetBool();
    }
    void ResetBool()
    {
        if (Stay && delayS > 0) delayS--;
        else { delayS = setDelay; Stay = false; }
        if (Exit && delayEX>0) delayEX--;
        else { delayEX = setDelay; Exit = false; }
        if (Enter && delayEN > 0) delayEN--;
        else { delayEN = setDelay; Enter = false; }
    }
    private void OnTriggerStay(Collider other)
    {
        GetObject(other,ref Stay);
    }
    private void OnTriggerEnter(Collider other)
    {
        GetObject(other, ref Enter);
    }
    private void OnTriggerExit(Collider other)
    {
        GetObject(other, ref Exit);
    }
    void GetObject(Collider other, ref bool data)
    {
        if (onNameObj)
        {
            if (other.gameObject.name == nameOrTag) { data = true; }
            else { data = false;}
            //if (other.gameObject.name == nameOrTag && delay > 0) { data = true; delay--; }
            //else { data = false; delay = 3; }
        }
        else
        {
            if (other.gameObject.tag == nameOrTag ) { data = true;  }
            else { data = false;  }
            //if (other.gameObject.tag == nameOrTag && delay > 0) { data = true; delay--; }
            //else { data = false; delay = 3; }
        }
    }
}
