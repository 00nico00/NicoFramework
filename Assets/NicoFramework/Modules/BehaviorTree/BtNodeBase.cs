using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NicoFramework.Modules.BehaviorTree
{
    public enum BehaviorState
    {
        NotExecuted,    // 未执行
        Success,        // 成功
        Failure,        // 失败
        InProgress      // 执行中
    }
    
    [BoxGroup]
    [HideReferenceObjectPicker]
    public abstract class BtNodeBase
    {
        [FoldoutGroup("@NodeName"), LabelText("唯一标识")]
        public string Guid;
        [FoldoutGroup("@NodeName"), LabelText("节点位置")]
        public Vector2 Position;
        [FoldoutGroup("@NodeName"), LabelText("名称")]
        public string NodeName;

        public abstract BehaviorState Tick();
    }

    /// <summary>
    /// 组合节点
    /// </summary>
    public abstract class BtCompositeNode : BtNodeBase
    {
        [FoldoutGroup("@NodeName"), LabelText("子节点")]
        public List<BtNodeBase> ChildNodes = new List<BtNodeBase>();
    }

    /// <summary>
    /// 条件节点
    /// </summary>
    public abstract class BtDecoratorNode : BtNodeBase
    {
        [FoldoutGroup("@NodeName"), LabelText("子节点")]
        public BtNodeBase ChildNode;
    }
    
    /// <summary>
    /// 行为节点
    /// </summary>
    public abstract class BtActionNode : BtNodeBase {}

    public abstract class BtConditionNode : BtNodeBase {}
}