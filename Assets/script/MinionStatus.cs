using UnityEngine;
using System.Collections;

public class MinionStatus : MonoBehaviour {

    //public static Type CreateInstance<Type>(GameObject prefab,Vector3 p, float direction=0.0f,float speeds=0.0f) where Type : MinionStatus
    //{
    //    GameObject gg = Instantiate(prefab, p, Quaternion.identity) as GameObject;
    //    Type obj = gg.GetComponent<Type>();
    //    //obj.SetVelocity(direction, speeds);
    //    return obj;
    //}
    /// <summary>
    /// ミニオンクラス
    /// </summary>
    public job Job;
    public enum job
    {
        Swordman,
        Archer,
        Superminion,
        k
    }
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
    private GameObject nearobj;
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
        //nearobj = searchTag(gameObject,"enemy");
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
        if (Job == job.Swordman)
        {
            _hp = Parameter.HitPoint(lvHP);
            _atk = Parameter.Attack(lvAtk);
            _speed = Parameter.Speed(lvspeed);
        }
        if (Job == job.Archer)
        {
            _hp = Parameter.LongRangeHP(lvHP);
            _atk = Parameter.LongRangeATK(lvAtk);
            _range = Parameter.Range(LVATK);
            _speed = Parameter.Speed(lvspeed);
        }
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
        Tfirerate += Time.deltaTime;
        if (walk == true&&attack==false)
        {
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
            //Shot.Add(ATK);
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
    /// <summary>
    /// 近い敵を探す
    /// </summary>
    /// <param name="objc"></param>
    /// <param name="Tagname"></param>
    /// <returns></returns>
    //GameObject searchTag(GameObject objc,string Tagname)
    //{
    //    float tmpdis = 0;
    //    float neardis = 0;
    //    GameObject target = null;
    //    foreach (GameObject ob in GameObject.FindGameObjectsWithTag(Tagname)) 
    //    {
    //        tmpdis = Vector3.Distance(ob.transform.position, objc.transform.position);
    //        if (neardis == 0 || neardis > tmpdis)
    //        {
    //            neardis = tmpdis;
    //            target = ob;
    //        }
    //    }
    //    return target;
    //}
}
