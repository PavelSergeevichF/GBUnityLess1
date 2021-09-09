using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGrenade1 : MonoBehaviour
{
    public int damag = 1;
    public float speed = 10;
    float speedG = 10;
    public int SetlifeTime = 50;
    int lifeTime ;
    int moveTime = 2;
    public bool bullet = true;
    public GameObject Flash;
    public GameObject FlashPartic;
    bool moveGr = true;
    bool contact = false;
    new Renderer renderer;
    new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = SetlifeTime;
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bullet();
        Grenade();
    }
    void Bullet()
    {
        if (bullet)
        {
            if (lifeTime < 1) Destroy(gameObject, lifeTime);
        }
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
    void Grenade()
    {
        if (!bullet)
        {
            if (moveGr)
            {
                moveTime--;
                if (moveTime < 1) moveGr = false;
                transform.position += transform.forward * speed * Time.fixedDeltaTime;
            }
            if (contact)
            {
                lifeTime--;
                FlashPartic.SetActive(true);
                Destroy(renderer);
                Destroy(rigidbody);
                if (lifeTime > 10) Flash.SetActive(true);
                else Flash.SetActive(false);
                if (lifeTime < 1) Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyTag"))
        { 
            contact = true;
            other.gameObject.GetComponent<SpiderScript>().getDamagSizee= damag;
            // other.gameObject.GetComponent<SpiderScript>().getDamag = true;
        }
        if (!bullet) lifeTime = 20;
    }
}
