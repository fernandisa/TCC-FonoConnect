using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;

public class senhaResp : MonoBehaviour {
	public InputField senharespField;
	private string charSenharesp;
	public InputField confsenharespField;
	private string charConfsenharesp;
	public Text fraseText;
	private string charEmail;

	// Use this for initialization
	void Start () {
		charEmail = cadastrar.charEmail;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onCadastrar ()
	{
		charSenharesp = senharespField.text;
		charConfsenharesp = confsenharespField.text;

		if (charSenharesp == charConfsenharesp) {
		
			string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
			IDbConnection cn = new SqliteConnection (conn);
			cn.Open ();
			if (cn.State.ToString () == "Open")
				Debug.Log ("open");

			IDbCommand cmd = cn.CreateCommand ();
			string SQLQuery = "UPDATE paciente SET senha_resp = '"+ charSenharesp + "' WHERE email = '" + charEmail + "'";
			Debug.Log (SQLQuery);
			cmd.CommandText = SQLQuery;
			cmd.ExecuteNonQuery ();
			Debug.Log ("Modificado");

			if (cadastrar.irCadastrar) {
				cadastrar.irCadastrar = false;
				SceneManager.LoadScene ("login");
			}
			else if (configurarFonemas.irConfigFonemas)
			{
				configurarFonemas.irConfigFonemas = false;
				SceneManager.LoadScene ("configurarFonemas");
			}
		}
		else 
		{
			fraseText.text = "As senhas não são iguais. Tente novamente!";
		}
	}
}
