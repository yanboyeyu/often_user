using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneProgressBar : MonoBehaviour {

    public static LoadSceneProgressBar _instance;
    private GameObject bg;
    private Slider progressbar;
    private Text progressbarText;
    private bool isAsyn = false;
    private AsyncOperation ao = null;
    private void Awake()
    {
        _instance = this;
        bg = transform.Find("BG").gameObject;
        progressbar = transform.Find("BG/sld_progressbar").GetComponent<Slider>();
        progressbarText = transform.Find("BG/sld_progressbar/Text").GetComponent<Text>();
        gameObject.SetActive(false);
    }
    private void Update()
    {
       if(isAsyn){
            progressbar.value = ao.progress;
            progressbarText.text = progressbar.value * 100 + "%";
        }
    }

    public void Show(AsyncOperation ao)
    {
        gameObject.SetActive(true);
        bg.SetActive(true);
        isAsyn = true;
        this.ao = ao;
    }
}
