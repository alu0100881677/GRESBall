/**
 * Colisionador para finalizar el nivel.
 */

using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager gameManager;

	void OnTriggerEnter ()
	{
		gameManager.CompleteLevel();
	}

}
