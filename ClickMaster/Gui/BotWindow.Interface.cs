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

using ClickMaster.Gui.Components;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ClickMaster.Gui {
    partial class BotWindow {

        #region Variable declaration

        public NumericUpDown DelaySpinner { get; private set; }
        public NumericUpDown IterationsSpinner { get; private set; }
        public ActionList ActionsList { get; private set; }
        private IContainer components = null;
        private Button ClearButton;
        private Button RemoveButton;
        private Button UpButton;
        private Button DownButton;
        private Button MouseAddDownButton;
        private Button MouseAddUpButton;
        private Button MouseAddClickButton;
        private Button MouseChoosePointButton;
        private Button KeyAddDownButton;
        private Button KeyAddUpButton;
        private Button KeyAddTypeButton;
        private Button KeySelectButton;
        private Button StartKeyButton;
        private Button StartButton;
        private ToggleButton MouseKeyButton;
        private GroupBox MouseGroup;
        private GroupBox KeyGroup;
        private NumericUpDown MouseYSpinner;
        private NumericUpDown MouseXSpinner;
        private TextBox KeyChosenBox;
        private ToolTip ComponentToolTip;
        private Panel Seperator;
        private Label MouseYLabel;
        private Label MouseXLabel;
        private Label DelayLabel;
        private Label IterationsLabel;

        #endregion

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Window initialization

        private void InitializeComponent() {
            this.components = new Container();
            this.ClearButton = new Button();
            this.RemoveButton = new Button();
            this.UpButton = new Button();
            this.DownButton = new Button();
            this.MouseAddClickButton = new Button();
            this.MouseAddUpButton = new Button();
            this.MouseAddDownButton = new Button();
            this.MouseChoosePointButton = new Button();
            this.KeyAddTypeButton = new Button();
            this.KeyAddUpButton = new Button();
            this.KeyAddDownButton = new Button();
            this.KeySelectButton = new Button();
            this.StartKeyButton = new Button();
            this.StartButton = new Button();
            this.MouseKeyButton = new ToggleButton();

            this.MouseXSpinner = new NumericUpDown();
            this.MouseYSpinner = new NumericUpDown();
            this.DelaySpinner = new NumericUpDown();
            this.IterationsSpinner = new NumericUpDown();

            this.KeyChosenBox = new TextBox();

            this.ActionsList = new ActionList();

            this.MouseGroup = new GroupBox();
            this.KeyGroup = new GroupBox();
            this.MouseYLabel = new Label();
            this.MouseXLabel = new Label();
            this.DelayLabel = new Label();
            this.IterationsLabel = new Label();
            this.Seperator = new Panel();
            this.ComponentToolTip = new ToolTip(this.components);

            this.MouseGroup.SuspendLayout();
            this.KeyGroup.SuspendLayout();
            this.SuspendLayout();

            this.MouseXSpinner.BeginInit();
            this.MouseYSpinner.BeginInit();
            this.DelaySpinner.BeginInit();
            this.IterationsSpinner.BeginInit();
            
            this.ActionsList.Alignment = ListViewAlignment.Default;
            this.ActionsList.View = View.List;
            this.ActionsList.MultiSelect = false;
            this.ActionsList.Size = new Size(208, 592);
            this.ActionsList.Location = new Point(12, 12);
            this.ActionsList.TabStop = true;
            this.ActionsList.TabIndex = 0;

            this.ClearButton.Text = "Clear list";
            this.ClearButton.Location = new Point(226, 12);
            this.ClearButton.Size = new Size(218, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Click += this.ClearList;

            this.RemoveButton.Text = "Remove from list";
            this.RemoveButton.Location = new Point(226, 41);
            this.RemoveButton.Size = new Size(218, 32);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Click += this.RemoveFromList;

            this.UpButton.Text = "Up!";
            this.UpButton.Location = new Point(226, 97);
            this.UpButton.Size = new Size(101, 35);
            this.UpButton.TabIndex = 5;
            this.UpButton.Click += this.Up;

            this.DownButton.Text = "Down!";
            this.DownButton.Location = new Point(341, 97);
            this.DownButton.Size = new Size(103, 35);
            this.DownButton.TabIndex = 6;
            this.DownButton.Click += this.Down;

            this.MouseAddClickButton.Text = "Add mouse click";
            this.MouseAddClickButton.Location = new Point(17, 148);
            this.MouseAddClickButton.Size = new Size(179, 23);
            this.MouseAddClickButton.TabIndex = 4;
            this.MouseAddClickButton.Click += this.AddMousePress;

            this.MouseAddUpButton.Text = "Add mouse up";
            this.MouseAddUpButton.Location = new Point(17, 174);
            this.MouseAddUpButton.Size = new Size(179, 23);
            this.MouseAddUpButton.TabIndex = 5;
            this.MouseAddUpButton.Click += this.AddMouseUp;

            this.MouseAddDownButton.Text = "Add mouse down";
            this.MouseAddDownButton.Location = new Point(17, 200);
            this.MouseAddDownButton.Size = new Size(179, 23);
            this.MouseAddDownButton.TabIndex = 6;
            this.MouseAddDownButton.Click += this.AddMouseDown;

            this.MouseChoosePointButton.Text = "Choose Point";
            this.MouseChoosePointButton.Location = new Point(17, 230);
            this.MouseChoosePointButton.Size = new Size(179, 23);
            this.MouseChoosePointButton.TabIndex = 96;
            this.MouseChoosePointButton.Click += this.ChooseMouseCoords;

            this.KeyAddTypeButton.Text = "Add key type";
            this.KeyAddTypeButton.Location = new Point(17, 95);
            this.KeyAddTypeButton.Size = new Size(179, 23);
            this.KeyAddTypeButton.TabIndex = 2;
            this.KeyAddTypeButton.Click += this.AddKeyType;

            this.KeyAddUpButton.Text = "Add key up";
            this.KeyAddUpButton.Location = new Point(17, 124);
            this.KeyAddUpButton.Size = new Size(179, 23);
            this.KeyAddUpButton.TabIndex = 3;
            this.KeyAddUpButton.Click += this.AddKeyUp;

            this.KeyAddDownButton.Text = "Add key down";
            this.KeyAddDownButton.Location = new Point(17, 153);
            this.KeyAddDownButton.Size = new Size(179, 23);
            this.KeyAddDownButton.TabIndex = 4;
            this.KeyAddDownButton.Click += this.AddKeyDown;
            
            this.KeySelectButton.Text = "Select key";
            this.KeySelectButton.Location = new Point(17, 66);
            this.KeySelectButton.Size = new Size(179, 23);
            this.KeySelectButton.TabIndex = 1;
            this.KeySelectButton.Click += this.SelectKey;
            this.KeySelectButton.KeyUp += this.ReceiveKey;

            this.StartKeyButton.Text = "Key: " + this.StartKey;
            this.StartKeyButton.Location = new Point(12, 670);
            this.StartKeyButton.Size = new Size(135, 23);
            this.StartKeyButton.TabIndex = 16;
            this.StartKeyButton.Click += this.SelectStartKey;
            this.StartKeyButton.KeyUp += this.ReceiveKey;
            
            this.StartButton.Text = "Start bot";
            this.StartButton.Location = new Point(153, 670);
            this.StartButton.Size = new Size(297, 24);
            this.StartButton.TabIndex = 17;
            this.StartButton.Click += this.StartOrStopBot;

            this.MouseKeyButton.ActiveText = "Right click";
            this.MouseKeyButton.InactiveText = "Left click";
            this.MouseKeyButton.Size = new Size(179, 23);
            this.MouseKeyButton.Location = new Point(17, 120);
            this.MouseKeyButton.TabIndex = 18;

            this.MouseXSpinner.Location = new Point(17, 46);
            this.MouseXSpinner.Size = new Size(179, 20);
            this.MouseXSpinner.TabIndex = 1;
            this.MouseXSpinner.Minimum = 0;
            this.MouseXSpinner.Maximum = Screen.FromControl(this).Bounds.Width;

            this.MouseYSpinner.Location = new Point(17, 95);
            this.MouseYSpinner.Size = new Size(179, 20);
            this.MouseYSpinner.TabIndex = 3;
            this.MouseYSpinner.Minimum = 0;
            this.MouseYSpinner.Maximum = Screen.FromControl(this).Bounds.Height;

            this.KeyChosenBox.Location = new Point(17, 29);
            this.KeyChosenBox.Size = new Size(179, 20);
            this.KeyChosenBox.Enabled = false;
            this.KeyChosenBox.ReadOnly = true;

            this.DelaySpinner.Location = new Point(12, 640);
            this.DelaySpinner.Size = new Size(200, 20);
            this.DelaySpinner.TabIndex = 12;
            this.DelaySpinner.Maximum = Int32.MaxValue;

            this.IterationsSpinner.Location = new Point(229, 640);
            this.IterationsSpinner.Size = new Size(215, 20);
            this.IterationsSpinner.Minimum = -1;
            this.IterationsSpinner.TabIndex = 15;
            this.IterationsSpinner.Maximum = Int32.MaxValue;

            this.MouseGroup.Text = "Mouse events";
            this.MouseGroup.Size = new Size(218, 267);
            this.MouseGroup.Location = new Point(226, 142);
            this.MouseGroup.TabStop = false;
            this.MouseGroup.Controls.Add(this.MouseAddDownButton);
            this.MouseGroup.Controls.Add(this.MouseAddUpButton);
            this.MouseGroup.Controls.Add(this.MouseAddClickButton);
            this.MouseGroup.Controls.Add(this.MouseChoosePointButton);
            this.MouseGroup.Controls.Add(this.MouseYSpinner);
            this.MouseGroup.Controls.Add(this.MouseYLabel);
            this.MouseGroup.Controls.Add(this.MouseXSpinner);
            this.MouseGroup.Controls.Add(this.MouseXLabel);
            this.MouseGroup.Controls.Add(this.MouseKeyButton);

            this.KeyGroup.Text = "Keyboard events";
            this.KeyGroup.Size = new Size(215, 192);
            this.KeyGroup.Location = new Point(229, 412);
            this.KeyGroup.TabStop = false;
            this.KeyGroup.Controls.Add(this.KeyAddDownButton);
            this.KeyGroup.Controls.Add(this.KeyAddUpButton);
            this.KeyGroup.Controls.Add(this.KeyAddTypeButton);
            this.KeyGroup.Controls.Add(this.KeySelectButton);
            this.KeyGroup.Controls.Add(this.KeyChosenBox);

            this.MouseXLabel.Text = "Mouse x location";
            this.MouseXLabel.AutoSize = true;
            this.MouseXLabel.Location = new Point(14, 30);
            this.MouseXLabel.Size = new Size(87, 13);
            this.MouseYLabel.Text = "Mouse y location";
            this.MouseYLabel.AutoSize = true;
            this.MouseYLabel.Location = new Point(14, 79);
            this.MouseYLabel.Size = new Size(87, 13);
            this.DelayLabel.Text = "Type delay";
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.Location = new Point(9, 624);
            this.DelayLabel.Size = new Size(59, 13);
            this.IterationsLabel.Text = "Amount of iterations";
            this.IterationsLabel.AutoSize = true;
            this.IterationsLabel.Location = new Point(226, 624);
            this.IterationsLabel.Size = new Size(100, 13);

            this.Seperator.BackColor = Color.LightGray;
            this.Seperator.Location = new Point(6, 610);
            this.Seperator.Size = new Size(444, 1);

            string tooltip = "Sets the delay in which the bot will perform the actions (in milliseconds, 0 means no delay)";
            this.ComponentToolTip.SetToolTip(this.DelayLabel, tooltip);
            this.ComponentToolTip.SetToolTip(this.DelaySpinner, tooltip);

            tooltip = "Sets the amount how often the bot will perform the given actions (-1 means infinite)";
            this.ComponentToolTip.SetToolTip(this.IterationsLabel, tooltip);
            this.ComponentToolTip.SetToolTip(this.IterationsSpinner, tooltip);

            this.Text = "ClickMaster Sharp v1.0";
            this.ClientSize = new Size(456, 706);
            this.MaximumSize = new Size(472, 745);
            this.MinimumSize = new Size(472, 745);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Icon = Properties.Resources.ClickMaster_Icon;
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StartKeyButton);
            this.Controls.Add(this.IterationsSpinner);
            this.Controls.Add(this.IterationsLabel);
            this.Controls.Add(this.DelayLabel);
            this.Controls.Add(this.DelaySpinner);
            this.Controls.Add(this.KeyGroup);
            this.Controls.Add(this.MouseGroup);
            this.Controls.Add(this.ActionsList);
            this.Controls.Add(this.Seperator);

            this.MouseGroup.ResumeLayout(false);
            this.MouseGroup.PerformLayout();
            this.KeyGroup.ResumeLayout(false);
            this.KeyGroup.PerformLayout();

            this.MouseYSpinner.EndInit();
            this.MouseXSpinner.EndInit();
            this.DelaySpinner.EndInit();
            this.IterationsSpinner.EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

