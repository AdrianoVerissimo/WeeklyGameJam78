using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionarCamera : MonoBehaviour
{
    // Start is called before the first frame update

    float AnguloTemp;
    private float RotacaoZ = 0;
    public float valor = 45;
    void Start()
    {
        AnguloTemp = valor;
    }

    
    void Update()
    {
        if (RotacaoZ >= 90f || RotacaoZ <= -90f)
        {
            AnguloTemp = AnguloTemp * -1;
        }

        Rotacao(AnguloTemp);
    }

    void Rotacao(float valor) {
        RotacaoZ += valor;
        if(RotacaoZ >= 360) {
            RotacaoZ -= 360;
        }

        else if(RotacaoZ <= 360) {
            RotacaoZ += 360;
        }

        Quaternion NovaRotacao = Quaternion.Euler(0, 0, RotacaoZ);
        transform.rotation = NovaRotacao;
    }
}
