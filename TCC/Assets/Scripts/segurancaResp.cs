using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using System;
using Mono.Data.Sqlite;

public class segurancaResp : MonoBehaviour {

	public InputField senhaField;
	private string charSenha;
	private string sqlQuery;
	public static string email, senha;
	public Text frase;
	private bool loginBool;

	public void onEntrar ()
	{
		charSenha = senhaField.text;
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		IDbConnection cn = new SqliteConnection (conn);
		cn.Open ();
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");

		IDbCommand dbcmd = cn.CreateCommand();
	
		sqlQuery = "SELECT senha_resp FROM paciente WHERE email ='" + login.charEmail + "' ";
		Debug.Log (sqlQuery);
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable ();
		dt.Load (dbcmd.ExecuteReader ());

		foreach (DataRow row in dt.Rows) 
		{
			Debug.Log ("entrou no foreach");
			senha = row [0].ToString ();
			Debug.Log ("senha=" + senha);
				if (senha == charSenha) {
				loginBool = true;
					Debug.Log ("SENHA iguais");
				    SceneManager.LoadScene ("testedrop"); //ERRO AQUI
				}
		}

		if(loginBool == false)
		{
			frase.color = Color.red;
			frase.text = "Senha incorreta";
		}

	}
}
