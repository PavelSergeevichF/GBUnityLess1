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
    int delay = 30;
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
            if (other.gameObject.name == nameOrTag && delay > 0) { data = true; delay--; }
            else { data = false; delay = 30; }
        }
        else
        {
            if (other.gameObject.tag == nameOrTag && delay > 0) { data = true; delay--; }
            else { data = false; delay = 30; }
        }
    }
}
