using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public struct FoodItem
{
    public FoodItem(string _picPath,string _audio_question,string _audioPath_2,
        string _audioPath_3,string _audioPath_4,string _audioPath_5)
    {
        picPath = _picPath;
        audio_question = _audio_question;
        audioPath_2 = _audioPath_2;
        audioPath_3 = _audioPath_3;
        audioPath_4 = _audioPath_4;
        audioPath_5 = _audioPath_5;
    }

    public string picPath;
    public string audio_question;
    public string audioPath_2;
    public string audioPath_3;
    public string audioPath_4;
    public string audioPath_5;
}

public struct string3
{
    public string name;
    
    public string aduioPath; 
    public string picPath;

    public string3(string _name, string _aduioPath, string _picPath)
    {
        name = _name;
        aduioPath = _aduioPath;
        picPath = _picPath;
    }
}



//数据相关
public class DataCenter
{
    //食物详细信息  用食物名做索引
    public Dictionary<string, FoodItem> foodData;

    public List<string> foodNames;

    //同一颜色索引
    public Dictionary<string, List<string>> colorFoodList;
    //同一类型索引
    public Dictionary<string, List<string>> typeFoodList;

    public List<string3> colorNames;

    public List<string3> typeNames;

    public List<string3> numAudios;

    public void InitData()
    {
        foodData = new Dictionary<string, FoodItem>();
        foodNames = new List<string>();
        colorFoodList = new Dictionary<string, List<string>>();
        typeFoodList = new Dictionary<string, List<string>>();
        colorNames = new List<string3>();
        typeNames = new List<string3>();
        numAudios = new List<string3>();

        GetBaseDataFromFile();
        GetFoodDateFromFile();


    }


    async void GetFoodDateFromFile()
    {
        TextAsset content = await Addressables.LoadAssetAsync<TextAsset>("").Task;
        JSONObject js = JSONObject.Create(content.text);

        //下面开始赋值
        for (int i = 0; i < js.Count; i++)
        {
            JSONObject _nowItem = js[i];
            FoodItem foodItem = new FoodItem(_nowItem.GetField("picPath").str, _nowItem.GetField("audio_question").str, _nowItem.GetField("audioPath_2").str,
                _nowItem.GetField("audioPath_3").str, _nowItem.GetField("audioPath_4").str, _nowItem.GetField("audioPath_5").str);
            string _name = _nowItem.GetField("name").str;
            foodNames.Add(_name);
            foodData.Add(_name, foodItem);
            colorFoodList[_nowItem.GetField("color").str].Add(_name);
            typeFoodList[_nowItem.GetField("type").str].Add(_name);
        }
    }

    async void GetBaseDataFromFile()
    {
        TextAsset content = await Addressables.LoadAssetAsync<TextAsset>("").Task;
        JSONObject js = JSONObject.Create(content.text);

        JSONObject nowFiled;
        //颜色
        nowFiled = js.GetField("color");
        for (int i = 0; i < nowFiled.list.Count;i++)
        {
           
            string3 _str3 = new string3(nowFiled.list[i].GetField("name").str, nowFiled.list[i].GetField("audio").str, nowFiled.list[i].GetField("pic").str);
            colorNames.Add(_str3);
        }

        //类型
        nowFiled = js.GetField("types");
        for (int i = 0; i < nowFiled.list.Count; i++)
        {
            string3 _str3 = new string3(nowFiled.list[i].GetField("name").str, nowFiled.list[i].GetField("audio").str, nowFiled.list[i].GetField("pic").str);
            typeNames.Add(_str3);
        }

        //数字
        nowFiled = js.GetField("nums");
        for (int i = 0; i < nowFiled.list.Count; i++)
        {
            string key = nowFiled.list[i].keys[0];
            string3 _str2 = new string3(key, nowFiled.list[i].GetField(key).str,"");
            numAudios.Add(_str2);
        }


    }
}
