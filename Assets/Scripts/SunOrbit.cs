using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunOrbit : MonoBehaviour {

    #region Editor vars;
    [Tooltip("Position we want to hit")]
    public Vector3 targetPos;

    [Tooltip("Horizontal speed, in units/sec")]
    public float speed = 10;

    [Tooltip("How high the arc should be, in units")]
    public float arcHeight = -20;

    #endregion Editor vars;
    Vector3 startPos;

    void Start() {
        // get our start position
        startPos = transform.position;
    }

    void Update() {
        // Compute the next position, with arc added in
        float x0 = startPos.x;
        float x1 = targetPos.x;
        float dist = x1 - x0;
        float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float baseZ = Mathf.Lerp(startPos.z, targetPos.z, (nextX - x0) / dist);
        float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
        Vector3 nextPos = new Vector3(nextX, transform.position.y, baseZ + arc);

        transform.position = nextPos;

        // Do something when we reach the target
        if(nextPos == targetPos) Debug.Log("Made it");
    }
}
