/**
 * Se encarga de controlar el menú de niveles de tal forma que muestra solo los que se han desbloqueado.
 */

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour {

	public Sprite unlockedLevel;
	public Sprite lockedLevel;
	public Transform levels;

	void Start () {
		for (int i = 0; i < levels.childCount; i++) {
			Button button = levels.GetChild (i).GetComponent<Button>();
			if (ScritpState.state.unlockedLevels [i].Equals (true)) {
				button.GetComponent<Image>().sprite = unlockedLevel;
			} else {
				button.GetComponent<Image>().sprite = lockedLevel;
			}
		}
	}

	public void LevelOne (){
		if (ScritpState.state.unlockedLevels [0].Equals (true)) {
			ScritpState.state.setcurrentLevel (0);
			SceneManager.LoadScene ("Level01");
		}
	}

	public void LevelTwo (){
		if (ScritpState.state.unlockedLevels [1].Equals (true)) {
			ScritpState.state.setcurrentLevel (1);
			SceneManager.LoadScene ("Level02");
		}
	}
		

}
