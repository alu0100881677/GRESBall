/**
 * Se encarga de controlar las barras de carga que afectan a la RV
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressController : MonoBehaviour {

	public int timeToComplete = 2;
	private GameObject listener;
	private UnityEvent action;
	private float timeInit;

	// Use this for initialization
	void Start () {
		listener = null;
		action = null;
	}

	IEnumerator RadialProgress(float time) {
		float rate = 1 / time;
		timeInit = Time.realtimeSinceStartup;
		float i = 0;
		while (i < 1) {
			i = (Time.realtimeSinceStartup - timeInit) * rate;
			gameObject.GetComponent<Renderer>().material.SetFloat("_Progress", i);
			yield return 0;
		}
			
		if (action != null) {
			action.Invoke ();
			listener = null;
			action = null;
		}
		transform.parent.gameObject.SetActive (false);
	}


	public void Init (Vector3 position, GameObject listener, UnityEvent action) {
		this.listener = listener;
		this.action = action;

		transform.parent.gameObject.SetActive (true);
		StartCoroutine(RadialProgress(timeToComplete));
	}

	public void Reset () {
		StopCoroutine (RadialProgress (timeToComplete));
		transform.parent.gameObject.SetActive (false);
		listener = null;
		action = null;
	}


}
