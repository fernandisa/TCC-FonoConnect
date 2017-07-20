using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class deleteDB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		IDbConnection cn = new SqliteConnection (conn);
		cn.Open ();
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");

		IDbCommand cmd = cn.CreateCommand ();
		string SQLQuery = "DELETE FROM tbl_score WHERE name='MAX'";
		cmd.CommandText = SQLQuery;
		cmd.ExecuteNonQuery ();
		Debug.Log ("Eliminado!");
		//Application.LoadLevel ("delete");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
