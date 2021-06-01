using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Converter : MonoBehaviour {

    public Collider[] arrayList;
    Balloon ballon;
    public List<Texture2D> ballonTxt;
    LayerMask headMask = 1 << 9;
    public BallonManager balloonManager;
    int selectColor;

	// Use this for initialization
	void Start ()
    {
        //We select wich color are we going to change the normal balloons
        balloonManager = GameObject.FindWithTag("manager").GetComponent<BallonManager>();
        selectColor = Random.Range(0, 4);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //we use OverlapSphere to manage a radius and wich elements are we going to catch
        arrayList = Physics.OverlapSphere(this.transform.position, 3, headMask);
        //For every balloon near the Refresher, we change the color
        for (int i = 0; i < arrayList.Length; i++)
        {
            ballon = arrayList[i].GetComponent<Balloon>();
            if (ballon.Idballoon == "red" || ballon.Idballoon == "yellow" || ballon.Idballoon == "blue" || ballon.Idballoon == "green")
            {
                if (selectColor == 0)
                {
                    if (ballon != null)
                    {
                        ballon.renderer.material.mainTexture = ballonTxt[0];
                        if (ballon.Idballoon == "yellow")
                        {
                            if (balloonManager.yellowBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.yellowBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "blue")
                        {
                            if (balloonManager.blueBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.blueBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "green")
                        {
                            if (balloonManager.greenBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.greenBalloons.Remove(arrayList[i].gameObject);
                            }
                        }

                        ballon.Idballoon = "red";
                        if (!balloonManager.redBalloons.Contains(arrayList[i].gameObject))
                        {
                            balloonManager.redBalloons.Add(arrayList[i].gameObject);
                        }
                    }
                }
                if (selectColor == 1)
                {
                    if (ballon != null)
                    {

                        ballon.renderer.material.mainTexture = ballonTxt[1];

                        if (ballon.Idballoon == "yellow")
                        {
                            if (balloonManager.yellowBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.yellowBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "red")
                        {
                            if (balloonManager.redBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.redBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "green")
                        {
                            if (balloonManager.greenBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.greenBalloons.Remove(arrayList[i].gameObject);
                            }
                        }

                        ballon.Idballoon = "blue";

                        if (!balloonManager.blueBalloons.Contains(arrayList[i].gameObject))
                        {
                            balloonManager.blueBalloons.Add(arrayList[i].gameObject);
                        }

                    }
                }
                if (selectColor == 2)
                {
                    if (ballon != null)
                    {
                        ballon.renderer.material.mainTexture = ballonTxt[2];

                        if (ballon.Idballoon == "yellow")
                        {
                            if (balloonManager.yellowBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.yellowBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "red")
                        {
                            if (balloonManager.redBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.redBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "blue")
                        {
                            if (balloonManager.blueBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.blueBalloons.Remove(arrayList[i].gameObject);
                            }
                        }

                        ballon.Idballoon = "green";
                        if (!balloonManager.greenBalloons.Contains(arrayList[i].gameObject))
                        {
                            balloonManager.greenBalloons.Add(arrayList[i].gameObject);
                        }
                    }
                }
                if (selectColor == 3)
                {
                    if (ballon != null)
                    {
                        ballon.renderer.material.mainTexture = ballonTxt[3];

                        if (ballon.Idballoon == "green")
                        {
                            if (balloonManager.greenBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.greenBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "red")
                        {
                            if (balloonManager.redBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.redBalloons.Remove(arrayList[i].gameObject);
                            }
                        }
                        if (ballon.Idballoon == "blue")
                        {
                            if (balloonManager.blueBalloons.Contains(arrayList[i].gameObject))
                            {
                                balloonManager.blueBalloons.Remove(arrayList[i].gameObject);
                            }
                        }

                        ballon.Idballoon = "yellow";
                        if (!balloonManager.yellowBalloons.Contains(arrayList[i].gameObject))
                        {
                            balloonManager.yellowBalloons.Add(arrayList[i].gameObject);
                        }
                    }
                }
            }
        }
        //
	}
}
