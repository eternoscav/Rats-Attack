using UnityEngine;
using System.Collections;

public class BombGetChildren : MonoBehaviour {

    //This script the only thing that it does is to grow up the sphere collider of the bomber
    //to the an explotion effect

    public BombScript bombScript;
    public GameObject particle;
    public  GameObject prov;
    public SphereCollider sphereCollider;
    bool once;

	void Start () 
    {
        bombScript = gameObject.GetComponentInChildren<BombScript>();
        sphereCollider = this.GetComponent<SphereCollider>();
        prov = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (bombScript.timerBomb < 1)
        {
            if (!once)
            {
                GameObject lala = (GameObject)GameObject.Instantiate(particle);
                lala.transform.parent = prov.transform;
                lala.transform.position = prov.transform.position + prov.transform.forward * 1f ;
                this.renderer.enabled = false;
                sphereCollider.radius = 4;
                Destroy(this.gameObject,0.1f);
                once = true;
            }
        }
	}
}
