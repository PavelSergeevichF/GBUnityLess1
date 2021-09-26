using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject targetOpen;
    public GameObject targetClose;
    public GameObject doorTrigger;
    public GameObject doorTrigger1;
    public GameObject doorTrigger2;
    public Renderer[] lampsRend;
    public float speedMove = 2f;
    public bool lockDoor = false;
    bool _ReadyPlaySound = true;
    [SerializeField] bool Open = false;
    public AudioSource SundMove;
    public bool Stay = false;
    public bool Exit = false;
    public bool Enter = false;
    TriggerScript triggerScript;
    TriggerScript triggerScript1;
    TriggerScript triggerScript2;
    void Start()
    {
        triggerScript = doorTrigger.GetComponent<TriggerScript>();
        triggerScript1 = doorTrigger1.GetComponent<TriggerScript>();
        triggerScript2 = doorTrigger2.GetComponent<TriggerScript>();
        SundMove = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckDoor();
    }
    void CheckDoor()
    {
        if (!lockDoor)
        {
            if (triggerScript.Enter) 
            {
                
            }
            if(triggerScript.Enter) 
            {
                if (_ReadyPlaySound)
                {
                    _ReadyPlaySound = false;
                    SundMove.Play();
                }
                
            }
            if (triggerScript.Stay)
            {
                Open = true;
            }
            else
            {
                Open = false;
            }
            if (triggerScript.Exit) 
            { 
                Open = false; 
            }
            if (Open)
            {
                //открытие
                if (door.transform != targetOpen.transform)
                {
                    MoveDoor(targetOpen);
                }
                else
                {
                    _ReadyPlaySound = true;
                }
                setColor('g');
            }
            else
            {

                //закрытие
                if (door.transform != targetClose.transform)
                {
                    if (_ReadyPlaySound)
                    {
                        _ReadyPlaySound = false;
                        SundMove.Play();
                    }
                    MoveDoor(targetClose);
                }
                else 
                {
                    _ReadyPlaySound = true;
                }
                setColor('b');
            }
            //Open = false;
        }
        else
        {
            setColor('r');
        }
    }
    void MoveDoor(GameObject doorObj)
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, doorObj.transform.position,Time.deltaTime* speedMove);
    }
    void setColor(char ch)
    {
        if (ch == 'r') { foreach (var lampRend in lampsRend) { lampRend.material.color = Color.red; } }
        if (ch == 'g') { foreach (var lampRend in lampsRend) { lampRend.material.color = Color.green; } }
        if (ch == 'b') { foreach (var lampRend in lampsRend) { lampRend.material.color = Color.blue; } }
        if (ch == 'y') { foreach (var lampRend in lampsRend) { lampRend.material.color = Color.yellow; } }
    }
    
    void GetObject(Collider other, ref bool data)
    {
        if (other.gameObject.tag == "FPSControllerTag") data = true;
        else data = false;
    }
}
