using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Light lightObject;
    public Collider2D col2D;

    public string[] arrayTagsCollider;

    public bool turnOffByTime = false;
    public float timeTurnedOn = 2f;
    public float timeTurnedOff = 3f;

    private SpriteRenderer spriteRendererTarget;
    private Animator enemyAC;

    private ColorController colorController;

    private void Start()
    {
        enemyAC = GetComponent<Animator>();

        if (turnOffByTime)
        {
            StartCoroutine(TurnOff());
        }
    }

    private void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CheckCollider(collision.tag))
        {
            colorController = collision.GetComponent<ColorController>();
            colorController.ResetColor();

            collision.GetComponent<CharacterController>().ResetAllNPCs();
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

    public IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(timeTurnedOn);

        enemyAC.SetBool("On", false);

        DisableSearchForPlayer();
        StartCoroutine(TurnOn());
    }
    public IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(timeTurnedOff);

        enemyAC.SetBool("On", true);

        EnableSearchForPlayer();
        StartCoroutine(TurnOff());
    }

    public void SetSearchForPlayer(bool value)
    {
        col2D.enabled = value;
        lightObject.enabled = value;
    }
    public void EnableSearchForPlayer()
    {
        SetSearchForPlayer(true);
    }
    public void DisableSearchForPlayer()
    {
        SetSearchForPlayer(false);
    }
}