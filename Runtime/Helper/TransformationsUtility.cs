using UnityEngine;
//using UnityEngine.InputSystem;

namespace TransformGizmos
{
    public static class TransformationsUtility
    {
        public static (Vector2, Vector2) HandleMouseOutsideScreen(Vector2 initialMousePosition, Vector3 moveDirection)
        {
            float newMousePositionX = Input.mousePosition.x;
            float newMousePositionY = Input.mousePosition.y;

            bool isOutsideOfScreen = false;
            // Check if the mouse has moved off the edge of the screen
            if (Input.mousePosition.y >= Screen.height)
            {
                isOutsideOfScreen = true;
                newMousePositionY = 2f;
            }

            else if (Input.mousePosition.y <= 0)
            {
                isOutsideOfScreen = true;
                newMousePositionY = Screen.height - 2f;
            }
            if (Input.mousePosition.x >= Screen.width)
            {
                isOutsideOfScreen = true;
                newMousePositionX = 2f;
            }
            else if (Input.mousePosition.x <= 0)
            {
                isOutsideOfScreen = true;
                newMousePositionX = Screen.width - 2f;
            }

            //if (isOutsideOfScreen)
            //    Mouse.current.WarpCursorPosition(new Vector2(newMousePositionX, newMousePositionY));

            Vector2 lastMousePosition = new Vector2(newMousePositionX, newMousePositionY);
            Vector2 moveVector = lastMousePosition - initialMousePosition;
            Vector2 projectedMoveVector = Vector3.Project(moveVector, moveDirection);
            Vector2 projectedPosition = initialMousePosition + projectedMoveVector;
            Vector2 lastProjectedMousePosition = projectedPosition;

            return (lastProjectedMousePosition, lastMousePosition);
        }
    }
}
