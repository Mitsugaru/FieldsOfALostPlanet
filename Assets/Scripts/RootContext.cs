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
        GameObject resources = GameObject.Find("SpriteResources");
        GameObject UI = GameObject.Find("UI");

        injectionBinder.Bind<IRootContext>().ToValue(this).ToSingleton().CrossContext();

        //Event manager goes first as it is the back bone for everything
        EventManager eventManager = managers.GetComponent<EventManager>();
        injectionBinder.Bind<IEventManager>().ToValue(eventManager).ToSingleton().CrossContext();

        // Dependent on event manager
        SelectionManager selectionManager = managers.GetComponent<SelectionManager>();
        injectionBinder.Bind<ISelectionManager>().ToValue(selectionManager).ToSingleton();

        TickTockManager tickTockManager = managers.GetComponent<TickTockManager>();
        injectionBinder.Bind<ITickTockManager>().ToValue(tickTockManager).ToSingleton().CrossContext();

        CropManager cropManager = managers.GetComponent<CropManager>();
        injectionBinder.Bind<ICropManager>().ToValue(cropManager).ToSingleton().CrossContext();

        // Depends on selection manager 
        TileManager tileManager = managers.GetComponent<TileManager>();
        injectionBinder.Bind<ITileManager>().ToValue(tileManager).ToSingleton();

        //The following are dependent on the Event Manager
        TerrainSpriteManager terrainSpriteManager = resources.GetComponent<TerrainSpriteManager>();
        injectionBinder.Bind<ITerrainSpriteManager>().ToValue(terrainSpriteManager).ToSingleton();
        
        //The following are dependent on the Tile Manager and Crop Manager
        UIPanelManager panelManager = UI.GetComponent<UIPanelManager>();
        injectionBinder.Bind<IUIPanelManager>().ToValue(panelManager).ToSingleton();

        //UI scripts that require references
        TerrainPanelScript terrainPanelScript = UI.GetComponentInChildren<TerrainPanelScript>();
        injectionBinder.injector.Inject(terrainPanelScript);

        TileInfoPanelScript tileInfoPanelScript = UI.GetComponentInChildren<TileInfoPanelScript>();
        injectionBinder.injector.Inject(tileInfoPanelScript);

        // Manual injection - remove
        HexagonBoard hexBoard = UI.GetComponentInChildren<HexagonBoard>();
        injectionBinder.injector.Inject(hexBoard);
    }

    public void Inject(Object o)
    {
        injectionBinder.injector.Inject(o);
    }
}
