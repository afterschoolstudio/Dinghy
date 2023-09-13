main thing is that --file should be the header file itself, and a shim header if there are inner header deps. --traverse is where you want the actual files.

so for something like sokol_gp this is the rsp file"

```
@settings.rsp  
--file  
sokol_gp_bindgen_helper.h  
--traverse  
../src/sokol_gp/sokol_gp.h  
--methodClassName  
SokolGP  
--output  
../../../../Dinghy.Core/src/generated/lib/sokol/Sokol_GP.cs
```

which points to the bindgen helper shim file:
```
#include "../src/sokol/sokol_gfx.h"  
#include "../src/sokol_gp/sokol_gp.h"
```

