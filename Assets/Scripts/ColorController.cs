using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorController : MonoBehaviour
{

    [Header("Color Config")]
    public List<Color> listColor;
    
    public SpriteRenderer spriteRenderer;
    
    [Header("Other Config")]
    public bool testMode = false;

    private Color initialColor;
    private int currentColorLevel = 0;

    // Use this for initialization
    void Start()
    {
        if (listColor.Count > 0)
            spriteRenderer.color = listColor[0];

        initialColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (testMode)
        {
            CheckInputs();
        }
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
        if (currentColorLevel + 1 >= listColor.Count)
            return;

        AddColorLevel(1);
        spriteRenderer.color = listColor[currentColorLevel];
    }
    public void ShowPreviousColor()
    {
        if (currentColorLevel - 1 < 0)
            return;

        SubtractColorLevel(1);
        spriteRenderer.color = listColor[currentColorLevel];
    }


    #endregion

    #region --- INPUTS ---

    public void CheckInputs()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShowNextColor();
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            ShowPreviousColor();
        }
    }

    #endregion
}
