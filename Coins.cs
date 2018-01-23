/**
 * Clase que se encarga de actualizar el número de monedas que tiene el jugador.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

	public Text coinsText;
	public int coins;
	// Use this for initialization
	void Start () {
		if (ScritpState.state.getCoins () != 0) {
			coins = ScritpState.state.getCoins ();
			coinsText.text = coins.ToString ();
		} else
			coinsText.text = ("0");
			
	}
	
	// Update is called once per frame
	void Update () {
		if(ScritpState.state.getCoins() != 0){
			coins = ScritpState.state.getCoins();
			coinsText.text = coins.ToString ();
		} else
			coinsText.text = ("0");
	}
}
