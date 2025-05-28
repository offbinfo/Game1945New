using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WaveNotification : GameMonoBehaviour
{
    private static WaveNotification instance;
    public static WaveNotification Instance { get => instance; }

    [SerializeField] private float timeShow = 2f;

    [SerializeField] private TMP_Text textGUI;

    [SerializeField] private string TextGeneral = "wave 0/0" ;

    [SerializeField] private int currentTextWave = 0;
    [SerializeField] private int maxTextWave = 0;

    protected override void Awake()
    {
        base.Awake();
        WaveNotification.instance = this;
    }

    protected void Update()
    {
        this.textGUI.text = TextGeneral;
        if (currentTextWave <=0 )
        {
            TextGeneral = "Ready to start";
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    public void SetTimeShow(float timeShow)
    {
        this.timeShow = timeShow;
    }

    private void LoadTextMeshPro()
    {
        if (textGUI != null) return;
        this.textGUI = transform.GetComponentInChildren<TMP_Text>();
        Debug.Log(transform.name + ": LoadTextMeshPro", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.HideText();
    }

    public void ShowTextInTime()
    {
        this.textGUI.gameObject.SetActive(true);
        StartCoroutine(this.HideText(this.timeShow));
    }
    public void SetMaxWave(int wave)
    {
        this.maxTextWave = wave;
        this.SetTextGeneral();
    }

    public void SetCurrentWave(int wave)
    {
        this.currentTextWave = wave;
        this.SetTextGeneral();
    }

    private void SetTextGeneral()
    {
        this.TextGeneral = $"WAVE {currentTextWave}/{maxTextWave}";
    }

    private IEnumerator HideText(float time = 0)
    {
        yield return new WaitForSeconds(timeShow);
        this.textGUI.gameObject.SetActive(false);
    }
}
