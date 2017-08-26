using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    #region Editor vars;
    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = -30;

    #endregion Editor vars;
    Vector3 eastSide = new Vector3(20f,0f,0f);
    Vector3 westSide = new Vector3(-20f, 0f, 0f);
    bool moving = false;


    void Start() {
        // get our start position
    }

    void Update() {
        if(moving) return; 
        else StartCoroutine(OrbitScene());
    }

    private IEnumerator OrbitScene() {
        Vector3 targetSide = (transform.position == eastSide) ? westSide : eastSide;
        int zInverse = (transform.position == eastSide) ? 1: -1;

        float x0 = transform.position.x;
        float x1 = targetSide.x;
        float z0 = transform.position.z;
        float z1 = targetSide.z;
        moving = true;
        while(moving) {
            // Compute the next position, with arc added in
            float dist = x1 - x0;
            float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
            float baseZ = Mathf.Lerp(z0, z1, (nextX - x0) / dist);
            float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
            Vector3 nextPos = new Vector3(nextX, transform.position.y, zInverse*(baseZ + arc));
            transform.position = nextPos;
            yield return null;
            if(transform.position == westSide || transform.position == eastSide) moving = false;
        }
        yield break;
    }
    

}
