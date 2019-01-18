using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToPlay : MonoBehaviour
{
    public void EventClick_ClickToPlay()
    {
        SceneManager.LoadScene("1 - Stage");
    }
}
