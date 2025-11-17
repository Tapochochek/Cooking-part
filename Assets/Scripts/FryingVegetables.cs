using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingVegetables : MonoBehaviour
{
    private bool isFrying = false;
    private Material mat;
    private Color originalColor;
    private Color targetColor;
    private float lightenAmount = 0.0003f;
    private float smoothSpeed = 5f;    
    private bool fryingComplete = false;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
        targetColor = originalColor;
        StartCoroutine(TimerCuking());
        
    }
    private void OnCollisionStay(Collision collision)
    {     
        if (!fryingComplete)
        {
            if (collision.gameObject.tag == "pan")
            {
                isFrying = true;
            }
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "pan")
        {
            isFrying=false;
        }
    }
    void Update()
    {
        if (isFrying)
        {
            targetColor = targetColor * (1f + lightenAmount);
        }

        mat.color = Color.Lerp(mat.color, targetColor, Time.deltaTime * smoothSpeed);
    }
    private IEnumerator TimerCuking()
    {
        int i = 0;
        while (i<40)
        {
            Debug.Log(i);
            i++;
            yield return new WaitForSeconds(1);           
        }
        fryingComplete = true;
        isFrying = false;
    }
}
