using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    private MovimentacaoPersonagem movimentacaoPersonagem;
    private Animator characterAC;

    // Use this for initialization
    void Start()
    {
        movimentacaoPersonagem = GetComponent<MovimentacaoPersonagem>();
        characterAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
    }

    public void UpdateAnimations()
    {
        characterAC.SetBool("Walk", movimentacaoPersonagem.GetIsWalking());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
