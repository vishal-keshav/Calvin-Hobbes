using UnityEngine;
using System.Collections;

/// <summary>
/// THis is for rotating collectors (yellow)
/// </summary>
public class Rotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,90)*Time.deltaTime);
	}
}
