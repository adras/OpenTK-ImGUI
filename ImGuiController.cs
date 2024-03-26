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

    string inputText = "";
    float sliderValue = 0;

    public void Render(float delta)
    {
        GL.ClearColor(new Color4(0, 32, 48, 255));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

        ImGui.Text($"Hello, world {123}");
        if (ImGui.Button("Save"))
            throw new NotImplementedException("hahahahaha");
        
        ImGui.InputText("string", ref inputText, 100);
        ImGui.SliderFloat("float", ref sliderValue, 0.0f, 1.0f);


        renderer.Render();

        GLHelpers.CheckGLError("End of frame");
        gameWindow.SwapBuffers();
    }

    internal void WindowResized(int newWidth, int newHeight)
    {
        renderer.WindowResized(newWidth, newHeight);
    }
}
