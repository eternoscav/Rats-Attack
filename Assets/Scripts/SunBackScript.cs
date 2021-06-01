using UnityEngine;
using System.Collections;

public class SunBackScript : MonoBehaviour {

    public MenuManipulator menuScript;

    public GameObject sun;
    public GameObject background1;
	public GameObject background2;
	public GameObject background3;
    Vector3 sunTrans1;
    Vector3 sunTrans2;
    Vector3 sunTrans3;
    Quaternion sunTrans1b;
    Quaternion sunTrans2b;
    Quaternion sunTrans3b;
    public Texture2D sunny1;
    public Texture2D sunny2;
    public Texture2D sunny3;
	public Texture2D rainy1;
	public Texture2D rainy2;
	public Texture2D rainy3;
	public Texture2D night1;
	public Texture2D night2;
	public Texture2D night3;

	// Use this for initialization
	void Start () 
    {

        sunTrans1 = new Vector3(-9.111609f, 4.956538f, 28.44743f);
        sunTrans1b = new Quaternion(0.6460419f, -177.7041f, 0,0);

        sunTrans2 = new Vector3(-9.105343f, 0.5043745f, 31.07658f);
        sunTrans2b = new Quaternion(1.767812f, 180, 1, 0);

        sunTrans3 = new Vector3(-0.2859659f, -4.687125f, 31.18364f);
        sunTrans3b = new Quaternion(1.973181f, 179.5033f, -1, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (menuScript.level>=1 && menuScript.level<=5)
        {
            sun.transform.position = sunTrans1;
            sun.transform.rotation = sunTrans1b;
            background1.renderer.material.mainTexture = sunny1;
        }
        if (menuScript.level >= 6 && menuScript.level <= 10)
        {
            sun.transform.position = sunTrans2;
            sun.transform.rotation = sunTrans2b;
            background1.renderer.material.mainTexture = sunny2;
        }
        if (menuScript.level >= 11 && menuScript.level <= 15)
        {
            sun.transform.position = sunTrans3;
            sun.transform.rotation = sunTrans3b;
            background1.renderer.material.mainTexture = sunny3;
        }
		if (menuScript.level>=16 && menuScript.level<=20)
		{
			sun.transform.position = sunTrans1;
			sun.transform.rotation = sunTrans1b;
			background2.renderer.material.mainTexture = rainy1;
		}
		if (menuScript.level >= 21 && menuScript.level <= 25)
		{
			sun.transform.position = sunTrans2;
			sun.transform.rotation = sunTrans2b;
			background2.renderer.material.mainTexture = rainy2;
		}
		if (menuScript.level >= 26 && menuScript.level <= 30)
		{
			sun.transform.position = sunTrans3;
			sun.transform.rotation = sunTrans3b;
			background2.renderer.material.mainTexture = rainy3;
		}
		if (menuScript.level>=31 && menuScript.level<=35)
		{
			sun.transform.position = sunTrans1;
			sun.transform.rotation = sunTrans1b;
			background3.renderer.material.mainTexture = night1;
		}
		if (menuScript.level >= 36 && menuScript.level <= 40)
		{
			sun.transform.position = sunTrans2;
			sun.transform.rotation = sunTrans2b;
			background3.renderer.material.mainTexture = night2;
		}
		if (menuScript.level >= 41 && menuScript.level <= 45)
		{
			sun.transform.position = sunTrans3;
			sun.transform.rotation = sunTrans3b;
			background3.renderer.material.mainTexture = night3;
		}
	}
}
