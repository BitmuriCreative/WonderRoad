using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WonderRoad
{
    public class Stage : MonoBehaviour
    {
        static private readonly string OBJ_NAME = "Stage";
        static private readonly string PIECE_PATH = "Prefabs/Piece/Piece";

        static public Stage Create()
        {
            GameObject obj = new GameObject();
            if (obj == null) return null;
            obj.name = OBJ_NAME;
            obj.transform.SetParent(null);
            obj.transform.Reset();

            Stage stage = obj.AddComponent<Stage>();
            if(stage == null)
            {
                Destroy(obj);
                return null;
            }

            stage.PrefabLoad();
            stage.SetUp();

            return stage;
        }

        private Piece m_PiecePrifab = null;

        private void PrefabLoad()
        {
            m_PiecePrifab = Resources.Load<Piece>(PIECE_PATH);
        }

        private void SetUp()
        {
            Tb_Data tempData = DataMgr.Get().GetData().GetDataIndex(1);
            GameObject[] tempObj = new GameObject[tempData._iVertical];
            for(int iLoop = 0; iLoop < tempObj.Length; ++iLoop)
            {
                tempObj[iLoop] = new GameObject();
                if (tempObj[iLoop] == null) continue;

                tempObj[iLoop].name = "Grid";
                PieceGridBundle.Get().Attach(tempObj[iLoop].transform);

                UIGrid tempGrid = tempObj[iLoop].AddComponent<UIGrid>();
                if (tempGrid == null)
                {
                    Destroy(tempObj[iLoop]);
                }

                tempGrid.arrangement = UIGrid.Arrangement.Horizontal;
                tempGrid.cellWidth   = 100;
                tempGrid.cellHeight  = 100;
                tempGrid.pivot       = UIWidget.Pivot.Center;

                PieceSetting(tempObj[iLoop].transform, tempData, iLoop);
            }
        }

        private void PieceSetting(Transform _transParent, Tb_Data _tbData, int _iVertical)
        {
            if (m_PiecePrifab == null) return;
            
            for(int iHorizontal = 0; iHorizontal < _tbData._iHorizontal; ++iHorizontal)
            {
                Piece tempPiece = Instantiate(m_PiecePrifab);
                if (tempPiece == null) return;

                tempPiece.transform.parent = _transParent;
                tempPiece.transform.Reset();

                string strPieceImgName = _tbData._iArrayPieceImg[_iVertical, iHorizontal].ToString();
                int iPieceRotate       = _tbData._iArrayPieceRotate[_iVertical, iHorizontal];

                tempPiece.SetUp(strPieceImgName, 100, 100, iPieceRotate);
            }
        }
    }
}
