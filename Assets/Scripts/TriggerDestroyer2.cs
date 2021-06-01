using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerDestroyer2 : MonoBehaviour {





    //we detect collision with balloons. every balloon that touch this trigger is destroyed
    void OnTriggerEnter(Collider c)
    {

            
            Destroy(c.collider.gameObject);
        }
        
}
