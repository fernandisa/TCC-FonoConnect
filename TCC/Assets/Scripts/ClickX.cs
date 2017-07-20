using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickX : MonoBehaviour {

	void OnMouseDown()
	{		
		telaInicialSou.souFono = false;
		telaInicialSou.souPaciente = false;
		SceneManager.LoadScene ("telaInicial"); //p botão da engrenagem do jogo
	}
}
