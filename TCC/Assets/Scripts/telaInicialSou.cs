using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class telaInicialSou : MonoBehaviour {

	public static bool souFono, souPaciente;

	public void onSouFono ()
	{
		souFono = true;
		Debug.Log ("sou fono");
		SceneManager.LoadScene ("login");
	}

	public void onSouPaciente ()
	{
		souPaciente = true;
		Debug.Log ("sou paciente");
		SceneManager.LoadScene ("login");
	}
}
