using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextHUD : MonoBehaviour {
    public GameObject textPrefab;
    private float speed =0.5f;
    private float height = 30f;
    private float colorSpeed =0.4f;
    private  Color colorOffset=Color.black;
    private List<Text> textList = new List<Text>();
    private Text currenText;
    private bool isGet = false;

    void Awake () {
        textPrefab = transform.Find("Text").gameObject;
        textList.Add(textPrefab.GetComponent<Text>());
        textPrefab.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate(){
        foreach(Text text in textList){
            if (!text.gameObject.activeInHierarchy) continue;
            text.rectTransform.anchoredPosition -= Vector2.up *speed;
            text.color -= colorOffset * Time.deltaTime* colorSpeed;
            if (text.color.a <= 0.1){
                text.color = Color.clear;
                text.gameObject.SetActive(false);
            }
        }
    }
    public void Add(string str){
        isGet = false;
        foreach (Text text in textList){
            if (!text.gameObject.activeInHierarchy) continue;
            text.rectTransform.anchoredPosition -= Vector2.up * height;
            text.transform.position += Vector3.forward * 0.01f;
        }
        foreach (Text text in textList){
            if(!text.gameObject.activeInHierarchy){
                currenText = text;
                isGet = true;
                break;
            }
        }
        if(isGet){
            currenText.gameObject.SetActive(true);
            ShowText(str);
        }else{
            GameObject go= Instantiate(textPrefab, transform);
            currenText = go.GetComponent<Text>();
            textList.Add(currenText);
            ShowText(str);
        }
    }
    void ShowText(string str){
        currenText.transform.localPosition = Vector3.zero;
        currenText.rectTransform.anchoredPosition = Vector2.zero;
        currenText.text = str;
        currenText.color = Color.red;

    }
}
