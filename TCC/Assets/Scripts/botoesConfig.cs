using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botoesConfig : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
	}
	public void confFonemas ()
	{
		SceneManager.LoadScene ("configurarFonemas");
	}

	public void confCadastro ()
	{
		if(telaInicialSou.souFono)
		SceneManager.LoadScene ("cadastrarFono");
		if(telaInicialSou.souPaciente)
			SceneManager.LoadScene ("cadastrarPaciente");
	}

	public void confJogo ()
	{
		SceneManager.LoadScene ("configurarJogo");
	}
	public void titulo ()
	{
		SceneManager.LoadScene ("titulo");
	}
	public void jogo ()
	{
		SceneManager.LoadScene ("jogo");
	}

	public void telaFono () 
	{
			SceneManager.LoadScene ("telaFono");

	}

	public void configurarPaciente ()
	{
		SceneManager.LoadScene ("configurarPaciente");
	}

}
