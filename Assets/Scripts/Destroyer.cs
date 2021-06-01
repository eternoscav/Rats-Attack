using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

    //Destructor script

    public float timer;
    public float acce;
	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, timer);
	}
    
	
	// Update is called once per frame
	void Update () 
    {
        if (acce < 1f)
        {
            acce += Time.deltaTime*0.5f;
        }
        this.transform.position += transform.up * -acce*Time.deltaTime;
	}
}
