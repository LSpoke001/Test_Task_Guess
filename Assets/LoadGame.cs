using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private LevelManager _levelManager;

    private void Awake()
    {
        gameObject.SetActive(false);
        _progressBar.fillAmount = 0f;
    }

    public void Loading()
    {
        StartCoroutine(LoadingScreen());
    }
    IEnumerator LoadingScreen()
    {
        _progressBar.fillAmount += 0.3f;
        yield return new WaitForSeconds(.5f);
        _progressBar.fillAmount += 0.6f;
        yield return new WaitForSeconds(.5f);
        _progressBar.fillAmount = 0f;
        _levelManager.CreateNewLevel();
        gameObject.SetActive(false);
    }
}
