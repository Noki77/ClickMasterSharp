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

using System.Windows.Forms;
using System.Drawing;

namespace ClickMaster {
    public class Action {
        public ActionType Type { get; }
        public Point Location { get; }
        public Keys Key { get; }

        public Action(ActionType Type, Keys Key) {
            this.Type = Type;
            this.Key = Key;
        }

        public Action(ActionType Type, Point Location) {
            this.Type = Type;
            this.Location = Location;
        }

        public bool isKey() {
            return this.Type.Equals(ActionType.KeyDown) || this.Type.Equals(ActionType.KeyUp) || this.Type.Equals(ActionType.KeyPress);
        }

        public override string ToString() {
            return Type.DisplayString + " " + (isKey() ? "[ " + this.Key + " ]" : "(" + this.Location.X + "; " + this.Location.Y + ")");
        }

        public class ActionType {
            public string DisplayString { get; }
            public MouseButton ButtonPressed { get; }

            private ActionType(string Display, MouseButton Pressed) {
                this.DisplayString = Display;
                this.ButtonPressed = Pressed;
            }

            private ActionType(string Display) {
                this.DisplayString = Display;
            }

            public static readonly ActionType LeftClick = new ActionType("Left click", MouseButton.LEFT_BUTTON);
            public static readonly ActionType RightClick = new ActionType("Right click", MouseButton.RIGHT_BUTTON);
            public static readonly ActionType MouseDownLeft = new ActionType("Left mouse down", MouseButton.LEFT_BUTTON);
            public static readonly ActionType MouseDownRight = new ActionType("Right mouse down", MouseButton.RIGHT_BUTTON);
            public static readonly ActionType MouseUpLeft = new ActionType("Left mouse up", MouseButton.LEFT_BUTTON);
            public static readonly ActionType MouseUpRight = new ActionType("Right mouse up", MouseButton.RIGHT_BUTTON);
            public static readonly ActionType KeyPress = new ActionType("Key press");
            public static readonly ActionType KeyUp = new ActionType("Key up");
            public static readonly ActionType KeyDown = new ActionType("Key down");

            public enum MouseButton {
                RIGHT_BUTTON, LEFT_BUTTON
            }
        }
    }
}
