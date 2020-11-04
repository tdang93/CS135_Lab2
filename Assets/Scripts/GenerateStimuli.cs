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
    private Vector3 originalLocalScale;
    private bool resizeToggle;
    private bool appearToggle;
    private float timer;

    private void Start() {
        //blueSphere1.transform.localScale *= ratio / Vector3.Distance(blueSphere1.transform.position, this.transform.position);
        //blueSphere2.transform.localScale *= ratio / Vector3.Distance(blueSphere2.transform.position, this.transform.position);

        originalLocalScale = blueSphere1.transform.localScale;
        timer = 0;
        resizeToggle = false;
        appearToggle = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) { resizeToggle = !resizeToggle; }
        if (Input.GetKeyDown(KeyCode.F)) { appearToggle = !appearToggle; } // going from visible to invisible
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

        if (resizeToggle) { Resize(); }
        else { blueSphere2.transform.localScale = blueSphere1.transform.localScale = originalLocalScale; }

        // Make Spheres appear and disappear
        if (redSphere.activeSelf && !appearToggle) {
            redSphere.SetActive(false);
        }
        else if (!redSphere.activeSelf && blueSphere1.activeSelf && !appearToggle) {
            // Red sphere is invisible, and button is pressed to activate disappearance
            timer += Time.fixedDeltaTime; // count to 2 seconds
            if(timer >= 2) {
                blueSphere1.gameObject.SetActive(false);
                blueSphere2.gameObject.SetActive(false);
                timer = 0;
            }
        }
        else if (!redSphere.activeSelf && !blueSphere1.activeSelf && appearToggle) {
            // Red and Blue spheres are invisible, and button is pressed to activate reappearance
            redSphere.SetActive(true);
        }
        else if(redSphere.activeSelf && !blueSphere1.activeSelf && appearToggle) {
            // Blue spheres are invisible, and button is pressed to activate reappearane
            timer += Time.fixedDeltaTime;
            if(timer >= 2) {
                blueSphere1.gameObject.SetActive(true);
                blueSphere2.gameObject.SetActive(true);
                timer = 0;
            }
        }
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
