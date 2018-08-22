using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleJSON;

namespace ArrangementTool
{
    class SaveData
    {
        static private readonly string SAVEDATA_SECTION          = "SAVEDATA";
        
        static private readonly string SAVEDATA_KEY_INDEX        = "Index";
        static private readonly string SAVEDATA_KEY_HORIZONTAL   = "Horizontal";
        static private readonly string SAVEDATA_KEY_VERTICAL     = "Vertical";
        static private readonly string SAVEDATA_KEY_TOUCHCOUNT   = "TouchCount";
        static private readonly string SAVEDATA_KEY_PIECE_IMG    = "PieceImg";
        static private readonly string SAVEDATA_KEY_PIECE_ROTATE = "PieceRotate";

        static SaveData m_Instance = null;

        private SaveData() { }

        static public SaveData Get()
        {
            if (m_Instance == null)
                m_Instance = new SaveData();

            return m_Instance;
        }

        public class Data
        {
            public int _iIndex      = 0;
            public int _iHorizontal = 0;
            public int _iVertical   = 0;
            public int _iTouchCount = 0;

            public int[] _iArrayPieceImg    = null; // 0~24순
            public int[] _iArrayPieceRotate = null; // 0~24순
        }

        private Data m_Data = new Data();
        public Data Current
        {
            get
            {
                if (m_Instance == null)
                    return null;

                if (m_Data == null)
                    m_Data = new Data();

                return m_Data;
            }
        }

        public void DataUpdate()
        {
            int iIdx = m_Data._iHorizontal * m_Data._iVertical;
            m_Data._iArrayPieceImg    = new int[iIdx];
            m_Data._iArrayPieceRotate = new int[iIdx];
        }

        public void PieceImgNumberUpdate(int _iPictureIdx, int _iImgNum)
        {
            if (m_Data._iArrayPieceImg        == null) return;
            if (m_Data._iArrayPieceImg.Length == 0)    return;
            m_Data._iArrayPieceImg[_iPictureIdx] = _iImgNum;
        }

        public void PieceRotationUpdate(int _iPictureIdx, int _iRoatate)
        {
            if (m_Data._iArrayPieceImg        == null) return;
            if (m_Data._iArrayPieceImg.Length == 0)    return;
            m_Data._iArrayPieceRotate[_iPictureIdx] = _iRoatate;
        }
        public int GetPieceRotate(int _iPictureIdx)
        {
            return m_Data._iArrayPieceRotate[_iPictureIdx];
        }

        /// <summary>
        /// Tool Data Load
        /// </summary>
        public void ToolDataLoad(string _strFileName)
        {
            SharpConfig.Configuration config = null;

            if (System.IO.File.Exists(_strFileName))
            {
                config = SharpConfig.Configuration.LoadFromFile(_strFileName);
            }

            if (config == null)
            {
                config = new SharpConfig.Configuration();
            }

            if (config.Contains(SAVEDATA_SECTION))
            {
                var userdata = config[SAVEDATA_SECTION];

                m_Data._iIndex      = userdata[SAVEDATA_KEY_INDEX     ].IntValue;
                m_Data._iHorizontal = userdata[SAVEDATA_KEY_HORIZONTAL].IntValue;
                m_Data._iVertical   = userdata[SAVEDATA_KEY_VERTICAL  ].IntValue;
                m_Data._iTouchCount = userdata[SAVEDATA_KEY_TOUCHCOUNT].IntValue;

                m_Data._iArrayPieceImg    = userdata[SAVEDATA_KEY_PIECE_IMG   ].IntValueArray;
                m_Data._iArrayPieceRotate = userdata[SAVEDATA_KEY_PIECE_ROTATE].IntValueArray;
            }
        }

        /// <summary>
        /// Tool Data Save
        /// </summary>
        public void ToolDataSave(string _strFileName)
        {
            var config = new SharpConfig.Configuration();

            config[SAVEDATA_SECTION][SAVEDATA_KEY_INDEX     ].IntValue = m_Data._iIndex;
            config[SAVEDATA_SECTION][SAVEDATA_KEY_HORIZONTAL].IntValue = m_Data._iHorizontal;
            config[SAVEDATA_SECTION][SAVEDATA_KEY_VERTICAL  ].IntValue = m_Data._iVertical;
            config[SAVEDATA_SECTION][SAVEDATA_KEY_TOUCHCOUNT].IntValue = m_Data._iTouchCount;

            config[SAVEDATA_SECTION][SAVEDATA_KEY_PIECE_IMG   ].IntValueArray = m_Data._iArrayPieceImg;
            config[SAVEDATA_SECTION][SAVEDATA_KEY_PIECE_ROTATE].IntValueArray = m_Data._iArrayPieceRotate;

            config.SaveToFile(_strFileName);
        }

        public void SaveJson(string strPath)
        {
            JSONNode root = new JSONArray();
            JSONObject tempObj = new JSONObject();
            MakeJSONObject(ref tempObj, "Index", m_Data._iIndex);
            MakeJSONObject(ref tempObj, "Horizontal", m_Data._iHorizontal);
            MakeJSONObject(ref tempObj, "Vertical", m_Data._iVertical);
            MakeJSONObject(ref tempObj, "TouchCount", m_Data._iTouchCount);

            for (int iLoop = 0; iLoop < m_Data._iArrayPieceImg.Length; ++iLoop)
            {
                MakeJSONObject(ref tempObj, string.Format("PieceImg_{0}", iLoop), m_Data._iArrayPieceImg[iLoop]);
            }
            
            for (int iLoop = 0; iLoop < m_Data._iArrayPieceRotate.Length; ++iLoop)
            {
                MakeJSONObject(ref tempObj, string.Format("PieceRotate_{0}", iLoop), m_Data._iArrayPieceRotate[iLoop]);
            }

            root.Add(tempObj);

            StringBuilder sb = new StringBuilder();
            root.WriteToStringBuilder(sb, 0, 0, JSONTextMode.Indent);
            string temp = sb.ToString();

            System.IO.File.WriteAllText(strPath, temp, new UTF8Encoding(false));
        }

        private string MakeJSONObject(ref JSONObject _obj, string _strKey, int _iVal)
        {
            try
            {
                _obj[_strKey] = _iVal;
            }
            catch (FormatException e)
            {
                return e.Message;
            }

            return null;
        }

        //private string MakeJSONObject(ref JSONObject Obj, string strType, string strKey, string strVal)
        //{
        //    try
        //    {
        //        switch (strType)
        //        {
        //            case "int":
        //                Obj[strKey] = int.Parse(strVal);
        //                break;
        //            case "uint":
        //                Obj[strKey] = uint.Parse(strVal);
        //                break;
        //            case "float":
        //                Obj[strKey] = float.Parse(strVal);
        //                break;
        //            case "double":
        //                Obj[strKey] = double.Parse(strVal);
        //                break;
        //            case "bool":
        //                Obj[strKey] = bool.Parse(strVal);
        //                break;
        //            default:
        //                Obj[strKey] = strVal;
        //                break;
        //        }
        //    }
        //    catch (FormatException e)
        //    {
        //        return e.Message;
        //    }

        //    return null;
        //}
    }
}
