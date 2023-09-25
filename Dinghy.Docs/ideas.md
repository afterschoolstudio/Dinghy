* sourcegen
	* ideally leverage https://github.com/scriban/scriban for easy templating
		* also being able to provide templates to end-users to easily bind for arbitrary scenarios would be cool
	* ldtk
	* aseprite
	* depot
	* razor pages
		* use a razor compiler lib to spit out proper ui pages to be displayed and bound against
			* https://github.com/toddams/RazorLight

other interesting libs
* https://github.com/xoofx/markdig
	* markdown processor in dotnet
* https://github.com/xoofx/dotnet-releaser
	* releaser wrapper
* https://github.com/xoofx/zio
	* virtual filesystem
* https://github.com/GlaireDaggers/ContentPipe
	* content pipeline system
	* imo this is maybe nullified for normal build time deps via sourcegen
* https://github.com/Cysharp/MagicOnion
	* realtime network lib
* https://github.com/Cysharp/MemoryPack
	* super fast serializer
* https://github.com/libsdl-org/SDL/blob/399bc709b7485bab57880f8261f826f29dc0d7b2/src/joystick/SDL_gamepad.c
	* gamepad support (sokol doesnt have it)