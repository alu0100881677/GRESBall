/**
 * Actualiza el highscore instantáneamente a medida que el jugador va avanzando.
 */

using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Transform player;
	public Text scoreText;
	public int high = 0;

	void Start (){
		if((int) ScritpState.state.getHighScore()[ScritpState.state.getcurrentLevel()] != 0)
			high = (int) ScritpState.state.getHighScore()[ScritpState.state.getcurrentLevel()];
	}
	// Update is called once per frame
	void Update () {
		if (high <= player.position.z) {
			scoreText.text = player.position.z.ToString ("0");
	
		} else {
			scoreText.text = high.ToString ();
		}
	}
}
