using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;
using UnityEngine.SceneManagement;
public class consultarPaciente : MonoBehaviour {
	public IDbConnection cn;
	private string fonema;
	public int porc = 0;
	private string idpaciente;
	private int acertos, tentativas;
	public Text fon1, fon2, fon3, fon4, fon5, fon6, fon7, fon8, fon9, fon10, fon11, fon12,fon13, fon14, fon15, fon16, fon17, fon18, fon19, fon20,fon21, fon22, fon23, fon24, fon25, fon26, fon27, fon28;
	void Start () {
		idpaciente = telaFono.emailSelecionado;
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");
		IDbCommand dbcmd = cn.CreateCommand();
		//string sqlQuery = "UPDATE paciente_fonema SET porc = (acertos / tentativas ) * 100 WHERE acertos != 0 AND tentativas != 0";
		//dbcmd.CommandText = sqlQuery;
		//dbcmd.ExecuteNonQuery ();

		string sqlQuery1 = "SELECT id_fonemas, acertos, tentativas FROM paciente_fonema WHERE id_paciente = '" + idpaciente + "'";

		dbcmd.CommandText = sqlQuery1;
		DataTable dt = new DataTable (); 
		dt.Load (dbcmd.ExecuteReader ()); 

		foreach (DataRow row in dt.Rows) 
		{
			fonema = row [0].ToString ();
			acertos = Convert.ToInt32(row [1]);
			tentativas = Convert.ToInt32(row [2]);
			if(tentativas != 0)
			{
				porc = ((int)acertos * 100) / (int)tentativas;
			}

			Debug.Log ("fonema=" + fonema + "porc=" + porc);

			if (fon1.text == fonema) {
				fon1.text = fon1.text + ": " + porc + "% de acertos"; 
			}
			if (fon2.text == fonema) {
				fon2.text = fon2.text + ": " + porc + "% de acertos"; 
			}
			if (fon3.text == fonema) {
				fon3.text = fon3.text + ": " + porc + "% de acertos"; 
			}
			if (fon4.text == fonema) {
				fon4.text = fon4.text + ": " + porc + "% de acertos"; 
			}
			if (fon5.text == fonema) {
				fon5.text = fon5.text + ": " + porc + "% de acertos"; 
			}
			if (fon6.text == fonema) {
				fon6.text = fon6.text + ": " + porc + "% de acertos"; 
			}
			if (fon7.text == fonema) {
				fon7.text = fon7.text + ": " + porc + "% de acertos"; 
			}
			if (fon8.text == fonema) {
				fon8.text = fon8.text + ": " + porc + "% de acertos"; 
			}
			if (fon9.text == fonema) {
				fon9.text = fon9.text + ": " + porc + "% de acertos"; 
			}
			if (fon10.text == fonema) {
				fon10.text = fon10.text + ": " + porc + "% de acertos"; 
			}
			if (fon11.text == fonema) {
				fon11.text = fon11.text + ": " + porc + "% de acertos"; 
			}
			if (fon12.text == fonema) {
				fon12.text = fon12.text + ": " + porc + "% de acertos"; 
			}
			if (fon13.text == fonema) {
				fon13.text = fon13.text + ": " + porc + "% de acertos"; 
			}
			if (fon14.text == fonema) {
				fon14.text = fon14.text + ": " + porc + "% de acertos"; 
			}
			if (fon15.text == fonema) {
				fon15.text = fon15.text + ": " + porc + "% de acertos"; 
			}
			if (fon16.text == fonema) {
				fon16.text = fon16.text + ": " + porc + "% de acertos"; 
			}
			if (fon17.text == fonema) {
				fon17.text = fon17.text + ": " + porc + "% de acertos"; 
			}
			if (fon18.text == fonema) {
				fon18.text = fon18.text + ": " + porc + "% de acertos"; 
			}
			if (fon19.text == fonema) {
				fon19.text = fon19.text + ": " + porc + "% de acertos"; 
			}
			if (fon20.text == fonema) {
				fon20.text = fon20.text + ": " + porc + "% de acertos"; 
			}
			if (fon21.text == fonema) {
				fon21.text = fon21.text + ": " + porc + "% de acertos"; 
			}
			if (fon22.text == fonema) {
				fon22.text = fon22.text + ": " + porc + "% de acertos"; 
			}
			if (fon23.text == fonema) {
				fon23.text = fon23.text + ": " + porc + "% de acertos"; 
			}
			if (fon24.text == fonema) {
				fon24.text = fon24.text + ": " + porc + "% de acertos"; 
			}
			if (fon25.text == fonema) {
				fon25.text = fon25.text + ": " + porc + "% de acertos"; 
			}
			if (fon26.text == fonema) {
				fon26.text = fon26.text + ": " + porc + "% de acertos"; 
			}
			if (fon27.text == fonema) {
				fon27.text = fon27.text + ": " + porc + "% de acertos"; 
			}
			if (fon28.text == fonema) {
				fon28.text = fon28.text + ": " + porc + "% de acertos"; 
			}
				
		}
	

	}
	
	public void voltar()
	{
		SceneManager.LoadScene ("telaFono");
	}
}
