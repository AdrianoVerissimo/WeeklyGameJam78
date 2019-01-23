using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPersonagem : MonoBehaviour
{
    Rigidbody2D player;
    Vector2 move;
    public float velocidade = 5f; /*velocidade da movimentação*/

    private RotacionarCamera rotacionarCamera;
    private bool isWalking = false;
    void Start()
    {
        //Linkando o Rigidbody na variável ao iniciar o game
        player = GetComponent<Rigidbody2D>();
        rotacionarCamera = GetComponent<RotacionarCamera>();
    }

    
    void FixedUpdate()
    {
        //Eixos para a movimentação
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        UpdateDirection(horizontal, vertical);
        
        //Movimentação do personagem
        move = new Vector2(horizontal, vertical);

        //Aplicando movimento
        player.velocity = move * velocidade * Time.fixedDeltaTime;

        isWalking = player.velocity.x != 0f || player.velocity.y != 0f;

        // Aplicar som dos passos conforme valores dos inputs
        SomPassos(horizontal, vertical);
    }

    public void UpdateDirection(float horizontal, float vertical)
    {
        if (horizontal > 0f)
            rotacionarCamera.SetRotation(270f);
        else if (horizontal < 0f)
            rotacionarCamera.SetRotation(90f);
        else if (vertical > 0f)
            rotacionarCamera.SetRotation(0f);
        else if (vertical < 0f)
            rotacionarCamera.SetRotation(180f);
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }

    public void SomPassos(float h, float v) {
        if(h != 0 || v != 0) {
            GetComponent<AudioController>().PlayAudio(GetComponent<AudioSource>().clip,true,true);
           
        }
        else {
            GetComponent<AudioController>().StopAudio();
            
        }
    }
}
