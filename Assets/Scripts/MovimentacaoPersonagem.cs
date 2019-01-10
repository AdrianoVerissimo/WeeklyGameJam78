using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPersonagem : MonoBehaviour
{
    Rigidbody2D player;
    Vector2 move;
    public float velocidade = 5f; /*velocidade da movimentação*/

    private bool isWalking = false;
    void Start()
    {
        //Linkando o Rigidbody na variável ao iniciar o game
        player = GetComponent<Rigidbody2D>();
        
    }

    
    void FixedUpdate()
    {
        //Eixos para a movimentação
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        
        //Movimentação do personagem
        move = new Vector2(horizontal, vertical);

        //Aplicando movimento
        player.velocity = move * velocidade * Time.fixedDeltaTime;

        isWalking = player.velocity.x != 0f || player.velocity.y != 0f;
    }

    public bool GetIsWalking()
    {
        return isWalking;
    }
}
