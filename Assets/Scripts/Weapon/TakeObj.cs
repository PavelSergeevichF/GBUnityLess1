using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObj : MonoBehaviour
{
    public Weapon weapon;
    public string name="0";
    // Start is called before the first frame update
    void Start()
    {
        weapon= GameObject.Find("WeaponObject").GetComponent<Weapon>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FPSControllerTag")
        {
            weapon.GetAmmunition(name);
            if (weapon.GetObjAmmun)
            {
                weapon.GetObjAmmun = false;
                Destroy(gameObject);
            }
        }
    }
}
