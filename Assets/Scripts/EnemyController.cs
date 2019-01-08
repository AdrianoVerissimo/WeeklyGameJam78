using UnityEngine;
using UnityEditor;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public string[] arrayTagsCollider;
    public Color foundColor;

    public float timeTurnedOn = 2f;
    public float timeTurnedOff = 3f;

    private SpriteRenderer spriteRendererTarget;
    private Color oldTargetColor;

    private ColorController colorController;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckCollider(collision.tag))
        {
            colorController = collision.GetComponent<ColorController>();
            colorController.ResetColor();
        }
    }

    public bool CheckCollider(string tag)
    {
        foreach (string item in arrayTagsCollider)
        {
            if (item == tag)
            {
                return true;
            }
        }
        return false;
    }
}