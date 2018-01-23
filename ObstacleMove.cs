/**
 * SSe encarga de controlar el movimiento de algunos objetos que se encuentran en los niveles.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {

	public bool right = false;
	void Update () {
		if (transform.position.x < -4f)
			right = true;
		if (transform.position.x > 4f)
			right = false;

		if(right)
			transform.position += (new Vector3 (5, 0, 0) * Time.deltaTime);
		else
			transform.position -= (new Vector3 (5, 0, 0) * Time.deltaTime);
	}
}
