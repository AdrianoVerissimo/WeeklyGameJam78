using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false;

    private Animator doorAC;

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
                Close(true);
            }
            else
            {
                Open(true);
            }
        }
    }

    public void Open(bool useAnimation)
    {
        doorAC.SetBool("On", true);
        doorAC.SetBool("UseAnimation", useAnimation);

        isOpen = true;
    }
    public void Close(bool useAnimation)
    {
        doorAC.SetBool("On", false);
        doorAC.SetBool("UseAnimation", useAnimation);

        isOpen = false;
    }
}
