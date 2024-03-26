using OpenTK;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics;
using Imgui_Test;
//using OpenTK.Windowing.Desktop;

public class MyOpenTKApplication : GameWindow
{
    public static readonly string Version = "0.0.2";

    ImGuiController imguiController;
    OpenTkImguiInputConnector inputConnector;

    public MyOpenTKApplication() : base(1600, 900, GraphicsMode.Default, $"Chroma Flare {Version}", GameWindowFlags.FixedWindow, DisplayDevice.Default, 3, 3, GraphicsContextFlags.Default)
    {
        
    }

 

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        Title += ": OpenGL Version: " + GL.GetString(StringName.Version);

        imguiController = new ImGuiController(ClientSize.Width, ClientSize.Height);
        inputConnector = new OpenTkImguiInputConnector(this, imguiController);
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

        ImGuiController.CheckGLError("End of frame");

        SwapBuffers();
    }

    
    // Ehm, seems to not exist, maybe in the missing namespace?
    //protected override void OnTextInput(TextInputEventArgs e)
    //{
    //    base.OnTextInput(e);


    //    _controller.PressChar((char)e.Unicode);
    //}

    //protected override void OnMouseWheel(MouseWheelEventArgs e)
    //{
    //    base.OnMouseWheel(e);

    //    _controller.MouseScroll(e.Offset);
    //}
}
