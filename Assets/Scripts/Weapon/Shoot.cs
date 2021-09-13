using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 1f;
    public int damag = 1;
    public int SetlifeTime = 50;
    int lifeTime;
    bool contact = false;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = SetlifeTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Boolet();
        
    }
    private void Boolet()
    {
        if (contact) Destroy(gameObject);
        if (lifeTime < 1) Destroy(gameObject, lifeTime);
        lifeTime--;
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyTag"))
        {
            contact = true;
            other.gameObject.GetComponent<SpiderScript>().getDamagSizee = damag;
        }
    }
}
