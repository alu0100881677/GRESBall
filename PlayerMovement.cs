/**
 * Se encarga de controlar el movimiento del personaje.
 */ 

using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;
	public Transform player;
	//public Camera mainCamera;
	public GvrReticlePointer reticlePointer;

	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force
	public float maxSpeed = 10;
	public bool impulso = false;
	// We marked this as "Fixed"Update because we
	// are using it to mess with physics.
	void FixedUpdate ()
	{
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		// Add a force in the direction of the ray
		Ray ray = reticlePointer.GetRayForDistance (Mathf.Infinity).ray;
		rb.AddForce (ray.direction.x * sidewaysForce, 0, 0);

		if ((rb.velocity.magnitude > maxSpeed) && (!impulso)){
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);
		}



		/*
		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))	// If the player is pressing the "d" key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) // If the player is pressing the "a" key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		*/

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}

	public void Impulse () {
		impulso = true;
		Debug.Log (rb.velocity);
			//rb.velocity = Vector3.ClampMagnitude (rb.velocity, 30);
		rb.AddForce(0, 0, sidewaysForce * 0.5f, ForceMode.Impulse);
		Debug.Log(rb.velocity);
		
		Debug.Log ("Aumentando velocidad");
		Invoke("setImpulsoFalse",0.5f);
		Debug.Log (impulso);
	}

	public void setImpulsoFalse(){
		impulso = false;
		Debug.Log (impulso);
	}

	void Start(){
		player.GetComponent<Renderer> ().material.color = ScritpState.state.getBallMaterial ();
	}
}
