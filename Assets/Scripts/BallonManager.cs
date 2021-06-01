using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BallonManager : MonoBehaviour {

    //Gameobjects
    public List<GameObject> ballonList;
    public GameObject balloonParticle;
    public List<GameObject> allBalloons;
    public List<GameObject> redBalloons;
    public List<GameObject> blueBalloons;
    public List<GameObject> yellowBalloons;
    public List<GameObject> greenBalloons;
    //
    //Int&&Bool&&Float
    public int multiplyScore;
    public int calculationScore;
    public int cuantity;
    public int countingBalloons;
    public int count;
    int randomGoodExtra;
    int random;
    bool stopTimer;
    public float timerEnd;
    float timer;
    //
    public List<Texture2D> particles;
    MenuManipulator menuScript;

	void Start ()
    {
        menuScript = Camera.main.GetComponent<MenuManipulator>();
        timerEnd = 6;
        //We instanciate some balloons
        for (int i=0;i<ballonList.Count;i++)
        {
            if (i == 0)
            {
                GameObject blue = (GameObject)GameObject.Instantiate(ballonList[0]);
                blueBalloons.Add(blue);
                allBalloons.Add(blue);
            }
            if (i == 1)
            {
                GameObject green = (GameObject)GameObject.Instantiate(ballonList[1]);
                greenBalloons.Add(green);
                allBalloons.Add(green);
            }
            if (i == 2)
            {
                GameObject red = (GameObject)GameObject.Instantiate(ballonList[2]);
                redBalloons.Add(red);
                allBalloons.Add(red);
            }
            if (i == 3)
            {
                GameObject yellow = (GameObject)GameObject.Instantiate(ballonList[3]);
                yellowBalloons.Add(yellow);
                allBalloons.Add(yellow);
            }
            ballonList[i].transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f),0);
        }
        //
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if the game is loading do not instanciate balloons
        if (menuScript.loading||menuScript.loadingSurvivor)
        {
            DestroyAllBalloons();
            timer = 0;
            countingBalloons = menuScript.balloonsCuantity;
            count = 0;
            timerEnd = menuScript.timerBalloons;
            if (!menuScript.gameStarted||!menuScript.survivorMode)
            {
                stopTimer = true;
            }
        }
        //

        //If the mode finish, we stop instanciating (Survivor or Level)
        if (menuScript.survivorMode)
        {
            if (menuScript.scoreScript.survivorEnd >= 20)
            {
                DestroyAllBalloons();
                stopTimer = true;
            }
            else
            {
                stopTimer = false;
            }
        }

        if (menuScript.gameStarted)
        {
            if (count < menuScript.balloonsCuantity)
            {
                stopTimer = false;
            }
            else
            {
                stopTimer = true;
            }
        }

        //If the game is running we instanciate balloons
        if (!menuScript.gameStarted&&!menuScript.survivorMode)
        {
            stopTimer = false;
        }

        //Instanciate timer
        if (!stopTimer)
        {
            if (timer < timerEnd)
            {
                timer += Time.deltaTime;
            }
            else
            {
                //if its level mode its diff from survivor/we have to instanciate diff balloons according to the level
                if (menuScript.gameStarted)
                {
                    //Up to level 5, there are no special balloons
                    if (menuScript.level < 5)
                    {
                        //remember doing random range from 0 to 4, the posibles int are (0,1,2,3)
                        random = Random.Range(0, 4);
                    }
                    //Wich level is? Depending on the level, we instanciate more or less special balloons
                    if (menuScript.level >= 5)
                    {
                        //We do a random int, if randomGoodExtra is 10,20,15 or 16, we instanciate a special balloon, else, we instanciate a normal
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10||randomGoodExtra==20||randomGoodExtra==15||randomGoodExtra==16)
                        {
                            if (menuScript.level >= 5 && menuScript.level <10)
                            {
                                random = 4;
                            }
                            if (menuScript.level >= 10 && menuScript.level <15)
                            {
                                random = Random.Range(4, 6);
                            }
                            if (menuScript.level >= 15 && menuScript.level<20)
                            {
                                random = Random.Range(4, 7);
                            }
                            if (menuScript.level >= 20 && menuScript.level < 25)
                            {
                               random = Random.Range(4, 8);
                            }
                            if (menuScript.level >= 25 && menuScript.level < 30)
                            {
                                random = Random.Range(4, 9);
                            }
                            if (menuScript.level >= 30 && menuScript.level < 35)
                            {
                                random = Random.Range(4, 10);
                            }
                            if (menuScript.level >= 35 && menuScript.level <= 45)
                            {
                                random = Random.Range(4, 11);
                            }
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    //
                }

                //In survivor mode we are interested in the user score, so we take that to instanciate special balloons and modify speed and the timer
                if (menuScript.survivorMode)
                {
                    if (menuScript.scoreScript.plusMul < 500)
                    {
                        random = Random.Range(0, 4);
                    }
                    if (menuScript.scoreScript.plusMul >= 500 && menuScript.scoreScript.plusMul<1000)
                    {
                        timerEnd = 2;//Remember, timerEnd is the rate of balloons instance
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = 4;
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    if (menuScript.scoreScript.plusMul >= 1000 && menuScript.scoreScript.plusMul < 1500)
                    {
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = Random.Range(4, 6);
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    if (menuScript.scoreScript.plusMul >= 1500 && menuScript.scoreScript.plusMul < 2000)
                    {
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = Random.Range(4, 7);
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    if (menuScript.scoreScript.plusMul >= 2000 && menuScript.scoreScript.plusMul < 2500)
                    {
                        timerEnd = 1.7f;
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = Random.Range(4, 8);
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    if (menuScript.scoreScript.plusMul >= 2500 && menuScript.scoreScript.plusMul < 3000)
                    {
                        timerEnd = 1.5f;
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = Random.Range(4, 9);
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    if (menuScript.scoreScript.plusMul >= 3000 && menuScript.scoreScript.plusMul < 3500)
                    {
                        timerEnd = 1.5f;
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = Random.Range(4, 10);
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    if (menuScript.scoreScript.plusMul >= 3500)
                    {
                        timerEnd = 1f;
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = Random.Range(4, 11);
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                    if (menuScript.scoreScript.plusMul >= 4000)
                    {
                        timerEnd = .5f;
                        randomGoodExtra = Random.Range(0, 20);
                        if (randomGoodExtra == 10 || randomGoodExtra == 20 || randomGoodExtra == 15 || randomGoodExtra == 16)
                        {
                            random = Random.Range(4, 11);
                        }
                        else
                        {
                            random = Random.Range(0, 4);
                        }
                    }
                }
                //

                //if we are in the menu we instance some balloons
                if (!menuScript.gameStarted && !menuScript.survivorMode)
                {
                    random = Random.Range(0, 9);
                }
                //
                
                //Here are our balloons
                if (random == 0)
                {
                    GameObject blue = (GameObject)GameObject.Instantiate(ballonList[0]);
                    blue.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    blueBalloons.Add(blue);//we introduce it into the right list (if we have the ray balloon, we use the DestroyBlue Method)
                    allBalloons.Add(blue);//and in the "allBalloonsList" (if we have to destroy every balloon in scene)
                }
                if (random == 1)
                {
                    GameObject green = (GameObject)GameObject.Instantiate(ballonList[1]);
                    green.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    greenBalloons.Add(green);
                    allBalloons.Add(green);
                }
                if (random == 2)
                {
                    GameObject red = (GameObject)GameObject.Instantiate(ballonList[2]);
                    red.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    redBalloons.Add(red);
                    allBalloons.Add(red);
                }
                if (random == 3)
                {
                    GameObject yellow = (GameObject)GameObject.Instantiate(ballonList[3]);
                    yellow.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    yellowBalloons.Add(yellow);
                    allBalloons.Add(yellow);
                }
                if (random == 4)
                {
                    GameObject balck = (GameObject)GameObject.Instantiate(ballonList[4]);
                    balck.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    allBalloons.Add(balck);
                }
                if (random == 5)
                {
                    GameObject orange = (GameObject)GameObject.Instantiate(ballonList[5]);
                    orange.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    allBalloons.Add(orange);
                }
                if (random == 6)
                {
                    GameObject eater = (GameObject)GameObject.Instantiate(ballonList[6]);
                    eater.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    allBalloons.Add(eater);
                }
                if (random == 7)
                {
                    GameObject joker = (GameObject)GameObject.Instantiate(ballonList[7]);
                    joker.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    allBalloons.Add(joker);
                }
                if (random == 8)
                {
                    GameObject incognit = (GameObject)GameObject.Instantiate(ballonList[8]);
                    incognit.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    allBalloons.Add(incognit);
                }
                if (random == 9)
                {
                    GameObject bullet = (GameObject)GameObject.Instantiate(ballonList[9]);
                    bullet.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    allBalloons.Add(bullet);
                }
                if (random == 10)
                {
                    GameObject ray = (GameObject)GameObject.Instantiate(ballonList[10]);
                    ray.transform.position = new Vector3(Random.Range(this.transform.position.x - 10, this.transform.position.x + 10), Random.Range(this.transform.position.y - 0.1f, this.transform.position.y + 0.1f), 0);
                    allBalloons.Add(ray);
                }
                //
                //if we are in level mode, we have rest balloons
                if (menuScript.gameStarted)
                {
                    count++;
                    Rest();
                }
                //when all is done, we reset our timer
                timer = 0;
            }
        }
        //
	}

    //Destroys all balloons in the scene
   public  void DestroyAllBalloons()
    {
        cuantity = allBalloons.Count-1;
        for (int i = cuantity; 0 <= i; i--)
        {
            Destroy(allBalloons[i]);
        }
    }

   //Destroys all red in the scene
   public  void DestroyAllRed()
    {
        cuantity = redBalloons.Count-1;
       //This part is , if we pop the special 'Ray Balloon', we have to calculate the multiply of every balloon (Remember if we pop same color is. 10*1, 10*2, 10*3...10*n)
        for (int i = cuantity; 0 <= i; i--)
        {
            if (redBalloons[i] != null)
            {
                multiplyScore++;
                calculationScore += 10 * multiplyScore;
                GameObject particlePop = (GameObject)GameObject.Instantiate(balloonParticle);
                particlePop.transform.position = redBalloons[i].transform.position;
                particlePop.renderer.material.mainTexture = particles[0];
                Destroy(redBalloons[i]);
            }
            else
            {
                multiplyScore = 0;
            }
        }
       //
    }

    //Same as red
   public void DestroyAllBlue()
    {
        cuantity = blueBalloons.Count-1;
        for (int i = cuantity; 0 <= i; i--)
        {
            if (blueBalloons[i] != null)
            {
                multiplyScore++;
                calculationScore += 10 * multiplyScore;
                GameObject particlePop = (GameObject)GameObject.Instantiate(balloonParticle);
                particlePop.transform.position = blueBalloons[i].transform.position;
                particlePop.renderer.material.mainTexture = particles[2];
                Destroy(blueBalloons[i]);
            }
            else
            {
                multiplyScore = 0;
            }
        }
    }

   //Same as red
   public void DestroyAllYellow()
    {
        cuantity = yellowBalloons.Count-1;
        for (int i = cuantity; 0 <= i; i--)
        {
            if (yellowBalloons[i] != null)
            {
                multiplyScore++;
                calculationScore += 10 * multiplyScore;
                GameObject particlePop = (GameObject)GameObject.Instantiate(balloonParticle);
                particlePop.transform.position = yellowBalloons[i].transform.position;
                particlePop.renderer.material.mainTexture = particles[3];
                Destroy(yellowBalloons[i]);
            }
            else
            {
                multiplyScore = 0;
            }
        }
    }

   //Same as red
   public void DestroyAllGreen()
    {
        cuantity = greenBalloons.Count-1;
        for (int i = cuantity; 0 <= i; i--)
        {
            if (greenBalloons[i] != null)
            {
                multiplyScore++;
                calculationScore += 10 * multiplyScore;
                Destroy(greenBalloons[i]);
                GameObject particlePop = (GameObject)GameObject.Instantiate(balloonParticle);
                particlePop.transform.position = greenBalloons[i].transform.position;
                particlePop.renderer.material.mainTexture = particles[1];
            }
            else
            {
                multiplyScore = 0;
            }
        }
    }

    //We rest one balloon
    void Rest()
    {
        countingBalloons--;
    }
}
