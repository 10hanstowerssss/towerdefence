using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public GameObject Weapon;
    public Transform positions;
    public float Speed = 100;
    /// ショットの威力
    int _power;
    public int Power
    {
        get { return _power; }
    }

    /// 初期化
    public void Init(int power)
    {
        _power = power;
    }
    void Acquisition()
    {

    }
}
