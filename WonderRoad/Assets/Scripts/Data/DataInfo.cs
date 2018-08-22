using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tb_Data
{
    public int _iIndex = 0;
    public int _iHorizontal = 0;
    public int _iVertical = 0;
    public int _iTouchCount = 0;
    public int[,] _iArrayPieceImg = null;
    public int[,] _iArrayPieceRotate = null;
}

public class DataInfo
{
    private Dictionary<int, Tb_Data> m_Data = new Dictionary<int, Tb_Data>();

    //해당 인덱스에 데이터 저장.
    public void AddData(int _iIdx, Tb_Data _tbData)
    {
        m_Data[_iIdx] = _tbData;
    }

    //Index에 맞는 정보 리턴.
    public Tb_Data GetDataIndex(int _iIdx)
    {
        return (m_Data.ContainsKey(_iIdx)) ? m_Data[_iIdx] : null;
    }

    //DB 리턴.
    public Dictionary<int, Tb_Data> GetData()
    {
        return (m_Data != null) ? m_Data : null;
    }
}
