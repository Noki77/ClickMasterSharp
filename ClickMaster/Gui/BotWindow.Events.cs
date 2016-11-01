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

using Gma.UserActivityMonitor;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClickMaster.Gui {
    public partial class BotWindow {
        private Keys StartKey = Keys.Oem5;
        private Keys CurrentChosenKey;

        private void SelectKey(object sender, EventArgs e) {
            if (!this.IsWatingForPress) {
                this.IsWatingForPress = true;
                this.KeyToAccept = KeyType.KEY_ADD;
                this.KeyChosenBox.Text = "Press any key...";
                this.Focus();
            }
        }

        private void SelectStartKey(object sender, EventArgs e) {
            if (!this.IsWatingForPress) {
                this.IsWatingForPress = true;
                this.KeyToAccept = KeyType.KEY_START_STOP;
                this.StartKeyButton.Text = "Press any key...";
                this.Focus();
            }
        }

        private void ReceiveKey(object sender, KeyEventArgs e) {
            if (this.IsWatingForPress) {
                if (this.KeyToAccept == KeyType.KEY_ADD) {
                    this.CurrentChosenKey = e.KeyCode;
                    this.KeyChosenBox.Text = e.KeyCode.ToString();
                } else {
                    this.StartKey = e.KeyCode;
                    this.StartKeyButton.Text = "Key: " + this.StartKey;
                }
                this.IsWatingForPress = false;
            }
        }

        private void ClearList(object sender, EventArgs e) {
            this.ActionsList.Clear();
        }

        private void RemoveFromList(object sender, EventArgs e) {
            if (this.ActionsList.SelectedIndices.Count == 1) {
                this.ActionsList.Items.Remove(this.ActionsList.FocusedItem);
            }
        }
        
        private void Up(object sender, EventArgs e) {
            if (this.ActionsList.SelectedIndices.Count == 1 && this.ActionsList.SelectedIndices[0] > 0) {
                int NewIndex = this.ActionsList.SelectedIndices[0] - 1;

                ListViewItem CurrentItm = this.ActionsList.SelectedItems[0];
                ListViewItem PreviousItm = this.ActionsList.Items[NewIndex];
                this.ActionsList.Items.Remove(CurrentItm);
                this.ActionsList.Items.Remove(PreviousItm);
                this.ActionsList.Items.Insert(NewIndex, CurrentItm);
                this.ActionsList.Items.Insert(NewIndex + 1, PreviousItm);
            }
        }

        private void Down(object sender, EventArgs e) {
            if (this.ActionsList.SelectedIndices.Count == 1 && this.ActionsList.SelectedIndices[0] < this.ActionsList.Items.Count - 1) {
                int NewIndex = this.ActionsList.SelectedIndices[0] + 1;

                ListViewItem CurrentItm = this.ActionsList.SelectedItems[0];
                ListViewItem NextItm = this.ActionsList.Items[NewIndex];

                this.ActionsList.Items.Remove(CurrentItm);
                this.ActionsList.Items.Remove(NextItm);
                this.ActionsList.Items.Insert(NewIndex - 1, NextItm);
                this.ActionsList.Items.Insert(NewIndex, CurrentItm);
            }
        }

        private void ChooseMouseCoords(object sender, EventArgs e) {
            HookManager.MouseMove += this.GlobalMouseMove;
            HookManager.MouseUp += this.GlobalMouseUp;
        }

        private void StartOrStopBot(object sender, EventArgs e) {
            if (!this.Running) {
                StartButton.Enabled = false;
                StartBot();
                StartButton.Enabled = true;
                StartButton.Focus();
            } else {
                StartButton.Enabled = false;
                StopBot();
                StartButton.Enabled = true;
                StartButton.Focus();
            }
        }

        private void AddKeyType(object sender, EventArgs e) {
            if (this.KeyChosenBox.Text.Length > 0) {
                this.ActionsList.Add(new Action(Action.ActionType.KeyPress, this.CurrentChosenKey));
                this.KeyChosenBox.Text = "";
            }
        }

        private void AddKeyUp(object sender, EventArgs e) {
            if (this.KeyChosenBox.Text.Length > 0) {
                this.ActionsList.Add(new Action(Action.ActionType.KeyUp, this.CurrentChosenKey));
                this.KeyChosenBox.Text = "";
            }
        }

        private void AddKeyDown(object sender, EventArgs e) {
            if (this.KeyChosenBox.Text.Length > 0) {
                this.ActionsList.Add(new Action(Action.ActionType.KeyDown, this.CurrentChosenKey));
                this.KeyChosenBox.Text = "";
            }
        }

        private void AddMousePress(object sender, EventArgs e) {
            this.ActionsList.Add(new Action(this.MouseKeyButton.Toggled ? Action.ActionType.RightClick : Action.ActionType.LeftClick,
                new Point(Decimal.ToInt32(this.MouseXSpinner.Value), Decimal.ToInt32(this.MouseYSpinner.Value)), this.ChangePositionTick.Checked));
        }

        private void AddMouseUp(object sender, EventArgs e) {
            this.ActionsList.Add(new Action(this.MouseKeyButton.Toggled ? Action.ActionType.MouseUpRight : Action.ActionType.MouseUpLeft,
                new Point(Decimal.ToInt32(this.MouseXSpinner.Value), Decimal.ToInt32(this.MouseYSpinner.Value)), this.ChangePositionTick.Checked));
        }

        private void AddMouseDown(object sender, EventArgs e) {
            this.ActionsList.Add(new Action(this.MouseKeyButton.Toggled ? Action.ActionType.MouseDownRight : Action.ActionType.MouseDownLeft,
                new Point(Decimal.ToInt32(this.MouseXSpinner.Value), Decimal.ToInt32(this.MouseYSpinner.Value)), this.ChangePositionTick.Checked));
        }
    }
}