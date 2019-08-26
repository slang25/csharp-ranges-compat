#if (REFERENCE_ASSEMBLY && !NO_RANGES_SUPPORT)
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(System.Range))]
[assembly: TypeForwardedTo(typeof(System.Index))]

#endif