using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    public GameObject spider;
    private GameObject FPS;
    public GameObject AttackLongTrigger;//стреляю
    public GameObject AttackTrigger;//атакую
    public GameObject HearTrigger;//слыну
    public GameObject WatchTrigger;//вижу
    public int getDamagSizee=0;
    public int health = 1;
    float PosY;
    public float SpeedMove = 2f;
    public float SpeedRun = 4f;
    public float SpeedRotate = 2f;
    public bool isMove = true;
    bool isDead = false;
    public int delayAttackSet = 200;
    int delayAttack;
    public int delayMoveSet = 300;
    int delayMove;
    bool Stay = false;
    float randomLookFor;
    float randomMove;
    float rotation;

    Animation moveAnimation;
    TriggerScript triggerScriptLong,
                  triggerScriptAttac, 
                  triggerScriptWatch,
                  triggerScriptHear;
    public WeaponPanel weaponPanel;
    void Start()
    {
        delayAttack = delayAttackSet;
        delayMove = delayMoveSet;
        moveAnimation = spider.GetComponent<Animation>();
        triggerScriptLong  = AttackLongTrigger.GetComponent<TriggerScript>();
        triggerScriptAttac = AttackTrigger.GetComponent<TriggerScript>();
        triggerScriptWatch = WatchTrigger.GetComponent<TriggerScript>();
        triggerScriptHear  = HearTrigger.GetComponent<TriggerScript>();
        FPS = GameObject.FindGameObjectWithTag("FPSControllerTag");
        PosY = spider.transform.position.y;
        moveAnimation.Play("idle");
        weaponPanel=GameObject.Find("WeaponPanel").GetComponent<WeaponPanel>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (delayAttack < delayAttackSet) { delayAttack++; }
        GetDamageEnemy();
        Aktion();
    }
    void Aktion()
    {
        if(!isDead)
        {
            if (triggerScriptWatch.Stay) Run();
            else
            { if (isMove) LookFor(); }
            Attack();
        }
    }
    void GetDamageEnemy()
    { 
        if(getDamagSizee>0)
        {
            health -= getDamagSizee;
            getDamagSizee = 0;
            if (health<=0)
            {
                if(getDamagSizee>30)
                moveAnimation.Play("death2");
                else
                moveAnimation.Play("death1");
                weaponPanel.checkFrag=true;
                isDead = true;
            }
            else 
            {
                if (getDamagSizee > 30)
                    moveAnimation.Play("hit2");
                else
                    moveAnimation.Play("hit1");
                getDamagSizee = 0;
            }
        }
    }
    void Attack()
    {
        
        if (triggerScriptLong.Stay)
        {
            if (delayAttack == delayAttackSet)
            {
                AttackAnimation(false);
                delayAttack = 0;
            }
        }
        if (triggerScriptAttac.Stay)
        {
            if (delayAttack == delayAttackSet)
            {
                AttackAnimation(true);
                delayAttack = 0;
            }
        }
    }

    void AttackAnimation(bool near)
    {
        if(near) moveAnimation.Play("attack1");
        else
        moveAnimation.Play("attack2");//плевки
    }
    void LookFor()
    {
        if (delayMove >= delayMoveSet) { randomLookFor = Random.Range(0f, 10f); delayMove = 0; }
        else { delayMove++; }
        if(randomLookFor < 5f)
        { Move(delayMove); }
        else 
        { StopAnimation(delayMove); }
    }
    void Move(int n)
    {
        if (n == 1) { randomMove = Random.Range(0f, 10f); moveAnimation.Play("walk"); }
        if (randomMove < 5f)
        {
            //transform.position+=transform.forward* Time.deltaTime*SpeedObj;
            spider.transform.position += transform.forward * Time.deltaTime * SpeedMove;
        }
        else
        {
            rotation += 5f;
            if (rotation > 360) rotation -= 360;
            if (rotation < -360) rotation += 360;
            spider.transform.rotation = Quaternion.Euler(0, rotation, 0);
            
        }
    }
    void Run()
    {
        spider.transform.position += transform.forward * Time.deltaTime * SpeedRun;
        spider.transform.LookAt(FPS.transform);
    }
    void MoveAnimation()
    {
        moveAnimation.Play("walk");
    }
    void RanAnimation()
    {
        moveAnimation.Play("ran");
    }
    void JampAnimation()
    {
        moveAnimation.Play("walk");
    }
    void StopAnimation(int n)
    {
        if(n==1)
        moveAnimation.Play("idle");
    }
}
