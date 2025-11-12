using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WashHandScript : MonoBehaviour
{
    private VisualEffect effectSoap;
    private bool isWashing = false;
    private bool isSoap = false;
    private bool washComplete = false;
    private float minusSize = 0.1f;
    int countSeconds = 0;

    private float timer = 0f;
    private void Start()
    {
        effectSoap = GetComponentInChildren<VisualEffect>();
        effectSoap.gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (isSoap) {
            if (other.tag == "water")
            {
                Debug.Log("dsdsds");
                isWashing = true;
            }
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (isSoap) {
            if(other.tag == "water")
            {
                Debug.Log("dsdsds");
                isWashing = false;
            }
        }

    }   
    public void ClickSoap()
    {
        isSoap=true;
        effectSoap.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (!washComplete && isWashing)
        {
            Debug.Log("start washing");
            if (countSeconds<60)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
                if (timer >= 1f)
                {
                    timer = 0f;
                    Debug.Log("Уменьшение");
                    countSeconds++;
                    effectSoap.SetFloat("waterAmount", minusSize);
                }               
            }
            else
            {
                Debug.Log("Все");
                washComplete = true;
            }
        }
    }
}
