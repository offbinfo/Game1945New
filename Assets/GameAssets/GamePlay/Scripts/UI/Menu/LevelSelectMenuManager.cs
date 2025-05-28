using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenuManager : MenuController
{
    [SerializeField] List<Image> imagesButtonSelect = new List<Image>();
    protected override void LoadMenuType()
    {
        this.menuType = Menu.LEVEL_SELECT;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImages();
    }

    private void LoadImages()
    {
        imagesButtonSelect.Clear(); 
        Transform images = transform.Find("Level");
        
        foreach (Transform image in images)
        {
            Transform buttonChild = image.Find("Button");
            if (buttonChild == null) continue;
            Transform imageChild = buttonChild.Find("Image");
            if (imageChild == null) continue;
            this.imagesButtonSelect.Add(imageChild.GetComponentInChildren<Image>());
        }
        HideAllLevel();
    }

    private void Update()
    {
        this.HidesLevel();
    }

    private void HidesLevel()
    {
        imagesButtonSelect.Take(DataLoaderAndSaver.Instance.PlayerData.process).ToList().ForEach(image => image.gameObject.SetActive(false));
    }

    private void HideAllLevel()
    {
        imagesButtonSelect.ForEach(image => image.gameObject.SetActive(true));
    }
}
