using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//This script its IN a gameobject in the Eater balloon
public class Bite : MonoBehaviour {

    Balloon hitObject;
    public GameObject particle;
    public List<Texture2D> particleTexture;
    MenuManipulator menuScript;
    SoundManager soundScript;
	void Start () 
    {
        menuScript = Camera.main.GetComponent<MenuManipulator>();
        soundScript = Camera.main.GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    //Simple collision detection
    void OnTriggerEnter(Collider c)
    {
        if (c.collider.gameObject.layer == 9)
        {
            hitObject = c.collider.gameObject.GetComponent<Balloon>();
            GameObject particleProv = (GameObject)GameObject.Instantiate(particle);
            particleProv.transform.position = hitObject.transform.position;

            if (hitObject.Idballoon == "red")
            {
                particleProv.renderer.material.mainTexture = particleTexture[0];
            }
            if (hitObject.Idballoon == "blue")
            {
                particleProv.renderer.material.mainTexture = particleTexture[1];
            }
            if (hitObject.Idballoon == "green")
            {
                particleProv.renderer.material.mainTexture = particleTexture[2];
            }
            if (hitObject.Idballoon == "yellow")
            {
                particleProv.renderer.material.mainTexture = particleTexture[3];
            }
            if (menuScript.survivorMode) 
            {
                menuScript.scoreScript.SurvivorDestroyed();
            }
            soundScript.PlaySound(33, false, 0.5f);
            Destroy(hitObject.gameObject);
        }
    }
}
