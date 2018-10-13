using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_controller : MonoBehaviour {

    Camera mainCam;

	// Use this for initialization
	void Start () {
        mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)){
            RaycastHit camHit;
            Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out camHit, Mathf.Infinity))
            {
                Transform objectHit = camHit.transform;
                health_controller objectHealth = objectHit.GetComponent<health_controller>();
                if (objectHealth != null){
                    objectHealth.Damage(35);
                }
            }
        }

    }
}
