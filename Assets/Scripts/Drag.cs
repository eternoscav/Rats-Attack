using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour
{
    MenuManipulator menuScript;
    ScoreManipulator scoreScipt;
    FaceManager faceManager;
    Balloon ballonScript;
    RaycastHit hit;

    public GameObject item;
    GameObject score;
    GameObject objectGo;

    Vector3 posMouse;

    bool onDrag;
    
    int randomFace;
    

    void Start()
    {
        menuScript = Camera.main.GetComponent<MenuManipulator>();
        ballonScript = gameObject.transform.root.GetComponent<Balloon>();
    }
    void Update()
    {
        //if pause is on, we cannot drag them
        if (!menuScript.pause)
        {
            //we use raycast to catch the drag collider
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.layer == 8)
                    {
                        objectGo = hit.collider.gameObject;
                        onDrag = true;
                    }
                }
            }
            //If we clicked or touched now the balloon position belongs to our cursor o finger position
            if (onDrag)
            {
                posMouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 30));
                if (objectGo != null)
                {
                    ballonScript = objectGo.transform.root.gameObject.GetComponent<Balloon>();
                    if (ballonScript.Idballoon == "red" || ballonScript.Idballoon == "green" || ballonScript.Idballoon == "blue" || ballonScript.Idballoon == "yellow")
                    {
                        faceManager = objectGo.transform.root.GetComponentInChildren<FaceManager>();
                    }
                    if (faceManager != null)
                    {
                        faceManager.gameObject.renderer.material.mainTexture = faceManager.facesList[1];
                    }
                    objectGo.transform.position = posMouse;
                }
                else
                {
                    onDrag = false;
                }
            }
            //
            //If we stop dragging now the balloon has his own position
            if (Input.GetMouseButtonUp(0))
            {
                onDrag = false;
                if (objectGo != null)
                {
                    ballonScript = objectGo.transform.root.gameObject.GetComponent<Balloon>();
                    ballonScript.aceleration = -1;
                    if (ballonScript.Idballoon == "red" || ballonScript.Idballoon == "green" || ballonScript.Idballoon == "blue" || ballonScript.Idballoon == "yellow")
                    {
                        //randomFace = Random.Range(2, 2);
                        faceManager.gameObject.renderer.material.mainTexture = faceManager.facesList[0];
                    }
                    objectGo = null;
                }
            }
            //
        }
    }
}
