/*
 * This file is part of the project ClickMaster, licensed under the
 * Creative Commons Attribution-NoDerivatives 4.0 International license.
 * 
 * Copyright (c) 2016 Justin Vogel <dernoki77@gmail.com>
 * 
 * You should have received a copy of the license along with this
 * work. If not, see <http://creativecommons.org/licenses/by-nd/4.0/>.
 * 
 * THIS SOFTWARE IS PROVIDED UNDER THE TERMS
 * OF THIS CREATIVE COMMONS PUBLIC LICENSE ("CCPL" OR "LICENSE").
 * THE SOFTWARE IS PROTECTED BY COPYRIGHT AND/OR OTHER APPLICABLE LAW.
 * ANY USE OF THE WORK OTHER THAN AS AUTHORIZED UNDER THIS LICENSE
 * OR COPYRIGHT LAW IS PROHIBITED.
 * 
 * BY EXERCISING ANY RIGHTS TO THE SOFTWARE PROVIDED HERE,
 * YOU ACCEPT AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE.
 * TO THE EXTENT THIS LICENSE MAY BE CONSIDERED TO BE A CONTRACT,
 * THE LICENSOR GRANTS YOU THE RIGHTS CONTAINED HERE IN CONSIDERATION
 * OF YOUR ACCEPTANCE OF SUCH TERMS AND CONDITIONS.
 */

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClickMaster.Util {
    public static class WinApiUtil {

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowID);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint DwFlags, uint DX, uint DY, uint DwData, int DwExtraInfo);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte KeyCode, byte BScan, uint DwFlags, UIntPtr DwExtraInfo);

        private static void mouse_event(MouseFlags DwFlags, uint DX, uint DY, uint DwData, int DwExtraInfo) {
            mouse_event((uint) DwFlags, DX, DY, DwData, DwExtraInfo);
        }

        public static void MouseDown(Action.ActionType.MouseButton MouseButton, uint MouseX, uint MouseY, bool move) {
            if (move) {
                SetCursorPos((int) MouseX, (int) MouseY);
            }
            mouse_event(MouseButton == Action.ActionType.MouseButton.LEFT_BUTTON ? MouseFlags.MouseDownLeft
                : MouseFlags.MouseDownRight, 0, 0, 0, 0);
        }

        public static void MouseDown(Action.ActionType.MouseButton MouseButton, uint MouseX, uint MouseY) {
            MouseDown(MouseButton, MouseX, MouseY, true);
        }

        public static void MouseDown(Action.ActionType.MouseButton MouseButton) {
            MouseDown(MouseButton, 0, 0, false);
        }

        public static void MouseUp(Action.ActionType.MouseButton MouseButton, uint MouseX, uint MouseY, bool move) {
            if (move) {
                SetCursorPos((int) MouseX, (int) MouseY);
            }
            mouse_event(MouseButton == Action.ActionType.MouseButton.LEFT_BUTTON ? MouseFlags.MouseUpLeft
                : MouseFlags.MouseUpRight, 0, 0, 0, 0);
        }

        public static void MouseUp(Action.ActionType.MouseButton MouseButton, uint MouseX, uint MouseY) {
            MouseUp(MouseButton, MouseX, MouseY, true);
        }

        public static void MouseUp(Action.ActionType.MouseButton MouseButton) {
            MouseUp(MouseButton, 0, 0, false);
        }

        public static void MouseClick(Action.ActionType.MouseButton MouseButton, uint MouseX, uint MouseY, bool move) {
            MouseDown(MouseButton, MouseX, MouseY, move);
            MouseUp(MouseButton, MouseX, MouseY, move);
        }

        public static void MouseClick(Action.ActionType.MouseButton MouseButton, uint MouseX, uint MouseY) {
            MouseClick(MouseButton, MouseX, MouseY, true);
        }

        public static void MouseClick(Action.ActionType.MouseButton MouseButton) {
            MouseClick(MouseButton, 0, 0, false);
        }

        public static void MouseMove(uint AmountX, uint AmountY) {
            mouse_event(MouseFlags.Move, AmountX, AmountY, 0, 0);
        }

        public static void Scroll(uint ScrollAmount) {
            mouse_event(MouseFlags.Wheel, 0, 0, ScrollAmount, 0);
        }

        public static void KeyDown(Keys Key) {
            keybd_event((byte) Key, 0x45, 0x0001 | 0, UIntPtr.Zero);
        }

        public static void KeyUp(Keys Key) {
            keybd_event((byte) Key, 0x45, 0x0002 | 0x0001, UIntPtr.Zero);
        }

        public static void KeyPress(Keys Key) {
            KeyDown(Key);
            KeyUp(Key);
        }

        public enum MouseFlags : uint {
            MouseDownLeft = 0x0002,
            MouseDownRight = 0x0008,
            MouseDownMiddle = 0x0020,
            MouseUpLeft = 0x0004,
            MouseUpRight = 0x0010,
            MouseUpMiddle = 0x0040,
            Move = 0x0001,
            Wheel = 0x0800,
            Absolute = 0x8000,

            XDown = 0x0080,
            XUp = 0x0100
        }

        public enum MouseDataXButtons : uint {
            XButton1 = 0x0001,
            XButton2 = 0x0002
        }
    }
}
