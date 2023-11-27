using NicoFramework.Modules.BehaviorTree;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace NicoFramework.Editor.View
{
    public class NodeView : Node
    {
        public BtNodeBase NodeData;

        public Port InputPort;
        public Port OutputPort;

        public NodeView(BtNodeBase nodeData) {
            NodeData = nodeData;
            InitNodeView(nodeData);
        }

        public void InitNodeView(BtNodeBase nodeData) {
            title = nodeData.NodeName;
            InputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single,
                typeof(NodeView));
            switch (nodeData) {
                case BtCompositeNode compositeNode:
                    OutputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi,
                        typeof(NodeView));
                    break;
                case BtDecoratorNode decoratorNode:
                    OutputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single,
                        typeof(NodeView));
                    break;
            }
            inputContainer.Add(InputPort);
            if (OutputPort != null) {
                outputContainer.Add(OutputPort);
            }
        }

        public override void SetPosition(Rect newPos) {
            // 拖动节点回调也能改变 NodeData 里面的信息
            base.SetPosition(newPos);
            NodeData.Position = new Vector2(newPos.xMin, newPos.yMin);
        }
    }
}