using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField]IzakayaEvent izakayaEvent;
    [SerializeField]Kushikatsu[] SSRKushikatsus;
    [SerializeField, Range(0, 100)]int SSRWeight = 1;
    [SerializeField]Kushikatsu[] debuffKushikatsus;
    [SerializeField, Range(0, 100)]int debuffWeight = 10;
    [SerializeField]Kushikatsu[] normalKushikatsu;
    [SerializeField, Range(0, 100)]int normalWeight = 100;

    [SerializeField]List<Kushikatsu> onDishKatsusList;
    [SerializeField]Vector3 offset = new Vector3(0.1f, 0, 0);
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
            Vector3 katsuPos = offset * ((-maxKushiLength / 2 ) + i);
            Kushikatsu kushikatsuObject = Instantiate(SpawnKatsu(), katsuPos, quaternion.identity);
            kushikatsuObject.transform.SetParent(transform, false);
            onDishKatsusList.Add(kushikatsuObject);
        }
    }

    void UpdateVisuals()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    Kushikatsu SpawnKatsu()
    {
        int normalProbability = normalWeight * normalKushikatsu.Length;
        int debuffProbability = debuffWeight * debuffKushikatsus.Length;
        int SSRProbability = SSRWeight * SSRKushikatsus.Length;
        int tortalProbability = normalProbability + debuffProbability + SSRProbability;

        //乱数生成
        int randomValue = UnityEngine.Random.Range(0, tortalProbability);
        //Debug.Log(randomValue);

        if(randomValue < normalProbability)
        {
            return normalKushikatsu[UnityEngine.Random.Range(0, normalKushikatsu.Length)];
        }
        else if(randomValue < normalProbability + debuffProbability)
        {
            //デバフ串の場合は特殊効果を割り当てる
            Kushikatsu chosenKushi = debuffKushikatsus[UnityEngine.Random.Range(0, debuffKushikatsus.Length)];
            chosenKushi.OnSpecialEffect += izakayaEvent.ForceTurnSK;
            return chosenKushi;
        }
        else
        {
            return SSRKushikatsus[UnityEngine.Random.Range(0, SSRKushikatsus.Length)];
        }
    }

    public Kushikatsu GetKushikatsu()
    {
        if(onDishKatsusList[0])
        {
            Kushikatsu taken = onDishKatsusList[0];
            //taken.transform.SetParent(null);
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
            return null;
        }
    }
}