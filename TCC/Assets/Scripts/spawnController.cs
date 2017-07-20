using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class spawnController : MonoBehaviour {
	//ESSE SCRIPT PODE SER USADO PARA APARECER QUALQUER OBJETO NA TELA DO SEU JOGO. EX.: INIMIGOS, NAVES, BALAOZINHOS DE PALAVRAS

	public GameObject barreiraPrefab, palavraPrefab, abelhaPrefab, quatroPrefab;
	public float rateSpawn; // de qnto em qnto tempo um novo obj vai aparecer na tela
	private float currentTime; // tempo decorrido entre um spawn e outro.. ex.: a cada 2seg, mostrar barreira na tela.. essa variável vai contar o tempo p verificar isso
	private int posicao, posRandom;
	public static int colorRandom, niveldif;
	private float y;
	public float posA;
	public float posB;
	public float posD;
	public static int corPalavra = 0;
	public IDbConnection cn;
	private string sqlQuery;
	public static string palavra;
	private int alfabetizada, facilitacao;


	// Use this for initialization
	void Start () {
		currentTime = 0;
		string conn = "URI=file:" + Application.dataPath + "/fonemas.db";
		cn = new SqliteConnection(conn);
		cn.Open(); //Open connection to the database.
		if (cn.State.ToString () == "Open")
			Debug.Log ("open");
		//this.balaoPrefab = balaoPrefab;
		//this.t = balaoPrefab.transform;
		IDbCommand dbcmd = cn.CreateCommand();
		string sqlQuery = "SELECT alfabetizada, facilitacao FROM paciente WHERE email = '" + login.charEmail + "'";
		Debug.Log (sqlQuery);
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable (); 
		dt.Load (dbcmd.ExecuteReader ()); 

		foreach (DataRow row in dt.Rows) 
		{
			alfabetizada = Convert.ToInt32 (row [0]);
			facilitacao = Convert.ToInt32 (row [1]); 
			Debug.Log (alfabetizada);
			Debug.Log (facilitacao);
		}

		}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= rateSpawn) { //ta na hr d chamar outro obj
			currentTime = 0;
			posicao = random.posicao; //chamar obj aleatório.. 2 op: baixo ou cima
			if (posicao == 1) { // vai ser lançada a barreira na tela 
				if (facilitacao == 1) //facilitacao dos comandos do teclado diminuindo a barreira p 1
				{
					y = posB;
				} 
				else 
				{
					posRandom = random.posRandom; //sortear a posicao da barreira 
					if (posRandom == 1) //se o num alet for 1, instanciar a barreira p passar por cima
						y = posA;
					else

						y = posB; //barreira p passar por baixo
				}
	
				GameObject tempPrefab = Instantiate (barreiraPrefab) as GameObject; //instanciar a barreira p aparecer na cena
				tempPrefab.transform.position = new Vector3(transform.position.x, y, tempPrefab.transform.position.z); //surgindo no lugar certo
			} 
			else{ //vai ser lançada a palavra

				selectWord (); //selecionar a palavra de acordo com a dificuldade
				//LANÇAR IMAGENS NA TELA
				if (alfabetizada == 0) { //se n for alfabetizado mostra imagens
					Debug.Log ("n é alfabetizada por isso imagens");
					carregarSkin ();
				} else 
				{

					y = random.y; //sortear p ver se vai em cima ou embaixo
					GameObject tempPrefab2 = Instantiate (palavraPrefab) as GameObject; //instanciar a palavra que aparece na tela
					tempPrefab2.transform.position = new Vector3(transform.position.x, y, tempPrefab2.transform.position.z); //surgindo no lugar certo
					if (niveldif == 2) {
						corPalavra = 10; //pont máx pq fonema é difícil
						tempPrefab2.GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.red);
					} else if (niveldif == 1) {
						corPalavra = 5; //pont média pq fonema é médio
						tempPrefab2.GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.yellow);
					} else  if (niveldif == 0){ //niveldif == 2
						corPalavra = 1; //pont menor pq fonema é fácil
						tempPrefab2.GetComponent<MeshRenderer> ().material.SetColor ("_Color", Color.green);
					}
				}
				//	umPrefab = GameObject.Find(palavra); 
				//	y = random.y; //sortear p ver se vai em cima ou embaixo
				//GameObject tempPrefab3 = Instantiate (umPrefab) as GameObject;
				//	tempPrefab3.transform.position = new Vector3(transform.position.x, y, tempPrefab3.transform.position.z); //surgindo no lugar certo
				//	if (niveldif == 2) {
				//		corPalavra = 10;
				//	} else if (niveldif == 1) {
				//		corPalavra = 5;

				//	} else  if (niveldif == 0){
				//		corPalavra = 1;
				//}



					//LANÇAR PALAVRAS NA TELA


			//	} //se n for abelha

		

			}// se for uma palavra

		}


	}//caba o update

	public void selectWord ()
	{	
		IDbCommand dbcmd = cn.CreateCommand ();
		//sqlQuery = "SELECT palavra, dificuldade FROM (SELECT pala.palavra, MAX(paci_fone. dificuldade) dificuldade FROM palavras pala JOIN palavras_fonemas pala_fone ON pala.palavra = pala_fone.palavra JOIN fonemas fone ON pala_fone.fonema = fone.fonema JOIN paciente_fonema paci_fone ON fone.fonema = paci_fone.id_fonemas WHERE paci_fone.id_paciente = '" +login.charEmail + "' GROUP BY pala.palavra HAVING MAX(paci_fone.dificuldade) = 0 UNION SELECT pala.palavra, MAX(paci_fone. dificuldade) dificuldade FROM palavras pala JOIN palavras_fonemas pala_fone ON pala.palavra = pala_fone.palavra JOIN fonemas fone ON pala_fone.fonema = fone.fonema JOIN paciente_fonema paci_fone ON fone.fonema = paci_fone.id_fonemas WHERE paci_fone.id_paciente = '" + login.charEmail + "'  GROUP BY pala.palavra HAVING MAX(paci_fone.dificuldade) > 0 UNION SELECT pala.palavra, MAX(paci_fone. dificuldade) dificuldade FROM palavras pala JOIN palavras_fonemas pala_fone ON pala.palavra = pala_fone.palavra JOIN fonemas fone ON pala_fone.fonema = fone.fonema JOIN paciente_fonema paci_fone ON fone.fonema = paci_fone.id_fonemas WHERE paci_fone.id_paciente = '" + login.charEmail + "' GROUP BY pala.palavra HAVING MAX(paci_fone.dificuldade) > 1) tab ORDER BY RANDOM() LIMIT 1;";
		sqlQuery = "SELECT palavra, dificuldade FROM (SELECT pala.palavra, MAX(paci_fone. dificuldade) dificuldade, 0 FROM palavras pala JOIN palavras_fonemas pala_fone ON pala.palavra = pala_fone.palavra JOIN fonemas fone ON pala_fone.fonema = fone.fonema JOIN paciente_fonema paci_fone ON fone.fonema = paci_fone.id_fonemas WHERE paci_fone.id_paciente = '" + login.charEmail + "' GROUP BY pala.palavra HAVING MAX(paci_fone.dificuldade) < 2 UNION SELECT pala.palavra, MAX(paci_fone. dificuldade) dificuldade, 1 FROM palavras pala JOIN palavras_fonemas pala_fone ON pala.palavra = pala_fone.palavra JOIN fonemas fone ON pala_fone.fonema = fone.fonema JOIN paciente_fonema paci_fone ON fone.fonema = paci_fone.id_fonemas WHERE paci_fone.id_paciente = '" + login.charEmail + "' GROUP BY pala.palavra HAVING MAX(paci_fone.dificuldade) > 0 UNION SELECT pala.palavra, MAX(paci_fone. dificuldade) dificuldade, 2 FROM palavras pala JOIN palavras_fonemas pala_fone ON pala.palavra = pala_fone.palavra JOIN fonemas fone ON pala_fone.fonema = fone.fonema JOIN paciente_fonema paci_fone ON fone.fonema = paci_fone.id_fonemas WHERE paci_fone.id_paciente = '" + login.charEmail + "' GROUP BY pala.palavra HAVING MAX(paci_fone.dificuldade) = 2 UNION SELECT pala.palavra, MAX(paci_fone. dificuldade) dificuldade, 3 FROM palavras pala JOIN palavras_fonemas pala_fone ON pala.palavra = pala_fone.palavra JOIN fonemas fone ON pala_fone.fonema = fone.fonema JOIN paciente_fonema paci_fone ON fone.fonema = paci_fone.id_fonemas WHERE paci_fone.id_paciente = '" + login.charEmail + "' GROUP BY pala.palavra HAVING MAX(paci_fone.dificuldade) = 2) tab ORDER BY RANDOM() LIMIT 1;";
		dbcmd.CommandText = sqlQuery;
		DataTable dt = new DataTable ();
		dt.Load (dbcmd.ExecuteReader ());
		foreach (DataRow row in dt.Rows) {
			Debug.Log ("entrou no foreach");
			palavra = row [0].ToString ();
			niveldif = Convert.ToInt32 (row [1]);
			Debug.Log ("palavra=" + palavra + "\n niveldif=" + niveldif);
			}
				
		}

	private void carregarSkin()
	{
		y = -0.5f;
		GameObject tempPrefab10 = Instantiate (quatroPrefab) as GameObject; //instanciar a palavra que aparece na tela
		tempPrefab10.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + palavra);
		tempPrefab10.transform.position = new Vector3(transform.position.x, y, tempPrefab10.transform.position.z); //surgindo no lugar certo
		//tempPrefab10.transform.position = new Vector3(transform.position.x, y, tempPrefab10.transform.position.z); //surgindo no lugar certo
		if (niveldif == 2) {
			corPalavra = 10; //pont máx pq fonema é difícil
		} else if (niveldif == 1) {
			corPalavra = 5; //pont média pq fonema é médio

		} else  if (niveldif == 0){ //niveldif == 2
			corPalavra = 1; //pont menor pq fonema é fácil
		}

	}
	}

	

	


	
