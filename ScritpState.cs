/**
 * Se encarga de guardar las principales características del juego sobre el jugador.
 * ALmacena la skin que se está usando de la bola, el número de niveles desbloqueados, las monedas, el highscore, ...
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScritpState : MonoBehaviour {

	public Transform player;

	public static ScritpState state;
	public static Color ballMaterial = Color.white;
	public static int coins = 0;
	public static int numLevels = 2;
	public static int currentLevel = 0;
	public ArrayList highscore = new ArrayList (numLevels);
	public ArrayList unlockedLevels = new ArrayList (numLevels);
	public static int numItems = 7;
	public ArrayList itemsPurchased = new ArrayList (numItems);

	void Awake () {
		if (state == null) {
			state = this;
			DontDestroyOnLoad (gameObject);
	
		} else if (state != this) {
			Destroy (gameObject);
		}
	}

	void Start(){				
		// Primer nivel desbloqueado
		unlockedLevels.Add (true);
		highscore.Add (0);

		// Resto de niveles bloqueados
		for (int i = 1; i < numLevels; i++) {
			unlockedLevels.Add (false);
			highscore.Add (0);
		}
			
		// Todos los objetos sin comprar
		for(int i = 0; i < numItems; i++){
			itemsPurchased.Add (false);
		}

	}															
																								

	public ArrayList getHighScore(){
		return highscore;
	}

	public void setCoins (int c){
		coins = c;
	}

	public int getCoins(){
		return coins;
	}

	public int getnumLevels(){
		return numLevels;
	}

	public int getcurrentLevel(){
		return currentLevel;
	}

	public void setcurrentLevel(int i){
		currentLevel = i;
	}

	public void setBallMaterial(Color m){
		ballMaterial = m;
	}

	public Color getBallMaterial(){
		return ballMaterial;
	}


	// Desbloquea un nivel l
	public void unlockLevel (int l){
		if (l < unlockedLevels.Count) {
			unlockedLevels.Insert (l, true);
			unlockedLevels.RemoveAt (l + 1);
		}
	}

	public void printUnlockedLevels(){
		for (int i = 0; i < unlockedLevels.Count; i++) {
			Debug.Log (unlockedLevels [i]);
		}
	}
}
