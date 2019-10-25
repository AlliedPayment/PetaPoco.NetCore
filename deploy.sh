#!/bin/bash

echo Building and Deploying Allied.Core Nuget Packages && \
dotnet build ./src/PetaPoco.NetCore/Allied.PetaPoco.NetCore.csproj -c Release && \
dotnet nuget push ./src/PetaPoco.NetCore/bin/Release/*.nupkg -k nate:AP2oXRuWNKXUCVarK1RCAcGRZin -s https://alliedpayment.jfrog.io/alliedpayment/api/nuget/nuget