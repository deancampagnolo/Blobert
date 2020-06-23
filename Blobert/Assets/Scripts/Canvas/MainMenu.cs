﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject noOptions;

	public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //FIXME this needs to be changed in the future to be more direct in what you are playing.
    }

    public void SelectOptions()
    {
        noOptions.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
