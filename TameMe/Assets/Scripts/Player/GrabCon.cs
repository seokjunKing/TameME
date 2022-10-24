using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCon : MonoBehaviour
{
    public Transform grabPoint;

    public Transform rayPoint;
    public float rayDistance;

    private GameObject grabObject;

    public bool isGrabbed = false;
    
    void Update()
    {
        int layerMask = 1 << LayerMask.NameToLayer("gg");
        RaycastHit2D hit = Physics2D.Raycast(rayPoint.position, Vector2.right * transform.localScale.x, rayDistance, layerMask);
        Debug.DrawRay(rayPoint.position, Vector2.right * transform.localScale.x * rayDistance);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Grab"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isGrabbed && grabObject == null)
                {
                    isGrabbed = true;
                    grabObject = hit.collider.gameObject;
                    grabObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    grabObject.transform.position = grabPoint.position;
                    grabObject.transform.SetParent(transform);
                }
                else
                {
                    isGrabbed = false;
                    grabObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabObject.transform.SetParent(null);
                    grabObject = null;
                }

            }

        }
    }
}
