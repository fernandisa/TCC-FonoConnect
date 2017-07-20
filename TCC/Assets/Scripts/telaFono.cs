using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
using UnityEngine.SceneManagement;
public class telaFono : MonoBehaviour {
	public IDbConnection cn;
	public Dropdown menu;
	private string nome;
	public static int valor;
	private string emailFono;
	public static string emailSelecionado;
	public Text erro;
	List<string> pacientes = new List<string> ();
	// Use this for initialization
	void Start () {
		emailFono = login.charEmail;
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");
		IDbCommand dbcmd = cn.CreateCommand();
		string sqlQuery = "SELECT email FROM paciente WHERE fono_email ='" + emailFono + "'";
		Debug.Log (sqlQuery);
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable ();
		dt.Load (dbcmd.ExecuteReader ());
		foreach (DataRow row in dt.Rows) 
		{
			string emailPaciente = row [0].ToString ();
			pacientes = new List<string> () { emailPaciente};
			menu.AddOptions(pacientes);
		}
		//menu.value = 0; //como inicializa já com um valor no dropdown
		//Debug ("valor menu.value=" + menu.value);

			
	}
	
	// Update is called once per frame
	public void ProcessaMenu (Dropdown mDropdown) {
		valor = mDropdown.value;
		emailSelecionado = mDropdown.options[mDropdown.value].text;
		Debug.Log ("email selecionado=" + emailSelecionado);
	}
	void Update () {
		//menu.onValueChanged.AddListener (delegate { //só qndo clica no dropdown q executa
		//	ProcessaMenu (menu);
		//});
	}
	public void consultar() // vendo evolução do paciente
	{
		if (menu.value == 0) 
		{
			erro.color = Color.red;
			erro.text = "Nenhum paciente selecionado";
		}
		else 
		{
			SceneManager.LoadScene ("consultarPaciente");
		}

	}
	public void fonoFonemas() // alterando dificuldade dos fonemas do paciente
	{
		if (menu.value == 0) 
		{
			erro.color = Color.red;
			erro.text = "Nenhum paciente selecionado";
		}
		else 
		{
			SceneManager.LoadScene ("fonoFonemas"); //script do configurar fonemas
		}

	}

	public void sair ()
	{
		SceneManager.LoadScene ("telaInicial");
	}


}
