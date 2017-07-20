using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
using UnityEngine.SceneManagement;
public class DropdownMenu : MonoBehaviour {
	public Dropdown menu;
	public int valor;
	public Text fonematexto;
	public IDbConnection cn;
	private string email;
	private int idade;
	// Use this for initialization
	void Start () {
		Debug.Log (valor);
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open dropdown menu");


		if (telaInicialSou.souPaciente) {
			email = login.email; //pegar o email do login
			Debug.Log(email);
		} else {
			email = telaFono.emailSelecionado; //pegar o email do dropdown
			Debug.Log(email);
		}
		IDbCommand dbcmd = cn.CreateCommand();
		string sqlQuery = "SELECT dificuldade FROM paciente_fonema WHERE id_fonemas = '" + fonematexto.text + "' AND id_paciente = '" + email + "'";
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable (); 
		dt.Load (dbcmd.ExecuteReader ()); 

		foreach (DataRow row in dt.Rows) 
		{
			int dificuldade = Convert.ToInt32 (row [0]);
			Debug.Log ("Dificuldade=" + dificuldade );
			menu.value = dificuldade;
		}



	}

	public void ProcessaMenu (Dropdown mDropdown) {
		valor = mDropdown.value;
		IDbCommand dbcmd = cn.CreateCommand();
		string sqlQuery = "UPDATE paciente_fonema SET dificuldade = " + valor + " WHERE id_fonemas = '" + fonematexto.text+"' AND id_paciente = '" + email +"'"; //mudar apenas esse fonema aqui em todos o resto é igual
		Debug.Log(sqlQuery);
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable ();
		dt.Load (dbcmd.ExecuteReader ()); 

		Debug.Log ("valor dropdown: " + mDropdown.value);
	}
	// Update is called once per frame
	void Update () {
		

	}


}
