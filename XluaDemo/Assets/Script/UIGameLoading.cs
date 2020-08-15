using System.Collections;
using System.Collections.Generic;
#if !UNITY_WEBPLAYER
using System.IO;
#endif
using UnityEngine;
using UnityEngine.UI;
 using System;

public class UIGameLoading : MonoBehaviour
{ 
    public Text txtVersion;
    public Text txtRes;
    public Text txtSize;
    public Text txtSize2;
    public Text txtSpeed;
    public Slider progressBar;
    public GameObject objMessage;
    public Text txtContent;
    public Button btnConfirm;
    public GameObject Tip;

#if !UNITY_WEBPLAYER

 

    public void Start()
    { 
            StartLogin(); 
      
    }
     
 
 

    private void StartLogin()
    {
        StartCoroutine(InitGame());
    }

    private IEnumerator InitGame()
    {
        txtRes.text = "游戏初始化";
        progressBar.gameObject.SetActive(true);
        txtSpeed.gameObject.SetActive(false);
        txtSize.gameObject.SetActive(false);
        txtSize2.gameObject.SetActive(false);
        progressBar.value = 0f;
        yield return new WaitForEndOfFrame();

        LoadTools.Init(); 
        txtRes.text = "";
        progressBar.gameObject.SetActive(false); 
        GameObject go = Resources.Load<GameObject>("Main");
        Instantiate(go);
        Destroy(this.gameObject);
        AppBoot.instance.Init();
    }
     
    
#endif
}

public class AssetBundleInfo
{
    public string name;
    public string md5;
    public float size;
    public int type;
    public int level;

    public AssetBundleInfo(int type, string name, string md5, float size,int level)
    {
        this.type = type;
        this.name = name;
        this.size = size;
        this.md5 = md5;
        this.level = level;
    }

}
