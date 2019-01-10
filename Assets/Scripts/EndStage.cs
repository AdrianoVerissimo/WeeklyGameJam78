using UnityEngine;
using System.Collections;

public class EndStage : MonoBehaviour
{
    public string sceneGoTo = "";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GoToSceneController.GoToScene(sceneGoTo);
        }
    }
}
