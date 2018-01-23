/**
 * Controlador del juego.
 * Se encarga de la finalización de los niveles, ya sea completando uno o fallando en el intento (Reiniciando en este último caso).
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;
	public HighScore highScore;
	public Text scoreText;
	public float restartDelay = 1f;

	public GameObject completeLevelUI;


	// Se encarga de actualizar el highscore y de mostrar la escena de nivel completado
	public void CompleteLevel ()
	{
		if(int.Parse (scoreText.text.ToString ()) > (int) ScritpState.state.getHighScore()[ScritpState.state.getcurrentLevel()])
			ScritpState.state.getHighScore()[ScritpState.state.getcurrentLevel()] = (int.Parse (scoreText.text.ToString ()));

		completeLevelUI.SetActive(true);
		FindObjectOfType<AudioManager> ().Pause ("OriginalTheme");
		FindObjectOfType<AudioManager> ().Play ("LevelComplete");
		FindObjectOfType<AudioManager> ().Play ("OriginalTheme");

	}


	// Se encarga de reiniciar el nivel cuando se falla.
	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Invoke("Restart", restartDelay);
		}
	}


	// Se encarga de actualizar el highscore en caso de que se haya superado el nivel anterior.
	public void Restart ()
	{
		Debug.Log (scoreText.text.ToString ());
		if(int.Parse (scoreText.text.ToString ()) > (int) ScritpState.state.getHighScore()[ScritpState.state.getcurrentLevel()])
			ScritpState.state.getHighScore()[ScritpState.state.getcurrentLevel()] = (int.Parse (scoreText.text.ToString ()));
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}

}
