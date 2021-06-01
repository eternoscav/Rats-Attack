using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Flash;

 
public class MenuManipulator : MonoBehaviour
{   
	public Banner banner;
    //Variables
    //GameObjects
	public GameObject Fundo;
	public GameObject Fundo2;
	public GameObject Survivor_Barra;
    public List<GameObject> feedback;
	public GameObject Casa_Manha_Barra;
	public GameObject Casa_Manha;
	public GameObject Casa_Tarde;
	public GameObject Casa_Noite;
	public GameObject Jardim_Manha;
	public GameObject Jardim_Tarde;
	public GameObject Jardim_Noite;
	public GameObject Rua_Manha;
	public GameObject Rua_Tarde;
	public GameObject Rua_Noite;
    public GameObject entireMenu;
    public GameObject levels;
    public GameObject back;
    public GameObject menuDeco;
    public GameObject score;
    public GameObject scoreFeedback;
    public GameObject particle;
    public GameObject ballonManager;
    public GameObject particleBoom;
    public GameObject howToPlay;
    public GameObject feedbackPos;
    public GameObject particleGreen;
    public GameObject pauseGo;
    public GameObject help;
    public GameObject soundButton;
    public GameObject soundInMenu; 
    public GameObject intro;
    public GameObject pauseOptions;
    GameObject prepare;
    GameObject clouds;
    GameObject help1;
    GameObject particleGreen2;
    //
    //Boll&&Ints&&Floats&&Strings
    public bool inStorm;
    public bool loading;
    public bool gameStarted;
    public bool pause;
    public bool survivorMode;
    public bool loadingSurvivor;
    public bool bulletTime;
    bool once;
    bool onceHelp;
    bool onceSound;
    bool soundOnOff;

    public int multiply;
    public int objectiveScore;
    public int balloonsCuantity;
    public int level;
    public int highScore;
    int highScoreLevel;
    int bombArrayLength;
    int randomIncognit;

    public float timerBalloons;
    float waiting;
    float bulletTimer;

    public string provisorio;
    //
    //Texture2D
    public List<Texture2D> scoreFeedbackTextures;
    public List<Texture2D> particleTexture;
    public List<Texture2D> helpTxt;
    public Texture2D greenTxt;
    public Texture2D redTxt;
    public Texture2D yellowParticle;
    public Texture2D pauseOff;
    public Texture2D pauseOn;
    public Texture2D soundOn;
    public Texture2D soundOff;
    //
    //Scripts
    Balloon hitObject;
    BombScript bombScript;
    BombGetChildren bombChild;
    public ScoreManipulator scoreScript;
    BallonManager ballonManagerScript;
    SoundManager soundScript;
    public ButtonId buttonPressed;
    //
    //Others
    RaycastHit hit;
    public Transform cloudsPos;
    public Transform helpPos;
    public GameObject scoreScreen;
    //

	private string sourceString = "https://www.facebook.com/jymidiaglobal?fref=ts";

	void Start () 
    {

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
        /*ActionScript.Import("flash.net.URLRequest");

        ActionScript.Import("flash.net.navigateToURL");*/

        scoreScreen.SetActiveRecursively(false);
       // Screen.SetResolution(960, 640, false);
        //Setting Variables
        inStorm = false;
        level = 0;
        soundScript = this.gameObject.GetComponent<SoundManager>();
        soundScript.PlaySound(0, true, 0.1f);
        soundScript.PlaySound(1, true, 0.1f);
        ballonManagerScript = ballonManager.GetComponent<BallonManager>();
        clouds = (GameObject)GameObject.Instantiate(menuDeco);
        clouds.transform.position = cloudsPos.position;
        provisorio = "";
        scoreScript = score.GetComponent<ScoreManipulator>();
	}
	
	void Update () 
    {

        //BulletTimer Settings
        if (bulletTime)
        {
            if (bulletTimer < 3)
            {
                soundScript.ChangePitch();
                bulletTimer += Time.deltaTime;
            }
            else
            {
                soundScript.ResumePitch();
                bulletTime = false;
                bulletTimer = 0;
            }
        }
        //BulletTimer SettingsEnd

        //Levels Settings //ObjectiveScore-Timer between instanciating Balloons-Loading
        if (level == 46)
        {
            if (!once)
            {
                balloonsCuantity = 100000;
                timerBalloons = 3;
                loadingSurvivor = true;
                once = true;
            }
        }
        if (level == 1)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(true);
				Casa_Manha.SetActive(true);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(false);
                objectiveScore = 500;
                balloonsCuantity = 30;
                timerBalloons = 3;
                loading = true;
                once = true;
            }
        }
        if (level == 2)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(true);
				Casa_Manha.SetActive(true);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(false);
                objectiveScore = 750;
                balloonsCuantity = 35;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 3)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(true);
				Casa_Manha.SetActive(true);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(false);
                objectiveScore = 1000;
                balloonsCuantity = 40;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 4)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(true);
				Casa_Manha.SetActive(true);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(false);
                objectiveScore = 1250;
                balloonsCuantity = 45;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 5)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(true);
				Casa_Manha.SetActive(true);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(false);
                objectiveScore = 800;
                balloonsCuantity = 45;
                timerBalloons = 1.5f;
                loading = true;
                once = true;
            }
        }
        if (level == 6)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(true);
				Casa_Noite.SetActive(false);
                objectiveScore = 800;
                balloonsCuantity = 40;
                timerBalloons = 2f;
                loading = true;
                once = true;
            }
        }
        if (level == 7)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(true);
				Casa_Noite.SetActive(false);
                objectiveScore = 1000;
                balloonsCuantity = 45;
                timerBalloons = 2f;
                loading = true;
                once = true;
            }
        }
        if (level == 8)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(true);
				Casa_Noite.SetActive(false);
                objectiveScore = 1000;
                balloonsCuantity = 40;
                timerBalloons = 1.5f;
                loading = true;
                once = true;
            }
        }
        if (level == 9)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(true);
				Casa_Noite.SetActive(false);
                objectiveScore = 1250;
                balloonsCuantity = 45;
                timerBalloons = 1.5f;
                loading = true;
                once = true;
            }
        }
        if (level == 10)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(true);
				Casa_Noite.SetActive(false);
                objectiveScore = 2000;
                balloonsCuantity = 55;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 11)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(true);
                objectiveScore = 2000;
                balloonsCuantity = 50;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 12)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(true);
                objectiveScore = 2000;
                balloonsCuantity = 50;
                timerBalloons = 1.5f;
                loading = true;
                once = true;
            }
        }
        if (level == 13)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(true);
                objectiveScore = 2250;
                balloonsCuantity = 55;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 14)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(true);
                objectiveScore = 2250;
                balloonsCuantity = 55;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 15)
        {
            if (!once)
            {
				Casa_Manha_Barra.SetActive(false);
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(true);
                objectiveScore = 2000;
                balloonsCuantity = 55;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 16)
        {
            if (!once)
            {
				Casa_Manha.SetActive(false);
				Casa_Tarde.SetActive(false);
				Casa_Noite.SetActive(true);
                objectiveScore = 1250;
                balloonsCuantity = 40;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 17)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(true);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1250;
                balloonsCuantity = 35;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 18)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(true);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1500;
                balloonsCuantity = 40;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 19)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(true);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1500;
                balloonsCuantity = 40;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 20)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(true);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1250;
                balloonsCuantity = 35;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 21)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(true);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1500;
                balloonsCuantity = 40;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 22)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(true);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1500;
                balloonsCuantity = 35;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 23)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(true);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1500;
                balloonsCuantity = 40;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 24)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(true);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1500;
                balloonsCuantity = 35;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 25)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(true);
				Jardim_Noite.SetActive(false);
                objectiveScore = 1500;
                balloonsCuantity = 40;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 26)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(true);
                objectiveScore = 1750;
                balloonsCuantity = 40;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 27)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(true);
                objectiveScore = 1750;
                balloonsCuantity = 40;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 28)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(true);
                objectiveScore = 1500;
                balloonsCuantity = 40;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 29)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(true);
                objectiveScore = 1750;
                balloonsCuantity = 45;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 30)
        {
            if (!once)
            {
				Jardim_Manha.SetActive(false);
				Jardim_Tarde.SetActive(false);
				Jardim_Noite.SetActive(true);
                objectiveScore = 1750;
                balloonsCuantity = 45;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 31)
        {
            if (!once)
            {
				Rua_Manha.SetActive(true);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(false);
                objectiveScore = 1750;
                balloonsCuantity = 40;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 32)
        {
            if (!once)
            {
				Rua_Manha.SetActive(true);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(false);
                objectiveScore = 2000;
                balloonsCuantity = 50;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 33)
        {
            if (!once)
            {
				Rua_Manha.SetActive(true);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(false);
                objectiveScore = 2000;
                balloonsCuantity = 40;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 34)
        {
            if (!once)
            {
				Rua_Manha.SetActive(true);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(false);
                objectiveScore = 2500;
                balloonsCuantity = 45;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 35)
        {
            if (!once)
            {
				Rua_Manha.SetActive(true);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(false);
                objectiveScore = 2500;
                balloonsCuantity = 40;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 36)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(true);
				Rua_Noite.SetActive(false);
                objectiveScore = 2500;
                balloonsCuantity = 40;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 37)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(true);
				Rua_Noite.SetActive(false);
                objectiveScore = 2750;
                balloonsCuantity = 45;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 38)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(true);
				Rua_Noite.SetActive(false);
                objectiveScore = 2750;
                balloonsCuantity = 45;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 39)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(true);
				Rua_Noite.SetActive(false);
                objectiveScore = 2500;
                balloonsCuantity = 45;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 40)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(true);
				Rua_Noite.SetActive(false);
                objectiveScore = 3000;
                balloonsCuantity = 60;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 41)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(true);
                objectiveScore = 3000;
                balloonsCuantity = 55;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 42)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(true);
                objectiveScore = 3000;
                balloonsCuantity = 50;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 43)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(true);
                objectiveScore = 3000;
                balloonsCuantity = 55;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        if (level == 44)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(true);
                objectiveScore = 3000;
                balloonsCuantity = 55;
                timerBalloons = 2;
                loading = true;
                once = true;
            }
        }
        if (level == 45)
        {
            if (!once)
            {
				Rua_Manha.SetActive(false);
				Rua_Tarde.SetActive(false);
				Rua_Noite.SetActive(true);
                objectiveScore = 3500;
                balloonsCuantity = 60;
                timerBalloons = 1;
                loading = true;
                once = true;
            }
        }
        //ButtonsLevelsEnd

        //Pause && Sound
        if (pause)
        {
            pauseOptions.SetActiveRecursively(true);
            soundScript.StopSound();
            Time.timeScale = 0;
            pauseGo.renderer.material.mainTexture = pauseOn;
        }
        else
        {
            pauseOptions.SetActiveRecursively(false);
            if (!soundOnOff)
            {
                soundScript.ResumeSound();
            }
            else
            {
                soundScript.StopSound();
            }
            if (bulletTime)
            {
                Time.timeScale = 0.3f;
            }
            else
            {
                Time.timeScale = 1;
            }
            pauseGo.renderer.material.mainTexture = pauseOff;
        }
        if (soundOnOff)
        {
            soundInMenu.renderer.material.mainTexture = soundOff;
            soundButton.renderer.material.mainTexture = soundOff;
            soundScript.StopSound();
        }
        else
        {
            soundInMenu.renderer.material.mainTexture = soundOn;
            soundButton.renderer.material.mainTexture = soundOn;
            if (!pause)
            {
                soundScript.ResumeSound();
            }
        }
        //Pause && Sound End

        //Buttons-Balloons Manipulator   
        if (!pause)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    //Menu
                    if (hit.collider.gameObject.GetComponent<ButtonId>())
                    {
                        buttonPressed = hit.collider.gameObject.GetComponent<ButtonId>();
                        if (buttonPressed.id == "face")
                        {
                            soundScript.PlaySound(19, false, 1f);
                           // Application.OpenURL("https://www.facebook.com/pages/Crusher-Balloons/192136817565820");
                            //ActionScript.Statement("navigateToURL(new URLRequest({0}))", sourceString);  
                            URLHelper.navigateTo(sourceString);
                        }
                        if (buttonPressed.id == "twitter")
                        {
                            soundScript.PlaySound(19, false, 1f);
							Application.OpenURL("http://jymidiaglobal.com/");
                        }

                        if (buttonPressed.id == "restart")
                        {
                            soundScript.PlaySound(19, false, 1f);
                            Reset();
                        }
                        if (buttonPressed.id == "sound")
                        {
                            soundOnOff = !soundOnOff;
                        }
                        if (buttonPressed.id == "okIntro")
                        {
                            Destroy(intro.gameObject);
                        }
                        if (buttonPressed.id == "pause")
                        {
                            pause = !pause;
                        }
                        if (buttonPressed.id == "survivor")
                        {
                            level = buttonPressed.idLevel;
                            highScore = scoreScript.highScoreList[level];
                            entireMenu.animation.Play("@SurvivorToLoading");
                        }
                        if (buttonPressed.id == "toMenu")
                        {
                            soundScript.PlaySound(19, false, 1f);
                            level = 0;
                            once = false;
                            gameStarted = false;
							GoogleMobileAdsPlugin.ShowBannerView ();
                            survivorMode = false;
                            ballonManagerScript.timerEnd = 5;
                            entireMenu.animation.Play("@LoadingToLevels");
                            Reset();

                        }
                        if (buttonPressed.id == "toNextLevel")
                        {
                            soundScript.PlaySound(19, false, 1f);
                            gameStarted = false;
							GoogleMobileAdsPlugin.ShowBannerView ();
                            once = false;
                            Reset();
                            level++;
							if(level == 16){
								soundScript.PlaySound(19, false, 1f);
								levels.animation.Play("@Level1ToLevel2");
								back.animation.Play("@BackToLevel2");
								inStorm = true;
							}
							if(level == 31){
								soundScript.PlaySound(19, false, 1f);
								levels.animation.Play("@Level2ToLevel3");
								back.animation.Play("@BackToLevel3");
								inStorm = false;
							}
                        }
                        if (buttonPressed.id == "play")
                        {
                            soundScript.PlaySound(19, false, 1f);
                            entireMenu.animation.Play("@PlayToLevelSurvivor");
                        }
                        if (buttonPressed.id == "BackFromHow")
                        {
                            soundScript.PlaySound(20, false, 0.5f);
                            entireMenu.animation.Play("@HowToPlay");
                        }
                        if (buttonPressed.id == "how")
                        {
                            entireMenu.animation.Play("@PlayToHow");
                            soundScript.PlaySound(19, false, 1f);
                        }
                        if (buttonPressed.id == "exit")
                        {
							Application.Quit();
                           //System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                        if (buttonPressed.id == "levels")
                        {
                            soundScript.PlaySound(19, false, 1f);
                            entireMenu.animation.Play("@LevelsToSelectLevel");
                        }
                        if (buttonPressed.id == "back1")
                        {
                            soundScript.PlaySound(20, false, 0.5f);
                            entireMenu.animation.Play("@LevelSurvivorToPlay");
                        }
                        if (buttonPressed.id == "back2")
                        {
                            soundScript.PlaySound(20, false, 0.5f);
                            entireMenu.animation.Play("@SelectLevelsToLevelSurvivor");
                        }
                        if (buttonPressed.id == "next1")
                        {
                            soundScript.PlaySound(19, false, 1f);
                            levels.animation.Play("@Level1ToLevel2");
                            back.animation.Play("@BackToLevel2");
                            inStorm = true;
                        }
                        if (buttonPressed.id == "next2")
                        {
                            soundScript.PlaySound(19, false, 1f);
                            levels.animation.Play("@Level2ToLevel3");
                            back.animation.Play("@BackToLevel3");
                            inStorm = false;
                        }
                        if (buttonPressed.id == "backlevel1")
                        {
                            soundScript.PlaySound(20, false, 0.5f);
                            levels.animation.Play("@Level2ToLevel1");
                            back.animation.Play("@BackToLevel1");
                            inStorm = false;
                        }
                        if (buttonPressed.id == "backlevel2")
                        {
                            soundScript.PlaySound(20, false, 0.5f);
                            levels.animation.Play("@Level3ToLevel2");
                            back.animation.Play("@ReturnBack2");
                            inStorm = true;
                        }
                        ///////levels
                        if (buttonPressed.who == "levels")
                        {
                            entireMenu.animation.Play("@SelectLevelsToLoading");
                            level = buttonPressed.idLevel;
                            highScore = scoreScript.highScoreList[level];
                        }
                    }
                    //MenuEnd

                    ///Balloons
                    if (hit.collider.gameObject.layer == 10)
                    {
                        hitObject = hit.collider.gameObject.GetComponent<Balloon>();
                        if (hitObject.Idballoon == "orange")
                        {
                            Destroy(hit.collider.gameObject.transform.root.gameObject);
                            GameObject particleProv = (GameObject)GameObject.Instantiate(particle);
                            particleProv.transform.position = hitObject.transform.position;
                            particleProv.renderer.material.mainTexture = particleTexture[0];
                        }
                        if (hitObject.Idballoon == "bullet")
                        {
                            bulletTime = true;
                            Destroy(hit.collider.gameObject.transform.root.gameObject);
                        }
                        if (hitObject.Idballoon == "black")
                        {
                            Camera.main.animation.Play("@CameraShakeLight");
                            
                            bombScript = hit.collider.gameObject.GetComponentInChildren<BombScript>();
                            bombChild = hit.collider.gameObject.GetComponent<BombGetChildren>();
                            hitObject.renderer.enabled = false;
                            bombScript.timerBomb = 10;
                            bombChild.sphereCollider.radius = 4;
                            bombArrayLength = bombScript.arrayList.Length-1;
                            for (int i = bombArrayLength; 0 <= i; i--)
                            {
                                if (bombScript.arrayList != null)
                                {
                                    Destroy(bombScript.arrayList[i].gameObject);
                                    scoreScript.SurvivorDestroyed();
                                }
                            }
                            bombScript.thisMesh.renderer.enabled = false;
                            GameObject particleBoom1 = (GameObject)GameObject.Instantiate(particleBoom);
                            particleBoom1.transform.position = hitObject.transform.position;
                            Destroy(hit.collider.gameObject.transform.root.gameObject,0.1f);
                        }
                        if (hitObject.Idballoon == "eater")
                        {
                            Destroy(hit.collider.gameObject.transform.root.gameObject); 
                        }

                        if (hitObject.Idballoon == "theray")
                        {
                            particleGreen2 = (GameObject)GameObject.Instantiate(particleGreen);
                            particleGreen2.transform.position = hitObject.transform.position;
                            particleGreen2.renderer.material.mainTexture = yellowParticle;
                            if (hitObject.randomRayColor == 0)
                            {
                                ballonManagerScript.DestroyAllRed();
                            }
                            else
                            {
                                if (hitObject.randomRayColor == 1)
                                {
                                    ballonManagerScript.DestroyAllGreen();
                                }
                                else
                                {
                                    if (hitObject.randomRayColor == 2)
                                    {
                                        ballonManagerScript.DestroyAllBlue();
                                    }
                                    else
                                    {
                                        if (hitObject.randomRayColor == 3)
                                        {
                                            ballonManagerScript.DestroyAllYellow();
                                        }
                                    }
                                }
                            }
                            scoreScript.PlusScore(ballonManagerScript.calculationScore, 1);
                            ballonManagerScript.calculationScore = 0;
                            Destroy(hit.collider.gameObject.transform.root.gameObject);
                        }
                    }
                    if (hit.collider.gameObject.layer == 9)
                    {
                        hitObject = hit.collider.gameObject.GetComponent<Balloon>();
                        GameObject particleProv = (GameObject)GameObject.Instantiate(particle);
                        particleProv.transform.position = hitObject.transform.position;
                        if (gameStarted||survivorMode)
                        {
                            particleGreen2 = (GameObject)GameObject.Instantiate(particleGreen);
                            particleGreen2.transform.position = hitObject.transform.position;
                        }
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
                        

                        if (hitObject.Idballoon == "joker")
                        {
                            if (provisorio == "red" || provisorio == "blue" || provisorio == "yellow" || provisorio == "green" || provisorio != null)
                            {
                                hitObject.Idballoon = provisorio;
                            }
                            else
                            {
                                if (gameStarted || survivorMode)
                                {
                                    GameObject scoreFeedbackProv = (GameObject)GameObject.Instantiate(scoreFeedback);
                                    scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[0];
                                    scoreFeedbackProv.transform.position = hit.collider.gameObject.transform.position;
                                    scoreFeedbackProv.animation.Play("@ScoreFeedback");
                                    multiply = 1;
                                    scoreScript.PlusScore(10, multiply);
                                }
                            }
                        }
                        if (hitObject.Idballoon == "incognit")
                        {
                            if (gameStarted || survivorMode)
                            {
                                randomIncognit = Random.Range(0, 3);
                                if (randomIncognit == 0)
                                {
                                    particleGreen2 = (GameObject)GameObject.Instantiate(particleGreen);
                                    particleGreen2.transform.position = hitObject.transform.position;
                                    GameObject scoreFeedbackProv = (GameObject)GameObject.Instantiate(scoreFeedback);
                                    scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[0];
                                    scoreFeedbackProv.transform.position = hit.collider.gameObject.transform.position;
                                    scoreFeedbackProv.animation.Play("@ScoreFeedback");
                                    multiply = 1;
                                    scoreScript.PlusScore(10, multiply);
                                }
                                else
                                {
                                    if (randomIncognit == 1)
                                    {
                                        particleGreen2 = (GameObject)GameObject.Instantiate(particleGreen);
                                        particleGreen2.transform.position = hitObject.transform.position;
                                        if (provisorio == "red" || provisorio == "blue" || provisorio == "yellow" || provisorio == "green" || provisorio != null)
                                        {
                                            hitObject.Idballoon = provisorio;
                                        }
                                        else
                                        {
                                            GameObject scoreFeedbackProv = (GameObject)GameObject.Instantiate(scoreFeedback);
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[0];
                                            scoreFeedbackProv.transform.position = hit.collider.gameObject.transform.position;
                                            scoreFeedbackProv.animation.Play("@ScoreFeedback");
                                            multiply = 1;
                                            scoreScript.PlusScore(10, multiply);
                                        }
                                    }
                                    else
                                    {
                                        if (randomIncognit == 2)
                                        {
                                            soundScript.PlaySound(31, false, 0.7f);
                                            GameObject particleBoom1 = (GameObject)GameObject.Instantiate(particleBoom);
                                            particleBoom1.transform.position = hitObject.transform.position;
                                            for (int i = hitObject.arrayList.Length - 1; 0 <= i; i--)
                                            {
                                                if (hitObject.arrayList != null)
                                                {
                                                    Destroy(hitObject.arrayList[i].gameObject);
                                                    scoreScript.SurvivorDestroyed();
                                                }
                                            }
                                            scoreScript.PlusScore(-10, multiply);
                                        }
                                    }
                                }
                            }
                            if (gameStarted || survivorMode)
                            {
                                if (hitObject.Idballoon == "incognit" && randomIncognit == 2)
                                {
                                    particleGreen2.renderer.material.mainTexture = redTxt;
                                }
                                else
                                {
                                    particleGreen2.renderer.material.mainTexture = greenTxt;
                                }
                            }
                            Destroy(hit.collider.gameObject.transform.root.gameObject, 0.1f);
                        }
                        if (hitObject.Idballoon == "red" || hitObject.Idballoon == "blue" || hitObject.Idballoon == "green" || hitObject.Idballoon == "yellow")
                        {
                            if (gameStarted || survivorMode)
                            {
                                if (provisorio == "")
                                {

                                    GameObject scoreFeedbackProv = (GameObject)GameObject.Instantiate(scoreFeedback);
                                    scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[0];
                                    scoreFeedbackProv.transform.position = hit.collider.gameObject.transform.position;
                                    scoreFeedbackProv.animation.Play("@ScoreFeedback");
                                    multiply = 1;
                                    provisorio = hitObject.Idballoon;
                                    scoreScript.PlusScore(10, multiply);
                                }
                                else
                                {
                                    if (provisorio == hitObject.Idballoon)
                                    {
                                        GameObject scoreFeedbackProv = (GameObject)GameObject.Instantiate(scoreFeedback);
                                        scoreFeedbackProv.transform.position = hit.collider.gameObject.transform.position;
                                        scoreFeedbackProv.animation.Play("@xScore");
                                        multiply++;

                                        if (multiply == 2)
                                        {

                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[1];
                                        }
                                        if (multiply == 3)
                                        {
                                            soundScript.PlaySound(22, false, 1);
                                            GameObject feedBack = (GameObject)GameObject.Instantiate(feedback[0]);
                                            feedBack.transform.position = feedbackPos.transform.position;
                                            this.animation.Play("@CameraShakeLight");
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[2];
                                        }
                                        if (multiply == 4)
                                        {
                                            this.animation.Play("@CameraShakeLight");
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[3];
                                        }
                                        if (multiply == 5)
                                        {
                                            soundScript.PlaySound(23, false, 1);
                                            GameObject great = (GameObject)GameObject.Instantiate(feedback[1]);
                                            great.transform.position = feedbackPos.transform.position;
                                            this.animation.CrossFade("@CameraShakingLight");
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[4];
                                        }
                                        if (multiply == 6)
                                        {
                                            this.animation.CrossFadeQueued("@CameraShakingLight");
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[5];
                                        }
                                        if (multiply == 7)
                                        {
                                            soundScript.PlaySound(28, false, 1);
                                            GameObject awesome = (GameObject)GameObject.Instantiate(feedback[2]);
                                            awesome.transform.position = feedbackPos.transform.position;
                                            this.animation.CrossFade("@CameraShakingHeavy");
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[6];
                                        }
                                        if (multiply == 8)
                                        {
                                            this.animation.CrossFade("@CameraShakingHeavy");
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[7];
                                        }
                                        if (multiply == 9)
                                        {
                                            this.animation.CrossFade("@CameraShakingHeavy");
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[8];
                                        }
                                        if (multiply >= 10)
                                        {
                                            soundScript.PlaySound(29, false, 1);
                                            GameObject perfect = (GameObject)GameObject.Instantiate(feedback[3]);
                                            perfect.transform.position = feedbackPos.transform.position;
                                            this.animation.CrossFade("@CameraShakingSuperHeavy");
                                            multiply = 10;
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[9];
                                        }
                                        scoreScript.PlusScore(10, multiply);
                                    }
                                    else
                                    {
                                        if (provisorio != hitObject.Idballoon)
                                        {
                                            provisorio = hitObject.Idballoon;

                                            this.animation.CrossFade("@CameraIdle");
                                            GameObject scoreFeedbackProv = (GameObject)GameObject.Instantiate(scoreFeedback);
                                            scoreFeedbackProv.renderer.material.mainTexture = scoreFeedbackTextures[0];
                                            scoreFeedbackProv.transform.position = hit.collider.gameObject.transform.position;
                                            scoreFeedbackProv.animation.Play("@ScoreFeedback");
                                            multiply = 1;
                                            scoreScript.PlusScore(10, multiply);
                                        }
                                    }
                                }
                        
                            }
                        }
                        Destroy(hit.collider.gameObject.transform.root.gameObject);
                    }
                    ///BalloonsEnd
                }
            }
        }
        else
        {
            //I do an else cause if pause is true i cant cast ray, so the only things that i can catch we my ray in pause is one of the optionsButtons 
            //OptionsSelection
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    buttonPressed = hit.collider.gameObject.GetComponent<ButtonId>();
                    if (buttonPressed != null)
                    {
                        if (buttonPressed.id == "pause")
                        {
                            pause = !pause;
                        }

                        if (buttonPressed.id == "restart")
                        {
                            pause = false;
                            soundScript.PlaySound(19, false, 1f);
                            Reset();
                        }
                        if (buttonPressed.id == "toMenu")
                        {
                            pause = false;
                            soundScript.PlaySound(19, false, 1f);
                            level = 0;
                            once = false;
                            gameStarted = false;
							GoogleMobileAdsPlugin.ShowBannerView ();
                            survivorMode = false;

                            ballonManagerScript.timerEnd = 5;
                            entireMenu.animation.Play("@LoadingToLevels");
                            Reset();
                        }
                        if (buttonPressed.id == "sound")
                        {
                            soundOnOff = !soundOnOff;
                        }
                    }
                }
            }
        }

        //Loadings (Levels or Survivor)
        if (loadingSurvivor)
        {
            if (waiting < 3)
            {
                waiting += Time.deltaTime;
            }
            else
            {
                //I show a little help or feedback about the special balloon-how to play
                if (!onceHelp)
                {
                    help1 = (GameObject)GameObject.Instantiate(help);
                    help1.transform.position = helpPos.position;
                    help1.renderer.material.mainTexture = helpTxt[9];
                    onceHelp = true;
                }
                //Do i pressed the ok button of the help? Yes-Get ready to play
                if (buttonPressed.id == "ok")
                {
                    soundScript.PlaySound(19, false, 1f);
                    prepare = (GameObject)GameObject.Instantiate(feedback[4]);
                    prepare.transform.position = feedbackPos.transform.position;
                    help1.animation.Play("@HelpOut");
                    Destroy(help1.gameObject, 1);
                    Destroy(clouds.gameObject);
                    clouds = (GameObject)GameObject.Instantiate(menuDeco);
                    clouds.transform.position = cloudsPos.position;
                    waiting = 0;
                    scoreScript.survivorEnd = 0;
                    loadingSurvivor = false;
                    survivorMode = true;
					GoogleMobileAdsPlugin.HideBannerView ();
                }
            }
        }

		if(gameStarted == false){
			Fundo.SetActive(true);
			//banner.LigarBanner();
			//banner.IsGrounded = false;
		
		}else if(gameStarted == true) {
			Fundo.SetActive(false);
			//banner.LigarBanner();
			//banner.IsGrounded = true;
		//	GoogleMobileAdsPlugin.HideBannerView();
		//	banner.ligarBanner = false;
		}

		if(survivorMode == false){
			//Casa_Manha_Barra.SetActive(true);
			Fundo2.SetActive(false);
			Survivor_Barra.SetActive(false);
		}else if(survivorMode == true) {
			Casa_Manha_Barra.SetActive(false);
			Casa_Manha.SetActive(false);
			Casa_Tarde.SetActive(false);
			Casa_Noite.SetActive(false);
			Survivor_Barra.SetActive(true);
			Fundo2.SetActive(true);
			Fundo.SetActive (false);
		}
		





        if (loading)
        {

            if (waiting < 3)
            {
                waiting += Time.deltaTime;
            }
            else
            {
                //I show a little help or feedback about the special balloon-how to play (Depending the level)
				if (level == 1 ||  level == 5||level==10||level==15||level==16||level==20||level==25||level==30||level==35)
                {
                    if (!onceHelp)
                    {
                        help1 = (GameObject)GameObject.Instantiate(help);
                        help1.transform.position = helpPos.position;
                        if (level == 1)
                        {
							help1.renderer.material.mainTexture = helpTxt[0];
                        }

                        if (level == 5)
						{

                            help1.renderer.material.mainTexture = helpTxt[1];
                        }

                        if (level == 10)
                        {

                            help1.renderer.material.mainTexture = helpTxt[2];
                        }
                        if (level == 15)
                        {

                            help1.renderer.material.mainTexture = helpTxt[3];
                        }
                        if (level == 16)
                        {

                            help1.renderer.material.mainTexture = helpTxt[6];
                        }
                        if (level == 20)
                        {

                            help1.renderer.material.mainTexture = helpTxt[4];
                        }
                        if (level == 25)
                        {
                            help1.renderer.material.mainTexture = helpTxt[5];
                        }
                        if (level == 30)
                        {

                            help1.renderer.material.mainTexture = helpTxt[7];
                        }
                        if (level == 35)
                        {

                            help1.renderer.material.mainTexture = helpTxt[8];
                        }
                        onceHelp = true;
                    }
                    //Do i pressed the ok button of the help? Yes-Get ready to play
                    if (buttonPressed.id == "ok")
                    {
                        soundScript.PlaySound(19, false, 1f);
                        prepare = (GameObject)GameObject.Instantiate(feedback[4]);
                        prepare.transform.position = feedbackPos.transform.position;
                        help1.animation.Play("@HelpOut");
                        Destroy(help1.gameObject, 1);
                        Destroy(clouds.gameObject);
                        clouds = (GameObject)GameObject.Instantiate(menuDeco);
                        clouds.transform.position = cloudsPos.position;
                        waiting = 0;
                        scoreScript.totalBallonsDestroyed = 0;
                        loading = false;
                        gameStarted = true;
						GoogleMobileAdsPlugin.HideBannerView ();

                    }
                }
                else
                {
                    prepare = (GameObject)GameObject.Instantiate(feedback[4]);
                    prepare.transform.position = feedbackPos.transform.position;
                    Destroy(clouds.gameObject);
                    clouds = (GameObject)GameObject.Instantiate(menuDeco);
                    clouds.transform.position = cloudsPos.position;
                    waiting = 0;
                    scoreScript.totalBallonsDestroyed = 0;
                    loading = false;
                    gameStarted = true;
					GoogleMobileAdsPlugin.HideBannerView ();
                }
            }
        }

        //When the menu can be seen?
        if (gameStarted||survivorMode)
        {
            soundInMenu.renderer.enabled = false;
            soundInMenu.collider.enabled = false;
            if (!scoreScript.showingScore)
            {
                pauseGo.renderer.enabled = true;
                pauseGo.collider.enabled = true;
            }
            else
            {
                pauseGo.renderer.enabled = false;
                pauseGo.collider.enabled = false;
            }
            soundScript._channels[0].mute = true;

            if (!pause && !soundOnOff)
            {
                soundScript._channels[1].volume = 0.1f;
            }
            else
            {
                soundScript._channels[1].volume = 0;
            }

            entireMenu.SetActiveRecursively(false);
			Fundo.SetActive(false);
        }
        else
        {
            soundInMenu.renderer.enabled = true;
            soundInMenu.collider.enabled = true;
            pauseGo.renderer.enabled = false;
            pauseGo.collider.enabled = false;
            if (!onceSound)
            {
                onceSound = true;
            }

            if (!pause&&!soundOnOff)
            {
                soundScript._channels[0].volume = 0.1f;
            }
            soundScript._channels[1].volume = 0;
            
            entireMenu.SetActiveRecursively(true);
			Fundo.SetActive(true);
        }
	}


   //Reset Method (Reset every variable)
    void Reset()
    {

        if (prepare != null)
        {
            Destroy(prepare.gameObject);
        }
        if (ballonManagerScript.allBalloons != null)
        {
            for (int i = 0; i < ballonManagerScript.allBalloons.Count; i++)
            {
                Destroy(ballonManagerScript.allBalloons[i].gameObject);
            }
        }
        multiply = 0;
        scoreScript.survivorEnd = 0;
        scoreScript.onceSound = false;
        scoreScript.onceSound2 = false;
        //highScore = scoreScript.highScoreList[highScore];
        onceHelp = false;
        scoreScript.plusMul = 0;
        scoreScript.score = 0;
        scoreScript.counting = 0;
        scoreScript.timerToScore = 0;
        ballonManagerScript.countingBalloons = balloonsCuantity;
        scoreScript.showingScore = false;
        scoreScript.once = false;
        scoreScript.scoreScreen.SetActiveRecursively(false);
        scoreScript.DestroyList();
        scoreScript.disableHud = false;
        scoreScript.totalBallonsDestroyed = 0;
        scoreScript.showButtons = false;
        ballonManagerScript.count = 0;
        scoreScript.waitSec = 0;
        scoreScript.showingScoreSurvivor = false;
        Destroy(clouds.gameObject);
        clouds = (GameObject)GameObject.Instantiate(menuDeco);
        clouds.transform.position = cloudsPos.position;
        scoreScript.fireworks.SetActiveRecursively(false);
    }
}
