using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFPS : MonoBehaviour
{
    [SerializeField] private Animator _Anim;
    // Start is called before the first frame update
    private void Awake()
    {
        _Anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsFireAnim();
        IsGoAnim();
    }
    void IsFireAnim()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            _Anim.SetBool("isFire", true);
        }
    }
    void IsGoAnim()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S))
        {
            _Anim.SetBool("isGo", true);
        }
        else 
        {
            _Anim.SetBool("isGo", false);
        }
    }
}
