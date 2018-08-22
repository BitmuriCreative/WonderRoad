using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace WonderRoad
{
    public class DataMgr : MonoDontDestroySingleton<DataMgr>
    {
        static private readonly string FORMAT_IMG    = "PieceImg_{0}";
        static private readonly string FORMAT_ROTATE = "PieceRotate_{0}";

        // 데이터 로드 시작했는지 체크.
        private bool m_AllLoadCheck    = false;
        private bool m_AllLoadEndCheck = false;

        private string[] m_DBLoadFunctionName =
        {
            "LoadStage1Data",
        };

        protected override void OnAwake()
        {
            base.OnAwake();
            DataLoad();
        }

        //로딩이 다 끝났는지 체크.
        public bool GetAllLoadEndCheck()
        {
            return m_AllLoadEndCheck;
        }

        public void DataLoad()
        {
            if (m_AllLoadCheck) return;

            StartCoroutine(LoadAllData());
        }

        public IEnumerator LoadAllData()
        {
            m_AllLoadCheck = true;
            for(int iLoop = 0; iLoop < m_DBLoadFunctionName.Length; ++iLoop)
            {
                Debug.Log(m_DBLoadFunctionName[iLoop] + " : Load");
                
                yield return StartCoroutine(m_DBLoadFunctionName[iLoop]);
            }

            m_AllLoadEndCheck = true;
            yield return null;
        }

        private DataInfo m_DataInfo = new DataInfo();
        public DataInfo GetData()
        {
            return (m_DataInfo != null) ? m_DataInfo : null;
        }

        //파일 정보 가져오기.
        public TextAsset GetTextAsset(string _strFolderFileName)
        {
            return (TextAsset)Resources.Load(_strFolderFileName, typeof(TextAsset));
        }

        IEnumerator LoadStage1Data()
        {
            string strDBFileName = "DB/Tb_Stage1";
            TextAsset tempTextAsset = GetTextAsset(strDBFileName);

            if(tempTextAsset != null)
            {
                JSONNode tempJsonData = JSON.Parse(tempTextAsset.ToString());
                for(int iLoop = 0; iLoop < tempJsonData.Count; ++iLoop)
                {
                    Tb_Data formData = new Tb_Data();

                    formData._iIndex      = tempJsonData[iLoop]["Index"     ].AsInt;
                    formData._iHorizontal = tempJsonData[iLoop]["Horizontal"].AsInt;
                    formData._iVertical   = tempJsonData[iLoop]["Vertical"  ].AsInt;
                    formData._iTouchCount = tempJsonData[iLoop]["TouchCount"].AsInt;

                    formData._iArrayPieceImg    = new int[formData._iVertical, formData._iHorizontal];
                    formData._iArrayPieceRotate = new int[formData._iVertical, formData._iHorizontal];

                    for (int iVertical = 0; iVertical < formData._iVertical; ++iVertical)
                    {
                        for(int iHorizontal = 0; iHorizontal < formData._iHorizontal; ++iHorizontal)
                        {
                            int iIdx = iVertical * formData._iHorizontal + iHorizontal;

                            string strTempJsonKey = string.Format(FORMAT_IMG, iIdx);
                            formData._iArrayPieceImg[iVertical, iHorizontal] = tempJsonData[iLoop][strTempJsonKey].AsInt;

                            strTempJsonKey = string.Format(FORMAT_ROTATE, iIdx);
                            formData._iArrayPieceRotate[iVertical, iHorizontal] = tempJsonData[iLoop][strTempJsonKey].AsInt;
                        }
                    }

                    m_DataInfo.AddData(formData._iIndex, formData);
                }
            }
            else
            {
                Debug.Log(strDBFileName + " : error");
            }

            yield return null;
        }
    }
}