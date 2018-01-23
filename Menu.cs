/**
 * Menú principal
 * Contiene las funciones para cualquier botón de nuestro menú.
 */

using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

	public void Play (){
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		int n = 1;
		for (int i = 0; i < ScritpState.state.unlockedLevels.Count; i++) {
			if(ScritpState.state.unlockedLevels[i].Equals(false)){
				n = i;
				break;
			}
		}
		if (ScritpState.state.unlockedLevels[ScritpState.state.getnumLevels () - 1].Equals (true)) {
			n = ScritpState.state.getnumLevels ();
		}
		
		string name = "Level0" + n.ToString();
		ScritpState.state.setcurrentLevel (n-1);
		SceneManager.LoadScene(name);
	}

	public void Levels (){
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		SceneManager.LoadScene ("Levels");
	}

	public void Store (){
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		SceneManager.LoadScene ("Store");
	}

	public void Credits () {
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		SceneManager.LoadScene ("Credits");
	}

	public void Back (){
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		SceneManager.LoadScene ("Menu");
	}

	public void Quit (){
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		Application.Quit ();
	}

	public void Facebook (){
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		Application.OpenURL ("https://www.facebook.com/");
	}

	public void Twitter (){
		FindObjectOfType<AudioManager> ().Play ("ButtonPressed");
		Application.OpenURL ("https://www.twitter.com/");
	}

}
