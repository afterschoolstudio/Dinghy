#
# project: sokol-dll-builder
# copied mostly from sokol-samples
#
cmake_minimum_required(VERSION 3.2)
set(CMAKE_OSX_DEPLOYMENT_TARGET "10.13" CACHE STRING "")
set(CMAKE_C_STANDARD 99)
if (CMAKE_SYSTEM_NAME STREQUAL "WindowsStore")
    set(CMAKE_CXX_STANDARD 17)
else()
    set(CMAKE_CXX_STANDARD 14)
endif()
project(sokol-dll-builder)

if (SOKOL_USE_WGPU_DAWN)
    set(USE_DAWN_SDK ON)
endif()

# include the fips main cmake file
get_filename_component(FIPS_ROOT_DIR "../fips" ABSOLUTE)
include("${FIPS_ROOT_DIR}/cmake/fips.cmake")
fips_setup()

# just suppress this pesky "missing field initializer warning" for now
if (FIPS_CLANG OR FIPS_GCC)
    set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wno-missing-field-initializers -Wsign-conversion")
endif()

#  platform selection
add_definitions(-DSOKOL_NO_DEPRECATED)
if (FIPS_EMSCRIPTEN)
    if (FIPS_EMSCRIPTEN_USE_WEBGPU)
        set(sokol_backend SOKOL_WGPU)
        set(slang "wgpu")
    else()
        set(sokol_backend SOKOL_GLES3)
        set(slang "glsl300es:glsl100")
    endif()
elseif (FIPS_ANDROID)
    set(sokol_backend SOKOL_GLES3)
    set(slang "glsl300es:glsl100")
elseif (SOKOL_USE_D3D11)
    set(sokol_backend SOKOL_D3D11)
    set(slang "hlsl4")
elseif (SOKOL_USE_METAL)
    set(sokol_backend SOKOL_METAL)
    if (FIPS_IOS)
        set(slang "metal_ios:metal_sim")
    else()
        set(slang "metal_macos")
    endif()
else()
    if (FIPS_IOS)
        set(sokol_backend SOKOL_GLES3)
        set(slang "glsl300es:glsl100")
    else()
        set(sokol_backend SOKOL_GLCORE33)
        set(slang "glsl330")
    endif()
endif()

include_directories(libs)
fips_ide_group("Libs")
add_subdirectory(libs)
fips_finish()


