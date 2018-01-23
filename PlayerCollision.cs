/**
 * Se encarga de controlar cualquier tipo de colisión que sufra el personaje.
 */

using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;     // A reference to our PlayerMovement script
	public GameManager gameManager;
	public float resizeDelay = 2f;

	// This function runs when we hit another object.
	// We get information about the collision and call it "collisionInfo".
	void OnCollisionEnter (Collision collisionInfo)
	{
		// We check if the object we collided with has a tag called "Obstacle".
		if (collisionInfo.collider.tag == "Obstacle")
		{
			movement.enabled = false;   // Disable the players movement.
			FindObjectOfType<GameManager>().EndGame();
			FindObjectOfType<AudioManager> ().Play ("BlockCollide");

		}

		if (collisionInfo.collider.tag == "Ramp")
		{
			movement.rb.AddForce(0, movement.sidewaysForce * 2, movement.sidewaysForce * 2, ForceMode.VelocityChange);
		}
		if (collisionInfo.collider.tag == "RampL2") {
			if ((movement.rb.velocity.magnitude > 10)) {
				movement.rb.velocity = Vector3.ClampMagnitude (movement.rb.velocity, 10);
			} else {
				movement.rb.AddForce (0, movement.sidewaysForce * 5, movement.sidewaysForce * 5, ForceMode.VelocityChange);
		
			}
		}
		if (collisionInfo.collider.tag == "RampL2.2")
		{
			movement.rb.AddForce(0, movement.sidewaysForce * 2, movement.sidewaysForce * 2, ForceMode.VelocityChange);
		}
		if (collisionInfo.collider.tag == "Ice") 
		{
			movement.rb.AddForce(0, 0, movement.sidewaysForce * 2, ForceMode.VelocityChange);
		
		}
	}

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			FindObjectOfType<AudioManager> ().Play ("MiniSize");
			transform.localScale -= new Vector3 (1.5f, 1.5f, 1.5f);
			Invoke ("Resize", resizeDelay);

		} else if (other.CompareTag ("Coin")) {
			other.gameObject.SetActive (false);
			FindObjectOfType<AudioManager> ().Play ("GrabCoin");
			ScritpState.state.setCoins (ScritpState.state.getCoins () + 100);
		} 

		else if (other.CompareTag ("End")) {
			gameManager.CompleteLevel();
		}
	}

	public void Resize(){
		transform.localScale = new Vector3 (1f, 1f, 1f);
		FindObjectOfType<AudioManager> ().Play ("OriginalSize");
	}

}
