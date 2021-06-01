using UnityEngine;
using System.Collections;

public class MakeSound : MonoBehaviour {

    //Simple script where we make a sound in a determinate moment;

    float timer;
    int randomVoice;
    SoundManager soundScript;
    MenuManipulator menuScript;

	void Start () 
    {
        timer = Random.Range(0, 10);
        soundScript = Camera.main.GetComponent<SoundManager>();
       
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (timer < 15)
        {
            timer += Time.deltaTime;
        }
        else
        {
            randomVoice = Random.Range(6, 19);
            soundScript.PlaySound(randomVoice, false, 0.3f);
            timer = 0;
        }
	}
}
