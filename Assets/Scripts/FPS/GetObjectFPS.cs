using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectFPS : MonoBehaviour
{
    public GameObject getObject;
    public int SetTimePause = 5;
    [SerializeField]bool getObjNow = false;
    bool redySot = false;
    [SerializeField] bool StayGO = false;
    [SerializeField] int timePause;
    public SpawnWeapon spawnWeapon;
    void Start()
    {
        timePause = SetTimePause;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && timePause == SetTimePause&& StayGO) { GetNow(); timePause = 0; }
        if (timePause < SetTimePause) timePause++;
        if (StayGO && getObjNow) spawnWeapon.SotReady = false;
        else spawnWeapon.SotReady = true;
    }
    private void GetNow() 
    {
        if (getObjNow)
        {
            getObjNow = false;
            return;
        }
        if (!getObjNow)
        {
            getObjNow = true;
        }
    }
    void _GetObject()
    {

    }
    private void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("GetObjTag")|| other.CompareTag("DestroyObjTag"))
        {
            StayGO = true;
            if (getObjNow)
            {
                if (!redySot)
                {
                    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    //rb.isKinematic = true;
                }
                redySot = true;
                other.gameObject.transform.position = getObject.transform.position;
                other.gameObject.transform.rotation = getObject.transform.rotation;
            }
            if (redySot && !getObjNow)
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                //rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddForce(transform.forward * 0.05f, ForceMode.Impulse);
            }
        }
        else
            StayGO = false;
    }

}
