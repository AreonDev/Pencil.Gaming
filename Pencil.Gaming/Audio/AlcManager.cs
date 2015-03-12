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
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Pencil.Gaming.Audio
{
    internal sealed class AlcManager
    {
        private static IntPtr alcDeviceHandle;
        private static IntPtr alcContextHandle;

        private delegate bool CloseDevice (IntPtr hndl);

        private delegate IntPtr OpenDevice (string str);

        private delegate bool IsExtensionPresent (IntPtr hndl, string extnsn);

        private delegate void GetIntegerv (IntPtr hndl, int @int, int count, int[] @out);

        private delegate IntPtr CreateContext (IntPtr hndl, int[] attribs);

        private delegate bool MakeContextCurrent (IntPtr hndl);

#if DEBUG

        private delegate IntPtr GetString(IntPtr dev, int getString);

        private delegate int GetError();
        private static string _GetString(GetString alcGetString, IntPtr device, int param)
        {
            return Marshal.PtrToStringAnsi(alcGetString(device, param));
        }

        private static IList<string> GetStringList(GetString alcGetString, IntPtr device, int param)
        {
            List<string> result = new List<string>();
            IntPtr t = alcGetString(IntPtr.Zero, param);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            byte b;
            int offset = 0;
            do
            {
                b = Marshal.ReadByte(t, offset++);
                if (b != 0)
                    sb.Append((char)b);
                if (b == 0)
                {
                    result.Add(sb.ToString());
                    if (Marshal.ReadByte(t, offset) == 0) // offset already properly increased through ++
                        break; // 2x null
                    else
                        sb.Remove(0, sb.Length); // 1x null
                }
            } while (true);

            return (IList<string>)result;
        }

#endif
        public AlcManager ()
        {
#if DEBUG
			Stopwatch sw = new Stopwatch();
			sw.Start();
#endif
            CloseDevice alcCloseDevice = null;
            OpenDevice alcOpenDevice = null;
            IsExtensionPresent alcIsExtensionPresent = null;
            GetIntegerv alcGetIntegerv = null;
            CreateContext alcCreateContext = null;
            MakeContextCurrent alcMakeContextCurrent = null;
#if DEBUG
            GetString alcGetString = null;
            GetError alcGetError = null;
#endif
            if (IntPtr.Size == 8)
            {
                alcCloseDevice = Alc64.alcCloseDevice;
                alcOpenDevice = Alc64.alcOpenDevice;
                alcIsExtensionPresent = Alc64.alcIsExtensionPresent;
                alcGetIntegerv = Alc64.alcGetIntegerv;
                alcCreateContext = Alc64.alcCreateContext;
                alcMakeContextCurrent = Alc64.alcMakeContextCurrent;
#if DEBUG
                Console.WriteLine("Alc64");
                alcGetString = Alc64.alcGetString;
                alcGetError = Alc64.alcGetError;
#endif
            }
            else
            {
                alcCloseDevice = Alc32.alcCloseDevice;
                alcOpenDevice = Alc32.alcOpenDevice;
                alcIsExtensionPresent = Alc32.alcIsExtensionPresent;
                alcGetIntegerv = Alc32.alcGetIntegerv;
                alcCreateContext = Alc32.alcCreateContext;
                alcMakeContextCurrent = Alc32.alcMakeContextCurrent;
#if DEBUG
                Console.WriteLine("Alc32");
                alcGetString = Alc32.alcGetString;
                alcGetError = Alc32.alcGetError;
#endif
            }

            alcDeviceHandle = alcOpenDevice (null);

#if DEBUG
            IList<string> list = GetStringList(alcGetString, IntPtr.Zero, 0x1005);
            var error = alcGetError();
            Console.WriteLine("error: {0}", error);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            if (alcDeviceHandle == IntPtr.Zero)
            {
                // TODO: Named devices
                throw new Exception ("Could not find audio device.");
            }

            string str = _GetString(alcGetString, IntPtr.Zero, 0x1006);
            Console.WriteLine(str);
#endif
            List<int> attributes = new List<int> { 4105, 0, };
            if (alcIsExtensionPresent (alcDeviceHandle, "ALC_EXT_EFX"))
            {
                int[] alcInteger = new int[1];
                alcGetIntegerv (alcDeviceHandle, 0x20003, 1, alcInteger);
                attributes.Add(0x20003);
                attributes.Add (alcInteger[0]);
                MaxAuxiliarySends = alcInteger[0];
            }
            attributes.Add (0);

            alcContextHandle = alcCreateContext (alcDeviceHandle, attributes.ToArray ());

            if (alcContextHandle == IntPtr.Zero)
            {
                alcCloseDevice (alcDeviceHandle);
                throw new Exception ("Failed to create ALC context.");
            }

            alcMakeContextCurrent (alcContextHandle);

#if DEBUG
			sw.Stop();
			Console.WriteLine("Initializing ALC took {0} milliseconds.", sw.ElapsedMilliseconds);
#endif
        }

        public int MaxAuxiliarySends{ get; private set;}
        ~AlcManager ()
        {
            if (IntPtr.Size == 8)
            {
                Alc64.alcCloseDevice (alcDeviceHandle);
            }
            else
            {
                Alc32.alcCloseDevice (alcDeviceHandle);
            }
        }

        public void MakeCurrent()
        {
            Alc64.alcMakeContextCurrent(alcContextHandle);
        }
    }
}

