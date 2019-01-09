using UnityEngine;
using System.Collections;

public class MudarCorNPC : MonoBehaviour
{
    [Header("Color Config")]
    public Color[] arrayColor;
    public SpriteRenderer spriteRenderer;

    [Header("Other Config")]
    public bool testMode = false;

    private Color initialColor;
    private int currentColorLevel = 0;

    // Use this for initialization
    void Start()
    {
        spriteRenderer.color = arrayColor[0];
        initialColor = spriteRenderer.color;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") {
            ShowNextColor();
            Debug.Log("ok");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ShowPreviousColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (testMode)
        //{
        //    CheckInputs();
        //}
    }

    #region --- COLOR ---

    public int getCurrentColorLevel()
    {
        return currentColorLevel;
    }

    public void SetColorLevel(int value)
    {
        currentColorLevel = value;
    }
    public void AddColorLevel(int value)
    {
        SetColorLevel(currentColorLevel + value);
    }
    public void SubtractColorLevel(int value)
    {
        SetColorLevel(currentColorLevel - value);
    }
    public void ResetColor()
    {
        if (getCurrentColorLevel() == 0)
            return;

        currentColorLevel = 0;
        spriteRenderer.color = initialColor;
    }

    public void ShowNextColor()
    {
        if (currentColorLevel + 1 >= arrayColor.Length)
            return;

        AddColorLevel(1);
        spriteRenderer.color = arrayColor[currentColorLevel];
    }
    public void ShowPreviousColor()
    {
        if (currentColorLevel - 1 < 0)
            return;

        SubtractColorLevel(1);
        spriteRenderer.color = arrayColor[currentColorLevel];
    }


    #endregion

    #region --- INPUTS ---

    //public void CheckInputs()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        ShowNextColor();
    //    }
    //    else if (Input.GetButtonDown("Fire2"))
    //    {
    //        ShowPreviousColor();
    //    }
    //}

    #endregion
}