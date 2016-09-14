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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ClickMaster.Gui.Components{
    public class ToggleButton : Button {
        public bool Toggled { get; set; } = false;
        public string ActiveText { get; set; } = "Active";
        public string InactiveText { get; set; } = "Inactive";

        protected override void OnPaint(PaintEventArgs pevent) {
            if (this.Text.Length == 0) {
                this.Text = GetCurrentText();
            }

            ButtonRenderer.DrawButton(pevent.Graphics, pevent.ClipRectangle, this.Text, this.Font, this.Focused, this.Toggled ? PushButtonState.Pressed : PushButtonState.Normal);
        }

        public string GetCurrentText() {
            return this.Toggled ? this.ActiveText : this.InactiveText;
        }

        public void Toggle() {
            this.Toggled = !this.Toggled;
            this.Text = GetCurrentText();
        }

        protected override void OnMouseClick(MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Toggle();
            } else {
                base.OnMouseClick(e);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (e.KeyChar == ' ') {
                Toggle();
            } else {
                base.OnKeyPress(e);
            }
        }
    }
}
