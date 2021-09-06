using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] spavnOBJs;
    public GameObject Position;
    public bool onlyOneObj = true;
    public int delySpawnSet = 500;
    [SerializeField] int delySpawn;
    public int numSpawn = 5;
    // Start is called before the first frame update
    void Start()
    {
        delySpawn = delySpawnSet;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Spawn();
    }
    void Spawn()
    {
        if(numSpawn>0)
        {
            if (delySpawn > 0) { delySpawn--; }
            else
            {
                delySpawn = delySpawnSet;
                int rnd = Random.Range(0, spavnOBJs.Length - 1);
                //GameObject Enemy = Instantiate(spavnOBJs[rnd], Position.position,Quaternion.identity);
                GameObject Shell = Instantiate(spavnOBJs[rnd], transform.position, transform.rotation) as GameObject;
                numSpawn--;
            }
        }
        
    }
}
