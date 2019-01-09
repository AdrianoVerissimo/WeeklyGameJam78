﻿using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public NPCController[] npcObjectsInteract;

    private Animator doorAC;
    private int npcLenght = 0;

    // Use this for initialization
    void Start()
    {
        doorAC = GetComponent<Animator>();

        if (isOpen)
            Open(false);
        else
            Close(false);
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
            Open();
    }

    public void Open(bool useAnimation = true)
    {
        doorAC.SetBool("On", true);
        doorAC.SetBool("UseAnimation", useAnimation);

        isOpen = true;
    }
    public void Close(bool useAnimation = true)
    {
        doorAC.SetBool("On", false);
        doorAC.SetBool("UseAnimation", useAnimation);

        isOpen = false;
    }

    public void LoadNPCObjects()
    {
        foreach (NPCController item in npcObjectsInteract)
        {
            item.SetDoorController(this);
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

            if (npcCount >= npcLenght)
            {
                return true;
            }
        }

        return false;
    }
}
