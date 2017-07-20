using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetAndSetText : MonoBehaviour {

	public InputField palavra;
	public Text frase;
	private string rightOrNot;
	private bool alreadyRight;
	public static int tentativas;
	public static int pontuacaoPronuncia;
	public void setget (){
		
		if (palavra.text == editTextMesh.displayText && alreadyRight == false && tentativas != 0) {
			frase.text = "Sua pronúncia está CERTA.";
			alreadyRight = true; //para ele n pontuar 2x
			Debug.Log(pontuacaoPronuncia);
			pontuacaoPronuncia = spawnController.corPalavra; //aumentando a pontuacao de acordo com a cor
			Debug.Log(pontuacaoPronuncia);
			// verde = 1 pt.. amarelo = 5pt.. vermelho = 10pt
			spawnController.corPalavra = 0; //zerando novamente
		} else if (palavra.text == editTextMesh.displayText && alreadyRight == true) {
			frase.text = "Você já pontuou nesta palavra.";
		} else if (palavra.text != editTextMesh.displayText && tentativas != 0 && alreadyRight == false) {
			tentativas--;
			frase.text = "Sua pronúncia está ERRADA. A palavra é " + editTextMesh.displayText + ".Você tem mais " + tentativas + " tentativas.";
		} else if (palavra.text != editTextMesh.displayText && tentativas == 0 && alreadyRight == false) {
			frase.text = "Sua pronúncia está ERRADA. A palavra era " + editTextMesh.displayText + ".Você não tem mais tentativas.";
		} else if (palavra.text == editTextMesh.displayText && tentativas == 0) {
			frase.text = "Você não tem mais tentativas.";
		}
	}
	public void voltar ()
	{
		if (tentativas == 0) {
			playerController.died = true;
			PlayerPrefs.SetInt ("pontuacao", playerController.pontuacao);
			if (playerController.pontuacao > PlayerPrefs.GetInt ("recorde")) 
				PlayerPrefs.SetInt ("recorde", playerController.pontuacao);

				SceneManager.LoadScene ("gameover");
			}

		else
			SceneManager.LoadScene ("jogo");
		
	}
	// Use this for initialization
	void Start () {
		tentativas = 3;
		frase.text = "A palavra a pronunciar é: " + editTextMesh.displayText + ".";
		pontuacaoPronuncia = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
			}
}
