using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class updateDB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		IDbConnection cn = new SqliteConnection (conn);
		cn.Open ();
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");

		IDbCommand cmd = cn.CreateCommand ();
		string SQLQuery = "UPDATE tbl_score SET name='MAX' WHERE score=33";
		cmd.CommandText = SQLQuery;
		cmd.ExecuteNonQuery ();
		Debug.Log ("Modificado");
		//Application.LoadLevel ("update");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
