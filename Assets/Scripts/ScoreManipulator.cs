using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class ScoreManipulator : MonoBehaviour {

    //Variables
    //Gameobjects
    public List<GameObject> blocks;
    public GameObject survivorBlock;
    public GameObject NextLevel;
    public GameObject highscorePos;
    public GameObject newHighScore;
    public GameObject scoreScreen;
    public GameObject scoreButtons;
    public List<GameObject> stars;
    public List<GameObject> scoreObjects;
    public List<GameObject> listToDestroy;
    GameObject starProv;
    public GameObject fireworks;
    //
    //Int&&Bools&&Floats
    public int totalBallonsDestroyed;
    public int plusMul;
    public int score;
    public int survivorEnd;
    int destroyBlock;
    public List<int> highScoreList;
    public bool count;
    public bool showingScore;
    public bool once;
    public bool disableHud;
    public bool onceSound;
    public bool onceSound2;
    public bool showingScoreSurvivor;
    public bool showButtons;
    bool coinSound;
    public float counting = 0;
    public float waitSec;
    //
    //Texture2D
    public Texture2D levelClearedTxt;
    public Texture2D levelFailedTxt;
    public Texture2D scoreLevels;
    public Texture2D scoreSurvivor;
    public Texture2D nextLevelNormal;
    public List<Texture2D> starsTxt;
    //
    //Scripts
    MenuManipulator menuScript;
    Stars starScript;
    SoundManager soundScript;
    //
    //Other
    public List<Transform> positions;
    //

    public float timerToScore;
    
    void Start()
    {
		/*
		Destroy(blocks[0].gameObject);
	    Destroy(blocks[1].gameObject);
		Destroy(blocks[2].gameObject);
		Destroy(blocks[3].gameObject);
		Destroy(blocks[4].gameObject);
		Destroy(blocks[5].gameObject);
		Destroy(blocks[6].gameObject);
		Destroy(blocks[7].gameObject);
		Destroy(blocks[8].gameObject);
		Destroy(blocks[9].gameObject);
		Destroy(blocks[10].gameObject);
		Destroy(blocks[11].gameObject);
		Destroy(blocks[12].gameObject);
		Destroy(blocks[13].gameObject);
		Destroy(blocks[14].gameObject);
		Destroy(blocks[15].gameObject);
		Destroy(blocks[16].gameObject);
		Destroy(blocks[17].gameObject);
		Destroy(blocks[18].gameObject);
		Destroy(blocks[19].gameObject);
		Destroy(blocks[20].gameObject);
		Destroy(blocks[21].gameObject);
		Destroy(blocks[22].gameObject);
		Destroy(blocks[23].gameObject);
		Destroy(blocks[24].gameObject);
		Destroy(blocks[25].gameObject);
		Destroy(blocks[26].gameObject);
		Destroy(blocks[27].gameObject);
		Destroy(blocks[28].gameObject);
		Destroy(blocks[29].gameObject);
		Destroy(blocks[30].gameObject);
		Destroy(blocks[31].gameObject);
		Destroy(blocks[32].gameObject);
		Destroy(blocks[33].gameObject);
		Destroy(blocks[34].gameObject);
		Destroy(blocks[35].gameObject);
		Destroy(blocks[36].gameObject);
		Destroy(blocks[37].gameObject);
		Destroy(blocks[38].gameObject);
		Destroy(blocks[39].gameObject);
		Destroy(blocks[40].gameObject);
		Destroy(blocks[41].gameObject);
		Destroy(blocks[42].gameObject);
		Destroy(blocks[43].gameObject);
		Destroy(blocks[44].gameObject);
		Destroy(blocks[45].gameObject);

*/


        fireworks.SetActiveRecursively(false);
        //Initizalize
		//PlayerPrefs.DeleteAll();
        LoadData();
        for (int i = 0; i < destroyBlock+1; i++)
        {
            if (i <= 45)
            {
                Destroy(blocks[i].gameObject);
            }
        }
        
        //Should i destroy the blocks? (Dependes on the int destroyBlock)
        soundScript = Camera.main.GetComponent<SoundManager>();
        menuScript = Camera.main.GetComponent<MenuManipulator>();
        soundScript.PlaySound(21, true, 1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //This part is just to make the effect that the score is counting
        if (count)
        {
            Camera.main.animation.CrossFade("@CameraIdle");

            if (counting < plusMul)
            {
                counting += 2;
                score = Mathf.FloorToInt(counting);
            }
            else
            {
                counting = plusMul;
                score = Mathf.FloorToInt(counting);
                count = false;
            }
        } 
        //

        //When the level Mode finish, i show if the level is cleared or failed
        if (showingScore)
        {
            ShowScore();

            scoreButtons.SetActiveRecursively(false);

            if (once)
            {
                if (counting < plusMul)
                {
                    coinSound = true;
                    counting += 10 * Time.deltaTime * 200;
                    score = Mathf.FloorToInt(counting);
                }
                else
                {
                    coinSound = false;
                    
                    if (plusMul >= menuScript.objectiveScore)
                    {
                        if (!onceSound)
                        {
                            GameObject levelCleared = (GameObject)GameObject.Instantiate(scoreObjects[3]);
                            levelCleared.animation.Play("@LevelCleared");
                            levelCleared.renderer.material.mainTexture = levelClearedTxt;
                            levelCleared.transform.position = positions[3].position;
                            listToDestroy.Add(levelCleared);
                            soundScript.PlaySound(27, false, 0.5f);
                            onceSound = true;
                            fireworks.SetActiveRecursively(true);
                            showButtons = true;
                        }
                    }
                    else
                    {
                        if (!onceSound)
                        {
                            soundScript.PlaySound(30, false, 0.5f);
                            GameObject levelFailed = (GameObject)GameObject.Instantiate(scoreObjects[3]);
                            levelFailed.animation.Play("@LevelFailed");
                            levelFailed.renderer.material.mainTexture = levelFailedTxt;
                            levelFailed.transform.position = positions[3].position;
                            listToDestroy.Add(levelFailed);
                            onceSound = true;
                            showButtons = true;
                        }
                    }
                    score = plusMul;
                   
                }
            }
        }

        if (showButtons)
        {
            scoreButtons.SetActiveRecursively(true);
        }

        //

        //When the coin sound must be heard? Only when coinsound is true
        if (coinSound)
        {
            for (int i = soundScript.channelCount-1; 0 <= i; i--)
            {
                if (soundScript._channels[i].clip == soundScript.clips[21])
                {
                    soundScript._channels[i].volume = 1;
                }
            }
        }
        else
        {
            for (int i = soundScript.channelCount-1; 0 <= i; i--)
            {
                if (soundScript._channels[i].clip == soundScript.clips[21])
                {
                    soundScript._channels[i].volume = 0;
                }
            }
        }
        //

        //When the survivor mode finish, i show the coin effects
        if (showingScoreSurvivor)
        {
            Camera.main.animation.CrossFade("@CameraIdle");
            ShowSurvivor();
            if (once)
            {
                if (counting < plusMul)
                {
                    coinSound = true;
                    counting += 5 * Time.deltaTime * 200;
                    score = Mathf.FloorToInt(counting);
                }
                else
                {
                    coinSound = false;
                    score = plusMul;
                }
            }
        }
        //
	}

    //Survivor Method (When the survivor mode finished?
    public void SurvivorDestroyed()
    {
        survivorEnd++;
        if (survivorEnd >= 20)
        {
            showingScoreSurvivor = true;
        }
    }

    //We plus the score
    public void PlusScore(int plus,int multiply)
    {
        plusMul += plus * multiply;
    }

    //When the level Mode finished?
    public void ManageDestroyedBalloons()
    {
        totalBallonsDestroyed++;
        if (menuScript.gameStarted)
        {
            if (totalBallonsDestroyed >= menuScript.balloonsCuantity)
            {
                showingScore = true;
            }
        }
    }

    //Survivor Method(Did the user do a new highscore?)
    void ShowSurvivor()
    {
        if (waitSec < 3)
        {
            waitSec += Time.deltaTime;
        }
        else
        {
            disableHud = true;
            scoreScreen.SetActiveRecursively(true);
            scoreScreen.renderer.material.mainTexture = scoreSurvivor;
            if (!once)
            {
                NextLevel.renderer.enabled = false;
                NextLevel.collider.enabled = false;
                if (plusMul > highScoreList[menuScript.level])
                {
                    GameObject scoreHigh = (GameObject)GameObject.Instantiate(newHighScore);
                    scoreHigh.transform.position = highscorePos.transform.position;
                    listToDestroy.Add(scoreHigh);
                    highScoreList[menuScript.level] = plusMul;
                   SaveData();
                }
                counting = 0;
                once = true;
            }
        }
    }

    //Level Method (Did the user cleared the level?)
    void ShowScore()
    {
        if (waitSec < 3)
        {
            waitSec += Time.deltaTime;
        }
        else
        {
            if (!once)
            {
                disableHud = true;
                scoreScreen.SetActiveRecursively(true);

                scoreScreen.renderer.material.mainTexture = scoreLevels;
                if (plusMul >= menuScript.objectiveScore && plusMul < menuScript.objectiveScore + 75)
                {
                    if (!onceSound2)
                    {
                        soundScript.PlaySound(24, false, 1);
                        onceSound2 = true;
                    }
                }
                if (plusMul >= menuScript.objectiveScore + 75 && plusMul < menuScript.objectiveScore + 150)
                {
                    if (!onceSound2)
                    {
                        soundScript.PlaySound(25, false, 1);
                        onceSound2 = true;
                    }
                }
                if (plusMul >= menuScript.objectiveScore + 150)
                {
                    if (!onceSound2)
                    {
                        soundScript.PlaySound(26, false, 1);
                        onceSound2 = true;
                    }
                }
                if (plusMul >= menuScript.objectiveScore)
                {
					destroyBlock++;
					if(destroyBlock<=45){
						Destroy(blocks[destroyBlock].gameObject);
					}
                  

                    if (menuScript.level == 45)
                    {
                        NextLevel.renderer.enabled = false;
                        NextLevel.collider.enabled = false;
                    }
                    else
                    {
                        NextLevel.renderer.material.mainTexture = nextLevelNormal;
                        NextLevel.renderer.enabled = true;
                        NextLevel.collider.enabled = true;
                    }
                    if (menuScript.highScore < plusMul)
                    {
                        GameObject scoreHigh = (GameObject)GameObject.Instantiate(newHighScore);
                        scoreHigh.transform.position = highscorePos.transform.position;
                        listToDestroy.Add(scoreHigh);
                        highScoreList[menuScript.level] = plusMul;
                        SaveData();
                    }
                }
                else
                {
                    NextLevel.renderer.enabled = false;
                    NextLevel.collider.enabled = false;
                }
                if (plusMul >= menuScript.objectiveScore)
                {
                    GameObject star1 = (GameObject)GameObject.Instantiate(scoreObjects[0]);
                    star1.transform.position = positions[0].position;
                    listToDestroy.Add(star1);
                    starProv = stars[menuScript.level];
                    starScript = starProv.GetComponent<Stars>();
                    starScript.SetStar(1);
                }
                if (plusMul >= menuScript.objectiveScore + 75)
                {

                    GameObject star2 = (GameObject)GameObject.Instantiate(scoreObjects[1]);
                    star2.transform.position = positions[1].position;
                    listToDestroy.Add(star2);
                    starProv = stars[menuScript.level];
                    starScript = starProv.GetComponent<Stars>();
                    starScript.SetStar(2);
                }
                if (plusMul >= menuScript.objectiveScore + 150)
                {
                    GameObject star3 = (GameObject)GameObject.Instantiate(scoreObjects[2]);
                    star3.transform.position = positions[2].position;
                    listToDestroy.Add(star3);
                    starProv = stars[menuScript.level];
                    starScript = starProv.GetComponent<Stars>();
                    starScript.SetStar(3);
                }
                counting = 0;
                once = true;
            }
        }
    }

    //We destroy every asset of the score screen
    public void DestroyList()
    {
        for (int i = 0; i < listToDestroy.Count; i++)
        {
            Destroy(listToDestroy[i].gameObject);
        }
    }

    //We save the data
    void SaveData()
    {
        for (int i = 0; i < highScoreList.Count; i++)
        {
            PlayerPrefs.SetInt("highScore" + i,highScoreList[i]);
        }
        PlayerPrefs.SetInt("destroyer", destroyBlock);
        PlayerPrefs.Flush();
    }

    //We load the data
    void LoadData()
    {
        for (int i = 0; i < highScoreList.Count; i++)
        {
            highScoreList[i] = PlayerPrefs.GetInt("highScore" + i);
        }
        destroyBlock = PlayerPrefs.GetInt("destroyer");
    }
}
