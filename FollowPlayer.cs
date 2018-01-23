/**
 * Script que se encarga de mantener un punto (x, y, z) de tal forma que se encuentre detrás del personaje durante toda la ejecución.
 */

using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;	// Variable que se encarrga de almacenar la referencia del jugador
	public Vector3 offset;		// Variable que se encarrga de almacenar la diferencia sobre la referencia del jugador.
	
	// Update is called once per frame
	void Update () {
		// Set our position to the players position and offset it
		transform.position = player.position + offset;
	}
}
