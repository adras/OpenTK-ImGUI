using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;

public static class GLHelpers
{

    public static void CheckGLError(string title)
    {
        OpenTK.Graphics.OpenGL4.ErrorCode error;
        int i = 1;
        while ((error = GL.GetError()) != OpenTK.Graphics.OpenGL4.ErrorCode.NoError)
        {
            Debug.Print($"{title} ({i++}): {error}");
        }
    }
}