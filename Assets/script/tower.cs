using UnityEngine;
using System.Collections;

public class tower : MonoBehaviour {

    public GameObject explosion;
    public Transform[] explosionPoints;
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

    // Use this for initialization
    void Start () {
        _hp = 10;
        _atk = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Playermob")
        {
            MinionStatus m = collider.gameObject.GetComponent<MinionStatus>();
            Damages(m.ATK);
        }
    }
    void Damages(int val)
    {
        _hp -= val;
        if (_hp <= 0)
        {
            //foreach (Transform explosionPos in explosionPoints)
            //{
            //    GameObject expl = Instantiate(explosion, explosionPos.position, transform.rotation) as GameObject;
            //    Destroy(expl, 5f);
            //}
            Destroy(this.gameObject);
        }
    }
}
