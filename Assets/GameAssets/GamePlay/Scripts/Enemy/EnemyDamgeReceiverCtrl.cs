using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamgeReceiverCtrl : GameMonoBehaviour
{
    [SerializeField]
    private EnemyDamageReceiver receiverBody;
    [SerializeField]
    private List<EnemyDamageReceiver> receiverTurrets;

/*    protected override void Start()
    {
        base.Start();
        receiverBody.gameObject.SetActive(false);
    }*/

    public void ResetReceiver()
    {
        foreach (EnemyDamageReceiver receiver in receiverTurrets)
        {
            receiver.gameObject.SetActive(true);
        }
        receiverBody.gameObject.SetActive(false);
    }

    public void ActiveReceiverBody()
    {
        bool isActive = true;
        foreach (EnemyDamageReceiver receiver in receiverTurrets)
        {
            if(receiver.gameObject.activeSelf) isActive = false;
        }

        if(isActive)
        {
            receiverBody.gameObject.SetActive(true);
        }
    }

    public bool IsBodyActive()
    {
        return receiverBody.gameObject.activeSelf;
    }
}
