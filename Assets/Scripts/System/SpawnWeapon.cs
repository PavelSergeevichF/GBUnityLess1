using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWeapon : MonoBehaviour
{
    public GameObject[] spavnOBJs;
    public GameObject Position;
    public int delySpawnSet = 200;
    [SerializeField] int delySpawn;
    public int numSpawn = 50;
    public Slider sliderRedy;
    // Start is called before the first frame update
    void Start()
    {
        delySpawn = delySpawnSet;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)|| Input.GetKey(KeyCode.F)) Spawn();//Mouse0 Mouse1 Mouse2
        if(delySpawn < delySpawnSet) delySpawn++;
        sliderRedy.value = delySpawn;
    }
    void Spawn()
    {
        if (numSpawn > 0)
        {
            if (delySpawn >= delySpawnSet) 
            { 
                delySpawn=0;
                GameObject Shell = Instantiate(spavnOBJs[0], transform.position, transform.rotation) as GameObject;
                numSpawn--;
            }
        }

    }
}
