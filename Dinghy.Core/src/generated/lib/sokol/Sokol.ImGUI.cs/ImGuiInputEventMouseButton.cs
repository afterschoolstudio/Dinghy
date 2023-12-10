namespace Dinghy.Internal.Sokol;

public partial struct ImGuiInputEventMouseButton
{
    public int Button;

    [NativeTypeName("bool")]
    public byte Down;

    public ImGuiMouseSource MouseSource;
}
