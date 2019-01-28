using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndStage : MonoBehaviour
{
    //public string sceneGoTo = "";
    public Animator fadeOut; // Animator Controller do Fade Out
    public string nextSceneName; // Nome da próxima cena que será carregada
    private float waiting = 2f; // Tempo de espera necessário para que a cena comece a carregar
    private bool waitForNextScene = false; // Condição para começar a contagem


    void Update() {
        if(waitForNextScene) //Caso verdadeiro 
        {
            waiting -= Time.deltaTime; // Iniciar contagem

            if(waiting <= 0 ) // Caso contagem menor ou igual a 0 
            {
                SceneManager.LoadScene(nextSceneName); // Carregar próxima cena de acordo com o nome passado como parâmetro
                waiting = 2f; // Resetar a contagem
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Quando o EndStage entrar em contato com o Player
        {
            fadeOut.SetTrigger("SetFadeOut"); // Iniciar a animação de Fade Out
            waitForNextScene = true; // Validar como verdadeiro a contagem
            
        }
    }
}
