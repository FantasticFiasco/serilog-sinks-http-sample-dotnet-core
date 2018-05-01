# Serilog.Sinks.Http - Sample in .NET Core

[![Build status](https://ci.appveyor.com/api/projects/status/n6xpr0vxexlb1oro/branch/master?svg=true)](https://ci.appveyor.com/project/FantasticFiasco/serilog-sinks-http-sample-dotnet-core/branch/master)

This repository contains a sample application of [Serilog.Sinks.Http](https://github.com/FantasticFiasco/serilog-sinks-http) producing log events sent over HTTP to a basic log server.

## Running the application

1. Run `docker-compose up`

What you will end up with is two containers, one producing log events while the other consumes the log events.