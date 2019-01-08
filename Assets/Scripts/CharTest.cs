using UnityEngine;
using UnityEditor;

public class CharTest : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public string[] arrayTagsCollider;
    public Color foundColor;

    public float timeTurnedOn = 2f;
    public float timeTurnedOff = 3f;

    private SpriteRenderer spriteRendererTarget;
    private Color oldTargetColor;

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
            spriteRendererTarget = collision.GetComponent<SpriteRenderer>();
            Color oldColor = spriteRendererTarget.color;
            oldTargetColor = oldColor;


            spriteRendererTarget.color = foundColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRendererTarget.color = oldTargetColor;
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