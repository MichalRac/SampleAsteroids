using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    private const float BUFFOR_VALUE_AFTER_MOVING = 1.0f; 
    private BoxCollider boxCollider;
    protected float verExtent;
    protected float horExtent;


    private void Awake()
    {
        verExtent = (Camera.main.orthographicSize * 2);
        horExtent = (verExtent * Screen.width / Screen.height);

        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(horExtent, 50.0f, verExtent);
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        Vector3 targetPosition = other.transform.position;

        if (other.transform.position.x >= horExtent / 2 || other.transform.position.x <= -horExtent / 2)
        {
            targetPosition.x = -other.transform.position.x;

            if (targetPosition.x > 0)
                targetPosition.x -= BUFFOR_VALUE_AFTER_MOVING;
            else if (targetPosition.x < 0)
                targetPosition.x += BUFFOR_VALUE_AFTER_MOVING;
        }

        if (other.transform.position.z >= verExtent / 2 || other.transform.position.z <= -verExtent / 2)
        {
            targetPosition.z = -other.transform.position.z;

            if (targetPosition.z > 0)
                targetPosition.z -= BUFFOR_VALUE_AFTER_MOVING;
            else if (targetPosition.z < 0)
                targetPosition.z += BUFFOR_VALUE_AFTER_MOVING;
        }

        other.transform.position = targetPosition;


    }
}
