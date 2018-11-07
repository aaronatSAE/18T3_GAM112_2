﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
