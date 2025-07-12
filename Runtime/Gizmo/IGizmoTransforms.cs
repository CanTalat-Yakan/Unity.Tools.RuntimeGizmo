using System;
using UnityEngine;

namespace TransformGizmos
{
    public interface IGizmoTransforms
    {
        public void OnMouseEnter();
        public void OnMouseExit();
        public void OnMouseDown();
        public void OnMouseUp();
        public void OnMouseDrag();
    }

    [Serializable]
    public class GizmoTransformsWrapper
    {
        public MonoBehaviour behaviour;

        public IGizmoTransforms GizmoTransforms { get { return behaviour as IGizmoTransforms; } }
    }
}
