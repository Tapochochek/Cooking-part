using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LeverLimitEvents : MonoBehaviour
{
    [SerializeField] GameObject water;
    private HingeJoint hingle;
    private bool atMin = false;
    private bool atMax = false;
    private void Start()
    {
        hingle = GetComponent<HingeJoint>();
    }
    private void Update()
    {
        float angle = hingle.angle;
        float min = hingle.limits.min;
        float max = hingle.limits.max;
        if (angle <= min && !atMin)
        {
            atMin = true;
            atMax = false;
            OffWater();
        }
        else if (angle >= max && !atMax)
        {
            atMax = true;
            atMin = false;
            OnWater();
        }
    }
    public void OnWater()
    {
        water.SetActive(true);
    }
    public void OffWater ()
    {
        water.SetActive(false);
    }
}