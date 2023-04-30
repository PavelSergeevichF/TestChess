using Core.Controller.Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectController : IExecute
{
    private bool _isWorckEffect = false;
    private bool _isUp = true;
    private float _minVolEffect = 0f;
    private float _maxVolEffect = 1f;
    private float _stepEffect = 0.05f;
    private float _bloomIntensity;
    private EffectView _effectView;
    private MainController _mainController;

    public EffectController(EffectView effectView, MainController mainController)
    {
        _effectView = effectView;
        _mainController = mainController;
        _bloomIntensity = _minVolEffect;
        _mainController.FinishLevel += FinishTask;
    }

    public void Execute()
    {
        if (_isWorckEffect) EffectWorck();
    }
    private void FinishTask()
    {
        _isWorckEffect = true;
    }
    private void EffectWorck()
    {
        if (_isUp)
        {
            if (_bloomIntensity < _maxVolEffect)
            {
                _bloomIntensity += _stepEffect;
                _effectView.GameObject.GetComponent<PostProcessVolume>().weight = _bloomIntensity;
            }
            else
            {
                _isUp = false;
            }
        }
        else 
        {
            if (_bloomIntensity > _minVolEffect)
            {
                _bloomIntensity -= _stepEffect;
                _effectView.GameObject.GetComponent<PostProcessVolume>().weight = _bloomIntensity;
            }
            else
            {
                _isUp = true;
                _isWorckEffect = false;
            }
        }
    }
}
