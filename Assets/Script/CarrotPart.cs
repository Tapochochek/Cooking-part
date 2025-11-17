using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPart : MonoBehaviour
{
    bool isInCup = false;
    bool isComplete = false;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "board")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
