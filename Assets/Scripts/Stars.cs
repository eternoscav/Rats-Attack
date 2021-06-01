using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class Stars : MonoBehaviour 
{
    public List<Texture2D> starsTxt;
    public GameObject score;
    ScoreManipulator scoreScript;
    public int idStar;
    public List<int> savedStar;
    int levelStar;

	// Use this for initialization
	void Start () 
    {
        LoadStarsData();
        this.renderer.enabled = false;
        //We load the every stars
        for (int i = 0; i < savedStar.Count; i++)
        {
            if (idStar == i)
            {
                SetStar(savedStar[i]);
            }
        }      
	}
	
    public void SetStar(int cuantity)
    {
        //Depending on the cuantity of the stars (given in ScoreManipulator) we render 1,2, 3 or none stars 
        if (cuantity == 0)
        {
            renderer.enabled = false;
        }
        if (cuantity == 1)
        {
            renderer.enabled = true;
            this.renderer.material.mainTexture = starsTxt[0];
        }
        if (cuantity == 2)
        {
            renderer.enabled = true;
            this.renderer.material.mainTexture = starsTxt[1];
        }
        if (cuantity == 3)
        {
            renderer.enabled = true;
            this.renderer.material.mainTexture = starsTxt[2];
        }

        //We need to save our stars information in a unique variable//and also we have to ask for teh current star that we want to show
        if (idStar == 0)
        {
            savedStar[0] = cuantity;
            PlayerPrefs.SetInt("savedStars0", savedStar[0]);
        }
        if (idStar == 1)
        {
            savedStar[1] = cuantity;
            PlayerPrefs.SetInt("savedStars1", savedStar[1]);
        }
        if (idStar == 2)
        {
            savedStar[2] = cuantity;
            PlayerPrefs.SetInt("savedStars2", savedStar[2]);
        }
        if (idStar == 3)
        {
            savedStar[3] = cuantity;
            PlayerPrefs.SetInt("savedStars3", savedStar[3]);
        }
        if (idStar == 4)
        {
            savedStar[4] = cuantity;
            PlayerPrefs.SetInt("savedStars4", savedStar[4]);
        }
        if (idStar == 5)
        {
            savedStar[5] = cuantity;
            PlayerPrefs.SetInt("savedStars5", savedStar[5]);
        }
        if (idStar == 6)
        {
            savedStar[6] = cuantity;
            PlayerPrefs.SetInt("savedStars6", savedStar[6]);
        }
        if (idStar == 7)
        {
            savedStar[7] = cuantity;
            PlayerPrefs.SetInt("savedStars7", savedStar[7]);
        }
        if (idStar == 8)
        {
            savedStar[8] = cuantity;
            PlayerPrefs.SetInt("savedStars8", savedStar[8]);
        }
        if (idStar == 9)
        {
            savedStar[9] = cuantity;
            PlayerPrefs.SetInt("savedStars9", savedStar[9]);
        }
        if (idStar == 10)
        {
            savedStar[10] = cuantity;
            PlayerPrefs.SetInt("savedStars10", savedStar[10]);
        }
        if (idStar == 11)
        {
            savedStar[11] = cuantity;
            PlayerPrefs.SetInt("savedStars11", savedStar[11]);
        }
        if (idStar == 12)
        {
            savedStar[12] = cuantity;
            PlayerPrefs.SetInt("savedStars12", savedStar[12]);
        }
        if (idStar == 13)
        {
            savedStar[13] = cuantity;
            PlayerPrefs.SetInt("savedStars13", savedStar[13]);
        }
        if (idStar == 14)
        {
            savedStar[14] = cuantity;
            PlayerPrefs.SetInt("savedStars14", savedStar[14]);
        }
        if (idStar == 15)
        {
            savedStar[15] = cuantity;
            PlayerPrefs.SetInt("savedStars15", savedStar[15]);
        }
        if (idStar == 16)
        {
            savedStar[16] = cuantity;
            PlayerPrefs.SetInt("savedStars16", savedStar[16]);
        }
        if (idStar == 17)
        {
            savedStar[17] = cuantity;
            PlayerPrefs.SetInt("savedStars17", savedStar[17]);
        }
        if (idStar == 18)
        {
            savedStar[18] = cuantity;
            PlayerPrefs.SetInt("savedStars18", savedStar[18]);
        }
        if (idStar == 19)
        {
            savedStar[19] = cuantity;
            PlayerPrefs.SetInt("savedStars19", savedStar[19]);
        }
        if (idStar == 20)
        {
            savedStar[20] = cuantity;
            PlayerPrefs.SetInt("savedStars20", savedStar[20]);
        }
        if (idStar == 21)
        {
            savedStar[21] = cuantity;
            PlayerPrefs.SetInt("savedStars21", savedStar[21]);
        }
        if (idStar == 22)
        {
            savedStar[22] = cuantity;
            PlayerPrefs.SetInt("savedStars22", savedStar[22]);
        }
        if (idStar == 23)
        {
            savedStar[23] = cuantity;
            PlayerPrefs.SetInt("savedStars23", savedStar[23]);
        }
        if (idStar == 24)
        {
            savedStar[24] = cuantity;
            PlayerPrefs.SetInt("savedStars24", savedStar[24]);
        }
        if (idStar == 25)
        {
            savedStar[25] = cuantity;
            PlayerPrefs.SetInt("savedStars25", savedStar[25]);
        }
        if (idStar == 26)
        {
            savedStar[26] = cuantity;
            PlayerPrefs.SetInt("savedStars26", savedStar[26]);
        }
        if (idStar == 27)
        {
            savedStar[27] = cuantity;
            PlayerPrefs.SetInt("savedStars27", savedStar[27]);
        }
        if (idStar == 28)
        {
            savedStar[28] = cuantity;
            PlayerPrefs.SetInt("savedStars28", savedStar[28]);
        }
        if (idStar == 29)
        {
            savedStar[29] = cuantity;
            PlayerPrefs.SetInt("savedStars29", savedStar[29]);
        }
        if (idStar == 30)
        {
            savedStar[30] = cuantity;
            PlayerPrefs.SetInt("savedStars30", savedStar[30]);
        }
        if (idStar == 31)
        {
            savedStar[31] = cuantity;
            PlayerPrefs.SetInt("savedStars31", savedStar[31]);
        }
        if (idStar == 32)
        {
            savedStar[32] = cuantity;
            PlayerPrefs.SetInt("savedStars32", savedStar[32]);
        }
        if (idStar == 33)
        {
            savedStar[33] = cuantity;
            PlayerPrefs.SetInt("savedStars33", savedStar[33]);
        }
        if (idStar == 34)
        {
            savedStar[34] = cuantity;
            PlayerPrefs.SetInt("savedStars34", savedStar[34]);
        }
        if (idStar == 35)
        {
            savedStar[35] = cuantity;
            PlayerPrefs.SetInt("savedStars35", savedStar[35]);
        }
        if (idStar == 36)
        {
            savedStar[36] = cuantity;
            PlayerPrefs.SetInt("savedStars36", savedStar[36]);
        }
        if (idStar == 37)
        {
            savedStar[37] = cuantity;
            PlayerPrefs.SetInt("savedStars37", savedStar[37]);
        }
        if (idStar == 38)
        {
            savedStar[38] = cuantity;
            PlayerPrefs.SetInt("savedStars38", savedStar[38]);
        }
        if (idStar == 39)
        {
            savedStar[39] = cuantity;
            PlayerPrefs.SetInt("savedStars39", savedStar[39]);
        }
        if (idStar == 40)
        {
            savedStar[40] = cuantity;
            PlayerPrefs.SetInt("savedStars40", savedStar[40]);
        }
        if (idStar == 41)
        {
            savedStar[41] = cuantity;
            PlayerPrefs.SetInt("savedStars41", savedStar[41]);
        }
        if (idStar == 42)
        {
            savedStar[42] = cuantity;
            PlayerPrefs.SetInt("savedStars42", savedStar[42]);
        }
        if (idStar == 43)
        {
            savedStar[43] = cuantity;
            PlayerPrefs.SetInt("savedStars43", savedStar[43]);
        }
        if (idStar == 44)
        {
            savedStar[44] = cuantity;
            PlayerPrefs.SetInt("savedStars44", savedStar[44]);
        }
        //
        SaveStarsData();
    }
    void SaveStarsData()
    {
       PlayerPrefs.Flush();
    }
    void LoadStarsData()
    {
        for (int i = 0; i < savedStar.Count; i++)
        {
            savedStar[i] = PlayerPrefs.GetInt("savedStars"+i);
        }
    }
    
}
