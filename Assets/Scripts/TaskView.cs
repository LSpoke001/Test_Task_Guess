using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskView : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    
    private Text _task;

    private void Start()
    {
        _task = GetComponent<Text>();
        _spawner.Changed += ChangeTask;
    }

    private void OnDisable()
    {
        _spawner.Changed -= ChangeTask;
    }

    private void ChangeTask(string task)
    {
        _task.text = "Find " + task;
    }
}
