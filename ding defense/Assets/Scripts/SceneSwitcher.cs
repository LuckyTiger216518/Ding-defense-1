using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string targetscene = "ding-wip1";
    public void SwitchScene()
    {
        SceneManager.LoadScene(targetscene);
    }
}