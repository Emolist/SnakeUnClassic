using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    [SerializeField] private ExchangerToggler exhanger;
    [SerializeField] private Bank bank;
    [SerializeField] private PeachHolder peach;
    public void ConvertOne()
    {
        int index = exhanger.index;

        if(index >= 0)
        {
            if(bank.CheckIfEnough(index, 1))
            {
                bank.Spend(index, 1);
            }
        }

        peach.SavePeaches(1);
    }

    public void ConvertAll()
    {
        int indexAll = exhanger.index;
        int all = bank.bank[indexAll];

        if (indexAll >= 0)
        {
            bank.Spend(indexAll, all);
        }

        peach.SavePeaches(all);
    }

    public void SpendOne()
    {
        int index = exhanger.index;
        if (peach.CheckIfEnough(1))
        {
            peach.SpendPeaches(1);
            bank.Add(index, 1);
        }
    }

    public void SpendAll()
    {
        int index = exhanger.index;
        int total = peach.numberOfPeaches;
        peach.SpendPeaches(total);
        bank.Add(index, total);
    }
}
