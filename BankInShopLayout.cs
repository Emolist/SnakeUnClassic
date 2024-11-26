using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankInShopLayout : MonoBehaviour
{
    public Bank bank;

    public TMP_Text orange, blueberry, lemon, apple, watermelon;
    public List<int> Count;

    void Start()
    {
        Count.AddRange(new int[5]);
    }

    void Update()
    {
        for (int i = 0; i < Count.Count; i++)
        {
            Count[i] = bank.bank[i];
        }

        orange.text = Count[0].ToString();
        blueberry.text = Count[1].ToString();
        lemon.text = Count[2].ToString();
        apple.text = Count[3].ToString();
        watermelon.text = Count[4].ToString();
    }
}
