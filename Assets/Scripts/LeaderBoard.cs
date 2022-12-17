using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _fakeNamesTexts;
    [SerializeField] private List<TMP_Text> _fakeNumbersTexts;
    [SerializeField] private GameManager _gameManager;
    private Dictionary<string, int> _players = new Dictionary<string, int>();


    private int _count = 10; 
    private int _playerId = 0;
    private int _visualizePlayerId = 0;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int rnd = Random.Range(1, 100);
            SetPlayerId(rnd);
            AddPlayers(_visualizePlayerId);
            //SetLeaderboardsTextValues(_visualizePlayerId);
            StartCoroutine(Effect());
        }
    }

    private void AddPlayers(int _playerId)
    {
        for (int i = 0; i < 30; i++)
        {
            if (i < 15)
            {
                _players.Add(_gameManager.GetRandomCharacterName(), _playerId - (15 - (i + 1)));
            }
            else
            {
                _players.Add(_gameManager.GetRandomCharacterName(), _playerId + (i - 15));
            }
        }
    }

    private void SetPlayerId(int id)
    {
        this._playerId = id;
        _visualizePlayerId = _playerId + 10;
    }
    
    private void SetLeaderboardsTextValues(int id)
    {
        ResetTextColors();
        ResetTextScale();
        
        TMP_Text _playerNameText;
        TMP_Text _playerNumberText;
        
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

        _playerNameText.transform.parent.parent.localScale = Vector3.one * 1.2f;
        
        if (_playerValue == 1)
        {
            for (int i = 1; i < _fakeNamesTexts.Count; i++)
            {
                KeyValuePair<string, int> _player = _players.Where(a => a.Value == (_playerValue + (i))).First();
                _fakeNumbersTexts[i].text = "#" + _player.Value.ToString();
                _fakeNamesTexts[i].text = _player.Key.ToString();
            }
        }
        else if (_playerValue == 2)
        {
            for (int i = 0; i < _fakeNamesTexts.Count; i++)
            {
                
                if (i < 1)
                {
                    KeyValuePair<string, int> _player = _players.Where(a => a.Value == (_playerValue - 1)).First();
                    _fakeNumbersTexts[i].text = "#" + _player.Value.ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
                else if (i > 1)
                {
                    KeyValuePair<string, int> _player = _players.Where(a => a.Value == (_playerValue + (i - 1))).First();
                    _fakeNumbersTexts[i].text = "#" + _player.Value.ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
            }
        }
        else if (_playerValue == 3)
        {
            for (int i = 0; i < _fakeNamesTexts.Count; i++)
            {
                
                if (i < 2)
                {
                    KeyValuePair<string, int> _player = _players.Where(a => a.Value == (_playerValue - (2 - i))).First();
                    _fakeNumbersTexts[i].text = "#" + _player.Value.ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
                else if (i > 2)
                {
                    KeyValuePair<string, int> _player = _players.Where(a => a.Value == (_playerValue + (i - 2))).First();
                    _fakeNumbersTexts[i].text = "#" + _player.Value.ToString();
                    _fakeNamesTexts[i].text = _player.Key.ToString();
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                KeyValuePair<string, int> _player = _players.Where(a => a.Value == (_playerValue - (3 - i))).First();
                _fakeNumbersTexts[i].text = "#" + _player.Value.ToString();
                _fakeNamesTexts[i].text = _player.Key.ToString();
            }

            for (int i = 4; i < _fakeNamesTexts.Count; i++)
            {
                KeyValuePair<string, int> _player = _players.Where(a => a.Value == (_playerValue + (i - 3))).First();
                _fakeNumbersTexts[i].text = "#" + _player.Value.ToString();
                _fakeNamesTexts[i].text = _player.Key.ToString();
            }
        }
    }

    private IEnumerator Effect()
    {
        _count = 1;
        while (_count < 11)
        {
            _count++;
            _visualizePlayerId --;
            SetLeaderboardsTextValues(_visualizePlayerId);
            yield return new WaitForSeconds((_count) * .033f);
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

    private void ResetTextScale()
    {
        for (int i = 0; i < _fakeNamesTexts.Count; i++)
        {
            _fakeNamesTexts[i].transform.parent.parent.localScale = Vector3.one;
        }
    } 
}