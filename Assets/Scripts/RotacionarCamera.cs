using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionarCamera : MonoBehaviour
{
    // Start is called before the first frame update

    
    
    public float valor = 5;
    public float anguloMudar = 90f;

    private float RotacaoZ = 0;
    private float valorUsar = 0f;

    void Start()
    {
        valorUsar = valor;
    }

    
    void FixedUpdate()
    {
        //if (RotacaoZ >= anguloMudar || RotacaoZ <= -anguloMudar)
        if (Mathf.Abs(RotacaoZ) >= anguloMudar) //se o ângulo absoluto (sem sinal) for maior do que o ângulo limite
        {
            valorUsar *= -1; //inverte o valor usado para somar no ângulo. Se positivo, vai somar; se negativo, vai subtrair.
        }

        Rotacao(valorUsar);
    }

    void Rotacao(float valor) {
        RotacaoZ += valor;
        print(RotacaoZ);

        if(RotacaoZ >= 360f) {
            RotacaoZ -= 360f;
        }

        else if(RotacaoZ <= -360f) {
            RotacaoZ += 360f;
        }

        Quaternion NovaRotacao = Quaternion.Euler(0, 0, RotacaoZ);
        transform.rotation = NovaRotacao;
    }
}
