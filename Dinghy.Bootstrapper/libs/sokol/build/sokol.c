#define SOKOL_IMPL
#define SOKOL_DLL
#define SOKOL_NO_ENTRY

#define USE_SOKOL_APP

#if defined(_WIN32)
#define SOKOL_LOG(s) OutputDebugStringA(s)
#endif
/* sokol 3D-API defines are provided by build options */
#include "../../libs/sokol/sokol_app.h"
#include "../../libs/sokol/sokol_args.h"
#include "../../libs/sokol/sokol_audio.h"
#include "../../libs/sokol/sokol_fetch.h"
#include "../../libs/sokol/sokol_gfx.h"

#include "../../libs/sokol_gp/sokol_gp.h"

#include "../../libs/sokol/sokol_glue.h"
#include "../../libs/sokol/sokol_time.h"
#include "../../libs/sokol/sokol_log.h"