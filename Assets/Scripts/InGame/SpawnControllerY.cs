using UnityEngine;
using System.Collections;

public class SpawnControllerY : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public float rateSpawn;
	public float currentTime;
	private int posicao;
	private float y;
	private float x;

	public int rotationOffset; 

	void Start () 
	{
		currentTime = 0;
	}	

	void Update ()
	{
		if (LifeHandler.numVidas > 0 && SpawnControllerX.isBossActive == false) 
		{
			currentTime += Time.deltaTime;
			if (currentTime >= rateSpawn) 
			{
				rateSpawn = Random.Range (1.0f, 9.0f);
				currentTime = 0;
				posicao = Random.Range (-3, 3);
				y = posicao;
				GameObject tempPrefab = Instantiate (enemyPrefab) as GameObject;
				tempPrefab.transform.position = new Vector3 (transform.position.x, transform.position.y + y, transform.position.z);
			}
		}
	}
}
