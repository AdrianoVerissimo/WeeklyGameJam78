using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPersonagem : MonoBehaviour
{
    Rigidbody2D player;
    Vector2 move;
    public float velocidade = 0.001f; /*velocidade da movimentação*/
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
        player.velocity += move * velocidade * Time.deltaTime;

  
    }
}
