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
    new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = SetlifeTime;
        rigidbody = GetComponent<Rigidbody>();
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
        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        //transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyTag"))
        {
            contact = true;
            other.gameObject.GetComponent<SpiderScript>().getDamagSizee = damag;
        }
        if (other.CompareTag("DestroyObjTag"))
        {
            contact = true;
            other.gameObject.GetComponent<DestructibleObjects01>().Contact = true;
        }
    }
}
