dev stuff is all linked via project references (including sandbox) so "just works"

at build:
	nuget package is created for Dinghy
		this also includes Dinghy.Magic as an analyzer DLL 

note: Dinghy.Magic could be packaged as its own nupkg (but right now isnt)