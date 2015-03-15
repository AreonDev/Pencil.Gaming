Pencil.Gaming
=============
Pencil.Gaming is a gaming library for C#, providing support for OpenGL, GLFW, OpenAL and Lua. It's a stable, cross-platform, open-source (some prefer the term "free") alternative to libraries like XNA, which has pretty much died now, OpenTK, which hasn't been updated for about a year, and SharpDX, which is not cross-platform. A feature that Pencil.Gaming has over most other C# gaming libraries, is that users **do not need to install any redistributables besides Mono/.NET!** 

This fork is used in our 3D framework [FreezingArcher] (https://github.com/fin-ger/FreezingArcher)

We removed the olkd and deprecated GLFW2 and the backward compatible GLFW3 build targets, introduced some patches to the OpenAL binding, added a newer OpenAL32.dll for Windows, patched some of the Window functions and many more.


The OpenGL implementation is based on the OpenTK source code.


GLFW3
-----
| Platform       | OpenGL core     | OpenGL extensions | GLFW            | OpenAL    |
| --------------:|:---------------:|:-----------------:|:---------------:|:---------:|
| Linux 64-bit   | Stable          | Stable            | Stable          | Stable    |
| Linux 32-bit   | Stable          | Stable            | **Broken**      | Stable    |
| Windows 64-bit | Stable          | Stable            | Stable          | Stable    |
| Windows 32-bit | Stable          | Stable            | Stable          | Stable    |
| Mac OS X       | Stable          | Stable            | Stable*         | Stable    |

*Both 32 and 64-bit versions provided for Mac OS X, but mono is realistically only available for 32-bit, so those are recommended.

Building
--------

While the official repository suggests building via Makefile, we don't support this officialy. However, the tutorial should still work, we recommend to build using xbuild or msbuild (Monodevelop/VisualStudio)

Lua
===
Lua is a light-weight scripting language, perfectly suitable for use in game development.

Pencil.Gaming provides support for Lua, using the default C# `PascalCased` identifiers, making it integrate seamlessly with other C# code.

Whereas a C-api function call might be `lua_pcall(L, 0, LUA_MULTRET, 0)`, the Pencil.Gaming C# API call would be `Lua.PCall(L, 0, Lua.MultRet, 0)`.

For more information on using these lua bindings, see the [Lua C api docs](http://www.lua.org/pil/contents.html#24).

Other Resources
===============

* [Collada Importer](http://sourceforge.net/projects/csharpcollada/)
