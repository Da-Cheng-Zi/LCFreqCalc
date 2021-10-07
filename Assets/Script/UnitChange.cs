//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;
//using System.Diagnostics;
using UnityEngine;
using System;



public class UnitChange : MonoBehaviour
{
    [SerializeField] InputField input_L;
    [SerializeField] InputField input_C;
    [SerializeField] InputField input_f;
    [SerializeField] Dropdown dropdown_L;
    [SerializeField] Dropdown dropdown_C;
    [SerializeField] Dropdown dropdown_f;
    public static double L = -1;//单位：H，F，Hz
    public static double C = -1;
    public static double f = -1;
    double[] Unit = { 1, 1000, 1000000, 1000000000, 1000000000000 };

    //单位换算
     public void ChangeUnit()
    {
        

        L = input_L.text != string.Empty ? Convert.ToDouble(input_L.text) / Unit[dropdown_L.value] : -1;
        //Debug.Log(L + "H");

        C = input_C.text != string.Empty ? Convert.ToDouble(input_C.text) / Unit[dropdown_C.value] : -1;
        //Debug.Log(C + "F");

        f = input_f.text != string.Empty ? Convert.ToDouble(input_f.text) * Unit[dropdown_f.value] : -1;
        //Debug.Log(f + "Hz");



        //CalcThem(L, C, f);
        
    }

    //void CalcThem(double L, double C, double f)
    //{
    //    //f = 1/(2 *PI * Sqrt(L * C));

    //    if (L != -1 && C != -1)
    //    {
    //        f = 1 / (2 * Math.PI * Math.Sqrt(L * C));
    //        input_f.text = f.ToString();
    //        return;
    //    }else if(L !=-1 && f != -1)
    //    {

    //        return;
    //    }else if (C != -1 && f != -1)
    //    {

    //        return;
    //    }else
    //    {

    //        return;
    //    }
    //}

    public void CalcL()
    {
        ChangeUnit();
        if(C != -1 && f != -1)
        {
            L = 1 / (4 * Math.PI * Math.PI * f * f * C);
            decimal decimal_L = (decimal)(L * Unit[dropdown_L.value]);
            //L *= Unit[dropdown_L.value];
            input_L.text = decimal_L.ToString();

            return;
        }
    }
    public void CalcC()
    {
        ChangeUnit();
        if (L != -1 && f != -1)
        {
            C = 1 / (4 * Math.PI * Math.PI * f * f * L);
            decimal decimal_C = (decimal)(C * Unit[dropdown_C.value]);
            //C *= Unit[dropdown_C.value];
            input_C.text = decimal_C.ToString();

            return;
        }
    }
    public void CalcF()
    {
        //Process.Start("");
        ChangeUnit();
        if (L != -1 && C != -1)
        {
            f = 1 / (2 * Math.PI * Math.Sqrt(L * C));
            decimal decimal_f = (decimal)(f / Unit[dropdown_f.value]);
            //f *= 1 / Unit[dropdown_f.value];

            input_f.text = decimal_f.ToString();
            return;
        }
    }

    public void QuitTheProgram()
    {
        Application.Quit();
    }

}
