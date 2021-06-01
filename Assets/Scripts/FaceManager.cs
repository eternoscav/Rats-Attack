using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FaceManager : MonoBehaviour {

    //Simple script where we ser a random face on our balloons

    public List<Texture2D> facesList;
    public int i;

	// Use this for initialization
	void Start ()
    {
        i = Random.Range(0, 1);
        this.renderer.material.mainTexture = facesList[i];
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    
}
