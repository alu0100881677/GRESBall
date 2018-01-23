using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Gaze : MonoBehaviour {
	private Vector3 startingPosition;
	private Renderer renderer;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;

	// Use this for initialization
	void Start () {
		startingPosition = transform.localPosition;
		renderer = GetComponent<Renderer>();
		SetGazedAt(false);
	}

	public void SetGazedAt(bool gazedAt) {
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			renderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
	}

	public void Reset() {
		int sibIdx = transform.GetSiblingIndex();
		int numSibs = transform.parent.childCount;
		for (int i=0; i<numSibs; i++) {
			GameObject sib = transform.parent.GetChild(i).gameObject;
			sib.transform.localPosition = startingPosition;
			sib.SetActive(i == sibIdx);
		}
	}

	// Update is called once per frame
	void Update () {
	}
}



