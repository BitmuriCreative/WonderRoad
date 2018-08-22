using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WonderRoad
{
    public class PieceGridBundle : MonoSingleton<PieceGridBundle>
    {
        private UIGrid m_uiGrid = null;
        private void Start()
        {
            m_uiGrid = gameObject.GetComponent<UIGrid>();
        }

        public void Attach(Transform _trans)
        {
            _trans.parent = gameObject.transform;
            _trans.Reset();
        }

        public void GridCellSizeSetting(float _fWidth, float _fHeight)
        {
            m_uiGrid.cellWidth  = _fWidth;
            m_uiGrid.cellHeight = _fHeight;
        }

        public void ChildDestroy()
        {
            while(transform.childCount > 0)
            {
                Transform temp = transform.GetChild(0);
                Destroy(temp.gameObject);
            }
        }
    }
}