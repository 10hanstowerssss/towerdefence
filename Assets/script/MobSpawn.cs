using UnityEngine;
using System.Collections;

public class MobSpawn : MonoBehaviour {

    int money;
    Control control;
    public GameObject Spawnpoint;
    private GameObject Soldier;
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
