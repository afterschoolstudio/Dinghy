#if defined(_WIN32)
#define CUTE_C2_API extern "C" __declspec(dllexport)
#else
#define CUTE_C2_API extern
#endif
#include "../src/cute_headers/cute_c2.h"