# Unity Essentials

This module is part of the Unity Essentials ecosystem and follows the same lightweight, editor-first approach.
Unity Essentials is a lightweight, modular set of editor utilities and helpers that streamline Unity development. It focuses on clean, dependency-free tools that work well together.

All utilities are under the `UnityEssentials` namespace.

```csharp
using UnityEssentials;
```

## Installation

Install the Unity Essentials entry package via Unity's Package Manager, then install modules from the Tools menu.

- Add the entry package (via Git URL)
    - Window → Package Manager
    - "+" → "Add package from git URL…"
    - Paste: `https://github.com/CanTalat-Yakan/UnityEssentials.git`

- Install or update Unity Essentials packages
    - Tools → Install & Update UnityEssentials
    - Install all or select individual modules; run again anytime to update

---

# Runtime Gizmo

> Quick overview: In‑game transform gizmo for Rotation/Translation/Scale. Toggle modes with keys (R/T/Z), hover/click to interact, see degree readout, and adjust gizmo size at runtime.

A lightweight runtime transform gizmo you can drop into any scene to manipulate a target object at play time. It provides rotation rings, translation arrows, and scale handles backed by simple MonoBehaviours that react to mouse hover, press, drag, and release. The controller keeps the gizmo aligned to the target object and exposes a size slider to scale the gizmo visuals.

![screenshot](Documentation/Screenshot.png)

## Features
- Three transformation modes
  - Rotation, Translation, and Scale modes; toggle with R/T/Z or via public API
- Runtime‑friendly
  - Works fully in Play Mode; controller tracks target position/rotation
- Visual feedback
  - Hover/click highlight materials; optional degree text overlay for rotation
- Adjustable size
  - Per‑frame gizmo size control to suit camera distance or preference
- Extensible handles
  - Axis handles implement a small `IGizmoTransforms` interface; easy to add custom shapes
- Robust mouse handling
  - Utility to keep drags stable even when the cursor hits screen edges

## Requirements
- Unity 6000.0+
- Legacy mouse events (`OnMouseEnter/Exit/Down/Up/Drag`) are used
  - Each gizmo piece must have a Collider and a visible Renderer to receive events
- Provide highlight/default Materials for visual feedback
- Provide a target GameObject to manipulate (position/rotation/scale)

## Usage
1) Add a Runtime Gizmo to your scene
   - Create an empty GameObject, add `TransformGizmos.GizmoController`
   - Make the gizmo visuals children of this object (rings/arrows/boxes), each with a Collider
   - Assign serialized fields on the controller:
     - Target Object (the thing to move/rotate/scale)
     - Clicked/Transparent Materials
     - Object With Meshes (root of gizmo visuals)
     - Degrees Text (optional world‑space text object)
     - Rotation Appendix (optional extra visuals)
     - Rotation/Translation/Scaling components (axis groups)

2) Interact at runtime
   - Press R, T, or Z to toggle Rotation, Translation, or Scale mode
   - Hover an axis/ring to highlight, click and drag to manipulate the target
   - Press the same key again to exit that mode (back to None)

3) Control from UI code (optional)
```csharp
using TransformGizmos;

public class GizmoUI
{
    public GizmoController gizmo;

    public void OnRotationButton() => gizmo.ToggleRotation();
    public void OnMoveButton()     => gizmo.ToggleMovement();
    public void OnScaleButton()    => gizmo.ToggleScale();
}
```

### Building handles
- Implement `IGizmoTransforms` on a MonoBehaviour attached to each axis/ring piece
- Use `GizmoTransformsWrapper` to reference that behaviour from proxy objects like `GizmoBigger`
- Example axis component (Rotation X) wires into a `Rotation` singleton for shared logic

## Controls
- Keyboard: R = Rotate, T = Translate, Z = Scale (press again to toggle off)
- Mouse: Hover to highlight; Click+Drag on an axis/ring/handle to apply the transform

## Public API surface
- `TransformGizmos.GizmoController`
  - Fields: Target Object, Gizmo Size, highlight materials, visual roots
  - Methods: `ToggleRotation()`, `ToggleMovement()`, `ToggleScale()`
- `TransformGizmos.IGizmoTransforms`
  - Interface: `OnMouseEnter/Exit/Down/Up/Drag()` for custom handle logic
- `TransformGizmos.TransformationsUtility`
  - `HandleMouseOutsideScreen(Vector2 initial, Vector3 moveDir)` projects drag when cursor hits screen edges

## Notes and Limitations
- Colliders are required on gizmo parts for mouse events to fire
- Event order depends on Unity’s `OnMouse*` implementation; ensure only gizmo layers receive clicks
- Materials/visuals are user‑provided; assign appropriate defaults for your project
- The rotation example uses a `Rotation` singleton and axis indices (0=X/1=Y/2=Z); ensure companion components exist for all axes/modes
- New Input System cursor warping is commented out; the utility still projects drags to keep motion stable at screen edges

## Files in This Package
- `Runtime/Gizmo/GizmoController.cs` – Main controller: mode switching, alignment, size, and initialization
- `Runtime/Gizmo/GizmoBigger.cs` – Proxy that forwards `OnMouse*` to a wrapped `IGizmoTransforms`
- `Runtime/Gizmo/IGizmoTransforms.cs` – Interface and wrapper for handle behaviours
- `Runtime/Helper/TransformationsUtility.cs` – Mouse edge handling and projection helper
- `Runtime/Rotation/RotationX.cs` – Example X‑axis rotation handle using a shared `Rotation` module
- `Runtime/UnityEssentials.RuntimeGizmo.asmdef` – Runtime assembly definition

## Tags
unity, runtime gizmo, transform, rotation, translation, scale, handles, mouse, collider, play mode, tools
