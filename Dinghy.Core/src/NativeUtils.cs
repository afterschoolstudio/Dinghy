using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Dinghy.NativeInterop;

internal static class Utils
{
    public class NativeArray<T> where T : unmanaged
    {
        public unsafe T* Ptr {get; protected set;}
        int len;
        public NativeArray(int size, bool defaultInit = true)
        {
            len = size;
            if(len < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Size must be a positive number");
            }
            unsafe {
                Ptr = (T*)NativeMemory.Alloc((nuint)size,(nuint)sizeof(T));
                if (defaultInit)
                {
                    for (int i = 0; i < size; i++)
                    {
                        Ptr[i] = default(T);
                    }
                }
            }

        }

        public void Free()
        {
            unsafe
            {
                if(Ptr != null)
                {
                    NativeMemory.Free(Ptr);
                    Ptr = null;
                }
            }
        }

        public ref T this[int index]
        {
            get
            {
                if(index >= len || index < 0)
                {
                    throw new IndexOutOfRangeException("Array Index out of range");
                }
                unsafe
                {
                    // return ref Unsafe.AsRef<T>(Ptr + index);
                    return ref Ptr[index];
                }
            }
        }

        ~NativeArray()
        {
            Free();
        }
    }
}