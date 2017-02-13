using UnityEngine;
using System.Collections;

public class Mousetocamera : MonoBehaviour {

    [SerializeField, Range(0.1f, 10f)]
    private float wheelSpeed = 1f;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        MouseUpdate();
    }
    private void MouseUpdate()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0f)
            MouseWheel(scrollWheel);
    }
    private void MouseWheel(float delta)
    {
        transform.position += transform.forward * delta * wheelSpeed;
        return;
    }
}
