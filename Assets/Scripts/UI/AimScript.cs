using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimScript : MonoBehaviour
{
    public GameObject[] Aim=new GameObject[14];
    public Weapon weapon;
    int _GetNum;
    int _num=0;
    // Start is called before the first frame update
    void Start()
    {
        SetAim();
        Aim[weapon.SetActivWeapon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SetAim();
    }
    void SetAim()
    {
        _GetNum = weapon.SetActivWeapon;
        if(_num!=_GetNum)
        {
            _num = _GetNum;
            for (int i = 0; i < Aim.Length; i++) Aim[i].SetActive(false);
            Aim[_num].SetActive(true);
        }
    }
}
