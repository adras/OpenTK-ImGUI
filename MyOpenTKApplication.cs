using OpenTK;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using Imgui_Test;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;

public class MyOpenTKApplication : GameWindow
{
    public static readonly string Version = "1.0.2";

    ImGuiController controller;
    OpenTkImguiInputConnector inputConnector;

    public MyOpenTKApplication() : base(new GameWindowSettings(), new NativeWindowSettings())
    {
    }


    protected override void OnLoad()
    {
        base.OnLoad();
        string openGLVersion = GL.GetString(StringName.Version);
        Title = $"ImGui-OpenTk - OpenGL version: {openGLVersion}";

        controller = new ImGuiController(this);
        inputConnector = new OpenTkImguiInputConnector(this, ImGui.GetIO());
        inputConnector.Connect();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);

        // Update the opengl viewport
        GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);

        // Tell ImGui of the new size
        controller.WindowResized(ClientSize.X, ClientSize.Y);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        controller.Update((float)args.Time);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        controller.Render((float)args.Time);
    }
}
