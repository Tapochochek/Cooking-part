using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public GameObject carrotBox;
    public GameObject board;

    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
        if (carrotBox.transform.childCount >= 4)
        {
            for(int i = 0; i < carrotBox.transform.childCount; i++)
            {
                carrotBox.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            }
            carrotBox.transform.SetParent(board.transform);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, target.GetComponent<Renderer>().material);
            
            upperHull.layer = 3;
            SetupSlicedComponent(upperHull);

            GameObject loverHull = hull.CreateLowerHull(target, target.GetComponent<Renderer>().material);
            loverHull.layer = 3;
            SetupSlicedComponent(loverHull);
        }

        Destroy(target);
    }

    public void SetupSlicedComponent(GameObject slicedObject)
    {
        slicedObject.transform.SetParent(carrotBox.transform);
        slicedObject.AddComponent<CarrotPart>();
        slicedObject.AddComponent<FryingVegetables>();
        slicedObject.tag = "carrotPart";
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        rb.mass = 0.01f;
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;

        StartCoroutine(EnablePhysicsNextFrame(rb));
        //StartCoroutine(RemoveRigidbodyAfterTime(rb, 0.2f));
    }
    private IEnumerator EnablePhysicsNextFrame(Rigidbody rb)
    {
        yield return null; // Ждём один кадр

        rb.isKinematic = false; // Теперь физика включается, отскока не будет
    }

    //private IEnumerator RemoveRigidbodyAfterTime(Rigidbody rb, float delay)
    //{
    //    yield return new WaitForSeconds(delay);

    //    if (rb != null)
    //    {
    //        Destroy(rb); // удаляем Rigidbody — объект снова "заморожен"
    //    }
    //}
}
