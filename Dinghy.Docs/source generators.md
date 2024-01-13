issue right now on source gen where whole solution rebuild needs to happen for them to be updated.

best way is running this in the root Dinghy/ dir
`dotnet clean && dotnet build-server shutdown && dotnet build`

then rebuilding the project