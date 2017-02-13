using UnityEngine;
using System.Collections;

public class MobStatus : MonoBehaviour {

    public enum Upgrade
    {
        LevelUP,
        None
    }
    float firerate;//攻撃速度
    float Tfirerate;//攻撃速度インターバル
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

    public Transform Goal;
    private NavMeshAgent agent;
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.destination = Goal.position;
	}
    /// <summary>
    /// ダメージ計算
    /// </summary>
    void Damage()
    {
        //_hp = Mathf.Max(0, HP - DAMAGE());
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
    void UpgradeStatus()
    {
        _hp = Parameter.HitPoint(lvHP);
        _atk = Parameter.Attack(lvAtk);
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
        //ステータス更新
        UpgradeStatus();
    }
    void Update()
    {
        Tfirerate += Time.deltaTime;
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
        }
    }
    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="collider">ヒットボックス</param>
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Tower")
        {
            Destroy(this.gameObject);
            //agent.Stop();
        }
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
