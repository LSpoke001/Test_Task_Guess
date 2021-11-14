using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CardView prefab;
    [SerializeField] private CardBundleData[] _cardBundleData;
    [SerializeField] private int[] _level;
    [SerializeField] private Button _restartBtn;

    private int _numLevel = 0;

    private Spawner _spawner;
    
    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        CreateNewLevel();
    }
    
    public void ChangeLevel()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
        _numLevel++;
        if (_numLevel >= _level.Length)
        {
            _numLevel = 0;
            _restartBtn.gameObject.SetActive(true);
        }
        else
        {
            _spawner.CreateLevel(_cardBundleData, _level[_numLevel], prefab);
        }
    }

    public void CreateNewLevel()
    {
        _spawner.CreateLevel(_cardBundleData, _level[_numLevel], prefab);
    }
}
