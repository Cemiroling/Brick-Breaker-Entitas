using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;
    public Globals globals;
    public RectTransform uiRoot;
    public Text text;
    public float timer;

    void Start()
    {
        _contexts = Contexts.sharedInstance;
        if (!_contexts.game.hasGlobals)
            _contexts.game.SetGlobals(globals);
        else
            _contexts.game.ReplaceGlobals(globals);
        if (!_contexts.game.hasUIRoot)
            _contexts.game.SetUIRoot(uiRoot);
        else
            _contexts.game.ReplaceUIRoot(uiRoot);
        if (!_contexts.game.hasGlobals)
            _contexts.game.SetText(text);
        else
            _contexts.game.ReplaceText(text);
        JsonManager.Serialize("save.json");

        _contexts.game.SetGameData(JsonManager.Deserialize("save.json"));

        _systems = CreateSystems(_contexts, _systems);

        _systems.ActivateReactiveSystems();
        _systems.Initialize();

        timer = 0;
    }

    private Systems CreateSystems(Contexts contexts, Systems _systems)
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
            .Add(new CooldownSystem(contexts))
            .Add(new CheckLoseSystem(contexts))
            .Add(new CheckWinSystem(contexts))
            //.Add(new RestartSystem(contexts, _systems))

            .Add(new AddBlockViewSystem(contexts))
            .Add(new AddBallViewSystem(contexts))
            .Add(new AddBoundaryViewSystem(contexts))
            .Add(new AddPointerViewSystem(contexts))
            .Add(new AddWinViewSystem(contexts))
            .Add(new AddLoseViewSystem(contexts));

    }

    // Update is called once per frame
    void Update()
    {
        if(_contexts.game.GetGroup(GameMatcher.Restart).GetEntities().Length != 0)
        {
            foreach (var ent in _contexts.game.GetEntities())
            {
                ent.isDestroy = true;
            }
            _systems.Execute();
            _systems.DeactivateReactiveSystems();
            _systems.TearDown();
            _systems.ClearReactiveSystems();
            _contexts.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (_contexts.game.GetGroup(GameMatcher.SetMainMenu).GetEntities().Length != 0)
        {
            foreach (var ent in _contexts.game.GetEntities())
            {
                ent.isDestroy = true;
            }
            _systems.Execute();
            _systems.DeactivateReactiveSystems();
            _systems.TearDown();
            _systems.ClearReactiveSystems();
            _contexts.Reset();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        _systems.Execute();
    }
}