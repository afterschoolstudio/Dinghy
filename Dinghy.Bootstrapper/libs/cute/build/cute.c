#if defined(_WIN32)
#define CUTE_C2_API __declspec(dllexport)
#else
#define CUTE_C2_API extern
#endif
#define CUTE_C2_IMPLEMENTATION
#include "../src/cute_headers/cute_c2.h"