using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
using UnityEngine.SceneManagement;
public class configurarPaciente : MonoBehaviour {
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
	public Text txtSenha, txtEmailfono, msgAtualizado;
	public static bool irCadastrar, atualizada;
	private int alfabetizada, facilitacao;
	private string email, nomeCrianca, nomeResp, senha, fonoEmail, emailFono;
	private bool fonobool, senhabool, senhaigual;

	// Use this for initialization
	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");
		IDbCommand dbcmd = cn.CreateCommand();
		string sqlQuery1 = "SELECT nome_crianca, nome_resp, email, senha, fono_email, alfabetizada, facilitacao FROM paciente WHERE email = '" + login.charEmail + "'";

		dbcmd.CommandText = sqlQuery1;
		DataTable dt = new DataTable (); 
		dt.Load (dbcmd.ExecuteReader ()); 

		foreach (DataRow row in dt.Rows) {
			nomeCrianca = row [0].ToString ();
			nomeResp = row [1].ToString ();
			email = row [2].ToString ();
			senha = row [3].ToString ();
			fonoEmail = row [4].ToString ();
			alfabetizada = Convert.ToInt32(row[5]);
			facilitacao = Convert.ToInt32(row[6]);
			Debug.Log ("email= " + email);
		}

		nomecriancaField.text = nomeCrianca;
		nomerespField.text = nomeResp;
		emailField.text = email;
		senhaField.text = senha;
		senhaconfField.text = senha;
		emailfonoField.text = fonoEmail;
		if (alfabetizada == 0)
			alfabe.isOn = false;
		else
			alfabe.isOn = true;

		if (facilitacao == 0)
			fac.isOn = false;
		else
			fac.isOn = true;
	}
	
	public void onAtualizar ()
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
			emailFono = row [0].ToString ();
			Debug.Log ("email= " + email);
		}

		if (emailFono == null) {
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
			string SQLQuery = "UPDATE paciente SET nome_crianca = '"+ charNomecrianca +"', nome_resp = '" + charNomeresp + "', email = '" + charEmail + "', senha = '" + charSenha + "', fono_email = '" +charEmailfono + "', alfabetizada =" + alfabetizada + " , facilitacao = " + facilitacao + " WHERE email = '" + login.charEmail + "';";
			Debug.Log ("config paciente: " + SQLQuery);
			cmd.CommandText = SQLQuery;
			cmd.ExecuteNonQuery ();
			Debug.Log ("Modificado");
			atualizada = true;
			SceneManager.LoadScene ("configuracoes"); //senão, vai se logar

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
		SceneManager.LoadScene ("configuracoes");
	}
}
