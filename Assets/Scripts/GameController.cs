using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GameController : MonoBehaviour {

    private void Awake()
    {

        List<EnemyBehavior> enemies = GetAllObjectsInScene();

        SetDifficulty(enemies);

        SetSwords();

    }

    private void SetSwords()
    {

        int swordNumber = PlayerPrefs.GetInt("Swords");

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

        int normal = PlayerPrefs.GetInt("NormalDifficulty");

        int hardcore = PlayerPrefs.GetInt("HardCoreDifficulty");


        if(hardcore == 1)
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
