using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour
{
    public PlayerData player;

    void Start()
    {
        //讀取玩家資料
        var loadPlayerData = LoadAndDeserialize();

        //如果讀取結果是沒有資料就創建新的
        if (loadPlayerData != null)
        {
            player = loadPlayerData;
        }
        else
        {
            //創建玩家資料
            player = new PlayerData()
            {
                level = 1,
                hp = 100
            };
        }
        Debug.Log($"玩家等級:{player.level} \n玩家血量{player.hp}");
    }

    void Update()
    {
        //按下A鍵可以扣血
        if (Input.GetKeyDown(KeyCode.N))
        {
            player.hp -= 10;
            Debug.Log($"玩家受到了10點傷害 HP剩餘 {player.hp}點");
        }
        //按下S鍵可以序列化
        if (Input.GetKeyDown(KeyCode.M))
        {
            // DoSerialize();
            DoSerializeAndSave();
        }
    }

    //序列化後由Log輸出
    private void DoSerialize()
    {
        //序列化
        var json = JsonUtility.ToJson(player);
        Debug.Log(json);
    }

    //序列化後保存
    private void DoSerializeAndSave()
    {
        //序列化
        var json = JsonUtility.ToJson(player);

        //獲取存檔位置
        //Application.persistentDataPath是unity提供給你的存讀檔路徑
        var savePath = Application.persistentDataPath;

        //寫入文件並保存到硬碟
        //WriteAllText是System.IO提供的API 也可以在文件上方用Using引入
        //這邊存檔名PlayerData.json可以自己決定，副檔名也可以隨意取
        System.IO.File.WriteAllText($"{savePath}/PlayerData.json", json);

        Debug.Log($"保存到{ savePath}/ PlayerData.json");
    }

    //讀取並反序列化
    private PlayerData LoadAndDeserialize()
    {
        // 獲取存檔位置
        var savePath = Application.persistentDataPath;

        try//直接讀取有可能讀不到檔案(因為存檔沒有建立) 可以使用例外處理
        {
            //檔案怎麼存就怎麼讀
            var json = System.IO.File.ReadAllText($"{savePath}/PlayerData.json");
            //反序列化成PlayerData物件
            var newPlayerData = JsonUtility.FromJson<PlayerData>(json);
            //回傳腳色資料
            return newPlayerData;
        }
        catch (System.IO.FileNotFoundException e)
        {
            return null;
        }


    }
}

//玩家類保存玩家資料
public class PlayerData
{
    public int level;//玩家的等級
    public int hp;//玩家的生命值
}
