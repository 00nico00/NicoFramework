using UnityEngine;

namespace NicoFramework.Modules.BehaviorTree
{
    public interface IGetBehaviorTree
    {
        BtNodeBase GetRoot();
        void SetRoot(BtNodeBase rootData);
    }
}
