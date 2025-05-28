using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class EnemyBossBehaviourManager : EnemyAbstract
{
    [SerializeField] private float speedDownwards = 0.5f;
    [SerializeField] private float speedOscillates = 0.1f;
    private Vector3 centerPos = new Vector3(0, 3f, 0);
    private Vector3 centerRot = new Vector3(0, 0, 0);
    private Vector3 leftPos = new Vector3(-0.6f, 1, 0);
    private Vector3 rightPos = new Vector3(0.6f, 1, 0);

    [SerializeField] List<EnemyBossBehaviour> behaviours;

    private float behaviourTimer = 0f;
    private float behaviourDelay = 5f;

    private int currnetBehaviourIndex = 0;


    protected override void Start()
    {
        base.Start();
        this.FirstMovement();
        this.DeativeAllBehaviour();
        this.enemyController.EnemyDamageReceiver.SetInvulnerable(true);
    }
    
    protected void DeativeAllBehaviour()
    {
        foreach (var item in behaviours)
        {
            item.Deactive();
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyBossBehaviour();
    }

    private void LoadEnemyBossBehaviour()
    {
        if (behaviours.Count > 0) return;
        this.behaviours = transform.GetComponentsInChildren<EnemyBossBehaviour>().ToList();

    }

    private void FirstMovement()
    {
        StartCoroutine(DownwardsRoutine());
    }

    private void Update()
    {
        StateSelector();
    }

    private void StateSelector()
    {
        behaviourTimer += Time.deltaTime;
        if (behaviourTimer < behaviourDelay) return;
        behaviourTimer = 0;
        DeativeAllBehaviour();
        currnetBehaviourIndex = UnityEngine.Random.Range(0, behaviours.Count);
        behaviours[currnetBehaviourIndex].Active();
    }

    private IEnumerator RightToLeftRoutine()
    {
        while (transform.parent.position.x > leftPos.x)
        {
            transform.parent.Translate(Vector3.left * speedOscillates * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(LeftToRightRoutine());
    }

    private IEnumerator LeftToRightRoutine()
    {
        while (transform.parent.position.x < rightPos.x)
        {
            transform.parent.Translate(Vector3.right * speedOscillates * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(RightToLeftRoutine());
    }

    private IEnumerator DownwardsRoutine()
    {
        transform.parent.position = centerPos;
        transform.parent.rotation = Quaternion.Euler(centerRot);

        while (transform.parent.position.y > 1f)
        {
            transform.parent.Translate(Vector3.down * speedDownwards * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f);
        this.enemyController.EnemyDamageReceiver.SetInvulnerable(false);
        StartCoroutine(LeftToRightRoutine());
    }
}
