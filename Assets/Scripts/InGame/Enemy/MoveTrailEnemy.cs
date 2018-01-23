using UnityEngine;
using System.Collections;

public class MoveTrailEnemy : MonoBehaviour 
{
	public int moveSpeed = 230;
	public GameObject playerExplosion;

	void Update () 
	{
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		if (transform.position.y > 5 ||
			transform.position.y < -4.7 ||
			transform.position.x < -6 ||
		    transform.position.x > 4.20) 
		{
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}		
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			SpawnControllerX.DestroyAllEnemies();
			LifeHandler.numVidas -= 1;
			if(LifeHandler.numVidas < 1)
			{
				Destroy (other.gameObject);
				PausedTime.PlayerDeath();
			}
			other.transform.position = new Vector3(-1.3f, -3.5f, 0.0f);
		}		
	}
}
