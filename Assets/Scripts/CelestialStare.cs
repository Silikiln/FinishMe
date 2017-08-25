using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialStare : MonoBehaviour {

    public GameObject celestialCenter;

	// Update is called once per frame
	void Update () {
        transform.LookAt(celestialCenter.transform);
	}
}
