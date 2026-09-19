<img width="1200" height="706" alt="EasyQuant-for-Unity (1)" src="https://github.com/user-attachments/assets/fc2b787b-d44f-45d5-81c2-ec1b5a2f65e8" />
# EasyQuat
## Unity 5.0+

Two helpers for making Quaternions in Unity.

## Download

Get either one:


- [EasyQuat.unitypackage](EasyQuat.unitypackage) - import with Assets > Import Package > Custom Package. Or just drag it in. Goes in `Assets/EasyQuat/`.
- [src/EasyQuat.cs](src/EasyQuat.cs) - drop it anywhere under `Assets/`.

Same script either way.

## Use

```csharp
using UnityEngine;
using EasyQuat;

public class Example : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.rotation = dir.Vec3ToQuat();
        transform.rotation = new Vector3(0f, 90f, 0f).EulerToQuat();
    }
}
```

Want to call them without a vector in front? Add this line and you can:

```csharp
using static EasyQuat.Quat;

transform.rotation = Vec3ToQuat(dir);
transform.rotation = EulerToQuat(0f, 90f, 0f);
```

(`using EasyQuat;` alone can't do that. C# only imports namespaces with `using`.)

## Functions

`Vec3ToQuat` takes a direction and gives you the rotation that faces down it.

```csharp
Vec3ToQuat(Vector3 direction)
Vec3ToQuat(Vector3 direction, Vector3 up)
Vec3ToQuat(float x, float y, float z)
```

`EulerToQuat` takes angles in degrees.

```csharp
EulerToQuat(Vector3 eulerAngles)
EulerToQuat(float pitch, float yaw, float roll)
```

Both also work as extension methods on Vector3.

`Vec3ToQuat` won't flip when you look straight up or down, and a zero-length direction just returns identity.

## Thanks for using EasyQuat
# Made by Cdev with love =D
