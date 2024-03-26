using OpenTK;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics;
using Imgui_Test;

public class MyOpenTKApplication : GameWindow
{
    public static readonly string Version = "1.0.2";

    ImGuiController imguiController;
    OpenTkImguiInputConnector inputConnector;

    public MyOpenTKApplication() : base(1600, 900, GraphicsMode.Default, $"My OpenTKApplication {Version}", GameWindowFlags.FixedWindow, DisplayDevice.Default, 3, 3, GraphicsContextFlags.Default)
    {
    }

 

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        Title += ": OpenGL Version: " + GL.GetString(StringName.Version);

        imguiController = new ImGuiController(ClientSize.Width, ClientSize.Height);
        inputConnector = new OpenTkImguiInputConnector(this, imguiController.imGuiIO);
        inputConnector.Connect();
    }


    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        // Update the opengl viewport
        GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);

        // Tell ImGui of the new size
        imguiController.WindowResized(ClientSize.Width, ClientSize.Height);
    }


    protected override void OnRenderFrame(OpenTK.FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        imguiController.Update(this, (float)e.Time);

        GL.ClearColor(new Color(0, 32, 48, 255));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

        // Enable Docking
        ImGui.DockSpaceOverViewport();

        ImGui.ShowDemoWindow();

        imguiController.Render();

        GLHelpers.CheckGLError("End of frame");

        SwapBuffers();
    }
}
