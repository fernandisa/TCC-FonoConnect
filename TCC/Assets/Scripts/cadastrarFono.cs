using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

public class cadastrarFono : MonoBehaviour {
	public InputField nomeField;
	private string charNome;
	public InputField sobrenomeField;
	private string charSobrenome;
	public InputField emailField;
	public static string charEmailFono;
	public InputField senhaField;
	private string charSenha;
	public InputField senhaconfField;
	private string charSenhaconf;
	public Text senhaconf;

	public void onCadastrar ()
	{
		charNome = nomeField.text;
		charSobrenome = sobrenomeField.text;
		charEmailFono = emailField.text;
		charSenha = senhaField.text;
		charSenhaconf = senhaconfField.text;
		if (charSenha == charSenhaconf) {

			string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
			IDbConnection cn = new SqliteConnection (conn);
			cn.Open ();
			if (cn.State.ToString () == "Open")
				Debug.Log ("open");

			IDbCommand cmd = cn.CreateCommand ();
			string SQLQuery = "INSERT INTO fono(nome, sobrenome, email, senha) VALUES ('" + charNome + "', '" + charSobrenome + "', '" + charEmailFono + "', '" + charSenha + "')";
			Debug.Log (SQLQuery);
			cmd.CommandText = SQLQuery;
			cmd.ExecuteNonQuery ();
			Debug.Log ("Modificado");


			SceneManager.LoadScene ("login"); //senão, passa direto p configurar os fonemas
		} 
		else
		{
			senhaconf.color = Color.red;
			senhaconf.text = "Senhas diferentes. Digite sua senha novamente!";
		}
	}

	public void onVoltar ()
	{	
		SceneManager.LoadScene ("telaInicial");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
