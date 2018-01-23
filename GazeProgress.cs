/**
 * Se encarga de gestionar la barra de progreso
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeProgress : MonoBehaviour {
	public ProgressController progress;
	public UnityEvent miEvento;

	// Use this for initialization
	void Start () {
	}

	public void Init () {
		Vector3 v = transform.position;
		Vector3 r = new Vector3 (v.x, v.y, v.z - 3);

		progress.Init (r, gameObject, miEvento);
	}

	public void Stop () {
		print ("stop");
		progress.Reset ();
	}
}
