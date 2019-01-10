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

    public void ResetAllNPCs()
    {
        GameObject[] arrayObjects = GameObject.FindGameObjectsWithTag("npc");
        NPCController npcTemp;

        if (arrayObjects.Length > 0)
        {
            foreach (GameObject item in arrayObjects)
            {
                npcTemp = item.GetComponent<NPCController>();
                if (npcTemp != null)
                {
                    npcTemp.ResetProperties();
                }
            }
        }
    }
}
