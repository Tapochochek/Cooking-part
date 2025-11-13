using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WashHandScript : MonoBehaviour
{
    private VisualEffect effectSoap;
    [SerializeField] private GameObject colpackOnTable;
    [SerializeField] private GameObject colpackOnHead;
    private bool isWashing = false;
    private bool isSoap = false;
    private bool washComplete = false;
    private float minusSize = 0.001f;
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
                isWashing = true;
            }
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (isSoap) {
            if(other.tag == "water")
            {
                isWashing = false;
            }
        }

    }   
    public void ClickSoap()
    {
        isSoap=true;
        effectSoap.gameObject.SetActive(true);
    }
    public void ClickColpack()
    {
        colpackOnHead.SetActive(true);
        colpackOnTable.SetActive(false);
    }
    private void Update()
    {
        if (!washComplete && isWashing)
        {
            if (countSeconds<20)
            {
                timer += Time.deltaTime;               
                if (timer >= 1f)
                {
                    timer = 0f;                   
                    countSeconds++;
                    effectSoap.SetFloat("water", effectSoap.GetFloat("water") - minusSize);
                    effectSoap.Reinit();
                }               
            }
            else
            {
                effectSoap.gameObject.SetActive(false);
                washComplete = true;
            }
        }
    }
}
