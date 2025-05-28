using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : GameMonoBehaviour
{
    [Header("EnemyModel")]
    [SerializeField] protected Animator baseAnimator;
    public Animator BaseAnimator => baseAnimator;

    [SerializeField] protected Animator engineAnimator;
    public Animator EngineAnimator => engineAnimator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEngineAnimator();
        this.LoadBaseAnimator();
    }

    protected virtual void LoadEngineAnimator()
    {
        if (this.engineAnimator != null) return;
        Transform engine = transform.Find("Engine");
        this.engineAnimator = engine.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadEngineAnimator", gameObject);
    }
    protected virtual void LoadBaseAnimator()
    {
        if (this.baseAnimator != null) return;
        Transform baseModel = transform.Find("Base");
        this.baseAnimator = baseModel.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadBaseAnimator", gameObject);
    }
}
