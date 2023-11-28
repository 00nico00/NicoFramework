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
        
#if UNITY_EDITOR
        public IGetBehaviorTree GetTree() => UnityEditor.EditorUtility.InstanceIDToObject(TreeID) as IGetBehaviorTree;
        public void SetRoot(BtNodeBase rootData) => GetTree().SetRoot(rootData);
#endif
    }
}
