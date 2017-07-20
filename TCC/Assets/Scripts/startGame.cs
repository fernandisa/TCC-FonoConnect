using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class startGame : MonoBehaviour {
	public static int idade;
	public IDbConnection cn;
	private string sqlQuery;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1)) //se apertar o botão direito do mouse..
		{
			SceneManager.LoadScene("jogo"); // o jogo começa 

		}

	}
	public void instrucoes ()
	{
		SceneManager.LoadScene ("instructions");
	}
}
