using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfView : MonoBehaviour
{

    public Vector3 SizeBoxCast;
    public float _seeAtDistance = 2f;
    public bool isSee = false;
    public Vector3 pointTarget;
    void Start()
    {
        SizeBoxCast.x = 0.01f;
        SizeBoxCast.y = 0.01f;
        SizeBoxCast.z = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        Show();
    }
    public void Show()
    {
        if (
              Physics.BoxCast
              (
                transform.position, SizeBoxCast, 
                transform.forward, out RaycastHit hit, 
                Quaternion.Euler(90f, 0f, 0f), _seeAtDistance
              )
            )
        {
            if (hit.collider.tag == "FPSControllerTag")
            { 
                isSee = true;
                pointTarget = hit.collider.transform.position;
            }
            else isSee = false;
        }
    }
}
