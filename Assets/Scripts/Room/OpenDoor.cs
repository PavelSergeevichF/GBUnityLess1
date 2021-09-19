using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject targetOpen;
    public GameObject targetClose;
    public GameObject doorTrigger;
    public Renderer[] lampsRend;
    public float speedMove = 2f;
    public bool lockDoor = false;
    bool _ReadyPlaySound = true;
    public AudioSource SundMove;
    public bool Stay = false;
    public bool Exit = false;
    public bool Enter = false;
    TriggerScript triggerScript;
    void Start()
    {
        triggerScript = doorTrigger.GetComponent<TriggerScript>();
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
            if (triggerScript.Stay)
            {
                //открытие
                if (door.transform!= targetOpen.transform)
                {
                    MoveDoor(targetOpen);
                }
                setColor('g');
            }
            else
            {
                //закрытие
                if (door.transform != targetClose.transform)
                {
                    MoveDoor(targetClose);
                }
                setColor('b');
            }
        }
        else
        {
            setColor('r');
        }
    }
    void MoveDoor(GameObject doorObj)
    {
        if(_ReadyPlaySound)
        {
            _ReadyPlaySound = false;
            SundMove.Play();
        }
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
        //if (other.gameObject.name == "FPSControllerTag") data = true;
        if (other.gameObject.tag == "FPSControllerTag") data = true;
        else data = false;
    }
}
