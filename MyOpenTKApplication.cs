using OpenTK;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using Imgui_Test;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;

public class MyOpenTKApplication : GameWindow
{
    public static readonly string Version = "1.0.2";

    ImGuiController imguiController;
    OpenTkImguiInputConnector inputConnector;

    public MyOpenTKApplication() : base (new GameWindowSettings(), new NativeWindowSettings())
    {
    }


    protected override void OnLoad()
    {
        base.OnLoad();

        Title += ": OpenGL Version: " + GL.GetString(StringName.Version);

        imguiController = new ImGuiController(ClientSize.X, ClientSize.Y);
        inputConnector = new OpenTkImguiInputConnector(this, imguiController.imGuiIO);
        inputConnector.Connect();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);

        // Update the opengl viewport
        GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);

        // Tell ImGui of the new size
        imguiController.WindowResized(ClientSize.X, ClientSize.Y);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        imguiController.Update(this, (float)args.Time);

        GL.ClearColor(new Color4(0, 32, 48, 255));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

        // Enable Docking
        ImGui.DockSpaceOverViewport();

        ImGui.ShowDemoWindow();

        imguiController.Render();

        GLHelpers.CheckGLError("End of frame");

        SwapBuffers();
    }
}
