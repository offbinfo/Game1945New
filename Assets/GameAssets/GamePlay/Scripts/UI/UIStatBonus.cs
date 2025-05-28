using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatBonus : GameMonoBehaviour
{
    [SerializeField] protected StatusBonusLevel statusBonusLevel;
    protected List<int> cointUpdate = new List<int>() { 500, 1000, 2000, 4000};


    [SerializeField] protected List<Image> listNode;
    [SerializeField] protected TMP_Text txtCoin;
    [SerializeField] protected Button btnUpdate;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNode();
        this.LoadTxtCoin();
        this.LoadButton();
    }

    private void LoadButton()
    {
        this.btnUpdate = transform.GetComponentInChildren<Button>();
    }

    private void LoadTxtCoin()
    {
        this.txtCoin = transform.Find("Sympol").GetComponentInChildren<TMP_Text>();
    }

    private void LoadNode()
    {
        Transform node = transform.Find("Node");
        Transform nodeList = node.Find("NodeList");
        foreach (Transform item in nodeList)
        {
            listNode.Add(item.GetComponentInChildren<Image>());
        }
    }

    public void SetStatusBonusLevel(StatusBonusLevel statusBonusLevel)
    {
        this.statusBonusLevel = statusBonusLevel;
    }
    protected override void Start()
    {
        base.Start();
        this.btnUpdate.onClick.AddListener(UpdateOneLevel);
    }
    private void Update()
    {
        OnViewLevel();
        OnViewCoin();
    }

    public virtual void UpdateStat(int level)
    {
        this.statusBonusLevel.level += level;
    }

    private void OnViewLevel()
    {
        listNode.Take(statusBonusLevel.level).ToList().ForEach(x => x.color = Color.red);
    }

    private void OnViewCoin()
    {
        if (statusBonusLevel.level < cointUpdate.Count)
        {
            txtCoin.text = cointUpdate[statusBonusLevel.level].ToString();
        }
        else
        {
            txtCoin.text = "MAX";
        }
    }
    
    public void UpdateOneLevel()
    {
        int coint = DataLoaderAndSaver.Instance.PlayerData.coint;
        if (statusBonusLevel.level < cointUpdate.Count)
        {
            if (coint >= cointUpdate[statusBonusLevel.level])
            {
                coint -= cointUpdate[statusBonusLevel.level];
                UpdateStat(1);
                DataLoaderAndSaver.Instance.PlayerData.coint = coint;
                DataLoaderAndSaver.Instance.SaveData();
            }
        }
    }
}
