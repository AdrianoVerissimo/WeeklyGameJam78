﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneController : MonoBehaviour {

	public static void GoToScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
