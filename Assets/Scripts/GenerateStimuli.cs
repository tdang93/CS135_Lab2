using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour {
    public GameObject player;
    public GameObject redSphere;
    public GameObject blueSphere1;
    public GameObject blueSphere2;
    private float ratio;
    public float redDist;
    public float blueDist1;
    public float blueDist2;
    private float ratio1;
    private float ratio2;
    private bool s;
    private Vector3 originalLocalScale;

    private void Start() {
        //blueSphere1.transform.localScale *= ratio / Vector3.Distance(blueSphere1.transform.position, this.transform.position);
        //blueSphere2.transform.localScale *= ratio / Vector3.Distance(blueSphere2.transform.position, this.transform.position);

        originalLocalScale = blueSphere1.transform.localScale;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) { s = !s; }
    }

    public void FixedUpdate() {
        //Debug.Log("update");
        /*    

        float magnitude2 = ratio * Vector3.Distance(blueSphere2.transform.position, this.transform.position);
        blueSphere2.transform.localScale = new Vector3(magnitude2, magnitude2, magnitude2);
        */
        
        redDist = Vector3.Distance(redSphere.transform.position, player.transform.position);
        blueDist1 = Vector3.Distance(blueSphere1.transform.position, player.transform.position);
        blueDist2 = Vector3.Distance(blueSphere2.transform.position, player.transform.position);

        // r1 / d1 = r2 / d2
        ratio = redSphere.transform.localScale.x / redDist;

        if (s) { Resize(); }
        else { blueSphere2.transform.localScale = blueSphere1.transform.localScale = originalLocalScale; }
    }

    private void Resize() {
        //blueSphere1.transform.localScale = 0.5f * new Vector3(ratio1, ratio1, ratio1);
        //blueSphere2.transform.localScale = 0.5f * new Vector3(ratio2, ratio2, ratio2);

        ratio1 = ratio * blueDist1;
        blueSphere1.transform.localScale = new Vector3(ratio1, ratio1, ratio1);

        ratio2 = ratio * blueDist2;
        blueSphere2.transform.localScale = new Vector3(ratio2, ratio2, ratio2);
    }
}
