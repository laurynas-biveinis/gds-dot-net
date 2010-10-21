The project needs the GD SDK interop assembly to compile.  Google does
not provide one, so it needs to be created by yourself:
1) Get the GD SDK.
2) Run MIDL on the api/misc/GoogleDesktopAPI.idl
3) In the Visual Studio project select add reference, choose Browse, select
the generated TLB file.  Remove any stale references.
