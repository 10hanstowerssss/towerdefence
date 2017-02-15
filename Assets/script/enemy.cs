﻿using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    int _hp;
    int _atk;
    int _range;
    float firerate;//攻撃速度
    float Tfirerate;//攻撃速度インターバル
    /// <summary>
    /// 体力
    /// </summary>
    public int EnemyHP
    {
        get { return _hp; }
    }
    /// <summary>
    /// 攻撃力
    /// </summary>
    public int EnemyATK
    {
        get { return _atk; }
    }
    /// <summary>
    /// 射程
    /// </summary>
    public int EnemyRANGE
    {
        get { return _range; }
    }
    int _speed;
    /// <summary>
    /// 移動速度
    /// </summary>
    public int EnemySPEED
    {
        get { return _speed; }
    }
    public Transform START;
    public Transform Goal;
    private float starttime;
    private float distance;//2点間の距離
    private NavMeshAgent agent;
    void Start()
    {
        starttime = Time.time;
        distance = Vector3.Distance(START.position, Goal.position);
        //agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.destination = Goal.position;
        Init();//あとで変えろよ
    }
    int lvHP;
    public int LVHP
    {
        get { return lvHP; }
    }
    int lvAtk;
    public int LVATK
    {
        get { return lvAtk; }
    }
    int lvspeed;
    public int LVSPEED
    {
        get { return lvspeed; }
    }
    void UpgradeStatus()
    {
        _hp = Parameter.HitPoint(lvHP);
        _atk = Parameter.Attack(lvAtk);
        _speed = Parameter.Speed(lvspeed);
    }
    /// <summary>
    /// 初期化
    /// </summary>
    void Init()
    {
        //インターバル初期化
        Tfirerate = 0;
        //ステータス初期化
        lvHP = 1;
        lvAtk = 1;
        lvspeed = 1;
        //ステータス更新
        UpgradeStatus();
    }
    private float discovered;
    private float frac;
    void Update()
    {
        Tfirerate += Time.deltaTime;
        discovered = (Time.time - starttime) * _speed;
        frac = discovered / distance;
        transform.position = Vector3.Lerp(START.position, Goal.position, frac);
        //インターバル
        Tfirerate = 0;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Tower")
        {
            Destroy(this.gameObject);
            //agent.Stop();
        }
        if (collider.gameObject.tag == "Playermob")
        {
            MobStatus m = collider.gameObject.GetComponent<MobStatus>();
            Damages(m.ATK);
        }
    }
    void Damages(int val)
    {
        _hp -= val;
        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
