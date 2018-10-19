using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class IniGame : MonoBehaviour {

    //private int gamemode = PlayerPrefs.GetInt("");

    private void Awake()
    {
        List<EnemyBehavior> Enemies = GetAllObjectsInScene();

        SetDifficulty(Enemies);
        SetSwords();
    }

    private void SetSwords()
    {
        var swordNumber = PlayerPrefs.GetInt("SwordsNumber");

        if(swordNumber == 0)
        {
            GameObject lSword = GameObject.Find("Lightsaber_L");
            GameObject lHandParent = GameObject.Find("LocalAvatar");
            OvrAvatarHand[] hands;

            lSword.gameObject.SetActive(false);
            hands = lHandParent.GetComponentsInChildren<OvrAvatarHand>(true);

            foreach (var item in hands)
            {
                if(item.gameObject.name == "hand_left")
                {
                    item.gameObject.SetActive(true);
                }
            }
        }
    }

    private static void SetDifficulty(List<EnemyBehavior> hola)
    {
        var difficulty = PlayerPrefs.GetInt("ShowHUD");

        if(difficulty == 1)
        {
            for (int i = 0; i < hola.Count; i++)
            {
                 hola[i].gameObject.SetActive(true);
            }
        }
    }

    List<EnemyBehavior> GetAllObjectsInScene()
    {
        List<EnemyBehavior> objectsInScene = new List<EnemyBehavior>();

        foreach (EnemyBehavior go in Resources.FindObjectsOfTypeAll(typeof(EnemyBehavior)) as EnemyBehavior[])
        {
            if (go.hideFlags != HideFlags.None)
                continue;
            if (PrefabUtility.GetPrefabType(go) == PrefabType.Prefab || PrefabUtility.GetPrefabType(go) == PrefabType.ModelPrefab)
                continue;
            objectsInScene.Add(go);
        }
        return objectsInScene;
    }
}
