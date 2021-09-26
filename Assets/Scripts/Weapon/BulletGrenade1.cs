using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGrenade1 : MonoBehaviour
{
    public int damag = 1;
    public float speed = 10;
    float speedG = 10;
    public int SetlifeTime = 50;
    [SerializeField]int lifeTime ;
    int moveTime = 2;
    public bool bullet = true;
    public GameObject Flash;
    public GameObject FlashPartic;
    bool moveGr = true;
    bool contact = false;
    bool setScale = true;
    new Renderer renderer;
    new Rigidbody rigidbody;
    public GameObject CastSundObj;
    public GameObject ContactSundObj;
    public AudioSource CastSund;
    public AudioSource ContactSund;
    bool PlayCastSund = true;
    bool PlayContactSund = true;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = SetlifeTime;
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        CastSund = CastSundObj.GetComponent<AudioSource>();
        ContactSund = ContactSundObj.GetComponent<AudioSource>();
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
            if(PlayCastSund)
            { 
                PlayCastSund = false; 
                CastSund.Play(); 
            }
            if (moveGr)
            {
                rigidbody.AddForce(transform.forward* speed,ForceMode.Impulse);
            }
            if (contact)
            {
                if (PlayContactSund)
                {
                    PlayContactSund = false;
                    ContactSund.Play();
                }
                lifeTime--;
                if (setScale) 
                {
                    setScale = false;
                    Vector3 setSize;
                    setSize.x = 5; setSize.y = 5; setSize.z = 5;
                    transform.localScale = setSize;
                }
                FlashPartic.SetActive(true);
                Destroy(renderer);
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
            other.gameObject.GetComponent<SpiderScript2>().getDamagSizee= damag;
        }
        if (!bullet&&!contact) lifeTime = 20;
    }
}
