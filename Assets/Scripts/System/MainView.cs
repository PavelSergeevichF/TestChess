using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainView : MonoBehaviour
{
    [SerializeField] private ViewsList _viewsList;
    private BehaviourController _behaviourController;

    private void Awake()
    {
        _behaviourController = new BehaviourController();

        new MainInit(_behaviourController, _viewsList);

        _behaviourController.Awake();

    }

    private void Start()
    {
        _behaviourController.Init();
    }

    private void Update()
    {
        _behaviourController.Execute();
    }

    private void FixedUpdate()
    {
        _behaviourController.FixedExecute();
    }

    private void LateUpdate()
    {
        _behaviourController.LateExecute();
    }

    private void OnDestroy()
    {
        _behaviourController.Cleanup();

    }
}
