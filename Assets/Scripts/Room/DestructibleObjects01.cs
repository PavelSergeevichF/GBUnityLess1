using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjects01 : MonoBehaviour
{
    Rigidbody RB;
    public bool Contact = false;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Contact)
        {
            RB.isKinematic = false;
            RB.useGravity = true;
        }
    }

}
