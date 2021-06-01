using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerDestroyer : MonoBehaviour {

    
    Balloon hitObject;
    BombScript bombScript;
    BombGetChildren bombChild;
    ScoreManipulator scoreScript;
    MenuManipulator menuScript;
    public BallonManager balloonManager;
    int bombArrayLenght;

    public List<Texture2D> particleTexture;

    public GameObject particleBoom;
    public GameObject particle;
    GameObject score;
    

	void Start () 
    {
        balloonManager = GameObject.FindWithTag("manager").GetComponent<BallonManager>();
        menuScript = Camera.main.GetComponent<MenuManipulator>();
        score = GameObject.FindWithTag("Score");
        scoreScript = score.GetComponent<ScoreManipulator>();
	}

    //we detect collision with balloons. every balloon that touch this trigger is destroyed
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
                if (menuScript.survivorMode)
                {
                    scoreScript.SurvivorDestroyed();
                }
                balloonManager.redBalloons.Remove(c.collider.gameObject);
            }
            if (hitObject.Idballoon == "blue")
            {
                particleProv.renderer.material.mainTexture = particleTexture[1];
                if (menuScript.survivorMode)
                {
                    scoreScript.SurvivorDestroyed();
                }
                balloonManager.blueBalloons.Remove(c.collider.gameObject);
            }
            if (hitObject.Idballoon == "green")
            {
                particleProv.renderer.material.mainTexture = particleTexture[2];
                if (menuScript.survivorMode)
                {
                    scoreScript.SurvivorDestroyed();
                }
                balloonManager.greenBalloons.Remove(c.collider.gameObject);
            }
            if (hitObject.Idballoon == "yellow")
            {
                
                particleProv.renderer.material.mainTexture = particleTexture[3];
                if (menuScript.survivorMode)
                {
                    scoreScript.SurvivorDestroyed();
                }
                balloonManager.yellowBalloons.Remove(c.collider.gameObject);
            }
            
            Destroy(c.collider.gameObject);
        }
        if (c.collider.gameObject.layer == 10)
        {
            hitObject = c.collider.gameObject.GetComponent<Balloon>();
            if (hitObject.Idballoon == "bullet")
            {
                Destroy(hitObject.collider.gameObject.transform.root.gameObject);
            }
            if (hitObject.Idballoon == "theray")
            {
                Destroy(hitObject.collider.gameObject.transform.root.gameObject);
            }
            if (hitObject.Idballoon == "black") 
            {
                Camera.main.animation.CrossFade("@CameraShakeLight");
                if (menuScript.multiply >= 5 && menuScript.multiply < 7)
                {
                    Camera.main.animation.CrossFade("@CameraShakingLight");
                }
                if (menuScript.multiply >= 7 && menuScript.multiply < 10)
                {
                    Camera.main.animation.CrossFade("@CameraShakingHeavy");
                }
                if (menuScript.multiply >= 10)
                {
                    Camera.main.animation.CrossFade("@CameraShakingSuperHeavy");
                }
                bombScript = hitObject.gameObject.GetComponentInChildren<BombScript>();
                bombChild = hitObject.gameObject.GetComponent<BombGetChildren>();
                hitObject.renderer.enabled = false;
                bombScript.timerBomb = 10;
                bombChild.sphereCollider.radius = 4;
                bombArrayLenght = bombScript.arrayList.Length-1;
                if (bombScript.arrayList != null)
                {
                    for (int i = bombArrayLenght; 0 <= i; i--)
                    {
                        if (hitObject != null)
                        {
                           // Destroy(bombScript.arrayList[i].gameObject);
                            scoreScript.SurvivorDestroyed();
                        }
                    }
                }
                bombScript.thisMesh.renderer.enabled = false;
                GameObject particleBoom1 = (GameObject)GameObject.Instantiate(particleBoom);
                particleBoom1.transform.position = hitObject.transform.position;
                Destroy(hitObject.transform.root.gameObject,0.3f);
            }
            if (hitObject.Idballoon == "orange")
            {
                GameObject particleProv = (GameObject)GameObject.Instantiate(particle);
                particleProv.transform.position = hitObject.transform.position;
                particleProv.renderer.material.mainTexture = particleTexture[0];
                Destroy(hitObject.transform.root.gameObject);
            }
            if (hitObject.Idballoon == "eater")
            {
                GameObject particleProv = (GameObject)GameObject.Instantiate(particle);
                particleProv.transform.position = hitObject.transform.position;
                particleProv.renderer.material.mainTexture = particleTexture[0];
                Destroy(hitObject.transform.root.gameObject);
            }
        }

        if (c.collider.gameObject.layer == 10 || c.collider.gameObject.layer == 9)
        {
            balloonManager.allBalloons.Remove(c.collider.gameObject);
        }
    }
}
