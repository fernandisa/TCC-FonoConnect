using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using System;
using Mono.Data.Sqlite;

public class login : MonoBehaviour {
	public InputField emailField;
	public static string charEmail;
	public InputField senhaField;
	private string charSenha;
	private string sqlQuery;
	public static string email, senha;
	private string cena;
	public Text frase, logintext;
	private bool loginBool;

	void Start ()
	{
		if(telaInicialSou.souPaciente)
			logintext.text = "Login Paciente";

		if (telaInicialSou.souFono)
			logintext.text = "Login Fono";
		}
	public void onEntrar ()
	{
		loginBool = false;
		charEmail = emailField.text;
		charSenha = senhaField.text;
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		IDbConnection cn = new SqliteConnection (conn);
		cn.Open ();
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");

		IDbCommand dbcmd = cn.CreateCommand();
		if (telaInicialSou.souFono) {
			sqlQuery = "SELECT email, senha FROM fono WHERE email ='" + charEmail + "' AND senha ='" + charSenha + "' ";
			cena = "telaFono";
		} 
		else 
		{
			sqlQuery = "SELECT email, senha FROM paciente WHERE email ='" + charEmail + "' AND senha ='" + charSenha + "' ";
			cena = "titulo";
		}
		Debug.Log (sqlQuery);
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable ();
		dt.Load (dbcmd.ExecuteReader ());

		foreach (DataRow row in dt.Rows) 
		{
			Debug.Log ("entrou no foreach");
			email = row [0].ToString ();
			senha = row [1].ToString ();
			Debug.Log ("email= " + email+ "senha=" + senha);
			if (email == charEmail) {
				Debug.Log ("email iguais");
				if (senha == charSenha) {
					Debug.Log ("SENHA iguais");
					loginBool = true;
					SceneManager.LoadScene (cena);
				}
			}
		}

		if(loginBool == false)
		{
			frase.color = Color.red;
			frase.text = "Email ou senha incorretos";
		}

	}

	public void onCadastrese()
	{
		if (telaInicialSou.souFono) {
			SceneManager.LoadScene ("cadastrarFono");
		} 
		else 
		{
			SceneManager.LoadScene ("cadastrarPaciente");
		}
			
	}

	public void onVoltar ()
	{
		telaInicialSou.souFono = false;
		telaInicialSou.souPaciente = false;
		SceneManager.LoadScene ("telaInicial");
	}

}

