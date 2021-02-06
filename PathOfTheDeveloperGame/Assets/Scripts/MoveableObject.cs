using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    private bool canRotate = false;
    private const float rotationFactor = 2.0f;

    private Vector3 mOffset;

    private float mZCoord;

    private void OnMouseDown()
    {
        if (enabled)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();

            canRotate = true;
        }
        
    }

    private void OnMouseUp()
    {
        if (enabled)
        {
            canRotate = false;
        }
        
    }

    private Vector3 GetMouseWorldPos()
    {
        //X and Y Coordinates
        Vector3 mousePoint = Input.mousePosition;

        //Get Z coordinate of game object.
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (enabled)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
        
    }

    private void Update()
    {
        if (canRotate)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                transform.Rotate(Vector3.back * rotationFactor, Space.Self);
            }
            else if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                transform.Rotate(Vector3.forward * rotationFactor, Space.Self);
            }
        }
    }
}
