using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class RootContext : MVCSContext, IRootContext
{

    public RootContext(MonoBehaviour view) : base(view)
    {

    }

    public RootContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        GameObject managers = GameObject.Find("Managers");
        GameObject UI = GameObject.Find("UI");

        injectionBinder.Bind<IRootContext>().ToValue(this).ToSingleton().CrossContext();

        EventManager eventManager = managers.GetComponent<EventManager>();
        injectionBinder.Bind<IEventManager>().ToValue(eventManager).ToSingleton().CrossContext();

        //The following are dependent on the Event Manager
        TickTockManager tickTockManager = managers.GetComponent<TickTockManager>();
        injectionBinder.Bind<ITickTockManager>().ToValue(tickTockManager).ToSingleton().CrossContext();

        CropManager cropManager = managers.GetComponent<CropManager>();
        injectionBinder.Bind<ICropManager>().ToValue(cropManager).ToSingleton().CrossContext();

        SelectionManager selectionManager = managers.GetComponent<SelectionManager>();
        injectionBinder.Bind<ISelectionManager>().ToValue(selectionManager).ToSingleton();

        //The following are dependent on the Selection Manager and Crop Manager
        UIPanelManager panelManager = UI.GetComponent<UIPanelManager>();
        injectionBinder.Bind<IUIPanelManager>().ToValue(panelManager).ToSingleton();
    }

    public void Inject(Object o)
    {
        injectionBinder.injector.Inject(o);
    }
}
