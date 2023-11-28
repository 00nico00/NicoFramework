using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NicoFramework.Modules.BehaviorTree
{
    [CreateAssetMenu(menuName = "BehaviorTree/InspectorViewDataSO")]
    public class InspectorViewDataSO : SerializedScriptableObject
    {
        public HashSet<BtNodeBase> DataView = new HashSet<BtNodeBase>();
    }
}
