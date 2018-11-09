using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour {

    [SerializeField] private Text _text = null;
    [SerializeField] private string[] _messages = null;
    [SerializeField] private float _duration = 0f;
    private float _timer = 0f;
    private int _currentMessageIndex = 0;

    public void Ok()
    {
    }

    protected void Start()
    {
        _text.text = _messages[_currentMessageIndex];
    }

    protected void Update()
    {
        if (_timer > _duration)
        {
            _timer = 0f;
            _text.text = _messages[NextIndex()];
        }

        _timer += Time.deltaTime;
    }

    private int NextIndex()
    {
        _currentMessageIndex = (_currentMessageIndex + 1) % _messages.Length;
        
        return _currentMessageIndex;
    }
}
