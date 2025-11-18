using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimShef : MonoBehaviour
{
    
    private void Start()
    {
        StartCoroutine(ShefAnimInstantly());
    }
    private IEnumerator ShefAnimInstantly()
    {
        while (true) {
            float scale = -gameObject.transform.localScale.x;            gameObject.transform.localScale = new Vector3(scale, 1, 1);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 8 * scale);
            yield return new WaitForSeconds(0.45f);
        }
        
    }
}
