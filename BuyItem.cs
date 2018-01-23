/**
 * Clase que se encarga de de controlar las compras dentro de la tienda del juego.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour {

	public Transform items;

	void Start(){

		for (int i = 0; i < items.childCount; i++) {
			if (ScritpState.state.itemsPurchased [i].Equals (true)) {
				items.GetChild(i).GetChild (0).GetComponent<Text> ().fontSize = 172;
				items.GetChild(i).GetChild(0).GetComponent<Text>().text = "PURCHASED";
			}
		}
		
	}


	// Inicia la ejecución del código que comprueba si puede realizar una compra en la tienda o no.
	public void itemPressed (){
		string buttonName = EventSystem.current.currentSelectedGameObject.name;
		for (int i = 0; i < items.childCount; i++) {
			if(items.GetChild(i).name.Equals(buttonName)){
				Transform boton = items.GetChild (i);
				int price = int.Parse(boton.GetChild (0).GetComponent<Text> ().text);
				if (ScritpState.state.itemsPurchased [i].Equals (false)) {
					if ((ScritpState.state.getCoins () - price) >= 0) {
						ScritpState.state.itemsPurchased [i] = true;
						ScritpState.state.setCoins (ScritpState.state.getCoins () - price);
						ScritpState.state.setBallMaterial (boton.GetComponent<Image> ().color);
						boton.GetChild (0).GetComponent<Text> ().fontSize = 172;
						boton.GetChild (0).GetComponent<Text> ().text = "PURCHASED";
						FindObjectOfType<AudioManager> ().Play ("ItemPurchased");
					} else {
						FindObjectOfType<AudioManager> ().Play ("CantAffordItem");

					}
				} else {
					ScritpState.state.setBallMaterial (boton.GetComponent<Image> ().color);
				}
			}
		}
	}
}
