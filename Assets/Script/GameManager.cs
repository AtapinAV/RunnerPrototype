using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Any;

    private int _nextvalue = 0;
    private int _index = 0;
    private float _last = 870.4f;
    private float _size = 100f;

    [SerializeField, Range(1f, 100f)] private int _heal;
    [SerializeField] private Transform[] _room;
    [SerializeField] private Text _next;

    private void Start()
    {
        Any = this;
    }

    public void SetDamage(int damage)
    {
        _heal -= damage;
        if(_heal <= 0)
        {
            Debug.Log("you perished");
            Debug.Log("the end of your wanderings");
            UnityEditor.EditorApplication.isPaused = true;
        }
    }

    public void LevelUp()
    {
        _nextvalue++;
        _next.text = _nextvalue.ToString();

        _last += _size;
        var position = _room[_index].position;
        position.z = _last;
        _room[_index].position = position;
        _index++;
        if(_index >= _room.Length)
        {
            _index = 0;
        }
    }

}
