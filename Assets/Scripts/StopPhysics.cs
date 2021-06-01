using UnityEngine;
using System.Collections;

public class StopPhysics : MonoBehaviour {

    //Is not what its seems but the only thing that this do, its to move our balloon from left to right in a minimun way

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        this.rigidbody.velocity = new Vector3(Random.Range(-0.2f,0.2f), 0, 0);
    }
}
