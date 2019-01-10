using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionarCamera : MonoBehaviour
{
    // Start is called before the first frame update


    public bool rotacionarAutomatico = true;
    public float valor = 5;
    public float anguloMudar = 90f;
    public float valorTempo = 3f;
    private float tempo;
    private bool parado = false;
    private float RotacaoZ = 0;

    private float valorUsar = 0f;


    void Start()
    {
        valorUsar = valor;
        tempo = valorTempo;
    }

    
    void FixedUpdate()
    {

        if (Mathf.Abs(RotacaoZ) >= anguloMudar) //se o ângulo absoluto (sem sinal) for maior do que o ângulo limite
        {
            parado = true; /*Se chegou no ângulo limite, câmera irá ficar parada*/
            if(tempo <= 0) /*Quando o tempo for menor ou igual a 0*/
            {
                valorUsar *= -1; //inverte o valor usado para somar no ângulo. Se positivo, vai somar; se negativo, vai subtrair.
                parado = false;
                tempo = valorTempo;
            }
           
        }


        if (rotacionarAutomatico)
        {
            if (parado) /*Se parado, o cronômetro irá inicializar*/
            {
                tempo -= Time.fixedDeltaTime;
            }
            else /*Se não estiver parado, rotação normal*/
            {
                Rotacao(valorUsar * Time.fixedDeltaTime);
            }
        }






        //if (rotacionarAutomatico)
        //{
        //    //if (RotacaoZ >= anguloMudar || RotacaoZ <= -anguloMudar)
        //    if (Mathf.Abs(RotacaoZ) >= anguloMudar) //se o ângulo absoluto (sem sinal) for maior do que o ângulo limite
        //    {
        //        valorUsar *= -1; //inverte o valor usado para somar no ângulo. Se positivo, vai somar; se negativo, vai subtrair.
        //    }

        //    Rotacao(valorUsar * Time.fixedDeltaTime);
        //}

        
    }

    void Rotacao(float valor) {
        RotacaoZ += valor;

        SetRotation(RotacaoZ);
    }

    public void SetRotation(float value)
    {
        
        if (value >= 360f)
        {
            value -= 360f;
        }


        else if (value <= -360f)
        {
            value += 360f;

        }

        Quaternion NovaRotacao = Quaternion.Euler(0, 0, value);
        transform.rotation = NovaRotacao;
    }
}
