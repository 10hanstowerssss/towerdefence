using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    int _hp;
    int _atk;
    int _range;
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

    public Transform Goal;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.destination = Goal.position;
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
            Destroy(this.gameObject);
        }
    }
}
