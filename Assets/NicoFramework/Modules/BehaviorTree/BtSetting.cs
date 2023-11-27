using UnityEngine;

namespace NicoFramework.Modules.BehaviorTree
{
    [CreateAssetMenu(menuName = "BehaviorTree/BtSetting")]
    public class BtSetting : ScriptableObject
    {
        public int TreeID;

        public static BtSetting GetSetting() {
            return Resources.Load<BtSetting>("BtSetting");
        }
    }
}
