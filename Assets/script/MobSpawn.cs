using UnityEngine;
using System.Collections;

public class MobSpawn : MonoBehaviour {

    int money;
    Control control;
    public GameObject Spawnpoint;
    private GameObject Soldier;
    private GameObject MagicUser;
    //public Camera camera;
    
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
        MagicUser = (GameObject)Resources.Load("Prefab/magic");
        if (control == null)
        {
            control = GetComponent<Control>();
            money = Control.Money;
        }
        //RaycastHit hit;
        //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
	}
	
	void Update () {
        
	}
    public void Spawn()
    {
        Instantiate(Soldier, Spawnpoint.transform.position, Quaternion.identity);
    }
    public void SpawnMagicUser()
    {
        Instantiate(MagicUser, Spawnpoint.transform.position, Quaternion.identity);
    }
    public void Onchangepoint()
    {

    }
}
