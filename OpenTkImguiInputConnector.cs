using ImGuiNET;
using OpenTK;
using OpenTK.Input;
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

            gameWindow.KeyPress += GameWindow_KeyPress;
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

            gameWindow.KeyPress -= GameWindow_KeyPress;
            gameWindow.KeyDown -= GameWindow_KeyDown;
            gameWindow.KeyUp -= GameWindow_KeyUp;
        }

        private void GameWindow_KeyDown(object? sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            ImGuiKey key = TranslateKey(e.Key);
            imGuiIO.AddKeyEvent(key, true);
        }

        private void GameWindow_KeyUp(object? sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            ImGuiKey key = TranslateKey(e.Key);
            imGuiIO.AddKeyEvent(key, false);
        }

        private void GameWindow_KeyPress(object? sender, KeyPressEventArgs e)
        {
            imGuiIO.AddInputCharacter(e.KeyChar);
        }

        private void GameWindow_MouseWheel(object? sender, OpenTK.Input.MouseWheelEventArgs e)
        {
            imGuiIO.MouseWheel = e.Delta;
        }

        private void GameWindow_MouseMove(object? sender, OpenTK.Input.MouseMoveEventArgs e)
        {
            imGuiIO.MousePos = new System.Numerics.Vector2(e.X, e.Y);
        }

        private void GameWindow_MouseUp(object? sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case OpenTK.Input.MouseButton.Left:
                    imGuiIO.MouseDown[0] = false;
                    break;
                case OpenTK.Input.MouseButton.Middle:
                    imGuiIO.MouseDown[1] = false;
                    break;
                case OpenTK.Input.MouseButton.Right:
                    imGuiIO.MouseDown[2] = false;
                    break;
                // TODO:
                case OpenTK.Input.MouseButton.Button1:
                    break;
                case OpenTK.Input.MouseButton.Button2:
                    break;
                case OpenTK.Input.MouseButton.Button3:
                    break;
                case OpenTK.Input.MouseButton.Button4:
                    break;
                case OpenTK.Input.MouseButton.Button5:
                    break;
                case OpenTK.Input.MouseButton.Button6:
                    break;
                case OpenTK.Input.MouseButton.Button7:
                    break;
                case OpenTK.Input.MouseButton.Button8:
                    break;
                case OpenTK.Input.MouseButton.Button9:
                    break;
                case OpenTK.Input.MouseButton.LastButton:
                    break;
            }

        }

        private void GameWindow_MouseDown(object? sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case OpenTK.Input.MouseButton.Left:
                    imGuiIO.MouseDown[0] = true;
                    break;
                case OpenTK.Input.MouseButton.Middle:
                    imGuiIO.MouseDown[1] = true;
                    break;
                case OpenTK.Input.MouseButton.Right:
                    imGuiIO.MouseDown[2] = true;
                    break;
                // TODO:
                case OpenTK.Input.MouseButton.Button1:
                    break;
                case OpenTK.Input.MouseButton.Button2:
                    break;
                case OpenTK.Input.MouseButton.Button3:
                    break;
                case OpenTK.Input.MouseButton.Button4:
                    break;
                case OpenTK.Input.MouseButton.Button5:
                    break;
                case OpenTK.Input.MouseButton.Button6:
                    break;
                case OpenTK.Input.MouseButton.Button7:
                    break;
                case OpenTK.Input.MouseButton.Button8:
                    break;
                case OpenTK.Input.MouseButton.Button9:
                    break;
                case OpenTK.Input.MouseButton.LastButton:
                    break;
            }
        }

        public static ImGuiKey TranslateKey(OpenTK.Input.Key key)
        {
            if (key >= Key.Number0 && key <= Key.Number9)
                return key - Key.Number0 + ImGuiKey._0;

            if (key >= Key.A && key <= Key.Z)
                return key - Key.A + ImGuiKey.A;

            if (key >= Key.Keypad0 && key <= Key.Keypad9)
                return key - Key.Keypad0 + ImGuiKey.Keypad0;

            if (key >= Key.F1 && key <= Key.F24)
                return key - Key.F1 + ImGuiKey.F24;

            switch (key)
            {
                case Key.Tab: return ImGuiKey.Tab;
                case Key.Left: return ImGuiKey.LeftArrow;
                case Key.Right: return ImGuiKey.RightArrow;
                case Key.Up: return ImGuiKey.UpArrow;
                case Key.Down: return ImGuiKey.DownArrow;
                case Key.PageUp: return ImGuiKey.PageUp;
                case Key.PageDown: return ImGuiKey.PageDown;
                case Key.Home: return ImGuiKey.Home;
                case Key.End: return ImGuiKey.End;
                case Key.Insert: return ImGuiKey.Insert;
                case Key.Delete: return ImGuiKey.Delete;
                case Key.BackSpace: return ImGuiKey.Backspace;
                case Key.Space: return ImGuiKey.Space;
                case Key.Enter: return ImGuiKey.Enter;
                case Key.Escape: return ImGuiKey.Escape;
                //case Key.Apostrophe: return ImGuiKey.Apostrophe;
                case Key.Comma: return ImGuiKey.Comma;
                case Key.Minus: return ImGuiKey.Minus;
                case Key.Period: return ImGuiKey.Period;
                case Key.Slash: return ImGuiKey.Slash;
                case Key.Semicolon: return ImGuiKey.Semicolon;
                //case Key.Equal: return ImGuiKey.Equal;
                case Key.BracketLeft: return ImGuiKey.LeftBracket;
                case Key.BackSlash: return ImGuiKey.Backslash;
                case Key.BracketRight: return ImGuiKey.RightBracket;
                
                case Key.Grave: return ImGuiKey.GraveAccent;
                case Key.CapsLock: return ImGuiKey.CapsLock;
                case Key.ScrollLock: return ImGuiKey.ScrollLock;
                case Key.NumLock: return ImGuiKey.NumLock;
                case Key.PrintScreen: return ImGuiKey.PrintScreen;
                case Key.Pause: return ImGuiKey.Pause;
                case Key.KeypadDecimal: return ImGuiKey.KeypadDecimal;
                case Key.KeypadDivide: return ImGuiKey.KeypadDivide;
                case Key.KeypadMultiply: return ImGuiKey.KeypadMultiply;
                case Key.KeypadSubtract: return ImGuiKey.KeypadSubtract;
                case Key.KeypadAdd: return ImGuiKey.KeypadAdd;
                case Key.KeypadEnter: return ImGuiKey.KeypadEnter;
                //case Key.Keypad: return ImGuiKey.KeypadEqual;
                case Key.ShiftLeft: return ImGuiKey.LeftShift;
                case Key.ControlLeft: return ImGuiKey.LeftCtrl;
                case Key.AltLeft: return ImGuiKey.LeftAlt;
                //case Key.LeftSuper: return ImGuiKey.LeftSuper;
                case Key.ShiftRight: return ImGuiKey.RightShift;
                case Key.ControlRight: return ImGuiKey.RightCtrl;
                case Key.AltRight: return ImGuiKey.RightAlt;
                //case Key.RightSuper: return ImGuiKey.RightSuper;
                case Key.Menu: return ImGuiKey.Menu;
                default: return ImGuiKey.None;
            }
        }


    }
}
