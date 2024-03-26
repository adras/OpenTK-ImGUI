using ImGuiNET;
using OpenTK;
using OpenTK.Input;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imgui_Test
{
    /// <summary>
    /// This class forwards input events from OpenTK to Imgui
    /// </summary>
    internal class OpenTkImguiInputConnector
    {
        GameWindow gameWindow;
        
        ImGuiIOPtr imGuiIO;

        public OpenTkImguiInputConnector(GameWindow gameWindow, ImGuiIOPtr imGuiIO)
        {
            this.gameWindow = gameWindow;
            this.imGuiIO = imGuiIO;
        }

        /// <summary>
        /// Connects the given OpenTk gameWindow with the given ImGui IO
        /// </summary>
        public void Connect()
        {
            gameWindow.MouseDown += GameWindow_MouseDown;
            gameWindow.MouseUp += GameWindow_MouseUp;
            gameWindow.MouseMove += GameWindow_MouseMove;
            gameWindow.MouseWheel += GameWindow_MouseWheel;

            gameWindow.TextInput += GameWindow_TextInput;
            gameWindow.KeyDown += GameWindow_KeyDown;
            gameWindow.KeyUp += GameWindow_KeyUp;
        }


        /// <summary>
        /// Unregisters the events setup by <see cref="Connect"/>
        /// </summary>
        public void Disconnect()
        {
            gameWindow.MouseDown -= GameWindow_MouseDown;
            gameWindow.MouseUp -= GameWindow_MouseUp;
            gameWindow.MouseMove -= GameWindow_MouseMove;
            gameWindow.MouseWheel -= GameWindow_MouseWheel;

            gameWindow.TextInput -= GameWindow_TextInput;
            gameWindow.KeyDown -= GameWindow_KeyDown;
            gameWindow.KeyUp -= GameWindow_KeyUp;
        }

        private void GameWindow_TextInput(TextInputEventArgs obj)
        {
            imGuiIO.AddInputCharacter((char)obj.Unicode);
        }

        private void GameWindow_KeyDown(KeyboardKeyEventArgs e)
        {
            ImGuiKey key = TranslateKey(e.Key);
            imGuiIO.AddKeyEvent(key, true);
        }

        private void GameWindow_KeyUp(KeyboardKeyEventArgs e)
        {
            ImGuiKey key = TranslateKey(e.Key);
            imGuiIO.AddKeyEvent(key, false);
        }


        private void GameWindow_MouseWheel(MouseWheelEventArgs e)
        {
            imGuiIO.MouseWheel = e.OffsetX;
            imGuiIO.MouseWheel = e.OffsetY;
        }

        private void GameWindow_MouseMove(MouseMoveEventArgs e)
        {
            imGuiIO.MousePos = new System.Numerics.Vector2(e.X, e.Y);
        }

        private void GameWindow_MouseUp(MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButton.Left:
                    imGuiIO.MouseDown[0] = false;
                    break;
                case MouseButton.Middle:
                    imGuiIO.MouseDown[1] = false;
                    break;
                case MouseButton.Right:
                    imGuiIO.MouseDown[2] = false;
                    break;
                // TODO:
                case MouseButton.Button4:
                    break;
                case MouseButton.Button5:
                    break;
                case MouseButton.Button6:
                    break;
                case MouseButton.Button7:
                    break;
                case MouseButton.Button8:
                    break;
            }

        }

        private void GameWindow_MouseDown(MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButton.Left:
                    imGuiIO.MouseDown[0] = true;
                    break;
                case MouseButton.Middle:
                    imGuiIO.MouseDown[1] = true;
                    break;
                case MouseButton.Right:
                    imGuiIO.MouseDown[2] = true;
                    break;
                // TODO:
                case MouseButton.Button4:
                    break;
                case MouseButton.Button5:
                    break;
                case MouseButton.Button6:
                    break;
                case MouseButton.Button7:
                    break;
                case MouseButton.Button8:
                    break;
            }
        }

        public static ImGuiKey TranslateKey(Keys key)
        {
            if (key >= Keys.D0 && key <= Keys.D9)
                return key - Keys.D0 + ImGuiKey._0;

            if (key >= Keys.A && key <= Keys.Z)
                return key - Keys.A + ImGuiKey.A;

            if (key >= Keys.KeyPad0 && key <= Keys.KeyPad9)
                return key - Keys.KeyPad0 + ImGuiKey.Keypad0;

            if (key >= Keys.F1 && key <= Keys.F24)
                return key - Keys.F1 + ImGuiKey.F24;

            switch (key)
            {
                case Keys.Tab: return ImGuiKey.Tab;
                case Keys.Left: return ImGuiKey.LeftArrow;
                case Keys.Right: return ImGuiKey.RightArrow;
                case Keys.Up: return ImGuiKey.UpArrow;
                case Keys.Down: return ImGuiKey.DownArrow;
                case Keys.PageUp: return ImGuiKey.PageUp;
                case Keys.PageDown: return ImGuiKey.PageDown;
                case Keys.Home: return ImGuiKey.Home;
                case Keys.End: return ImGuiKey.End;
                case Keys.Insert: return ImGuiKey.Insert;
                case Keys.Delete: return ImGuiKey.Delete;
                case Keys.Backspace: return ImGuiKey.Backspace;
                case Keys.Space: return ImGuiKey.Space;
                case Keys.Enter: return ImGuiKey.Enter;
                case Keys.Escape: return ImGuiKey.Escape;
                case Keys.Apostrophe: return ImGuiKey.Apostrophe;
                case Keys.Comma: return ImGuiKey.Comma;
                case Keys.Minus: return ImGuiKey.Minus;
                case Keys.Period: return ImGuiKey.Period;
                case Keys.Slash: return ImGuiKey.Slash;
                case Keys.Semicolon: return ImGuiKey.Semicolon;
                case Keys.Equal: return ImGuiKey.Equal;
                case Keys.LeftBracket: return ImGuiKey.LeftBracket;
                case Keys.Backslash: return ImGuiKey.Backslash;
                case Keys.RightBracket: return ImGuiKey.RightBracket;
                case Keys.GraveAccent: return ImGuiKey.GraveAccent;
                case Keys.CapsLock: return ImGuiKey.CapsLock;
                case Keys.ScrollLock: return ImGuiKey.ScrollLock;
                case Keys.NumLock: return ImGuiKey.NumLock;
                case Keys.PrintScreen: return ImGuiKey.PrintScreen;
                case Keys.Pause: return ImGuiKey.Pause;
                case Keys.KeyPadDecimal: return ImGuiKey.KeypadDecimal;
                case Keys.KeyPadDivide: return ImGuiKey.KeypadDivide;
                case Keys.KeyPadMultiply: return ImGuiKey.KeypadMultiply;
                case Keys.KeyPadSubtract: return ImGuiKey.KeypadSubtract;
                case Keys.KeyPadAdd: return ImGuiKey.KeypadAdd;
                case Keys.KeyPadEnter: return ImGuiKey.KeypadEnter;
                case Keys.KeyPadEqual: return ImGuiKey.KeypadEqual;
                case Keys.LeftShift: return ImGuiKey.LeftShift;
                case Keys.LeftControl: return ImGuiKey.LeftCtrl;
                case Keys.LeftAlt: return ImGuiKey.LeftAlt;
                case Keys.LeftSuper: return ImGuiKey.LeftSuper;
                case Keys.RightShift: return ImGuiKey.RightShift;
                case Keys.RightControl: return ImGuiKey.RightCtrl;
                case Keys.RightAlt: return ImGuiKey.RightAlt;
                case Keys.RightSuper: return ImGuiKey.RightSuper;
                case Keys.Menu: return ImGuiKey.Menu;
                default: return ImGuiKey.None;
            }
        }


    }
}
