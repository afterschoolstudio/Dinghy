bootstrapper:
* /builders
	* these are zig scripts corresponding to libraries in libs/
	* the zig scripts here build DLLs out of the C libraries in libs/
* /generators
	* these are .rsp files meant to generate bindings with ClangSharpPInvokeGenerator for the DLLs produced by running the build scripts in /builders
* /libs
	* these are the actual C libraries used by Dinghy that get compiled and bound against using the steps from above