using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("Texts")]
    string[] _names;
    [SerializeField]
    List<string> _characterNames = new List<string>();
    TextAsset _namesFile;

    private void Start()
    {
        GetNamesFromFile();
    }

    void GetNamesFromFile()
    {
        _namesFile = Resources.Load("PlayerNames") as TextAsset;
        _names = _namesFile.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);
        for (int i = 0; i < _names.Length; i++)
        {
            _characterNames.Add(_names[i]);
        }
    }

    public string GetRandomCharacterName()
    {
        string _name = _characterNames[Random.Range(0, _characterNames.Count)];
        _characterNames.Remove(_name);
        return _name;
    }
}
