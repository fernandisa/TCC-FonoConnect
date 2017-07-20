using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour {
	public UnityEngine.UI.Text pontos;
	public UnityEngine.UI.Text recorde;
	// Use this for initialization
	void Start () {
		pontos.text = PlayerPrefs.GetInt ("pontuacao").ToString();
		recorde.text = PlayerPrefs.GetInt ("recorde").ToString();

	}
	
	// Update is called once per frame
	public void inicio ()
	{
		SceneManager.LoadScene ("titulo"); //p botão da engrenagem do jogo
	}

}
