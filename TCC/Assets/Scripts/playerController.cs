using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour {

	public Animator anime;
	public Rigidbody2D playerRb; //RigidiBody
	public Transform GroundCheck; //se está ou n pisando no chão
	public LayerMask whatIsGround;
	public Transform colisor;
	public AudioSource audio;
	public AudioClip soundJump;
	public AudioClip soundSlide;
	public static int pontuacao, pontuacaoAloha;
	public UnityEngine.UI.Text txtPontuacao;
	public int forceJump;
	public bool  slide, grounded;
	public float timeTemp, slideTemp;
	public static bool died;
	// Use this for initialization
	void Start () {
		if (died == false) {
			pontuacao += pontuacaoAloha;
			pontuacaoAloha = 0;
			Debug.Log (pontuacao);
			PlayerPrefs.SetInt ("pontuacao", pontuacao);
		} else {
			pontuacao = 0;
			PlayerPrefs.SetInt ("pontuacao", pontuacao);
			died = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		txtPontuacao.text = pontuacao.ToString (); // mandando a pontuacao para o campo texto da tela e convertendo int p string
		if (Input.GetButtonDown("Jump") && grounded == true) //se o botão esquerdo do mouse for apertado = pula
		{
			playerRb.AddForce (new Vector2(0,forceJump) );
			playerRb.velocity = new Vector2 (0, 0); // n estava aqui antes
			audio.PlayOneShot (soundJump);
			audio.volume = 1;
			slide = false;
			if (slide == true) {
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z ); //corrigindo o bug
				slide = false;
			}
		
		}
		//se o botão direito do mouse for apertado ele desliza
		else if (Input.GetButtonDown("Slide") && grounded == true && slide == false) //se o botão pulo for apertado e estiver no chão e n estiver fazendo um slide já
		{
			colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z ); //mudar a posicao do colisor mais p baixo
			audio.PlayOneShot (soundSlide);
			audio.volume = 0.5f;
			slide = true;
			timeTemp = 0; //começar na contagem nova
		}
		                                //(onde ele comeca, tamanho do círculo)
		grounded = Physics2D.OverlapCircle (GroundCheck.position,0.2f, whatIsGround); //se ele colidir = true.. senão = false

		if (slide == true) { // se ele pular
			timeTemp += Time.deltaTime; // incremento no timeTemp
			if (timeTemp >= slideTemp) { // se ele chegar ao tempo máx da animação pulo ou mais
				slide = false; // parar d rodar a animação pulo
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z ); //qndo parar d deslizar, voltar o colisor p lugar original
			}
		}
		anime.SetBool ("jump", !grounded);
		anime.SetBool ("slide", slide);	

		if (moveBarrier.colidedBarrier == true) { // se bateu na barreira
			moveBarrier.colidedBarrier = false; //desmarcar 
			died = true; //morreu
			PlayerPrefs.SetInt ("pontuacao", pontuacao); //mudar a pontuacao	
			if (pontuacao > PlayerPrefs.GetInt ("recorde")) //se a pontuacao for maior q o recorde atual
				PlayerPrefs.SetInt ("recorde", pontuacao); //mudar o recorde

			SceneManager.LoadScene ("gameover"); //ir p tela de gameover
		}

		if (moveWord.colidedWord == true) { //se bateu na palavra
			moveWord.colidedWord = false; // desmarcar
			SceneManager.LoadScene ("ExampleCopia"); //ir p tela da pronúncia Example2
		}



	}





			
}

