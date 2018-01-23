using UnityEngine;
using UnityEngine.UI;

public class ManagerS : MonoBehaviour 
{
	static public float pontuacao;
	static public float highscore;
	public Text pontoTexto;
	public Text Highscore;
	public Text Damage;
	public float valorPontos;
	public float valorHighscore;
	public float prefsHighscore;

	void Start () 
	{
		pontuacao = 0;
		SaveScore ();
	}

	void Update () 
	{
		if(Input.GetKey(KeyCode.F12))
			PlayerPrefs.SetFloat("Highscore", 0);
		pontoTexto.text = "Score: " + pontuacao.ToString("f0");
		Damage.text = "Damage " + Atirador.Damage.ToString("f0");
		valorPontos = pontuacao;
		valorHighscore = highscore;
		prefsHighscore  = PlayerPrefs.GetFloat("Highscore");
		SaveScore ();
		if (PlayerPrefs.GetFloat ("Highscore") < pontuacao) 
		{
			highscore = pontuacao;
			PlayerPrefs.SetFloat("Highscore", pontuacao);
		}
		Highscore.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore").ToString("f0");
	}

	void SaveScore()
	{
		PlayerPrefs.SetFloat ("Score", pontuacao);
	}
	static public void SaveHighscore()
	{
		PlayerPrefs.SetFloat ("Highscore", highscore);
	}
}
