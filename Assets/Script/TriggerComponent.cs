using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    [SerializeField] private bool _isDamage;
    [SerializeField, Min(1f)] private int _damageValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (_isDamage)
        {
            GameManager.Any.SetDamage(_damageValue);
        }
        else
        {
            GameManager.Any.LevelUp();
        }
    }
}
