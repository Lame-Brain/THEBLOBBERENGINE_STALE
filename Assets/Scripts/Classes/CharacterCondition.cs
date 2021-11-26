using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCondition
{
    public int ConditionType;
    public int ConditionTimer;
    public int ConditionAmount;

    public CharacterCondition(int _type, int _timer, int _amount)
    {
        this.ConditionType = _type;
        this.ConditionTimer = _timer;
        this.ConditionAmount = _amount;
    }
    public int[] SaveCondition()
    {
        int[] result = new int[3];
        result[0] = this.ConditionType;
        result[1] = this.ConditionTimer;
        result[2] = this.ConditionAmount;
        return result;
    }
    public void LoadCondition(int[] _data)
    {
        this.ConditionType = _data[0];
        this.ConditionTimer = _data[1];
        this.ConditionAmount = _data[2];
    }
}