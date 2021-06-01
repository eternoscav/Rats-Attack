using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour
{
    // A script where we set teh gray clous and the movements

    public int cloudId;
    public float speed;
    //this bool i checked it in the inspector
    public bool thisIsGrayToo;
    public MenuManipulator menuScript;
    public Texture2D niceTxt;
    public Texture2D stormTxt;
    public GameObject thunder;
    bool startThunder;
    bool once;
    float timeThunder;
    float showThunder;
    int randomThunder;
    public GameObject thundereffect;
    SoundManager soundScript;

    // Use this for initialization
    void Start()
    {
        thundereffect = GameObject.FindWithTag("ThunderEffect");
        soundScript = Camera.main.GetComponent<SoundManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (thisIsGrayToo)
        {
            menuScript = Camera.main.gameObject.GetComponent<MenuManipulator>();
            if (startThunder)
            {
                if (!once)
                {
                    randomThunder = Random.Range(0, 3);
                    if (randomThunder == 0)
                    {
                        soundScript.PlaySound(32, false, 0.5f);
                    }
                    once = true;
                }
                if (randomThunder == 0)
                {
                    if (showThunder < 0.1f)
                    {
                        
                        thundereffect.renderer.enabled = true;
                        thunder.collider.enabled = true;
                        thunder.renderer.enabled = true;
                        showThunder += Time.deltaTime;
                    }
                    else
                    {
                        randomThunder = 1;
                        once = false;
                    }
                }
                else
                {
                    once = false;
                    thundereffect.renderer.enabled = false;
                    thunder.renderer.enabled = false;
                    thunder.collider.enabled = false;
                    showThunder = 0;
                    timeThunder = 0;
                    startThunder = false;
                }
            }
            if (menuScript.inStorm)
            {
                if (timeThunder < 5)
                {
                    timeThunder += Time.deltaTime;
                }
                else
                {
                    startThunder = true;
                }
                this.renderer.material.mainTexture = stormTxt;
            }
            else
            {
                thundereffect.renderer.enabled = false;
                thunder.renderer.enabled = false;
                thunder.collider.enabled = false;
                this.renderer.material.mainTexture = niceTxt;
            }
        }

        if (cloudId == 0)
        {
            this.transform.position += transform.right * speed * Time.deltaTime;
        }
        if (cloudId == 1)
        {
            this.transform.position += transform.right * -speed * Time.deltaTime;
        }
        if (cloudId == 2)
        {
            this.transform.position += transform.right * -speed * Time.deltaTime;
        }
    }
}
