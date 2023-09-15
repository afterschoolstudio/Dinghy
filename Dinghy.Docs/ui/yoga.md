c header
https://github.com/facebook/yoga/blob/main/yoga/Yoga.h

c api
https://github.com/facebook/yoga/blob/48d82224ee34fd60ad21ab90a2c38dd4cfb1fdb4/docs/_docs/api/c.md

there is also Taffy for similar purposes:
https://github.com/DioxusLabs/taffy

but it has no C externs:
https://github.com/DioxusLabs/taffy/issues/399

but once it does you could use:
https://github.com/Cysharp/csbindgen/
to compile the rust C FFI to C#
https://github.com/Cysharp/csbindgen/
(although maybe you can do direct rust to c# https://github.com/Cysharp/csbindgen/#builder-options-c-to-rust-to-c)


