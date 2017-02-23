using UnityEngine;
using System.Collections;

public class MobSpawn : MonoBehaviour {

    int money;
    Control control;
    public GameObject Spawnpoint;
    private GameObject Soldier;
    //private static MobSpawn _instance;
    //public static MobSpawn Instance
    //{
    //    get
    //    {
    //        // シーン上からオブジェクトプールを取得して返す
    //        _instance = FindObjectOfType<MobSpawn>();
    //        return _instance;
    //    }
    //}
    //private GameObject Archer;
    //private GameObject Gunner;
	void Start () {
        Soldier = (GameObject)Resources.Load("Prefab/mob");
        if (control == null)
        {
            control = GetComponent<Control>();
            money = control.Money;
        }
	}
	
	void Update () {
        
	}
    public void Spawn()
    {
        Instantiate(Soldier, Spawnpoint.transform.position, Quaternion.identity);
    }
}
