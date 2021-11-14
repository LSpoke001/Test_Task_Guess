using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button _restart;
    [SerializeField] private LoadGame _loadPanel;

    private void Awake()
    {
        _restart = GetComponent<Button>();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _restart.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _restart.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
        _loadPanel.gameObject.SetActive(true);
        _loadPanel.Loading();
        gameObject.SetActive(false);
    }
}
