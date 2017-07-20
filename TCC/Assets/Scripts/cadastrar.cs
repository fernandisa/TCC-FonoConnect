using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
using UnityEngine.SceneManagement;

public class cadastrar : MonoBehaviour {
	public IDbConnection cn;
	public Toggle alfabe, fac;
	public InputField nomecriancaField;
	private string charNomecrianca;
	public InputField nomerespField;
	private string charNomeresp;
	public InputField emailField;
	public static string charEmail;
	public InputField senhaField;
	private string charSenha;
	public InputField senhaconfField;
	private string charSenhaconf;
	public InputField emailfonoField;
	private string charEmailfono;
	public Text txtSenha;
	public Text txtEmailfono;
	public static bool irCadastrar;
	private int alfabetizada, facilitacao;
	private string email;
	private bool fonobool, senhabool, senhaigual;

	void Start ()
	{
		alfabe.isOn = false;
		fac.isOn = false;
	}

	public void onCadastrar ()
	{
		fonobool = true; 
		senhabool = true;
		charEmailfono = emailfonoField.text;
		charNomecrianca = nomecriancaField.text;
		charEmail = emailField.text;
		charSenha = senhaField.text;
		charSenhaconf = senhaconfField.text;
		charNomeresp = nomerespField.text;

		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");
		IDbCommand dbcmd = cn.CreateCommand();
		string sqlQuery1 = "SELECT email FROM fono WHERE email = '" + charEmailfono + "'";

		dbcmd.CommandText = sqlQuery1;
		DataTable dt = new DataTable (); 
		dt.Load (dbcmd.ExecuteReader ()); 

		foreach (DataRow row in dt.Rows) {
			email = row [0].ToString ();
			Debug.Log ("email= " + email);
		}

		if (email == null) {
			txtEmailfono.color = Color.red;
			txtEmailfono.text = "O seu fonoaudiólogo não está cadastrado ainda.";
			fonobool = false;
		} 
		else 
		{
			txtEmailfono.color = Color.green;
			txtEmailfono.text = "Fono email OK.";
			fonobool = true;
		}
		if (charSenha != charSenhaconf) {
			txtSenha.color = Color.red;
			txtSenha.text = "Senhas diferentes. Digite sua senha novamente!";	
			senhabool = false;
		} 
		else 
		{
			txtSenha.color = Color.green;
			txtSenha.text = "Senha OK!";	
			senhabool = true;
		}
		if (senhabool && fonobool) {
			IDbCommand cmd = cn.CreateCommand ();
			string SQLQuery = "INSERT INTO paciente(nome_crianca, nome_resp, email, senha, fono_email, alfabetizada, facilitacao) VALUES ('" + charNomecrianca + "', '" + charNomeresp + "', '" + charEmail + "', '" + charSenha + "', '" + charEmailfono + "', '" + alfabetizada + "', '" + facilitacao+ "' )";
			Debug.Log (SQLQuery);
			cmd.CommandText = SQLQuery;
			cmd.ExecuteNonQuery ();
			Debug.Log ("Modificado");
			string SQLQuery1 = "INSERT INTO paciente_fonema (id_paciente, id_fonemas, dificuldade, acertos, tentativas) SELECT '" + charEmail + "', fonema, 0, 0, 0 FROM fonemas ";
			Debug.Log (SQLQuery1);
			cmd.CommandText = SQLQuery1;
			cmd.ExecuteNonQuery ();
			SceneManager.LoadScene ("login"); //senão, vai se logar

		} 

			
		}
	public void ProcessaMenuAlfab (Toggle alfab) {
		if (alfab.isOn) {
			alfabetizada = 1;
			Debug.Log (alfabetizada);
		} else
			alfabetizada = 0;
	}


	public void ProcessaMenuFac (Toggle fac) {
		if (fac.isOn) {
			facilitacao = 1;
			Debug.Log (facilitacao);
		} else
			facilitacao = 0;
	}

	public void onVoltar ()
	{
		SceneManager.LoadScene ("login");
	}
	}