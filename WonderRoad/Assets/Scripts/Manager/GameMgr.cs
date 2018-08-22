using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WonderRoad
{
    public class GameMgr : MonoSingleton<GameMgr>
    {
        private Stage m_Stage = null;
        public Stage GetStage { get{ return (m_Instance == null) ? null : m_Instance.m_Stage; } }

        private void Start()
        {
            StageCreate();
        }

        private void StageCreate()
        {
            if (m_Stage == null)
                m_Stage = Stage.Create();
        }
    }
}