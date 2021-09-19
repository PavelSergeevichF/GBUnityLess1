using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWeapon : MonoBehaviour
{
    public GameObject[] spavnOBJs;
    public GameObject Position;
    public bool spawn = false;
    public bool SotReady = true;
    public int delySpawnSet = 200;
    [SerializeField] int delySpawn;
    public Weapon weaponScript;
    // Start is called before the first frame update
    void Start()
    {
        delySpawn = delySpawnSet;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.Mouse0)|| spawn)&& SotReady) //Input.GetKey(KeyCode.F)
        {
            Spawn();//Mouse0 Mouse1 Mouse2
            spawn = false;
        }
    }
    void Spawn()
    {
        if (weaponScript.bullet[weaponScript.SetActivWeapon] > 0)//
        {
            if (weaponScript.loadWeapon[weaponScript.SetActivWeapon] >= weaponScript.timeLoadWeapon[weaponScript.SetActivWeapon]) 
            {
                weaponScript.loadWeapon[weaponScript.SetActivWeapon] = 0;
                GameObject Shell = Instantiate(spavnOBJs[weaponScript.SetActivWeapon], transform.position, transform.rotation) as GameObject;
                weaponScript.bullet[weaponScript.SetActivWeapon]--;
                weaponScript.FullWeapon[weaponScript.SetActivWeapon] = false;
            }
        }

    }
}
