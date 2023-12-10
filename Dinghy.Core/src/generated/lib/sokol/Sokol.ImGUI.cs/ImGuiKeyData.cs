namespace Dinghy.Internal.Sokol;

public partial struct ImGuiKeyData
{
    [NativeTypeName("bool")]
    public byte Down;

    public float DownDuration;

    public float DownDurationPrev;

    public float AnalogValue;
}
