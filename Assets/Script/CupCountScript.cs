using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CupCountScript : MonoBehaviour
{
    public static int countCarrot = 0;
    public TextMeshProUGUI textCount;

    void Update()
    {
        Debug.Log(countCarrot);
        if (countCarrot >= 4) {
            Debug.Log("Все чикибамбони");
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "carrotPart")
        {
            countCarrot++;
            textCount.text = countCarrot.ToString() + "/4";
            Debug.Log("ffff");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "carrotPart")
        {
            countCarrot--;
            textCount.text = countCarrot.ToString() + "/4";
            Debug.Log("ffff");
        }
    }
}
