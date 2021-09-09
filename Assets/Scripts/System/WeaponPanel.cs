using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanel : MonoBehaviour
{
    public Text textBullet;
    public Text textG;
    public Text textFrag;
    public Text WeaponActiv;
    public Weapon weaponScript;
    public bool checkFrag = false;
    public int frag = 0;
    public int weapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponScript.SetActivWeapon<10)
        textBullet.text = weaponScript.bullet[weaponScript.SetActivWeapon].ToString();
        else
        textG.text = weaponScript.bullet[weaponScript.SetActivWeapon].ToString();
        WeaponActiv.text = weapon.ToString();
        NumFrag();
        textFrag.text = frag.ToString();
    }
    void NumFrag()
    {
        if(checkFrag)
        {
            checkFrag = false;
            frag++;
        }
    }

}
