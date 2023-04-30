using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectView : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public GameObject GameObject => _gameObject;
}
