using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField]IzakayaEventmanager izakayaEventmanager;
    [SerializeField]Hand hand;
    [SerializeField]Kushikatsu[] SSRKushikatsus;
    [SerializeField, Range(0, 100)]int SSRWeight = 1;
    [SerializeField]Kushikatsu[] debuffKushikatsus;
    [SerializeField, Range(0, 100)]int debuffWeight = 10;
    [SerializeField]Kushikatsu[] normalKushikatsu;
    [SerializeField, Range(0, 100)]int normalWeight = 100;

    [SerializeField]List<Kushikatsu> onDishKatsusList;
    [SerializeField]float spawncenter = -1f;
    [SerializeField]Vector3 spawnOffset = new Vector3(1.55f, 0f, 0f);
    int maxKushiLength = 5;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    void Init()
    {
        UpdateVisuals();
        for(int i = 0; i < maxKushiLength; i++)
        {
            Kushikatsu kushikatsuObject = SpawnKatsu(i);
            //kushikatsuObject.transform.SetParent(transform, false);
            Debug.Log(i);
            onDishKatsusList.Add(kushikatsuObject);
        }
    }

    //>>>DEV
    float a;
    Vector3 b;
    void Update()
    {
        // if(a != spawncenter || b != spawnOffset)
        // {
        //     int i = 0;
        //     foreach(Kushikatsu kushi in onDishKatsusList)
        //     {
        //         kushi.transform.localPosition = new Vector3(spawncenter + spawnOffset.x * ((-maxKushiLength / 2f) + i), spawnOffset.y, 0);
        //         i++;
        //     }
        //     a = spawncenter;
        //     b = spawnOffset;
        // }
    }

    void UpdateVisuals()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    Kushikatsu SpawnKatsu(int i)
    {
        int normalProbability = normalWeight * normalKushikatsu.Length;
        int debuffProbability = debuffWeight * debuffKushikatsus.Length;
        int SSRProbability = SSRWeight * SSRKushikatsus.Length;
        int tortalProbability = normalProbability + debuffProbability + SSRProbability;

        //乱数生成
        int randomValue = UnityEngine.Random.Range(0, tortalProbability);
        //Debug.Log(randomValue);
        Kushikatsu choseKushi;

        if(randomValue < normalProbability)
        {
            choseKushi = Instantiate<Kushikatsu>(normalKushikatsu[UnityEngine.Random.Range(0, normalKushikatsu.Length)], new Vector3(spawncenter + spawnOffset.x * (-maxKushiLength / 2f) + i, spawnOffset.y, spawnOffset.z), quaternion.identity, gameObject.transform);
        }
        else if(randomValue < normalProbability + debuffProbability)
        {
            //デバフ串の場合は特殊効果を割り当てる
            choseKushi = Instantiate<Kushikatsu>(debuffKushikatsus[UnityEngine.Random.Range(0, debuffKushikatsus.Length)], new Vector3(spawncenter + spawnOffset.x * (-maxKushiLength / 2f) + i, spawnOffset.y, spawnOffset.z), quaternion.identity, gameObject.transform);
            choseKushi.OnSpecialEffect += izakayaEventmanager.KushiEvent;
        }
        else
        {
            choseKushi = Instantiate<Kushikatsu>(SSRKushikatsus[UnityEngine.Random.Range(0, SSRKushikatsus.Length)], new Vector3(spawncenter + spawnOffset.x * (-maxKushiLength / 2f) + i, spawnOffset.y, spawnOffset.z), quaternion.identity, gameObject.transform);
        }

        return choseKushi;
    }

    public Kushikatsu GetKushikatsu()
    {
        if(onDishKatsusList[0])
        {
            Kushikatsu taken = onDishKatsusList[0];
            taken.transform.SetParent(hand.transform);
            taken.transform.localPosition = new Vector3(0f, 0f, 0f);
            onDishKatsusList.RemoveAt(0);
            //Debug.Log(onDishKatsusList);

            if(onDishKatsusList.Count <= 0)
            {
                Init();
            }
            return taken;
        }
        else
        {
            Debug.Log("KushikatsuList is null!");
            return null;
        }
    }
}