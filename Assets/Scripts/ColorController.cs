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

    private List<Color> listColorInitial;
    private Color initialColor;
    private int currentColorLevel = 0;

    // Use this for initialization
    void Start()
    {
        listColorInitial = listColor;

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
        currentColorLevel = 0;
        spriteRenderer.color = initialColor;
        listColor = listColorInitial;
    }
    public void MaxColor()
    {
        int value = CountListColor() - 1;
        if (getCurrentColorLevel() + 1 >= CountListColor())
            return;

        SetColorLevel(value);
    }
    public int CountListColor()
    {
        return listColor.Count;
    }

    public void ShowNextColor()
    {
        if (currentColorLevel + 1 >= CountListColor())
            return;

        AddColorLevel(1);
        UpdateSpriteColor();
    }
    public void ShowPreviousColor()
    {
        if (currentColorLevel - 1 < 0)
            return;

        SubtractColorLevel(1);
        UpdateSpriteColor();
    }
    public void ShowMaxColor()
    {
        if (currentColorLevel + 1 >= CountListColor())
            return;

        MaxColor();
        UpdateSpriteColor();
    }
    public void UpdateSpriteColor()
    {
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
