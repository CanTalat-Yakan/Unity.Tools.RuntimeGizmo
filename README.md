# Disclaimer

This project is a fork of [https://assetstore.unity.com/packages/tools/game-toolkits/transform-gizmos-280708](https://assetstore.unity.com/packages/tools/game-toolkits/transform-gizmos-280708).  
All credit for the original work goes to the original author.

This fork will expand on the original and unify it as part of the **Unity Essentials** ecosystem.

---

# Unity Essentials

**Unity Essentials** is a lightweight, modular utility namespace designed to streamline development in Unity. 
It provides a collection of foundational tools, extensions, and helpers to enhance productivity and maintain clean code architecture.

## 📦 This Package

This package is part of the **Unity Essentials** ecosystem.  
It integrates seamlessly with other Unity Essentials modules and follows the same lightweight, dependency-free philosophy.

## 🌐 Namespace

All utilities are under the `UnityEssentials` namespace. This keeps your project clean, consistent, and conflict-free.

```csharp
using UnityEssentials;
```

# Transform Gizmos

Please checkout the Demo scene. 

Using this package:

1) Drag the prefab "Gizmo" to a scene.
2) On the root gameobject "Gizmo" assign the target object, which should be transformed, to the "Target Object" field.
2) You can already start running the game.
3) In order to see the gizmos press "R" for rotation, "T" for translation and "Z" for scaling. 

Scene view:
If you want the gizmos to be at the correct place also in scene view make sure that the position, rotation and scale of the root "Gizmo" object are the same as of the target object.

Gizmo size:
On the root gameobject "Gizmo" there is a variable called "Gizmo Size". If you change this size, the gizmos will change their size (in runtime).

Transformation speed:
On the child gameobjects "Rotation", "Translation" and "Scaling" there is a variable called "..speed". If you adjust this value the speed/sensitivity of the transformation will be changed.

Adjust behaviour of showing gizmos:
By default only one transformation is visible at once. In the script "GizmoController" you can change this behaviour. There are also callback functions for showing the transforms.