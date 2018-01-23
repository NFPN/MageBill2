using UnityEngine;
using System.Collections;

public class MoveDownMana : MonoBehaviour 
{
	public Atirador fillPoint;
	public float speed;
	public Vector3 dir;

	void Start () 
	{
		if (fillPoint == null)
			fillPoint = GameObject.Find ("FirePoint").GetComponent<Atirador> ();
		dir = new Vector3 (0, -1, 0);
	}
	

	void Update () 
	{
		if (transform.position.y > 6 ||
		    transform.position.y < -7 ||
		    transform.position.x < -8 ||
		    transform.position.x > 7) 
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

		if (other.tag == "GetItem") 
		{

			if(SpawnControllerX.isBossActive == true)
			{
				fillPoint.mp.fillAmount += Random.Range(0.1f, 0.2f);
			}
			else
			{
				fillPoint.mp.fillAmount += Random.Range(0.005f, 0.02f);
			}
			Destroy(gameObject);
		}
	}
}
