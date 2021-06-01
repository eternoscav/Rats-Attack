using UnityEngine;
using System.Collections;

public class MoveParticle : MonoBehaviour {

    //This script is to guide our score feedback particle (little green particle in scene when we pop a balloon)

    public GameObject triggerPos;

	// Use this for initialization
	void Start () 
    {
        triggerPos = GameObject.FindWithTag("trigger");
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.LookAt(triggerPos.transform.position);
        this.transform.position += transform.forward * 10 * Time.deltaTime;
	}
}
