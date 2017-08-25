using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIManager : MonoBehaviour {

    public static WorldUIManager_instance;
    public GameObject hpBarPrefab;
    public GameObject textHUDPrefab;

    private void Awake()
    {
        _instance = this;
    }

    public GameObject GetHpBar(GameObject target,float height){
        GameObject go = Instantiate(hpBarPrefab,transform);
        go.GetComponent<UIFollowTarget>().targetgo = target;
        go.GetComponent<UIFollowTarget>().height = height;
        return go;
    }
    public GameObject GetHUDText(GameObject target,float height)
    {
        GameObject go = Instantiate(textHUDPrefab, transform);
        go.GetComponent<UIFollowTarget>().targetgo = target;
        go.GetComponent<UIFollowTarget>().height = height;
        return go;
    }
}
