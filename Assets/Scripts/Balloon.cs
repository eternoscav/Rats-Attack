using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Balloon : MonoBehaviour {
    
    RaycastHit hit;
    MenuManipulator menuScript;
    GameObject score;
    ScoreManipulator scoreScript;
    SoundManager soundScript;
    LayerMask headMask = 1 << 9;
    FaceManager faceManager;

    public Collider[] arrayList;

    public Texture2D redBalloon;
    public Texture2D greenBalloon;
    public Texture2D blueBalloon;
    public Texture2D yellowBalloon;

    public int randomRayColor;
    int explosionSound;
    public float aceleration;
    public string Idballoon;
    public float maxAcc;

	void Start () 
    {
        //if its the ray balloons, we have to initialize it with a color
        if (Idballoon == "theray")
        {
            randomRayColor = Random.Range(0, 4);

            if (randomRayColor == 0)
            {
                this.renderer.material.mainTexture = redBalloon;
            }
            else
            {
                if (randomRayColor == 1)
                {
                    this.renderer.material.mainTexture = greenBalloon;
                }
                else
                {
                    if (randomRayColor == 2)
                    {
                        this.renderer.material.mainTexture = blueBalloon;
                    }
                    else
                    {
                        if (randomRayColor == 3)
                        {
                            this.renderer.material.mainTexture = yellowBalloon;
                        }
                    }
                }
            }
        }
        //

        //If its the refresher (we have to destroy it cause if not, the user will use it his own benefit benefit forever)
        if (Idballoon == "orange")
        {
            Destroy(this.gameObject, 7);
        }
        //

        //Initialize
        faceManager = this.GetComponentInChildren<FaceManager>();
        menuScript = Camera.main.GetComponent<MenuManipulator>();
        soundScript = Camera.main.GetComponent<SoundManager>();
        score = GameObject.FindWithTag("Score");
        scoreScript = score.GetComponent<ScoreManipulator>();
        maxAcc = 0.5f;
        aceleration = -1;
        //
	}
	
	void Update () 
    {
        //If we are playing Level Mode, we set the speed of our balloons
        if (menuScript.gameStarted)
        {
            if (menuScript.level == 1|| menuScript.level==2|| menuScript.level==3|| menuScript.level==4)
            {
                maxAcc = Random.Range(0.5f, 0.7f);
            }
            if (menuScript.level >= 5 && menuScript.level < 10)
            {
                maxAcc = Random.Range(0.7f, 1f);
                if (Idballoon == "black")
                {
                    maxAcc = 0.5f;
                }
            }
            if (menuScript.level >= 10)
            {
                if (Idballoon == "incognit")
                {
                    arrayList = Physics.OverlapSphere(this.transform.position, 3, headMask);
                }
                if (!menuScript.pause)
                {
                    if (menuScript.bulletTime)
                    {
                        Time.timeScale = 0.3f;
                    }
                    else
                    {
                        Time.timeScale = 1f;
                    }
                }
                maxAcc = Random.Range(0.7f, 1f);
                if (Idballoon == "orange")
                {
                    maxAcc = 4f;
                }
                if (Idballoon == "eater")
                {
                    maxAcc = 4f;
                }
                if (Idballoon == "black")
                {
                    maxAcc = 0.5f;
                }
            }
        }
        //
        //If we are playing survivor mode, instead of the level we use the user score as reference
        if (menuScript.survivorMode)
        {
            
            if (menuScript.scoreScript.plusMul < 500)
            {
                maxAcc = Random.Range(0.5f, 0.7f);
            }
            if (menuScript.scoreScript.plusMul >= 500 && menuScript.scoreScript.plusMul < 1000)
            {
                maxAcc = Random.Range(0.5f, 0.7f);
            }
            if (menuScript.scoreScript.plusMul >= 1000 && menuScript.scoreScript.plusMul < 1500)
            {
                if (Idballoon == "orange" || Idballoon == "eater")
                {
                    maxAcc = 4f;
                }
                else
                {
                    if (Idballoon == "black")
                    {
                        maxAcc = 0.5f;
                    }
                    else
                    {
                        maxAcc = Random.Range(0.7f, 1f);
                    }
                }
            }
            if (menuScript.scoreScript.plusMul >= 1500 && menuScript.scoreScript.plusMul < 2000)
            {
                if (Idballoon == "orange" || Idballoon == "eater")
                {
                    maxAcc = 4f;
                }
                else
                {
                    if (Idballoon == "black")
                    {
                        maxAcc = 0.5f;
                    }
                    else
                    {
                        maxAcc = Random.Range(0.7f, 1f);
                    }
                }
            }
            if (menuScript.scoreScript.plusMul >= 2000 && menuScript.scoreScript.plusMul < 2500)
            {
                if (Idballoon == "orange" || Idballoon == "eater")
                {
                    maxAcc = 4f;
                }
                else
                {
                    if (Idballoon == "black")
                    {
                        maxAcc = 0.5f;
                    }
                    else
                    {
                        maxAcc = Random.Range(0.7f, 1f);
                    }
                }
            }
            if (menuScript.scoreScript.plusMul >= 2500 && menuScript.scoreScript.plusMul < 3000)
            {
                if (Idballoon == "orange" || Idballoon == "eater")
                {
                    maxAcc = 4f;
                }
                else
                {
                    if (Idballoon == "black")
                    {
                        maxAcc = 0.5f;
                    }
                    else
                    {
                        maxAcc = Random.Range(0.7f, 1f);
                    }
                }
            }
            if (menuScript.scoreScript.plusMul >= 3000 && menuScript.scoreScript.plusMul < 3500)
            {
                if (Idballoon == "orange" || Idballoon == "eater")
                {
                    maxAcc = 4f;
                }
                else
                {
                    if (Idballoon == "black")
                    {
                        maxAcc = 0.5f;
                    }
                    else
                    {
                        maxAcc = Random.Range(0.7f, 1f);
                    }
                }
            }
            if (menuScript.scoreScript.plusMul >= 3500)
            {
                if (Idballoon == "orange" || Idballoon == "eater")
                {
                    maxAcc = 4f;
                }
                else
                {
                    if (Idballoon == "black")
                    {
                        maxAcc = 0.5f;
                    }
                    else
                    {
                        maxAcc = Random.Range(1.5f, 2f);
                    }
                }
            }
        }
        //
        //if we are in the menu, we set a speed
        if (!menuScript.gameStarted && !menuScript.survivorMode)
        {
            maxAcc = Random.Range(0.5f, 0.7f);
            if (Idballoon == "orange")
            {
                maxAcc = 4f;
            }
            if (Idballoon == "eater")
            {
                maxAcc = 4f;
            }
        }

        //Aceleration procces
        if (aceleration < maxAcc)
        {
            aceleration += Time.deltaTime;
        }
        transform.position -= transform.up *-aceleration*Time.deltaTime;
        transform.Rotate(new Vector3(0,0,0),1);
        //
	}

    void OnTriggerEnter(Collider c)
    {
        //if we are near the balloonDestroyer, we set a comic face
        if (Idballoon == "red" || Idballoon == "blue" || Idballoon == "yellow" || Idballoon == "green")
        {
            if (c.collider.gameObject.layer == 2)
            {
               // faceManager.i = Random.Range(11, 13);
                faceManager.gameObject.renderer.material.mainTexture = faceManager.facesList[0];
            }
        }
    }
    void OnTriggerExit(Collider c)
    {
        //if we take it out of the balloonDestroyer we change his face
        if (Idballoon == "red" || Idballoon == "blue" || Idballoon == "yellow" || Idballoon == "green")
        {
            if (c.collider.gameObject.layer == 2)
            {
              //  faceManager.i = Random.Range(0, 11);
                faceManager.gameObject.renderer.material.mainTexture = faceManager.facesList[0];
            }
        }
    }

    void OnDestroy()
    {
        //if the bomber dies, he took everything that its near with him
        if (Idballoon == "black")
        {
           soundScript.PlaySound(31, false, 0.7f);
        }
        else
        {
           explosionSound = Random.Range(2, 6);
            soundScript.PlaySound(explosionSound, false, 0.7f);
        }
        //

        //When the balloon is destroyed we call a method in ScoreManipulator
        if (menuScript.gameStarted)
        {
            scoreScript.ManageDestroyedBalloons();
        }
    }
}
