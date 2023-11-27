using NicoFramework.Modules.BehaviorTree;
using UnityEditor.Experimental.GraphView;

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
    }
}