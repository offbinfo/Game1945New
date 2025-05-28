using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelection : GameMonoBehaviour
{
    public List<GameObject> ships;

    public int shipIndex = 0;

    private static ShipSelection instance;

    public static ShipSelection Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ShipSelection>();
            }
            return instance;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        if (ShipSelection.instance != null) Debug.LogError("Only allow 1 instance");
        ShipSelection.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        shipIndex = PlayerPrefs.GetInt("SelectedShip", 0);
        this.SwitchShip();
    }

    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipList();
    }

    private void LoadShipList()
    {
        if (ships.Count > 0) return;
        foreach (Transform prefab in transform)
        {
            if (prefab.gameObject.tag == "Player")
            {
                this.ships.Add(prefab.gameObject);
            }
        }

        
    }

    public void Update()
    {
        this.SetupShipPos();
    }

    protected void SetupShipPos()
    {
        if (MenuManager.Instance.LastActiveMenu.MenuType == Menu.MAIN_MENU)
        {
            this.transform.position = new Vector3(0, 0.25f, 0);
            this.transform.localScale = Vector3.one;
        }
        else if (MenuManager.Instance.LastActiveMenu.MenuType == Menu.SHIP_SELECTION)
        {
            this.transform.position = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            
        }
    }

    public void SwitchShip()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            if (i == shipIndex)
            {
                ships[i].SetActive(true);
            }
            else
            {
                ships[i].SetActive(false);
            }
        }
    }

    public void NextShip()
    {
        shipIndex++;
        if (shipIndex > ships.Count - 1)
        {
            shipIndex = 0;
        }
        this.SwitchShip();
    }

    public void PreviousShip()
    {
        shipIndex--;
        if (shipIndex < 0)
        {
            shipIndex = ships.Count - 1;
        }
        this.SwitchShip();
    }

    public void ResetIndex()
    {
        shipIndex = PlayerPrefs.GetInt("SelectedShip");
    }

    public void SelectShip()
    {
        PlayerPrefs.SetInt("SelectedShip", shipIndex);
    }

    public void ResetShip()
    {
        PlayerPrefs.SetInt("SelectedShip", 0);
    }


    public string CurrentIndexShipName()
    {
        string path = "Ship/"+ ships[shipIndex].transform.name;
        
        string resPath = "Ship/" + transform.name;
        ShipProfileSO shipProfile = Resources.Load<ShipProfileSO>(path);
        if (shipProfile != null)
        {
            return shipProfile.shipName;
        }
        else
        {
            return "No Name";
        }
    }

}
