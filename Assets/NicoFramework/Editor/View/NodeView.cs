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

        public void LinkLines() {
            var treeView = BehaviorTreeWindow.Instance.treeView;
            switch (NodeData) {
                case BtCompositeNode compositeNode:
                    compositeNode.ChildNodes.ForEach(node => {
                        treeView.AddElement(PortLink(OutputPort, treeView.GuidMapNodeView[node.Guid].InputPort));
                    });
                    break;
                case BtDecoratorNode decoratorNode:
                    treeView.AddElement(PortLink(OutputPort,
                        treeView.GuidMapNodeView[decoratorNode.ChildNode.Guid].InputPort));
                    break;
            }
        }

        public Edge PortLink(Port inputSocket, Port outputSocket) {
            var edge = new Edge() {
                input = inputSocket,
                output = outputSocket
            };
            edge.input?.Connect(edge);
            edge.output?.Connect(edge);

            return edge;
        }


        public override void SetPosition(Rect newPos) {
            // 拖动节点回调也能改变 NodeData 里面的信息
            base.SetPosition(newPos);
            NodeData.Position = new Vector2(newPos.xMin, newPos.yMin);
        }
    }
}