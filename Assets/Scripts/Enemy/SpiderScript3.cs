using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderScript3  : MonoBehaviour
{
    public GameObject spider;
    public int getDamagSizee = 0;
    public float StopingDistanc = 0.1f;
    public int health = 1;
    float PosY;
    int timeOfDisappearance = 150;
    public float SpeedMove = 2f;
    public float SpeedRun = 4f;
    public float SpeedRotate = 2f;
    public bool isMove = true;
    public bool isPatrul = false;
    bool isDead = false;
    public int delayAttackSet = 200;
    int delayAttack;
    public int delayMoveSet = 300;
    [SerializeField] float _seeAtDistance = 10f;
    [SerializeField] bool Stay = false;
    [SerializeField] private NavMeshAgent _agent;
    private Transform _target;
    [SerializeField] int _targetPoint = 1;
    [SerializeField] private Transform _target1;
    [SerializeField] private Transform _target2;
    [SerializeField] private float[] sizeBoxCast = { 0.5f,0.5f,0.5f};
    [SerializeField] bool setView = true;
    Animation moveAnimation;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = _target1;
    }
    void Start()
    {
        delayAttack = delayAttackSet;
        moveAnimation = spider.GetComponent<Animation>();
        PosY = spider.transform.position.y;
        moveAnimation.Play("idle");
        if (_target == null) return;
        _agent.SetDestination(_target.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (delayAttack < delayAttackSet) { delayAttack++; }
        Aktion();
    }
    void Aktion()
    {
        if (!isDead)
        {
            //!!!!!!!
            MovePatrol();
        }
        if (isDead)
        {
            Destroy(gameObject.GetComponent<NavMeshAgent>());
            timeOfDisappearance--;
            if (timeOfDisappearance < 0) Destroy(gameObject);
        }
    }
    
    

    void MovePatrol()
    {
        if ((
            spider.transform.position.x < _target1.transform.position.x + 0.3 ||
            spider.transform.position.x > _target1.transform.position.x - 0.3 ||
            spider.transform.position.z < _target1.transform.position.z + 0.3 ||
            spider.transform.position.z > _target1.transform.position.z - 0.3
            ) && (_targetPoint == 1))
        {
            _target = _target2;
            _targetPoint = 2;
            _agent.SetDestination(_target.position);
        }
        else
        {
            if (
                spider.transform.position.x < _target2.transform.position.x + 0.3 ||
                spider.transform.position.x > _target2.transform.position.x - 0.3 ||
                spider.transform.position.z < _target2.transform.position.z + 0.3 ||
                spider.transform.position.z > _target2.transform.position.z - 0.3
                )
            {
                _target = _target1;
                _targetPoint = 1;
                _agent.SetDestination(_target.position);
            }
        }
        MoveAnimation();
    }
    void MoveAnimation()
    {
        moveAnimation.Play("walk");
    }
    void RanAnimation()
    {
        moveAnimation.Play("run");
    }
    void JampAnimation()
    {
        moveAnimation.Play("walk");
    }
    void StopAnimation(int n)
    {
        if (n == 1)
            moveAnimation.Play("idle");
    }
}
