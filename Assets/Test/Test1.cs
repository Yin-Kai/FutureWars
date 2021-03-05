using System;
using System.Collections.Generic;



public static class Test1
{
    static void CrossRiver(int man, int savage, int ship, List<String> way)
    {
        //不满足基本条件
        if (man < 0 || man > 3 || savage < 0 || savage > 3 || (savage > man && man != 0) || (savage < man && man != 3))
            return;

        String nowWay = man.ToString() + savage.ToString() + ship.ToString();

        //排除回路
        foreach (String anyWay in way)
        {
            if (anyWay.Equals(nowWay))
                return;
        }

        way.Add(nowWay);

        if (man == 0 && savage == 0 && ship == 0)
        {
            String finalWay = null;
            //输出最终结果
            foreach (String temp in way)
            {
                finalWay = temp + "->";
            }
            Console.WriteLine(finalWay);
            return;
        }

        if (ship == 1)
        {
            CrossRiver(man - 1, savage, 0, way);
            CrossRiver(man, savage - 1, 0, way);
            CrossRiver(man - 1, savage - 1, 0, way);
        }
        else if (ship == 0)
        {
            CrossRiver(man + 1, savage, 1, way);
            CrossRiver(man, savage + 1, 1, way);
            CrossRiver(man + 1, savage + 1, 1, way);
        }
    }

    public static void Main(String[] args)
    {
        CrossRiver(3, 3, 1, new List<String>());
    }

}

