using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System.Runtime.InteropServices;

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

    bool isToolActive = false;
    System.Numerics.Vector4 color = new System.Numerics.Vector4(100, 200, 0, 1);

    public void Render(float delta)
    {
        GL.ClearColor(new Color4(0, 32, 48, 255));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

        ImGui.Begin("FirstExample");
        ImGui.Text($"Hello, world {123}");
        if (ImGui.Button("Save"))
            throw new NotImplementedException("hahahahaha");

        ImGui.InputText("string", ref inputText, 100);
        ImGui.SliderFloat("float", ref sliderValue, 0.0f, 1.0f);
        ImGui.End();

        // Create a window called "My First Tool", with a menu bar.
        ImGui.Begin("My First Tool", ref isToolActive);
        if (ImGui.BeginMenuBar())
        {
            if (ImGui.BeginMenu("File"))
            {
                if (ImGui.MenuItem("Open..", "Ctrl+O")) { /* Do stuff */ }
                if (ImGui.MenuItem("Save", "Ctrl+S")) { /* Do stuff */ }
                if (ImGui.MenuItem("Close", "Ctrl+W")) { isToolActive = false; }
                ImGui.EndMenu();
            }
            ImGui.EndMenuBar();
        }

        // Edit a color stored as 4 floats
        ImGui.ColorEdit4("Color", ref color);

        // Generate samples and plot them
        float[] samples = new float[100];
        for (int n = 0; n < 100; n++)
            samples[n] = MathF.Sin(n * 0.2f + (float)ImGui.GetTime() * 1.5f);

        // hmm, not sure how to pass that ref float
        //ImGui.PlotLines("Samples", samples, #samples);

        // Display contents in a scrolling region
        ImGui.TextColored(new System.Numerics.Vector4(1, 1, 0, 1), "Important Stuff");
        ImGui.BeginChild("Scrolling");
        for (int n = 0; n < 50; n++)
            ImGui.Text($"{n}: Some text");
        ImGui.EndChild();
        ImGui.End();

        renderer.Render();

        GLHelpers.CheckGLError("End of frame");
        gameWindow.SwapBuffers();
    }

    internal void WindowResized(int newWidth, int newHeight)
    {
        renderer.WindowResized(newWidth, newHeight);
    }
}
