namespace Dinghy.Internal.Sokol;

public partial struct ImGuiInputEventKey
{
    public ImGuiKey Key;

    [NativeTypeName("bool")]
    public byte Down;

    public float AnalogValue;
}
