#region

using UnityEngine;

#endregion

public class GameMonoBehaviour : MonoBehaviour
{
    private ConfigManager _cfg;
    private GameManager _gameManager;
    private GamePlayManager _gamePlayManager;
    private Transform _privateTransform;
    private Board_UIs _uiManager;

    [HideInInspector]
    public Transform Transform
    {
        get
        {
            if (_privateTransform == null)
                _privateTransform = transform;

            return _privateTransform;
        }
    }

    public ConfigManager Cfg
    {
        get
        {
            if (_cfg == null)
                _cfg = ConfigManager.instance;

            return _cfg;
        }
    }

    public GamePlayManager GPm
    {
        get
        {
            if (_gamePlayManager == null)
                _gamePlayManager = GamePlayManager.Instance;

            return _gamePlayManager;
        }
    }

    public GameManager Gm
    {
        get
        {
            if (_gameManager == null)
                _gameManager = GameManager.Instance;

            return _gameManager;
        }
    }

    public Board_UIs Gui
    {
        get
        {
            if (_uiManager == null)
                _uiManager = Board_UIs.instance;

            return _uiManager;
        }
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void OnEnable()
    {
        this.ResetValue();
    }

    protected virtual void Start()
    {

    }

    protected virtual void LoadComponents()
    {

    }

    protected virtual void ResetValue()
    {

    }
}