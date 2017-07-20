using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class banco : MonoBehaviour {

	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		IDbConnection cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");
		IDbCommand dbcmd = cn.CreateCommand();
		string sqlQuery = "SELECT * FROM fonemas";
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable ();
		dt.Load (dbcmd.ExecuteReader ());
	
		foreach (DataRow row in dt.Rows) {
			string fonema = row [0].ToString ();
			Debug.Log ("fonema= " + fonema);
		}
	}
	

}
