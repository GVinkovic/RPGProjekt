using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {

    public Transform camTarget;
    public float camHeight = 10f;
    public float camDistance = 20f;
    public float camAngle = 45f;

    public float zoomSpeed = 4f;
    public float minZoom = -5f;
    public float maxZoom = 15f;

    public float yawSpeed = 100f;

    private float currentZoom = 1f;
    

    // Use this for initialization
    void Start () {

        HandleCamera();

	}

    void Update()
    {
        HandleCamera();
       
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        
    }

    void HandleCamera()
    {
        //making sure there is a target
        if (!camTarget)
        {
            return;
        }

       

        //Build world position vector
        Vector3 worldPosition = (Vector3.forward * camDistance) + (Vector3.up * camHeight);
        Debug.DrawLine(camTarget.position, worldPosition, Color.red);

        //Building rotated vector
        Vector3 rotatedVector = Quaternion.AngleAxis(camAngle, Vector3.up) * worldPosition;
        Debug.DrawLine(camTarget.position, rotatedVector, Color.blue);

        //Move our position
        Vector3 flatTargetPosition = camTarget.position;
        flatTargetPosition.y = 0f;

        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        Debug.DrawLine(camTarget.position, finalPosition, Color.green);

        transform.position = finalPosition * currentZoom;
        transform.LookAt(camTarget);
    }
}
