using static Dinghy.Internal.Sokol.ImGuiDataType_;

namespace Dinghy.Internal.Sokol;

[NativeTypeName("unsigned int")]
public enum ImGuiDataTypePrivate_ : uint
{
    ImGuiDataType_String = ImGuiDataType_COUNT + 1,
    ImGuiDataType_Pointer,
    ImGuiDataType_ID,
}
