using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject[] door;
    Vector3[] _close=new Vector3[2];
    Vector3[] _open = new Vector3[2];
    float _posDoorY = 0f;
    //float _closeDoorY= 0f ;
    //float _openDoorY = 5.2f;
    public GameObject doorTrigger;
    public Renderer[] lampsRend;
    public float speedMove = 2f;
    public bool lockDoor = false;
    public char vec;
    bool openDoorStatus = false;
    public decimal openDoor = 0;
    int delay = 300;
    public AudioSource SundMove;
    public bool Stay = false;
    public bool Exit = false;
    public bool Enter = false;

    TriggerScript triggerScript;
    // Start is called before the first frame update
    void Start()
    {
        _close[0]=Vector3.zero;
        _close[1] = Vector3.zero;
        _open[0] = Vector3.zero;
        _open[1] = Vector3.zero;
        _open[0].y = 5.2f;
        _open[1].y = 5.2f;
        _close[0] = door[0].transform.position;
        _close[1] = door[1].transform.position;
        _close[0].y = 0f;
        _close[1].y = 0f;
        triggerScript = doorTrigger.GetComponent<TriggerScript>();
        SundMove = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
                openDoor = 1;
                setColor('g');
            }
            else
            {
                setColor('b');
                openDoor = -1;
            }
            MoveDoor();
        }
        else
        {
            setColor('r');
        }
    }
    void MoveDoor()
    {
        for (int i = 0; i < door.Length; i++)
        {
            _posDoorY = door[i].transform.position.y;
            if(openDoor == 1)
            { 
                if(_posDoorY < _open[i].y)
                { Open(i); }
            }
            if (openDoor == -1)
            { 
                if(_posDoorY > _close[0].y)
                { Close(i);  }
            }
            else
            {
                if (_posDoorY > 0f && delay > 0)
                {
                    delay--;
                    setColor('y');
                }
                if ( _posDoorY > 0f && delay < 1)
                {
                    delay = 300;
                    openDoor = -1;
                    setColor('y');
                }
            }
        }
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
        if (other.gameObject.name == "FPSControllerTag") data = true;
        else data = false;
    }
    void Open(int index)
    {
        door[index].transform.Translate(_open[index] * Time.deltaTime * speedMove);
        if (door[index].transform.position.z == 0f) openDoorStatus = false;
            SundMove.Play();
    }
    void Close(int index)
    {
        
        door[index].transform.Translate(_close[index] * Time.deltaTime * speedMove);
        if (door[index].transform.position.z == 0f) openDoorStatus = true;
        SundMove.Play();
    }
}
