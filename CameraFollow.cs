using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private float smoothing = 3;
    private  Transform player;
    private Camera mainCamera;
    private Vector3 angles;
    private  float x = 0.0f, y = 0.0f;
    private  float xSpeed = 4, ySpeed = 4, mSpeed = 50;
    private  float yMinLimit = 30, yMaxLimit = 70;
    private  float field = 25, minField = 25, maxField = 90;
    // Use this for initialization
    void Start () {
        mainCamera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        field = mainCamera.fieldOfView;
        angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed;
            y -= Input.GetAxis("Mouse Y") * ySpeed;

            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            
        }
        field -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
        field = Mathf.Clamp(field, minField, maxField);
        mainCamera.fieldOfView = field;

        Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
        transform.rotation = rotation;
        Vector3 disVector = new Vector3(0.0f, 0.0f, -6f);
        Vector3 position = rotation * disVector + player.position;

        transform.position = position;

    }
}
