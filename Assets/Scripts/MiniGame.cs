using DTT.MinigameMemory;
using Naninovel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    private MemoryGameManager _manager;
    [SerializeField]
    private MemoryGameSettings _settings;
    [SerializeField]
    private GameObject _miniGameCanvas;

    private IScriptPlayer _player;

    private static MiniGame _instance;
    public static MiniGame Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance == this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        _player = Engine.GetService<IScriptPlayer>();
        _manager = GetComponent<MemoryGameManager>();
        _miniGameCanvas.SetActive(false);
    }

    public void StartMemoryGame()
    {
        _player.Stop();
        _miniGameCanvas.SetActive(true);
        _manager.StartGame(_settings);
        _manager.Finish += StopGame;
    }

    private void StopGame(MemoryGameResults result)
    {
        _manager.Finish -= StopGame;
        _miniGameCanvas.SetActive(false);
        var nextIndex = _player.PlayedIndex + 1;
        _player.Play(_player.Playlist, nextIndex);
    }
}
