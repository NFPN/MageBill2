using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject fireWxplosion;
	public int scoreValue;
	
	public Atirador atScript;	
	public GameObject manaObj;

    private float manaAmount;
    private float enemyLife;

	void Start ()
	{
		if (atScript == null)
			atScript = GameObject.Find ("FirePoint").GetComponent<Atirador>();
		enemyLife = Random.Range (50, 110);
		manaAmount = Random.Range (1, 5);
	}

	void Update()
	{

		if (transform.position.y > 10 ||
		    transform.position.y < -4.7 ||
		    transform.position.x < -5.9 ||
		    transform.position.x > 4.7f) 
		{
			Destroy (gameObject);
		}
		if (enemyLife == 0) {
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion == null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		if (other.tag == "Tiro") 
		{
			Instantiate(fireWxplosion, other.transform.position, transform.rotation);
			other.gameObject.SetActive(false);
			enemyLife -= Atirador.Damage;
			ManagerS.pontuacao += Random.Range(100, 1000);
			if(enemyLife <= 0)
			{
				for (float i = 0; i < manaAmount; i++) 
				{ 
					//angulos = Random.Range (0, 360);
					//float aux = (i / manaAmount) * angulos;
					//rot.eulerAngles = new Vector3 (0.0f, 0.0f, 270 + aux1);
					//Instantiate (manaObj, transform.position, rot);
					float posicaox = Random.Range (-0.5f, 0.5f);
					float posicaoy = Random.Range (-0.5f, 0.5f);
					GameObject tempPrefab = Instantiate (manaObj) as GameObject;
					tempPrefab.transform.position = new Vector3 (transform.position.x + posicaox, 
					                                             transform.position.y + posicaoy, 
					                                             transform.position.z);
				}

				ManagerS.pontuacao += Random.Range(1000, 10000);
				Instantiate(explosion, transform.position, transform.rotation);
				atScript.mp.fillAmount += 0.03f;
				Destroy(gameObject);
			}
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			SpawnControllerX.DestroyAllEnemies();
			LifeHandler.numVidas -= 1;
			//Atirador.Damage -= 3;
			if(LifeHandler.numVidas < 1)
			{
                other.gameObject.SetActive(false);
				SpawnControllerX.DestroyAllEnemies();
				PausedTime.PlayerDeath();
			}
			other.transform.position = new Vector3(-1.3f, -3.5f, 0.0f);
		}		
	}
}