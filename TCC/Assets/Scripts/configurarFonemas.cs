using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
using UnityEngine.SceneManagement;
public class configurarFonemas : MonoBehaviour {
	public IDbConnection cn;
	private string email;
	private int idade;
	public static bool irConfigFonemas;
	// Use this for initialization
	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");


		if (telaInicialSou.souPaciente) {
			email = login.email; //pegar o email do login
			IDbCommand dbcmd = cn.CreateCommand();
			string sqlQuery = "SELECT idade FROM paciente WHERE id_paciente = '" + email +"'";
			dbcmd.CommandText = sqlQuery;
			DataTable dt = new DataTable (); 
			dt.Load (dbcmd.ExecuteReader ()); 

			foreach (DataRow row in dt.Rows) 
			{
				idade = Convert.ToInt32 (row [0]);
				Debug.Log ("Idade=" + idade );
			}
			if (idade > 9) {
				irConfigFonemas = true;
				SceneManager.LoadScene ("senhaResp");
			}
	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
