using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

    public GUISkin blueFont;
    public GUISkin blackFont;
    BallonManager bManager;
    MenuManipulator menuScript;
    public Texture2D barIdle;
    public Texture2D barFull;
    float initialWidth;
    Rect barRect;
    public GameObject score;
    ScoreManipulator scoreScript;
    public int scores;
    int objectiveScore;
    public GameObject balloonsManager;
 

	void Start () 
    {
        bManager = balloonsManager.GetComponent<BallonManager>();
        menuScript = Camera.main.GetComponent<MenuManipulator>();
        scoreScript = score.GetComponent<ScoreManipulator>();
	}

    void Update()
    {
        objectiveScore = menuScript.objectiveScore;
        scores = scoreScript.score;
		barRect = new Rect(Screen.width / 2 - 175, 10, 400, 15);
		initialWidth = barRect.width;
    }

    void OnGUI()
    {
        //if we are playing survivor show the statistics
        if (menuScript.survivorMode)
        {
            if (!scoreScript.disableHud)
            {
                if (menuScript.highScore > 0)
                {
                    GUI.Label(new Rect(0, 2, 200, 150), "  Higher: " + menuScript.highScore, blackFont.label);
                    GUI.Label(new Rect(0, 0, 200, 150), "  Higher: " + menuScript.highScore, blueFont.label);
                }
                GUI.Label(new Rect(Screen.width / 2 - 100, 2, 200, 150), "   Score: " + scores, blackFont.label);
                GUI.Label(new Rect(Screen.width / 2 - 100, 0, 200, 150), "   Score: " + scores, blueFont.label);
                GUI.Label(new Rect(Screen.width - 90, 2, 200, 100), scoreScript.survivorEnd + "-20", blackFont.label);
                GUI.Label(new Rect(Screen.width - 90, 0, 200, 100), scoreScript.survivorEnd + "-20", blueFont.label);
            }
            //This is the score showed in the score screen
            if (scoreScript.once)
            {
				GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 78, 200, 150), "" + scores, blackFont.label);
				GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 80, 200, 150), "" + scores, blueFont.label);
				/*if (Screen.currentResolution.width == 854 || Screen.currentResolution.width == 800)
                {
                    GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height / 2 - 50, 200, 150), "" + scores, blueFont.label);
                }
                else
                {
                    if (Screen.currentResolution.width == 1024)
                    {
                        GUI.Label(new Rect(Screen.width / 2 - 10, 170, 200, 150), "" + scores, blueFont.label);
                    }
                }*/
            }
        }
        //

        //or if we are playing level mode
        if (menuScript.gameStarted)
        {
            if (!scoreScript.disableHud)
            {
                if (menuScript.highScore > 0)
                {
                    GUI.Label(new Rect(0, 28, 200, 150), "  Higher: " + menuScript.highScore, blackFont.label);
                    GUI.Label(new Rect(0, 26, 200, 150), "  Higher: " + menuScript.highScore, blueFont.label);
                }
                GUI.Label(new Rect(0, 2, 200, 150), "   Score: " + scores, blackFont.label);
                GUI.Label(new Rect(0, 0, 200, 150), "   Score: " + scores, blueFont.label);
                GUI.Label(new Rect(Screen.width - 140, 2, 200, 100), "" + objectiveScore, blackFont.label);
                GUI.Label(new Rect(Screen.width - 140, 0, 200, 100), "" + objectiveScore, blueFont.label);
                GUI.Label(new Rect(Screen.width - 140, 38, 200, 100), "Lvl:" + menuScript.level, blackFont.label);
                GUI.Label(new Rect(Screen.width - 140, 36, 200, 100), "Lvl:" + menuScript.level, blueFont.label);
                GUI.Label(new Rect(Screen.width / 2, 18, 200, 100), "" + bManager.countingBalloons, blackFont.label);
                GUI.Label(new Rect(Screen.width / 2, 16, 200, 100), "" + bManager.countingBalloons, blueFont.label);
                GUI.DrawTexture(barRect, barIdle);
                GUI.BeginGroup(new Rect(barRect.x, barRect.y, ((initialWidth * scores) / objectiveScore), barRect.height));
                GUI.DrawTexture(new Rect(0, 0, barRect.width, 15), barFull);
                GUI.EndGroup();
            }
            if (scoreScript.once)
            {
				GUI.Label(new Rect(Screen.width / 2 - 30, 72, 200, 150), "" + scores, blackFont.label);
                GUI.Label(new Rect(Screen.width / 2 - 30, 70, 200, 150), "" + scores, blueFont.label);

                /*if (Screen.currentResolution.width == 854 || Screen.currentResolution.width == 800)
                {
                    GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height / 2 - 170, 200, 150), "" + scores, blueFont.label);
                }
                else
                {
                    if (Screen.currentResolution.width == 1024)
                    {
                        GUI.Label(new Rect(Screen.width / 2 - 10,100, 200, 150), "" + scores, blueFont.label);
                    }
                }*/
            }
            
        }
    }
}
