using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MenuController
{

    public GameObject pauseMenuUI;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnEnable()
    {
        this.Pause();
    }

    private void OnDisable()
    {
        this.Resume();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    protected override void LoadMenuType()
    {
        this.menuType = Menu.PAUSE;
    }
}
