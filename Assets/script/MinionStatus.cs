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
    BoxCollider _boxcollider = null;
    public BoxCollider BOXcollider
    {
        get { return _boxcollider ?? (_boxcollider = gameObject.GetComponent<BoxCollider>()); }
    }
    Control cc;
    /// <summary>
    /// ミニオンクラス
    /// </summary>
    public job Job;
    public enum job
    {
        Swordman,
        Archer,
        Magic,
        Superminion,
        k
    }
    //状態
    enum State
    {
        Walking,
        Attacking,
    }
    State state = State.Walking;
    State nextstate = State.Walking;
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
    int _cost;
    /// <summary>
    /// コスト
    /// </summary>
    public int COST
    {
        get { return _cost; }
        set { _cost = value; }
    }
    private GameObject nearobj;
    public Transform START;
    public Transform Goal;
    private float starttime;
    private float distance;//2点間の距離
    private NavMeshAgent agent;
    private GameObject _Range;
    void Start () {
        starttime = Time.time;
        _Range = transform.FindChild("range").gameObject;
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
            _hp = Parameter.HitPoint(LVHP);
            _atk = Parameter.Attack(LVATK);
            _speed = Parameter.Speed(LVSPEED);
            _cost = Parameter.Cost(lvHP);
        }
        if (Job == job.Archer)
        {
            _hp = Parameter.LongRangeHP(LVHP);
            _atk = Parameter.LongRangeATK(LVATK);
            _range = Parameter.Range(LVSPEED);
            _speed = Parameter.Speed(LVSPEED);
        }
        if (Job == job.Magic)
        {
            _hp = Parameter.MagicUserHP(LVHP);
            _atk = Parameter.MagicUserATK(LVATK);
            _speed = Parameter.Speed(LVSPEED);
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
        state = State.Walking;
        //ステータス更新
        UpgradeStatus();
    }
    private float discovered;
    private float frac;
    
    void Update()
    {
        Tfirerate += Time.deltaTime;
        switch (state)
        {
            case State.Walking:
                WALKING();
                break;
            case State.Attacking:
                AttackinG();
                break;
        }
        if (Tfirerate< firerate)
        {
            return;
        }
        //インターバル
        Tfirerate = 0;
    }
    void WALKING()
    {
        discovered = (Time.time - starttime) * _speed;
        frac = discovered / distance;
        transform.position = Vector3.Lerp(START.position, Goal.position, frac);
    }
    void AttackinG()
    {

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
        if(collider.gameObject.tag=="EnemyTower")
        {
            Destroy(this.gameObject);
            //agent.Stop();
        }
        if (collider.gameObject.tag == "Enemy")
        {
            state = State.Attacking;
            enemy e = collider.gameObject.GetComponent<enemy>();
            Damage(e.EnemyATK);
            if (e.EnemyHP <= 0)
            {
                Control.Enemykill();
                state = State.Walking;
            }
            //DestroyImmediate(collider);
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
