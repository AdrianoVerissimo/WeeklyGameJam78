using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    public Color[] arrayColor;
    public SpriteRenderer spriteRenderer;

    private Color initialColor;
    private int currentColorLevel = 0;

    // Use this for initialization
    void Start()
    {
        spriteRenderer.color = arrayColor[0];
        initialColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
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

    #region --- COLOR ---

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
    public void ResetColorLevel()
    {
        currentColorLevel = 0;
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
}
