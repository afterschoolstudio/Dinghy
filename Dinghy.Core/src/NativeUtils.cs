using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Dinghy.Core;

internal static class NativeUtils
{
    public class NativeArray<T> where T : unmanaged
    {
        public unsafe T* Ptr {get; protected set;}
        int len;
        public NativeArray(int size)
        {
            len = size;
            if(len < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Size must be a positive number");
            }
            unsafe {
                Ptr = (T*)NativeMemory.Alloc((nuint)size,(nuint)sizeof(T));
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