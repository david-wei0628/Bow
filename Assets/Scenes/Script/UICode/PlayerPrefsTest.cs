using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour
{
    public PlayerData player;

    void Start()
    {
        //Ū�����a���
        var loadPlayerData = LoadAndDeserialize();

        //�p�GŪ�����G�O�S����ƴN�Ыطs��
        if (loadPlayerData != null)
        {
            player = loadPlayerData;
        }
        else
        {
            //�Ыت��a���
            player = new PlayerData()
            {
                level = 1,
                hp = 100
            };
        }
        Debug.Log($"���a����:{player.level} \n���a��q{player.hp}");
    }

    void Update()
    {
        //���UA��i�H����
        if (Input.GetKeyDown(KeyCode.N))
        {
            player.hp -= 10;
            Debug.Log($"���a����F10�I�ˮ` HP�Ѿl {player.hp}�I");
        }
        //���US��i�H�ǦC��
        if (Input.GetKeyDown(KeyCode.M))
        {
            // DoSerialize();
            DoSerializeAndSave();
        }
    }

    //�ǦC�ƫ��Log��X
    private void DoSerialize()
    {
        //�ǦC��
        var json = JsonUtility.ToJson(player);
        Debug.Log(json);
    }

    //�ǦC�ƫ�O�s
    private void DoSerializeAndSave()
    {
        //�ǦC��
        var json = JsonUtility.ToJson(player);

        //����s�ɦ�m
        //Application.persistentDataPath�Ounity���ѵ��A���sŪ�ɸ��|
        var savePath = Application.persistentDataPath;

        //�g�J���ëO�s��w��
        //WriteAllText�OSystem.IO���Ѫ�API �]�i�H�b���W���Using�ޤJ
        //�o��s�ɦWPlayerData.json�i�H�ۤv�M�w�A���ɦW�]�i�H�H�N��
        System.IO.File.WriteAllText($"{savePath}/PlayerData.json", json);

        Debug.Log($"�O�s��{ savePath}/ PlayerData.json");
    }

    //Ū���äϧǦC��
    private PlayerData LoadAndDeserialize()
    {
        // ����s�ɦ�m
        var savePath = Application.persistentDataPath;

        try//����Ū�����i��Ū�����ɮ�(�]���s�ɨS���إ�) �i�H�ϥΨҥ~�B�z
        {
            //�ɮ׫��s�N���Ū
            var json = System.IO.File.ReadAllText($"{savePath}/PlayerData.json");
            //�ϧǦC�Ʀ�PlayerData����
            var newPlayerData = JsonUtility.FromJson<PlayerData>(json);
            //�^�Ǹ}����
            return newPlayerData;
        }
        catch (System.IO.FileNotFoundException e)
        {
            return null;
        }


    }
}

//���a���O�s���a���
public class PlayerData
{
    public int level;//���a������
    public int hp;//���a���ͩR��
}
