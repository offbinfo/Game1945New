using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : GameMonoBehaviour
{
    [SerializeField] private List<MenuController> menuList;
    [SerializeField] private MenuController lastActiveMenu;

    public MenuController LastActiveMenu => lastActiveMenu;

    private static MenuManager instance;

    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MenuManager>();
            }
            return instance;
        }
    }

    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMenuList();
    }

    protected override void Awake()
    {
        base.Awake();
        if (MenuManager.instance != null) Debug.LogError("Only allow 1 instance");
        MenuManager.instance = this;



    }
    protected override void Start()
    {
        base.Start();
        this.HideMenus();
        this.SwitchCanvas(Menu.MAIN_MENU);
    }
    protected virtual void LoadMenuList()
    {
        Transform prefabsObj = transform.Find("Menus");
        menuList.Clear();
        foreach (Transform prefab in prefabsObj)
        {
            MenuController menuController = prefab.GetComponent<MenuController>();
            if (menuController == null) continue;
            this.menuList.Add(menuController);
        }
        
    }

    public void HideMenus()
    {
        menuList.ForEach(m => m.gameObject.SetActive(false));
    }

    public void SwitchCanvas(Menu type)
    {
        if (lastActiveMenu != null)
        {
            lastActiveMenu.gameObject.SetActive(false);
        }

        MenuController menu = menuList.Find(m => m.MenuType == type);
        if (menu == null) return;

        if (menu != null)
        {
            menu.gameObject.SetActive(true);
            lastActiveMenu = menu;
        }
        else
        {
            Debug.LogError($"Menu {type} not found!");
        }
    }

    public MenuController GetMenu(Menu type)
    {
        return menuList.Find(m => m.MenuType == type);
    }
}
