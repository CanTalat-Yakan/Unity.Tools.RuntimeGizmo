using UnityEngine;

namespace TransformGizmos
{
    public class GizmoBigger : MonoBehaviour
    {
        [SerializeField] GizmoTransformsWrapper m_targetObject;

        private void OnMouseEnter()
        {
            m_targetObject.GizmoTransforms.OnMouseEnter();
        }

        private void OnMouseExit()
        {
            m_targetObject.GizmoTransforms.OnMouseExit();
        }

        private void OnMouseDown()
        {
            m_targetObject.GizmoTransforms.OnMouseDown();
        }

        private void OnMouseUp()
        {
            m_targetObject.GizmoTransforms.OnMouseUp();
        }

        private void OnMouseDrag()
        {
            m_targetObject.GizmoTransforms.OnMouseDrag();
        }
    }
}
