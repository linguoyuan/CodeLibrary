using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.Networking;
using System.IO;

namespace UDMAF
{
    public class CardsData : MonoBehaviour
    {
        // 卡片精灵字典，根据key值得到对应的卡片sprite
        public Dictionary<string, Sprite> CardSpriteDict;

        //输入的语音字串转换为新版带颜色的字串
        public Dictionary<string, string> VoiceStrDict;

        [System.Serializable]
        public struct CardStruct
        {
            public string key;
            public Sprite sprite;
        }

        public CardStruct[] CardDatas;
        private Dictionary<string, string> CardPathKeyWordDic = new Dictionary<string, string>();
        public void DataStart()
        {
            // 字典内容
            CardSpriteDict = new Dictionary<string, Sprite>();
            for (int i = 0; i < CardDatas.Length; i++)
            {
                if (!CardSpriteDict.ContainsKey(CardDatas[i].key))
                {
                    CardSpriteDict.Add(CardDatas[i].key, CardDatas[i].sprite);
                    CardPathKeyWordDic = new Dictionary<string, string>();
                    CardPathKeyWordDic.Add(CardDatas[i].key, CardDatas[i].key);
                    GameManager.Instance.CardDicList.Add(CardPathKeyWordDic);
                }
            }

            GetVoiceStrData();
        }


        private void GetVoiceStrData()
        {
            //StartCoroutine(ReadJsonFile(Path.Combine(Application.streamingAssetsPath,"VoiceStr1.json")));
            StartCoroutine(ReadJsonFile2(Path.Combine(Application.streamingAssetsPath,"VoiceStr2.json")));      
        }

        //JSONObject方式解析
        private IEnumerator ReadJsonFile(string path)
        {
            Debug.Log(path);
            string jsonStr;
            UnityWebRequest request = UnityWebRequest.Get(path);
            yield return request.SendWebRequest();
            jsonStr = request.downloadHandler.text;
            Debug.Log("jsonStr:" + jsonStr);
            JSONObject js = JSONObject.Create(jsonStr);
            JSONObject nowFiled;
            nowFiled = js.GetField("list");
            for (int i = 0; i < nowFiled.list.Count; i++)
            {
                string key = nowFiled.list[i].keys[0];
                string strColor = nowFiled.list[i].GetField(key).str;
                Debug.Log("key = " + key);
                Debug.Log("strColor = " + strColor);
            }
        }

        //litjson方式解析
        private IEnumerator ReadJsonFile2(string path)
        {
            Debug.Log(path);
            string jsonStr;
            UnityWebRequest request = UnityWebRequest.Get(path);
            yield return request.SendWebRequest();
            jsonStr = request.downloadHandler.text;
            Debug.Log(jsonStr);

            JsonData json = JsonMapper.ToObject(jsonStr);
            
            JsonData listJson = json["list"];
            //Debug.Log(listJson.ToString());array
            Debug.Log("listJson.Count = " + listJson.Count);
            for (int i = 0; i < listJson.Count; i++)
            {
                JsonData item = new JsonData();
                item = listJson[i];
                Debug.Log(item["0"]);
                Debug.Log(item["1"]);
            }

        }
    }
}
