using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeHandler : MonoBehaviour 
{
	public Image[] vidas;
	static public Image[] sVidas;
	static public int numVidas;
	public int seeNumVidas;
	public float auxADV;
	public float diferença;

	void Start () 
	{
		sVidas = vidas;
		numVidas = 3;
	}

	void Update () 
	{
		vidas = sVidas;
		seeNumVidas = numVidas;
		float addVidaPorPonto = ManagerS.pontuacao;
		diferença = addVidaPorPonto - auxADV;
		if (diferença >= 1000000) {
			numVidas += 1;
			Atirador.Damage += 3;
			auxADV = addVidaPorPonto;
		}
		if (numVidas > 7) {
			numVidas = 7;
			ManagerS.pontuacao += 500000;
		}
		if (numVidas == 0) {
			foreach(Image vida in sVidas)
			{
				vida.fillAmount = 0;
			}
		}

		if (numVidas >= 1)
			sVidas [0].fillAmount = 1;
		else
			sVidas [0].fillAmount = 0;


		if (numVidas >= 2)
			sVidas [1].fillAmount = 1;
		else
			sVidas [1].fillAmount = 0;


		if (numVidas >= 3)
			sVidas [2].fillAmount = 1;
		else
			sVidas [2].fillAmount = 0;


		if (numVidas >= 4)
			sVidas [3].fillAmount = 1;
		else
			sVidas [3].fillAmount = 0;


		if (numVidas >= 5)
			sVidas [4].fillAmount = 1;
		else
			sVidas [4].fillAmount = 0;


		if (numVidas >= 6)
			sVidas [5].fillAmount = 1;
		else
			sVidas [5].fillAmount = 0;


		if (numVidas >= 7)
			sVidas [6].fillAmount = 1;
		else
			sVidas [6].fillAmount = 0;
	}
}
