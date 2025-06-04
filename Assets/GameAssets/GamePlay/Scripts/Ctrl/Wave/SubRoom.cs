using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRoom : MonoBehaviour
{
    public FormationBase Formation;
    public List<PathCreator> paths;

    public void LoadPaths()
    {
        if (paths.Count > 0) paths.Clear();
        Transform prefabsObj = transform.Find("MovePaths");
        foreach (Transform prefab in prefabsObj)
        {
            this.paths.Add(prefab.GetComponent<PathCreator>());
        }

        Formation = transform.GetComponentInChildren<FormationBase>();
    }
}
