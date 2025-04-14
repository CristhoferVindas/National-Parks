using System.Runtime.Loader;

namespace NationalParks.Utils
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
         public IntPtr LoadUnmanagedLibrary(string path)
    {
        return LoadUnmanagedDllFromPath(path); // ✅ ahora lo usamos dentro de la clase
    }
        public CustomAssemblyLoadContext() : base(true) { }

        public  IntPtr LoadUnmanagedDll(string unmanagedDllPath)
        {
            return LoadUnmanagedDllFromPath(unmanagedDllPath);
        }

    }
}
