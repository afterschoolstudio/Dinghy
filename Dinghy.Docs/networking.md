general idea is to provide a super easy networking lib (ha)

my idea is that you tag functions as networked somehow, and as part of the compilation process those functions get exported/compiled/bound/deployed to a cloudflare worker style thing

c#->wasm
https://github.com/dotnet/aspnetcore/issues/46344#issuecomment-1410063222
https://blog.cloudflare.com/webassembly-on-cloudflare-workers/
from https://developers.cloudflare.com/workers/learning/languages/

it would also not be hard to just "emit" some basic js server code based on attributes at compile time:
https://blog.cloudflare.com/building-real-time-games-using-workers-durable-objects-and-unity/

tagging functions for conditional seperate compilation:
https://garry.net/posts/rusts-networking