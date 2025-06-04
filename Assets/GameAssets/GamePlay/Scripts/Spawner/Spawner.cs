using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : GameMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected List<Object_Pool> prefabs;
    [SerializeField] protected List<Object_Pool> poolObjs;
    [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadPrefabs();
        this.LoadHolder();
    }


    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }

/*    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }*/

    public virtual Object_Pool Spawn(PoolTag prefabName, Vector3 spawnPos, Quaternion rotation, Transform holder = null)
    {
        
        Object_Pool prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.Log("Prefab not found: " + prefab.name);
            return null;
        }

        return Spawn(prefab, spawnPos, rotation, holder);
    }


    public virtual Object_Pool Spawn(Object_Pool prefabs, Vector3 pos, Quaternion rot, Transform holder = null)
    {
        Object_Pool newPrefab = this.GetObjectFromPool(prefabs);
        newPrefab.transform.SetPositionAndRotation(pos, rot);
        if (holder != null)
        {
            newPrefab.transform.parent = holder;
        }
        else
        {
            newPrefab.transform.parent = this.holder;
        }
        return newPrefab;
    }


    protected virtual Object_Pool GetPrefabByName(PoolTag prefabName)
    {
        return prefabs.Find(prefab => prefab._tag == prefabName);
    }

    protected virtual Object_Pool GetObjectFromPool(Object_Pool prefab)
    {
        foreach (Object_Pool poolObj in poolObjs)
        {
            if (prefab.name == poolObj.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Object_Pool newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }


    public virtual void Despawn(Object_Pool obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual bool CheckObjectInPool(Object_Pool prefab)
    {
        return poolObjs.Contains(prefab);
    }
}
