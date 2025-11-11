using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    static List<GameObject> targets = new List<GameObject>();

    static int randomIndexes;
    static bool randoming = false;

    private GameObject target;

    private void Start()
    {
        if (gameObject.tag == "BlueTarget")
        {
            target = gameObject;
            randomIndexes = Random.Range(0, targets.Count);
        }
        targets.Add(gameObject);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        randoming = false;
        Destroy(collision.gameObject);
        if(gameObject.tag == "BlueTarget")
        {
            Debug.Log("Nice");
            for(int i = 0; i < targets.Count; i++)
            {
                if(i == randomIndexes)
                {
                    Vector3 transformTar = targets[i].transform.position;
                    targets[i].transform.position = target.transform.position;
                    target.transform.position = transformTar;
                    
                }
            }
            if(gameObject == target)
            {
                randomIndexes = Random.Range(0, targets.Count);
            }           
        }
        else
        {
            Debug.Log("Bue");
        }
    }
}
