#!/usr/bin/env bash

set -euo pipefail

dotnet run --project Dinghy.Bootstrapper.csproj -c Release -- "$@"