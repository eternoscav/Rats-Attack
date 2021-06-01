using UnityEngine;
using System.Collections;

public class TriggerParticleDestroyer : MonoBehaviour {

    //In this script when the Balloon particle touch this trigger the score count

    public GameObject score;
    ScoreManipulator scoreScript;

	// Use this for initialization
	void Start () 
    {
        scoreScript = score.GetComponent<ScoreManipulator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnTriggerEnter(Collider c)
    {
        if (c.collider.gameObject.layer == 11)
        {
            Destroy(c.collider.gameObject,1);
            scoreScript.count = true;
        }
    }
}
