using UnityEngine;
using System.Collections;

public class Mana : MonoBehaviour 
{
	public Atirador fillPoint;

	void Start () 
	{
		if (fillPoint == null)
			fillPoint = GameObject.Find ("FirePoint").GetComponent<Atirador> ();
	
	}
	

	void Update () 
	{
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		Debug.Log("encostou");
		if (other.tag == "Player") 
		{
			fillPoint.mp.fillAmount += Random.Range(0.1f, 0.3f);
			Destroy(gameObject);
		}
	}
}
