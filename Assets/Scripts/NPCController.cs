using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public ColorController colorController;

    [HideInInspector]
    public DoorController doorController;

    private bool isFound = false;

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
        if (collision.gameObject.tag == "Player")
        {
            SetIsFound(true);
            NextColorLevel();
        }
    }
}
