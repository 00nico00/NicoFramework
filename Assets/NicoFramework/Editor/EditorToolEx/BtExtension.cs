using NicoFramework.Editor.View;
using NicoFramework.Modules.BehaviorTree;
using UnityEditor.Experimental.GraphView;

public static class BtExtension
{
    /// <summary>
    /// 在结点连线的时候添加进输入到 NodeView
    /// </summary>
    /// <param name="edge"></param>
    public static void AddDataOnLinkLine(this Edge edge) {
        NodeView inputNode = edge.input.node as NodeView;
        NodeView outputNode = edge.output.node as NodeView;
        switch (outputNode.NodeData) {
            case BtCompositeNode compositeNode:
                compositeNode.ChildNodes.Add(inputNode.NodeData);
                break;
            case BtDecoratorNode decoratorNode:
                decoratorNode.ChildNode = inputNode.NodeData;
                break;
        }
    }

    /// <summary>
    /// 在结点断开的时候删除数据从 NodeView
    /// </summary>
    /// <param name="edge"></param>
    public static void RemoveDataOnUnLinkLine(this Edge edge) {
        NodeView inputNode = edge.input.node as NodeView;
        NodeView outputNode = edge.output.node as NodeView;
        switch (outputNode.NodeData) {
            case BtCompositeNode compositeNode:
                compositeNode.ChildNodes.Remove(inputNode.NodeData);
                break;
            case BtDecoratorNode decoratorNode:
                decoratorNode.ChildNode = null;
                break;
        }
    }
}
