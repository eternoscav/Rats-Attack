using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

    public float timerBomb;
    int timerBombInt;
    string timerBombStr;
    public TextMesh thisMesh;
    public Collider[] arrayList;
    public GameObject provisorio;
    LayerMask headMask = 1<<9;
    MenuManipulator menuScript;
    int cuantity;

	void Start()
    {
        thisMesh = this.gameObject.GetComponent<TextMesh>();
        menuScript = Camera.main.GetComponent<MenuManipulator>();
	}
	
	void Update () 
    {
        //OverlapSphere is used to determinate wich balloon is near the bomber
        arrayList = Physics.OverlapSphere(this.transform.position, 3, headMask);

        timerBombInt = Mathf.FloorToInt(timerBomb);
        timerBombStr = timerBombInt.ToString();
        thisMesh.text = timerBombStr;
        cuantity = arrayList.Length-1;

        if (timerBomb > 1)
        {
            timerBomb -= Time.deltaTime;
        }
        else
        {
            //it explode
            //Camera.mainCamera.animation.CrossFade("@CameraShakeLight");
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
            thisMesh.renderer.enabled = false;

            for (int i = cuantity; 0 <= i; i--)
            {
                if (arrayList != null)
                {
                    Destroy(arrayList[i].gameObject);
                    menuScript.scoreScript.SurvivorDestroyed();
                }
            }
        } 
	}
}
