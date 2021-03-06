#region License
// Copyright (c) 2013 Antonie Blom
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Runtime.InteropServices;

namespace Pencil.Gaming.Audio
{
    internal static class Alc32
    {
        private const string lib = "lib32/openal32.dll";

        [DllImport (Alc32.lib)]
        internal static extern bool alcCloseDevice (IntPtr device);

        [DllImport (Alc32.lib)]
        internal static extern IntPtr alcOpenDevice ([MarshalAs (UnmanagedType.LPStr)] string devicename);

        [DllImport (Alc32.lib)]
        internal static extern bool alcIsExtensionPresent (IntPtr device, [MarshalAs (UnmanagedType.LPStr)] string extname);

        [DllImport (Alc32.lib)]
        internal static extern void alcGetIntegerv (IntPtr device, int param, int size, [MarshalAs (UnmanagedType.LPArray)] int[] data);

        [DllImport (Alc32.lib)]
        internal static extern IntPtr alcCreateContext (IntPtr device, [MarshalAs (UnmanagedType.LPArray)] int[] attrlist);

        [DllImport (Alc32.lib)]
        internal static extern bool alcMakeContextCurrent (IntPtr context);

#if DEBUG
        [DllImport (Alc32.lib)]
        internal static extern IntPtr alcGetString([In] IntPtr device, int param);

        [DllImport(Alc32.lib)]
        internal static extern int alcGetError();
#endif
    }
}

