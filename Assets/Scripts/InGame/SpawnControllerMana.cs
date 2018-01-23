using UnityEngine;
using System.Collections;

public class SpawnControllerMana : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public float rateSpawn;
	public float currentTime;
	private float posicao;

	void Start () 
	{

		currentTime = 0;
	}	

	void Update () 
	{
		if (LifeHandler.numVidas > 0)
		{
			currentTime += Time.deltaTime;
			if (currentTime >= rateSpawn)
			{
				rateSpawn = Random.Range (9.1f, 30.5f);
				currentTime = 0;
				posicao = Random.Range (-5.0f, 4.0f);
				GameObject tempPrefab = Instantiate (enemyPrefab) as GameObject;
				tempPrefab.transform.position = new Vector3 (transform.position.x + posicao, 
				                                             transform.position.y, 
				                                             transform.position.z);
			}
		}
	}
}
