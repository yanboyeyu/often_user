using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowTarget : MonoBehaviour {

    public GameObject targetgo;
    public float height;
    private Transform camera;
    private Vector3 offset =Vector3.up;
	// Use this for initialization
	void Start (){
        camera = TranscriptManager._instance.mainCamera;
        if (targetgo != null){
            transform.position = targetgo.transform.position + offset* height;
        }
    }
	
	// Update is called once per frame
	void LateUpdate()
    {
        if (targetgo != null){
            transform.position = targetgo.transform.position + offset * height;
            transform.LookAt(camera);
        }else{
            Destroy(gameObject);
        }
    }
    
}
