using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeverLimitEvents : MonoBehaviour
{
    [SerializeField] GameObject door;
    private HingeJoint hingle;
    private bool atMin = false;
    private bool atMax = false;

    public float openHeight = 5f;      
    public float speed = 2f;           

    private Vector3 targetPosition;
    private bool isOpening = false;

    private void Start()
    {
        hingle = GetComponent<HingeJoint>();
        targetPosition = transform.position;
    }
    private void Update()
    {
        float angle = hingle.angle;
        float min = hingle.limits.min;
        float max = hingle.limits.max;
        if(angle<=min && !atMin)
        {
            atMin = true;
            atMax = false;
            Debug.Log("Минималка");
            CloseDoor();
        }
        else if(angle>=max && !atMax)
        {
            atMax = true;
            atMin = false;
            Debug.Log("Максималка");
            OpenDoor();
        }
        if (isOpening)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    public void OpenDoor()
    {
        targetPosition = door.transform.position + Vector3.up * openHeight;
        isOpening = true;
    }
    public void CloseDoor()
    {
        targetPosition = -(door.transform.position + Vector3.up * openHeight);
        isOpening = false;
    }
}
