using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _fakeNamesTexts;
    [SerializeField] private List<TMP_Text> _fakeNumbersTexts;
    [SerializeField] private GameManager _gameManager;
    List<KeyValuePair<string, int>> _players = new List<KeyValuePair<string, int>>();

    private void Start()
    {
        AddPlayers(50);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetLeaderboardsTextValues(3);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetLeaderboardsTextValues(2);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetLeaderboardsTextValues(1);
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            SetLeaderboardsTextValues(Random.Range(4, 10000));
        }
    }

    private void AddPlayers(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _players.Add(new KeyValuePair<string, int>(_gameManager.GetRandomCharacterName(),
                Random.Range(100, 10000)));
        }
    }

    private void SetLeaderboardsTextValues(int id)
    {
        ResetTextColors();
        TMP_Text _playerNameText;
        TMP_Text _playerNumberText;
        // int _playerValue = Random.Range(1, 500);
        int _playerValue = id;

        if (_playerValue < 4)
        {
            _playerNameText = _fakeNamesTexts[_playerValue - 1];
            _playerNumberText = _fakeNumbersTexts[_playerValue - 1];
            _playerNameText.color = Color.green;
            _playerNumberText.color = Color.green;
            _playerNameText.text = "PLAYER";
            _playerNumberText.text = "#" + _playerValue.ToString();
        }
        else
        {
            _playerNameText = _fakeNamesTexts[3];
            _playerNumberText = _fakeNumbersTexts[3];
            _playerNameText.color = Color.green;
            _playerNumberText.color = Color.green;
            _playerNameText.text = "PLAYER";
            _playerNumberText.text = "#" + _playerValue.ToString();
        }

        if (_playerValue == 1)
        {
            for (int i = 1; i < _fakeNamesTexts.Count; i++)
            {
                KeyValuePair<string, int> _player = _players[Random.Range(0, _players.Count)];
                _fakeNumbersTexts[i].text = "#" + (_playerValue + (i)).ToString();
                _fakeNamesTexts[i].text = _player.Key.ToString();
            }
        }
        else if (_playerValue == 2)
        {
            for (int i = 0; i < _fakeNamesTexts.Count; i++)
            {
                KeyValuePair<string, int> _player = _players[Random.Range(0, _players.Count)];
                if (i < 1)
                {
                    _fakeNumbersTexts[i].text = "#" + (_playerValue - 1).ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
                else if (i > 1)
                {
                    _fakeNumbersTexts[i].text = "#" + (_playerValue + (i - 1)).ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
            }
        }
        else if (_playerValue == 3)
        {
            for (int i = 0; i < _fakeNamesTexts.Count; i++)
            {
                KeyValuePair<string, int> _player = _players[Random.Range(0, _players.Count)];
                if (i < 2)
                {
                    _fakeNumbersTexts[i].text = "#" + (_playerValue - (2 - i)).ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
                else if (i > 2)
                {
                    _fakeNumbersTexts[i].text = "#" + (_playerValue + (i - 2)).ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                KeyValuePair<string, int> _player = _players[Random.Range(0, _players.Count)];
                _fakeNumbersTexts[i].text = "#" + (_playerValue - (3 - i)).ToString();
                _fakeNamesTexts[i].text = _player.Key.ToString();
            }

            for (int i = 4; i < _fakeNamesTexts.Count; i++)
            {
                KeyValuePair<string, int> _player = _players[Random.Range(0, _players.Count)];
                _fakeNumbersTexts[i].text = "#" + (_playerValue + (i - 3)).ToString();
                _fakeNamesTexts[i].text = _player.Key.ToString();
            }
        }
    }

    private void ResetTextColors()
    {
        for (int i = 0; i < _fakeNamesTexts.Count; i++)
        {
            _fakeNamesTexts[i].color = Color.white;;
        }

        for (int i = 0; i < _fakeNumbersTexts.Count; i++)
        {
            _fakeNumbersTexts[i].color = Color.white;
        }
    }
}