using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite; 
using System.Data; 


public class selectDB : MonoBehaviour {
	public string sqlQuery;
	// Use this for initialization
	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		IDbConnection cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");
		IDbCommand dbcmd = cn.CreateCommand();
		sqlQuery = "select * from palavras p join palavras_fonemas pf on p.palavra = pf.palavra join fonemas f on pf.fonema = f.fonema where f.dificuldade = 2 order by random() limit 1";

		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable ();
		dt.Load (dbcmd.ExecuteReader ());

		foreach (DataRow row in dt.Rows) 
		{
			Debug.Log ("entrou no foreach");
			string fonema = row [0].ToString ();
			Debug.Log ("fonemas= " + fonema);
		}
		//Application.LoadLevel ("select");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
