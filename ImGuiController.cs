using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

class ImGuiController
{
    ImGuiRenderer renderer;
    MyOpenTKApplication gameWindow;

    public ImGuiController(MyOpenTKApplication gameWindow)
    {
        this.renderer = new ImGuiRenderer(gameWindow);
        this.gameWindow = gameWindow;
    }

    public void Update(float delta)
    {
        renderer.Update(delta);
    }

    public void Render(float delta)
    {
        GL.ClearColor(new Color4(0, 32, 48, 255));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

        // Enable Docking
        ImGui.DockSpaceOverViewport();

        ImGui.ShowDemoWindow();

        renderer.Render();

        GLHelpers.CheckGLError("End of frame");
        gameWindow.SwapBuffers();

    }

    internal void WindowResized(int newWidth, int newHeight)
    {
        renderer.WindowResized(newWidth, newHeight);
    }
}
