using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public NPCController[] npcObjectsInteract;
    public AudioController audioController;
    public AudioClip soundInteract;

    private Animator doorAC;
    private int npcLenght = 0;

    // Use this for initialization
    void Start()
    {
        doorAC = GetComponent<Animator>();

        if (isOpen)
            Open(false, false);
        else
            Close(false, false);

        LoadNPCObjects();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void AskOpen()
    {
        if (CheckCanOpen())
            Open(true);
    }

    public void Open(bool useAnimation = true, bool playAudio = true)
    {
        doorAC.SetBool("Open", true);
        doorAC.SetBool("UseAnimation", useAnimation);

        isOpen = true;

        if (playAudio)
            audioController.PlayAudio(soundInteract);
    }
    public void Close(bool useAnimation = true, bool playAudio = true)
    {
        doorAC.SetBool("Open", false);
        doorAC.SetBool("UseAnimation", useAnimation);

        isOpen = false;

        if (playAudio)
            audioController.PlayAudio(soundInteract);
    }

    public void LoadNPCObjects()
    {
        npcLenght = npcObjectsInteract.Length;

        foreach (NPCController item in npcObjectsInteract)
        {
            item.doorController = GetComponent<DoorController>();
        }
    }

    public bool CheckCanOpen()
    {
        int npcCount = 0;

        foreach (NPCController item in npcObjectsInteract)
        {
            if (item == null)
                break;

            if (item.GetIsFound())
            {
                npcCount++;
            }
        }

        if (npcCount >= npcLenght)
        {
            foreach (NPCController item in npcObjectsInteract)
            {
                item.SetComplete(true);
            }

            return true;
        }

        return false;
    }
}
