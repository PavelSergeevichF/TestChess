using UnityEngine;
using Core.Controller.Abstractions;

public class TaskController : IAwake
{
    private TaskMapView _taskMapView;
    private char _startChar = 'A';

    public TaskController(TaskMapView taskMapView)
    {
        _taskMapView = taskMapView;
        GetTask();
    }

    public void Awake()
    {
        
    }
    private void GetTask()
    {
        if (_taskMapView.ShapesList.Count>0)
        {
            _taskMapView.SOModelTask.ShapesList.Clear();
            foreach (var task in _taskMapView.ShapesList) 
            {
                float x= (_taskMapView.StartRealPos.x - task.gameObject.transform.position.x+(-_taskMapView.StepRealPos.x/2))*-1;
                float tempXf = x / _taskMapView.StepRealPos.x;
                int tempXi =1+ (int)tempXf;
                task.PosOnGreed.x= tempXi;

                float y = _taskMapView.StartRealPos.y + task.gameObject.transform.position.z + (-_taskMapView.StepRealPos.y / 2);
                float tempYf = -y / _taskMapView.StepRealPos.y;
                int tempYi = _startChar + (int)tempYf;
                char tempYch = (char)tempYi;
                task.PosOnGreed.y = tempYch;

                _taskMapView.SOModelTask.ShapesList.Add(task);
            }
        }
    }
}
