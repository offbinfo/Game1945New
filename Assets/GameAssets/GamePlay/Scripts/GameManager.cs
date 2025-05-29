using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GameMonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    [SerializeField] bool isStartUpDone = false;
    [SerializeField] Transform spawnPos;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    [SerializeField] Transform currentShipPlayer;

    [SerializeField] Dictionary<float, int> timeCoint = new Dictionary<float, int>() { { 60, 300 }, { 120, 200 }, { 180, 100 } };

    [SerializeField] int coint = 0;

    private bool isEndlevelProcess = false;

    public int Coint { get => coint; }

    private float onLoseDelay = 1f;
    private float onLoseTimer = 0f;
    private float onWinDelay = 2f;
    private float onWinTimer = 0f;

    private float scrollSpeed = 0.5f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();
    }

    private void LoadPoint()
    {
        this.spawnPos = GameObject.Find("SpawnPoint").transform;
        if (this.spawnPos == null)
        {
            this.spawnPos.position = new Vector2(0, -2);
        }
        this.startPos = GameObject.Find("StartPoint").transform;
        if (this.startPos == null)
        {
            this.startPos.position = new Vector2(0, 0.5f);
        }
        this.endPos = GameObject.Find("EndPoint").transform;
        if (this.endPos == null)
        {
            this.endPos.position = new Vector2(0, 2f);
        }
    }

    protected override void Start()
    {
        base.Start();
        //AudioManager.Instance.PlayMusic("GamePlay");
        StartCoroutine(this.LoadStartUp());
    }

    private void Update()
    {
        if (isEndlevelProcess) return;
/*        CheckOnWinLevel();
        CheckOnLoseLevel();*/
    }

    private IEnumerator LoadStartUp()
    {
        while (true)
        {
            if (GameCtrl.Instance.CurrentShip != null) break;
            yield return new WaitForEndOfFrame();
        }
        currentShipPlayer = GameCtrl.Instance.CurrentShip;
        this.AddStatBonus();
        currentShipPlayer.position = spawnPos.position;
        while (currentShipPlayer.position != startPos.position)
        {
            currentShipPlayer.position = Vector2.MoveTowards(currentShipPlayer.position, startPos.position, 0.5f * Time.deltaTime);
            BackgroundManager.Instance.Backgrounds.SetScrollSpeed(scrollSpeed);
            SliderSkill1.Intance.StartCountDown();
            SliderSkill2.Intance.StartCountDown();
            yield return new WaitForEndOfFrame();
        }
        isStartUpDone = true;
        StartUp();
    }

    public void SetShipPlayerMovementAndShooting(GameObject ship, bool isSet)
    {
        Transform currentShip = ship.transform;
        ShipMovement shipMovement = currentShip.GetComponentInChildren<ShipMovement>();
        ShipShooting shipShooting = currentShip.GetComponentInChildren<ShipShooting>();
        ShipSubShooting shipSubShooting = currentShip.GetComponentInChildren<ShipSubShooting>();
        shipMovement.enabled = isSet;
        shipShooting.enabled = isSet;
        shipSubShooting.enabled = isSet;
    }

    public void StartUp()
    {
        if (isStartUpDone)
        {
            BackgroundManager.Instance.Backgrounds.ResetScrollSpeed();
            SetShipPlayerMovementAndShooting(currentShipPlayer.gameObject, true);
            LevelManager.Instance.StartLevel();
        }
    }

/*    public void CheckOnLoseLevel()
    {
        if (GameCtrl.Instance.CurrentShip == null)
        {
            if (onLoseTimer < onLoseDelay)
            {
                onLoseTimer += Time.deltaTime;
                return;
            }
            LevelOver();
            isEndlevelProcess = true;
        }

    }

    public void CheckOnWinLevel()
    {
        if (LevelManager.Instance.CurrentState == State.Completed)
        {
            if (onWinTimer < onWinDelay)
            {
                onWinTimer += Time.deltaTime;
                return;
            }
            SetShipPlayerMovementAndShooting(currentShipPlayer.gameObject, false);
            currentShipPlayer.Translate(Vector2.up * 2f * Time.deltaTime);
            BackgroundManager.Instance.Backgrounds.SetScrollSpeed(scrollSpeed);
            if (currentShipPlayer.position.y < endPos.position.y) return;
            LevelWin();
            isEndlevelProcess = true;
        }
    }*/

/*    public void LevelWin()
    {
        MenuManager.Instance.SwitchCanvas(Menu.GAME_WIN);
        foreach (var item in timeCoint)
        {
            if (Time.time < item.Key)
            {
                coint += item.Value;
                break;
            }
            else
            {
                coint += 50;
            }
        }
        //AudioManager.Instance.PlaySFX("Win");
        DataLoaderAndSaver.Instance.PlayerData.coint += coint;
        DataLoaderAndSaver.Instance.PlayerData.process = DataLoaderAndSaver.Instance.PlayerData.process <= DataLoaderAndSaver.Instance.CurrentLevel ? DataLoaderAndSaver.Instance.CurrentLevel + 1 : DataLoaderAndSaver.Instance.PlayerData.process;
        DataLoaderAndSaver.Instance.SaveData();
    }

    public void LevelOver()
    {
        MenuManager.Instance.SwitchCanvas(Menu.GAME_OVER);
        //AudioManager.Instance.PlaySFX("Lose");
        DataLoaderAndSaver.Instance.PlayerData.coint += coint;
        DataLoaderAndSaver.Instance.SaveData();
    }

    public void AddCoin(int coin)
    {
        coint += coin;
    }*/

    public void AddStatBonus()
    {
        PlayerData data = DataLoaderAndSaver.Instance.PlayerData;
        ShipController currentShip = GameCtrl.Instance.CurrentShip.GetComponentInChildren<ShipController>();


        int healLevel = data.data.Where(x => x.stat == Stat.Heath).FirstOrDefault().level;
        ShipDamageReceiver shipHealth = currentShip.ShipDamageReceiver;
        shipHealth.SetMaxHealthPointBonus(healLevel * 20);

        int damageLevel = data.data.Where(x => x.stat == Stat.MainAttack).FirstOrDefault().level;
        ShipShooting shipShooting = currentShip.ShipShooting;
        ShipSubShooting shipSubShooting = currentShip.ShipSubShooting;
        shipShooting.SetDamageBonus(currentShip.ShipProfile.mainDamage * 0.05f * damageLevel);
        shipSubShooting.SetDamageBonus(currentShip.ShipProfile.subDamage * 0.05f * damageLevel);

        int coolDownLevel = data.data.Where(x => x.stat == Stat.Cooldown).FirstOrDefault().level;
        currentShip.GetComponentInChildren<PowerUpAbility>().SetBonusCooldownValue(-coolDownLevel * 1f);
        currentShip.GetComponentInChildren<ShieldAbility>().SetBonusCooldownValue(-coolDownLevel * 1f);


        int shieldLevel = data.data.Where(x => x.stat == Stat.ShieldBonus).FirstOrDefault().level;
        ShieldAbility shipShield = currentShip.GetComponentInChildren<ShieldAbility>();
        shipShield.SetBonusTimeExits(shieldLevel * 0.5f);

        int poweUpLevel = data.data.Where(x => x.stat == Stat.PowerupBonus).FirstOrDefault().level;

        PowerUpAbility powerUpAbility = currentShip.GetComponentInChildren<PowerUpAbility>();

        powerUpAbility.SetBonusTimeExits(poweUpLevel * 0.5f);
    }

}
