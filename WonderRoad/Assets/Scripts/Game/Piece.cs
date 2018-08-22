using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WonderRoad
{
    public class Piece : MonoBehaviour
    {
        private UISprite m_uiImg = null;

        private void Awake()
        {
            m_uiImg = gameObject.GetComponent<UISprite>();
        }

        public void SetUp(string _strImgName, int _fW, int _fH, float _fRotate)
        {
            if (m_uiImg == null) return;
            m_uiImg.spriteName = _strImgName;
            m_uiImg.width      = _fW;
            m_uiImg.height     = _fH;
            transform.rotation = Quaternion.Euler(0f, 0f, -_fRotate);
        }

        public void OnPressed()
        {

        }
    }
}
