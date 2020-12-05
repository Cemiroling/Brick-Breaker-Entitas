using Entitas;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    public Globals globals;
    public RectTransform uiRoot;
    public Text text;

    void Start()
    {
        Contexts contexts = Contexts.sharedInstance;
        contexts.game.SetGlobals(globals);
        contexts.game.SetUIRoot(uiRoot);
        contexts.game.SetText(text);
        JsonManager.Serialize("save.json");

        contexts.game.SetGameData(JsonManager.Deserialize("save.json"));

        _systems = CreateSystems(contexts);


        _systems.Initialize();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializeBlockGridSystem(contexts))
            .Add(new InitializeBoundariesSystem(contexts))
            .Add(new InitializeTimerSystem(contexts))
            .Add(new InitializePointerSystem(contexts))

            .Add(new ClickInputSystem(contexts))
            .Add(new ProcessCollisionSystem(contexts))
            .Add(new DestroyEntitiesSystem(contexts))
            .Add(new TimerSystem(contexts))
            .Add(new MovingBlockSystem(contexts))
            .Add(new ChangePointerPositionSystem(contexts))
            .Add(new SetNewTurnSystem(contexts))

            .Add(new AddBlockViewSystem(contexts))
            .Add(new AddBallViewSystem(contexts))
            .Add(new AddBoundaryViewSystem(contexts))
            .Add(new AddPointerViewSystem(contexts));

    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
    }
}