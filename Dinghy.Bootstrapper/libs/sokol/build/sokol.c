#define SOKOL_IMPL
#define SOKOL_DLL
#define SOKOL_NO_ENTRY
#define SOKOL_DEBUG

#define USE_SOKOL_APP

#if defined(_WIN32)
#define SOKOL_LOG(s) OutputDebugStringA(s)
#endif
/* sokol 3D-API defines are provided by build options */
#include "../src/sokol/sokol_app.h"
#include "../src/sokol/sokol_args.h"
#include "../src/sokol/sokol_audio.h"
#include "../src/sokol/sokol_fetch.h"
#include "../src/sokol/sokol_gfx.h"

#include "../src/sokol_gp/sokol_gp.h"

#include "../src/sokol/sokol_glue.h"
#include "../src/sokol/sokol_time.h"
#include "../src/sokol/sokol_log.h"

#include "../src/sokol/util/sokol_gl.h"
