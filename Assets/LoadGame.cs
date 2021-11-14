using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private LevelManager _levelManager;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Loading()
    {
        StartCoroutine(LoadingScreen());
    }
    IEnumerator LoadingScreen()
    {
        progressBar.fillAmount += 0.3f;
        yield return new WaitForSeconds(.5f);
        progressBar.fillAmount += 0.6f;
        yield return new WaitForSeconds(.5f);
        yield return null;
        _levelManager.CreateNewLevel();
        gameObject.SetActive(false);
    }
}
