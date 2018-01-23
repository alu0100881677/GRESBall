/**
 * Se encarga de cargar la escena del siguiente nivel, además de desbloquearlo
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	public void LoadNextLevel ()
	{
		ScritpState.state.unlockLevel (ScritpState.state.getcurrentLevel () + 1);
		ScritpState.state.setcurrentLevel (ScritpState.state.getcurrentLevel () + 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
