using UnityEngine;
using System.Collections;

public class WarpPoint : MonoBehaviour { 

    void OnTriggerEnter(Collider other){
        other.gameObject.transform.position = new Vector3(0,20,0);
    }
}
	
	