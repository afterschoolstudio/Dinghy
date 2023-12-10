namespace Dinghy.Internal.Sokol;

public partial struct ImGuiDockContext
{
    public ImGuiStorage Nodes;

    public ImVector_ImGuiDockRequest Requests;

    public ImVector_ImGuiDockNodeSettings NodesSettings;

    [NativeTypeName("bool")]
    public byte WantFullRebuild;
}
