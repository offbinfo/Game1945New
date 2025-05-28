using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class SliderSkill : GameMonoBehaviour
{
    [SerializeField] protected Slider slider;
    public Slider Slider => slider;

    protected Transform currentShip;

    public GameObject countDown;

    public bool isCountDown = false;

    public float timeRemain = 0;

    public float cooldownValue;


    protected override void Start()
    {
        base.Start();
        StartCoroutine(this.SetSlider());
        isCountDown = false;
        timeRemain = 0;

    }

    protected virtual void Update()
    {
        if (!isCountDown)
        {
            countDown.SetActive(false);
            return;
        }
        timeRemain -= Time.deltaTime;
        this.slider.value = timeRemain;
        if (timeRemain <= 0)
        {
            isCountDown = false;
            timeRemain = 0;
            this.slider.value = 0;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCountDown();
        this.LoadSlider();

    }


    public virtual void SetupCooldown()
    {
        
    }
    public virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = transform.GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);
    }

    public virtual void LoadCountDown()
    {
        countDown = transform.Find("CountDown").gameObject;
    }

    public virtual IEnumerator SetSlider()
    {
        
        while (true)
        {
            currentShip = GameCtrl.Instance.CurrentShip;
            if (currentShip != null)
            { 
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public virtual void StartCountDown()
    {
        this.isCountDown = true;
        countDown.SetActive(true);
    }

    public virtual void SetSliderValue()
    {

    }
}
