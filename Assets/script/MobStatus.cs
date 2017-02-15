using UnityEngine;
using System.Collections;

public class MobStatus : MonoBehaviour {

    public enum Upgrade
    {
        LevelUP,
        None
    }
    float firerate;//攻撃速度
    float Tfirerate;//インターバル
    int _hp;
    /// <summary>
    /// 体力
    /// </summary>
    public int HP
    {
        get { return _hp; }
    }
    int _atk;
    /// <summary>
    /// 攻撃力
    /// </summary>
    public int ATK
    {
        get { return _atk; }
    }
    int _range;
    /// <summary>
    /// 射程
    /// </summary>
    public int RANGE
    {
        get { return _range; }
    }
    int _damage;
    /// <summary>
    /// ダメージ
    /// </summary>
    public int DAMAGE
    {
        get { return _damage; }
    }
    int _speed;
    /// <summary>
    /// 移動速度
    /// </summary>
    public int SPEED
    {
        get { return _speed; }
    }
    public Transform START;
    public Transform Goal;
    private float starttime;
    private float distance;//2点間の距離
    private bool walk;//歩行可能状態かどうか
    private bool attack;//攻撃中かどうか
    private NavMeshAgent agent;
	void Start () {
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
        walk = true;
        //ステータス更新
        UpgradeStatus();
    }
    private float discovered;
    private float frac;
    
    void Update()
    {
        if (walk == true&&attack==false)
        {
            Tfirerate += Time.deltaTime;
            discovered = (Time.time - starttime) * _speed;
            frac = discovered / distance;
            transform.position = Vector3.Lerp(START.position, Goal.position, frac);
        }
        if(Tfirerate< firerate)
        {
            return;
        }
        //インターバル
        Tfirerate = 0;
    }
    public void Upgrades(Upgrade type)
    {
        switch (type)
        {
            case Upgrade.LevelUP:
                lvHP++;
                lvAtk++;
                break;
            case Upgrade.None:
                break;
        }
    }
    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="collider">当たった物体</param>
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Tower")
        {
            Destroy(this.gameObject);
            //agent.Stop();
        }
        if (collider.gameObject.tag == "Enemy")
        {
            //walk = false;
            //attack = true;
            enemy e = collider.gameObject.GetComponent<enemy>();
            Damage(e.EnemyATK);
            
        }
    }
    /// <summary>
    /// ダメージ計算
    /// </summary>
    /// <param name="val"></param>
    void Damage(int val)
    {
        _hp -= val;
        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
