﻿/*
Technitium Bit Chat
Copyright (C) 2015  Shreyas Zare (shreyas@technitium.com)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BitChatApp.UserControls
{
    public partial class ChatListItem : CustomListViewItem
    {
        #region variables

        int _newMessageCount;

        #endregion

        #region constructor

        public ChatListItem(string title)
        {
            InitializeComponent();

            labTitle.Text = title;
            labIcon.Text = title.Substring(0, 1).ToUpper();

            ResetNewMessages();
        }

        #endregion

        #region private

        protected override void OnSelected()
        {
            this.SuspendLayout();

            if (Selected)
            {
                this.BackColor = Color.FromArgb(61, 78, 93);
                labIcon.BackColor = Color.FromArgb(255, 213, 89);

                ResetNewMessages();
            }
            else
            {
                this.BackColor = Color.FromArgb(51, 65, 78);
                labIcon.BackColor = Color.White;
            }

            this.ResumeLayout();
        }

        protected override void OnMouseOver(bool hovering)
        {
            if (!Selected)
            {
                if (hovering)
                    this.BackColor = Color.FromArgb(61, 78, 93);
                else
                    this.BackColor = Color.FromArgb(51, 65, 78);
            }
        }

        #endregion

        #region public

        public void SetNewMessage(string message)
        {
            labLastMessage.Text = message;

            if (_newMessageCount < 999)
                _newMessageCount++;

            if (!labNewMessageCount.Visible)
            {
                labNewMessageCount.Visible = true;
                labTitle.Width -= labNewMessageCount.Width;
            }

            labNewMessageCount.Text = _newMessageCount.ToString();
        }

        public void ResetNewMessages()
        {
            labLastMessage.Text = "";
            _newMessageCount = 0;
            labNewMessageCount.Visible = false;
            labTitle.Width += labNewMessageCount.Width;
        }

        public override string ToString()
        {
            return labTitle.Text;
        }

        #endregion

        #region properties

        public string Title
        { get { return labTitle.Text; } }

        public string LastMessage
        { get { return labLastMessage.Text; } }

        public int NewMessageCount
        { get { return _newMessageCount; } }

        #endregion
    }
}
