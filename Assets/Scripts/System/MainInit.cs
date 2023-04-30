using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInit
{
    private BehaviourController _behaviourController;
    private ViewsList _viewsList;

    public MainInit(BehaviourController behaviourController, ViewsList viewsList)
    {
        _behaviourController = behaviourController;
        _viewsList = viewsList;

        var taskController = new TaskController(viewsList.TaskMapView);
        behaviourController.Add(taskController);

        var mapController = new MapController(viewsList.Map);
        behaviourController.Add(mapController);

        var shapesControllers = new ShapesControllers(viewsList.ShapesViews, viewsList.Map);
        behaviourController.Add(shapesControllers);

        var mainController = new MainController(viewsList.TaskMapView, viewsList.Map, viewsList.ShapesViews);
        behaviourController.Add(mainController);

        var effectController = new EffectController(viewsList.EffectView, mainController);
        behaviourController.Add(effectController);
    }
}
