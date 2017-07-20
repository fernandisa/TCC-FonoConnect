using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickSettings : MonoBehaviour {

	// Use this for initialization
	void OnMouseDown()
	{		
			SceneManager.LoadScene ("configuracoes"); //p botão da engrenagem do jogo

	}
}
