using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
    public GameObject cameraChild;
    private Vector3 yaw;
    private Vector3 pitch;
    private Vector3 roll;
    public float sensitivity;

    private void Start() {
        sensitivity = 3;
    }

    private void Update() {
        yaw = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * sensitivity;
        pitch = new Vector3(0, Input.GetAxis("Mouse X"), 0) * sensitivity;
        if (Input.GetKey(KeyCode.Q)) { roll = new Vector3(0,0,1); }
        else if (Input.GetKey(KeyCode.E)) { roll = new Vector3(0,0,-1); }
        else { roll = Vector3.zero; }
    }
    private void FixedUpdate() {
        this.gameObject.transform.rotation *= Quaternion.Euler(yaw);
        cameraChild.transform.rotation *= Quaternion.Euler(pitch);
        cameraChild.transform.rotation *= Quaternion.Euler(roll);
        //this.gameObject.transform.rotation *= Quaternion.Euler(yaw + pitch);
    }
}
