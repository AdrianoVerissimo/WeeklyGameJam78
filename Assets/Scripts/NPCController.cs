using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public ColorController colorController;
    public AudioController audioController;

    public AudioClip soundInteract;

    [HideInInspector]
    public DoorController doorController;

    private bool isFound = false;
    private bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextColorLevel()
    {
        colorController.ShowNextColor();
    }
    public void MaxColorLevel()
    {
        colorController.ShowMaxColor();
    }
    public void ResetColor()
    {
        colorController.ResetColor();
    }

    public bool GetIsFound()
    {
        return isFound;
    }
    public void SetIsFound(bool value)
    {
        isFound = value;
    }

    public void SetDoorController(DoorController value)
    {
        doorController = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isFound)
            return;

        if (collision.gameObject.tag == "Player")
        {
            ColorController colorControllerTemp = collision.gameObject.GetComponent<ColorController>();
            if (colorControllerTemp.CountListColor() > 0 && colorControllerTemp.listColor[0] == colorController.listColor[0])
            {
                colorControllerTemp.ShowNextColor();
            }
            else
            {
                colorControllerTemp.listColor = colorController.listColor;
                colorControllerTemp.SetColorLevel(colorController.getCurrentColorLevel());
                colorControllerTemp.UpdateSpriteColor();
            }

            SetIsFound(true);
            MaxColorLevel();
            doorController.AskOpen();
            audioController.PlayAudio(soundInteract);
        }
    }

    public void ResetProperties()
    {
        ResetColor();
        SetIsFound(false);
    }

    public void SetComplete(bool value)
    {
        complete = value;
    }
    public bool GetComplete()
    {
        return complete;
    }
}
