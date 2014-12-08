#region License

// Author: Moreno Sint Hill alias Mirabis
// Created on: 01/12/2014                
// Last Edited on: 01/12/2014
// Project: PushHub
// File: Chrome_Theme.cs
// Copyright:  2014, Moreno Sint Hill - All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer. 
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
// The views and conclusions contained in the software and documentation are those
// of the authors and should not be interpreted as representing official policies, 
// either expressed or implied, of the FreeBSD Project.

#endregion

namespace PushHub
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    // Google Chrome Theme - Ported to C# by Ecco
    // Original Theme http://www.hackforums.net/showthread.php?tid=2926688
    // Credit to Mavamaarten~ for Google Chrome Theme & Aeonhack for Themebase
    // ReSharper Disable All 
    internal class ChromeForm : ThemeContainer154
    {
        /// <summary>
        ///     The _title color
        /// </summary>
        private Color _titleColor;

        /// <summary>
        ///     The _x
        /// </summary>
        private int _x;

        /// <summary>
        ///     The _xcolor
        /// </summary>
        private Color _xcolor;

        /// <summary>
        ///     The _xellipse
        /// </summary>
        private Color _xellipse;

        /// <summary>
        ///     The _y
        /// </summary>
        private int _y;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeForm" /> class.
        /// </summary>
        public ChromeForm()
        {
            this.TransparencyKey = Color.Fuchsia;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9);
            this.SetColor("Title color", Color.Black);
            this.SetColor("X-color", 90, 90, 90);
            this.SetColor("X-ellipse", 114, 114, 114);
        }

        /// <summary>
        ///     Gets or sets the color of the back.
        /// </summary>
        /// <value>
        ///     The color of the back.
        /// </value>
        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        ///     Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            this._titleColor = this.GetColor("Title color");
            this._xcolor = this.GetColor("X-color");
            this._xellipse = this.GetColor("X-ellipse");
        }

        /// <summary>
        ///     Raises the <see cref="E:MouseMove" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this._x = e.Location.X;
            this._y = e.Location.Y;
            base.OnMouseMove(e);
            this.Invalidate();
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseClick" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnClick(e);
        }

        /// <summary>
        ///     Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            this.G.Clear(this.BackColor);
            this.DrawCorners(Color.Fuchsia);
            this.DrawCorners(Color.Fuchsia, 1, 0, this.Width - 2, this.Height);
            this.DrawCorners(Color.Fuchsia, 0, 1, this.Width, this.Height - 2);
            this.DrawCorners(Color.Fuchsia, 2, 0, this.Width - 4, this.Height);
            this.DrawCorners(Color.Fuchsia, 0, 2, this.Width, this.Height - 4);

            this.G.SmoothingMode = SmoothingMode.HighQuality;

            this.DrawText(new SolidBrush(this._titleColor), new Point(8, 7));
        }
    }

    /// <summary>
    /// </summary>
    internal class ChromeButton : ThemeControl154
    {
        /// <summary>
        ///     The _bo
        /// </summary>
        private Color _bo;

        /// <summary>
        ///     The _GBD
        /// </summary>
        private Color _gbd;

        /// <summary>
        ///     The _GBN
        /// </summary>
        private Color _gbn;

        /// <summary>
        ///     The _gbo
        /// </summary>
        private Color _gbo;

        /// <summary>
        ///     The _GTD
        /// </summary>
        private Color _gtd;

        /// <summary>
        ///     The _GTN
        /// </summary>
        private Color _gtn;

        /// <summary>
        ///     The _gto
        /// </summary>
        private Color _gto;

        /// <summary>
        ///     The _TD
        /// </summary>
        private Color _td;

        /// <summary>
        ///     The _tdo
        /// </summary>
        private Color _tdo;

        /// <summary>
        ///     The _TN
        /// </summary>
        private Color _tn;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeButton" /> class.
        /// </summary>
        public ChromeButton()
        {
            this.Font = new Font("Segoe UI", 9);
            this.SetColor("Gradient top normal", 237, 237, 237);
            this.SetColor("Gradient top over", 242, 242, 242);
            this.SetColor("Gradient top down", 235, 235, 235);
            this.SetColor("Gradient bottom normal", 230, 230, 230);
            this.SetColor("Gradient bottom over", 235, 235, 235);
            this.SetColor("Gradient bottom down", 223, 223, 223);
            this.SetColor("Border", 167, 167, 167);
            this.SetColor("Text normal", 60, 60, 60);
            this.SetColor("Text down/over", 20, 20, 20);
            this.SetColor("Text disabled", Color.Gray);
        }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        /// <value>
        ///     The font.
        /// </value>
        public override sealed Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        ///     Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            this._gtn = this.GetColor("Gradient top normal");
            this._gto = this.GetColor("Gradient top over");
            this._gtd = this.GetColor("Gradient top down");
            this._gbn = this.GetColor("Gradient bottom normal");
            this._gbo = this.GetColor("Gradient bottom over");
            this._gbd = this.GetColor("Gradient bottom down");
            this._bo = this.GetColor("Border");
            this._tn = this.GetColor("Text normal");
            this._tdo = this.GetColor("Text down/over");
            this._td = this.GetColor("Text disabled");
        }

        /// <summary>
        ///     Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            this.G.Clear(this.BackColor);
            LinearGradientBrush lgb;
            this.G.SmoothingMode = SmoothingMode.HighQuality;

            switch (this.State)
            {
                case MouseStateControl.None:
                    lgb = new LinearGradientBrush(new Rectangle(0, 0, this.Width - 1, this.Height - 1), this._gtn, this._gbn, 90f);
                    break;
                case MouseStateControl.Over:
                    lgb = new LinearGradientBrush(new Rectangle(0, 0, this.Width - 1, this.Height - 1), this._gto, this._gbo, 90f);
                    break;
                default:
                    lgb = new LinearGradientBrush(new Rectangle(0, 0, this.Width - 1, this.Height - 1), this._gtd, this._gbd, 90f);
                    break;
            }

            if (!this.Enabled) lgb = new LinearGradientBrush(new Rectangle(0, 0, this.Width - 1, this.Height - 1), this._gtn, this._gbn, 90f);

            var buttonpath = this.CreateRound(Rectangle.Round(lgb.Rectangle), 3);
            this.G.FillPath(lgb, this.CreateRound(Rectangle.Round(lgb.Rectangle), 3));
            if (!this.Enabled) this.G.FillPath(new SolidBrush(Color.FromArgb(50, Color.White)), this.CreateRound(Rectangle.Round(lgb.Rectangle), 3));
            this.G.SetClip(buttonpath);
            lgb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height / 6), Color.FromArgb(80, Color.White), Color.Transparent, 90f);
            this.G.FillRectangle(lgb, Rectangle.Round(lgb.Rectangle));

            this.G.ResetClip();
            this.G.DrawPath(new Pen(this._bo), buttonpath);

            if (this.Enabled)
            {
                switch (this.State)
                {
                    case MouseStateControl.None:
                        this.DrawText(new SolidBrush(this._tn), HorizontalAlignment.Center, 1, 0);
                        break;
                    default:
                        this.DrawText(new SolidBrush(this._tdo), HorizontalAlignment.Center, 1, 0);
                        break;
                }
            }
            else this.DrawText(new SolidBrush(this._td), HorizontalAlignment.Center, 1, 0);
        }
    }

    /// <summary>
    ///     Class ChromeNumericUpDown, instant update when typing
    /// </summary>
    internal class ChromeNumericUpDown : NumericUpDown
    {
        public ChromeNumericUpDown() { this.TextChanged += this.OnTextChanged; }

        /// <summary>
        ///     Handles the <see cref="E:TextChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnTextChanged(object sender, EventArgs eventArgs)
        {
            this.OnValueChanged(eventArgs);
        }
    }

    /// <summary>
    /// </summary>
    [DefaultEvent("CheckedChanged")]
    internal class ChromeCheckbox : ThemeControl154
    {
        #region Delegates

        /// <summary>
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion

        /// <summary>
        ///     The _
        /// </summary>
        private Color _;

        /// <summary>
        ///     The _bo
        /// </summary>
        private Color _bo;

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ChromeCheckbox" /> is checked.
        /// </summary>
        /// <value>
        ///     <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        private bool _checked;

        /// <summary>
        ///     The _GBD
        /// </summary>
        private Color _gbd;

        /// <summary>
        ///     The _GBN
        /// </summary>
        private Color _gbn;

        /// <summary>
        ///     The _gbo
        /// </summary>
        private Color _gbo;

        /// <summary>
        ///     The _GTD
        /// </summary>
        private Color _gtd;

        /// <summary>
        ///     The _GTN
        /// </summary>
        private Color _gtn;

        /// <summary>
        ///     The _gto
        /// </summary>
        private Color _gto;

        /// <summary>
        ///     The _x
        /// </summary>
        private int _x;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeCheckbox" /> class.
        /// </summary>
        public ChromeCheckbox()
        {
            this.LockHeight = 17;
            this.Font = new Font("Segoe UI", 9);
            this.SetColor("Gradient top normal", 237, 237, 237);
            this.SetColor("Gradient top over", 242, 242, 242);
            this.SetColor("Gradient top down", 235, 235, 235);
            this.SetColor("Gradient bottom normal", 230, 230, 230);
            this.SetColor("Gradient bottom over", 235, 235, 235);
            this.SetColor("Gradient bottom down", 223, 223, 223);
            this.SetColor("Border", 167, 167, 167);
            this.SetColor("Text", 60, 60, 60);
            this.Width = 160;
        }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        /// <value>
        ///     The font.
        /// </value>
        public override sealed Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ChromeCheckbox" /> is checked.
        /// </summary>
        /// <value>
        ///     <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        internal bool Checked
        {
            get { return this._checked; }
            set
            {
                this._checked = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            this._gtn = this.GetColor("Gradient top normal");
            this._gto = this.GetColor("Gradient top over");
            this._gtd = this.GetColor("Gradient top down");
            this._gbn = this.GetColor("Gradient bottom normal");
            this._gbo = this.GetColor("Gradient bottom over");
            this._gbd = this.GetColor("Gradient bottom down");
            this._bo = this.GetColor("Border");
            this._ = this.GetColor("Text");
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseMove" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this._x = e.Location.X;
            this.Invalidate();
        }

        /// <summary>
        ///     Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            this.G.Clear(this.BackColor);
            LinearGradientBrush lgb;
            this.G.SmoothingMode = SmoothingMode.HighQuality;
            switch (this.State)
            {
                case MouseStateControl.None:
                    lgb = new LinearGradientBrush(new Rectangle(0, 0, 14, 14), this._gtn, this._gbn, 90f);
                    break;
                case MouseStateControl.Over:
                    lgb = new LinearGradientBrush(new Rectangle(0, 0, 14, 14), this._gto, this._gbo, 90f);
                    break;
                default:
                    lgb = new LinearGradientBrush(new Rectangle(0, 0, 14, 14), this._gtd, this._gbd, 90f);
                    break;
            }
            var buttonpath = this.CreateRound(Rectangle.Round(lgb.Rectangle), 5);
            this.G.FillPath(lgb, this.CreateRound(Rectangle.Round(lgb.Rectangle), 3));
            this.G.SetClip(buttonpath);
            lgb = new LinearGradientBrush(new Rectangle(0, 0, 14, 5), Color.FromArgb(150, Color.White), Color.Transparent, 90f);
            this.G.FillRectangle(lgb, Rectangle.Round(lgb.Rectangle));
            this.G.ResetClip();
            this.G.DrawPath(new Pen(this._bo), buttonpath);

            this.DrawText(new SolidBrush(this._), 17, -2);

            if (!this.Checked) return;
            var check =
                Image.FromStream(
                    new MemoryStream(
                        Convert.FromBase64String(
                            "iVBORw0KGgoAAAANSUhEUgAAAAsAAAAJCAYAAADkZNYtAAAABGdBTUEAALGOfPtRkwAAACBjSFJNAACHDwAAjA8AAP1SAACBQAAAfXkAAOmLAAA85QAAGcxzPIV3AAAKOWlDQ1BQaG90b3Nob3AgSUNDIHByb2ZpbGUAAEjHnZZ3VFTXFofPvXd6oc0wAlKG3rvAANJ7k15FYZgZYCgDDjM0sSGiAhFFRJoiSFDEgNFQJFZEsRAUVLAHJAgoMRhFVCxvRtaLrqy89/Ly++Osb+2z97n77L3PWhcAkqcvl5cGSwGQyhPwgzyc6RGRUXTsAIABHmCAKQBMVka6X7B7CBDJy82FniFyAl8EAfB6WLwCcNPQM4BOB/+fpFnpfIHomAARm7M5GSwRF4g4JUuQLrbPipgalyxmGCVmvihBEcuJOWGRDT77LLKjmNmpPLaIxTmns1PZYu4V8bZMIUfEiK+ICzO5nCwR3xKxRoowlSviN+LYVA4zAwAUSWwXcFiJIjYRMYkfEuQi4uUA4EgJX3HcVyzgZAvEl3JJS8/hcxMSBXQdli7d1NqaQffkZKVwBALDACYrmcln013SUtOZvBwAFu/8WTLi2tJFRbY0tba0NDQzMv2qUP91829K3NtFehn4uWcQrf+L7a/80hoAYMyJarPziy2uCoDOLQDI3fti0zgAgKSobx3Xv7oPTTwviQJBuo2xcVZWlhGXwzISF/QP/U+Hv6GvvmckPu6P8tBdOfFMYYqALq4bKy0lTcinZ6QzWRy64Z+H+B8H/nUeBkGceA6fwxNFhImmjMtLELWbx+YKuGk8Opf3n5r4D8P+pMW5FonS+BFQY4yA1HUqQH7tBygKESDR+8Vd/6NvvvgwIH554SqTi3P/7zf9Z8Gl4iWDm/A5ziUohM4S8jMX98TPEqABAUgCKpAHykAd6ABDYAasgC1wBG7AG/iDEBAJVgMWSASpgA+yQB7YBApBMdgJ9oBqUAcaQTNoBcdBJzgFzoNL4Bq4AW6D+2AUTIBnYBa8BgsQBGEhMkSB5CEVSBPSh8wgBmQPuUG+UBAUCcVCCRAPEkJ50GaoGCqDqqF6qBn6HjoJnYeuQIPQXWgMmoZ+h97BCEyCqbASrAUbwwzYCfaBQ+BVcAK8Bs6FC+AdcCXcAB+FO+Dz8DX4NjwKP4PnEIAQERqiihgiDMQF8UeikHiEj6xHipAKpAFpRbqRPuQmMorMIG9RGBQFRUcZomxRnqhQFAu1BrUeVYKqRh1GdaB6UTdRY6hZ1Ec0Ga2I1kfboL3QEegEdBa6EF2BbkK3oy+ib6Mn0K8xGAwNo42xwnhiIjFJmLWYEsw+TBvmHGYQM46Zw2Kx8lh9rB3WH8vECrCF2CrsUexZ7BB2AvsGR8Sp4Mxw7rgoHA+Xj6vAHcGdwQ3hJnELeCm8Jt4G749n43PwpfhGfDf+On4Cv0CQJmgT7AghhCTCJkIloZVwkfCA8JJIJKoRrYmBRC5xI7GSeIx4mThGfEuSIemRXEjRJCFpB+kQ6RzpLuklmUzWIjuSo8gC8g5yM/kC+RH5jQRFwkjCS4ItsUGiRqJDYkjiuSReUlPSSXK1ZK5kheQJyeuSM1J4KS0pFymm1HqpGqmTUiNSc9IUaVNpf+lU6RLpI9JXpKdksDJaMm4ybJkCmYMyF2TGKQhFneJCYVE2UxopFykTVAxVm+pFTaIWU7+jDlBnZWVkl8mGyWbL1sielh2lITQtmhcthVZKO04bpr1borTEaQlnyfYlrUuGlszLLZVzlOPIFcm1yd2WeydPl3eTT5bfJd8p/1ABpaCnEKiQpbBf4aLCzFLqUtulrKVFS48vvacIK+opBimuVTyo2K84p6Ss5KGUrlSldEFpRpmm7KicpFyufEZ5WoWiYq/CVSlXOavylC5Ld6Kn0CvpvfRZVUVVT1Whar3qgOqCmrZaqFq+WpvaQ3WCOkM9Xr1cvUd9VkNFw08jT6NF454mXpOhmai5V7NPc15LWytca6tWp9aUtpy2l3audov2Ax2yjoPOGp0GnVu6GF2GbrLuPt0berCehV6iXo3edX1Y31Kfq79Pf9AAbWBtwDNoMBgxJBk6GWYathiOGdGMfI3yjTqNnhtrGEcZ7zLuM/5oYmGSYtJoct9UxtTbNN+02/R3Mz0zllmN2S1zsrm7+QbzLvMXy/SXcZbtX3bHgmLhZ7HVosfig6WVJd+y1XLaSsMq1qrWaoRBZQQwShiXrdHWztYbrE9Zv7WxtBHYHLf5zdbQNtn2iO3Ucu3lnOWNy8ft1OyYdvV2o/Z0+1j7A/ajDqoOTIcGh8eO6o5sxybHSSddpySno07PnU2c+c7tzvMuNi7rXM65Iq4erkWuA24ybqFu1W6P3NXcE9xb3Gc9LDzWepzzRHv6eO7yHPFS8mJ5NXvNelt5r/Pu9SH5BPtU+zz21fPl+3b7wX7efrv9HqzQXMFb0ekP/L38d/s/DNAOWBPwYyAmMCCwJvBJkGlQXlBfMCU4JvhI8OsQ55DSkPuhOqHC0J4wybDosOaw+XDX8LLw0QjjiHUR1yIVIrmRXVHYqLCopqi5lW4r96yciLaILoweXqW9KnvVldUKq1NWn46RjGHGnIhFx4bHHol9z/RnNjDn4rziauNmWS6svaxnbEd2OXuaY8cp40zG28WXxU8l2CXsTphOdEisSJzhunCruS+SPJPqkuaT/ZMPJX9KCU9pS8Wlxqae5Mnwknm9acpp2WmD6frphemja2zW7Fkzy/fhN2VAGasyugRU0c9Uv1BHuEU4lmmfWZP5Jiss60S2dDYvuz9HL2d7zmSue+63a1FrWWt78lTzNuWNrXNaV78eWh+3vmeD+oaCDRMbPTYe3kTYlLzpp3yT/LL8V5vDN3cXKBVsLBjf4rGlpVCikF84stV2a9021DbutoHt5turtn8sYhddLTYprih+X8IqufqN6TeV33zaEb9joNSydP9OzE7ezuFdDrsOl0mX5ZaN7/bb3VFOLy8qf7UnZs+VimUVdXsJe4V7Ryt9K7uqNKp2Vr2vTqy+XeNc01arWLu9dn4fe9/Qfsf9rXVKdcV17w5wD9yp96jvaNBqqDiIOZh58EljWGPft4xvm5sUmoqbPhziHRo9HHS4t9mqufmI4pHSFrhF2DJ9NProje9cv+tqNWytb6O1FR8Dx4THnn4f+/3wcZ/jPScYJ1p/0Pyhtp3SXtQBdeR0zHYmdo52RXYNnvQ+2dNt293+o9GPh06pnqo5LXu69AzhTMGZT2dzz86dSz83cz7h/HhPTM/9CxEXbvUG9g5c9Ll4+ZL7pQt9Tn1nL9tdPnXF5srJq4yrndcsr3X0W/S3/2TxU/uA5UDHdavrXTesb3QPLh88M+QwdP6m681Lt7xuXbu94vbgcOjwnZHokdE77DtTd1PuvriXeW/h/sYH6AdFD6UeVjxSfNTws+7PbaOWo6fHXMf6Hwc/vj/OGn/2S8Yv7ycKnpCfVEyqTDZPmU2dmnafvvF05dOJZ+nPFmYKf5X+tfa5zvMffnP8rX82YnbiBf/Fp99LXsq/PPRq2aueuYC5R69TXy/MF72Rf3P4LeNt37vwd5MLWe+x7ys/6H7o/ujz8cGn1E+f/gUDmPP8usTo0wAAAAlwSFlzAAALEQAACxEBf2RfkQAAAK1JREFUKFN10D0OhSAQBGAOp2D8u4CNHY0kegFPYaSyM+EQFhY2NsTGcJ3xQbEvxlBMQsg3SxYGgMWitUbbtjiO40fAotBaizzPIYQI8YUo7rqO4DAM78nneYYLH2MMOOchdV3DOffH4zgiyzJM04T7vlFVFeF1XWkI27YNaZpSiqKgs1KKIC0opXwVfLksS1zX9cW+Nc9zeDpJkpBlWV7w83X7vqNpGvR9/4EePztSBhXQfRi8AAAAAElFTkSuQmCC")));
            this.G.DrawImage(check, new Rectangle(2, 3, check.Width, check.Height));
        }

        /// <summary>
        ///     Raises the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Checked = !this.Checked;
            if (this.CheckedChanged != null) this.CheckedChanged(this);
            base.OnMouseDown(e);
        }

        /// <summary>
        ///     Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;
    }

    /// <summary>
    /// </summary>
    [DefaultEvent("CheckedChanged")]
    internal class ChromeRadioButton : ThemeControl154
    {
        #region Delegates

        /// <summary>
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion

        /// <summary>
        ///     The _BB
        /// </summary>
        private Color _bb;

        /// <summary>
        ///     The _bo
        /// </summary>
        private Color _bo;

        /// <summary>
        ///     The _checked
        /// </summary>
        private bool _checked;

        /// <summary>
        ///     The _field
        /// </summary>
        private int _field = 16;

        /// <summary>
        ///     The _G1
        /// </summary>
        private Color _g1;

        /// <summary>
        ///     The _G2
        /// </summary>
        private Color _g2;

        /// <summary>
        ///     The _text color
        /// </summary>
        private Color _textColor;

        /// <summary>
        ///     The _x
        /// </summary>
        private int _x;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeRadioButton" /> class.
        /// </summary>
        public ChromeRadioButton()
        {
            this.Font = new Font("Segoe UI", 9);
            this.LockHeight = 17;
            this.SetColor("Text", 60, 60, 60);
            this.SetColor("Gradient top", 237, 237, 237);
            this.SetColor("Gradient bottom", 230, 230, 230);
            this.SetColor("Borders", 167, 167, 167);
            this.SetColor("Bullet", 100, 100, 100);
            this.Width = 180;
        }

        /// <summary>
        ///     Gets or sets the font.
        /// </summary>
        /// <value>
        ///     The font.
        /// </value>
        public override sealed Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        ///     Gets or sets the field.
        /// </summary>
        /// <value>
        ///     The field.
        /// </value>
        public int Field
        {
            get { return this._field; }
            set
            {
                if (value < 4) return;
                this._field = value;
                this.LockHeight = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ChromeRadioButton" /> is checked.
        /// </summary>
        /// <value>
        ///     <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        private bool Checked
        {
            get { return this._checked; }
            set
            {
                this._checked = value;
                this.InvalidateControls();
                if (this.CheckedChanged != null) this.CheckedChanged(this);
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            this._textColor = this.GetColor("Text");
            this._g1 = this.GetColor("Gradient top");
            this._g2 = this.GetColor("Gradient bottom");
            this._bb = this.GetColor("Bullet");
            this._bo = this.GetColor("Borders");
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseMove" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            this._x = e.Location.X;
            this.Invalidate();
        }

        /// <summary>
        ///     Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            this.G.Clear(this.BackColor);
            this.G.SmoothingMode = SmoothingMode.HighQuality;
            if (this._checked)
            {
                var lgb = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 14)), this._g1, this._g2, 90f);
                this.G.FillEllipse(lgb, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }
            else
            {
                var lgb = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(14, 16)), this._g1, this._g2, 90f);
                this.G.FillEllipse(lgb, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }

            if (this.State == MouseStateControl.Over & this._x < 15)
            {
                var sb = new SolidBrush(Color.FromArgb(10, Color.Black));
                this.G.FillEllipse(sb, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }
            else if (this.State == MouseStateControl.Down & this._x < 15)
            {
                var sb = new SolidBrush(Color.FromArgb(20, Color.Black));
                this.G.FillEllipse(sb, new Rectangle(new Point(0, 0), new Size(14, 14)));
            }

            var p = new GraphicsPath();
            p.AddEllipse(new Rectangle(0, 0, 14, 14));
            this.G.SetClip(p);

            var llggbb = new LinearGradientBrush(new Rectangle(0, 0, 14, 5), Color.FromArgb(150, Color.White), Color.Transparent, 90f);
            this.G.FillRectangle(llggbb, llggbb.Rectangle);

            this.G.ResetClip();

            this.G.DrawEllipse(new Pen(this._bo), new Rectangle(new Point(0, 0), new Size(14, 14)));

            if (this._checked)
            {
                var lgb = new SolidBrush(this._bb);
                this.G.FillEllipse(lgb, new Rectangle(new Point(4, 4), new Size(6, 6)));
            }

            this.DrawText(new SolidBrush(this._textColor), HorizontalAlignment.Left, 17, -2);
        }

        /// <summary>
        ///     Raises the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!this._checked) this.Checked = true;
            base.OnMouseDown(e);
        }

        /// <summary>
        ///     Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;

        /// <summary>
        ///     Called when [creation].
        /// </summary>
        protected override void OnCreation()
        {
            this.InvalidateControls();
        }

        /// <summary>
        ///     Invalidates the controls.
        /// </summary>
        private void InvalidateControls()
        {
            if (!this.IsHandleCreated || !this._checked) return;

            foreach (var c in from Control c in this.Parent.Controls where !ReferenceEquals(c, this) && c is ChromeRadioButton select c)
            {
                ((ChromeRadioButton)c).Checked = false;
            }
        }
    }

    /// <summary>
    /// </summary>
    internal class ChromeSeparator : ThemeControl154
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeSeparator" /> class.
        /// </summary>
        public ChromeSeparator()
        {
            this.LockHeight = 2;
            this.BackColor = Color.FromArgb(78, 87, 100);
        }

        /// <summary>
        ///     Gets or sets the color of the back.
        /// </summary>
        /// <value>
        ///     The color of the back.
        /// </value>
        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        ///     Colors the hook.
        /// </summary>
        protected override void ColorHook() {}

        /// <summary>
        ///     Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            this.G.Clear(this.BackColor);
        }
    }

    /// <summary>
    /// </summary>
    internal class ChromeTabcontrol : TabControl
    {
        /// <summary>
        ///     The _C1
        /// </summary>
        private Color _c1 = Color.FromArgb(78, 87, 100);

        /// <summary>
        ///     The _ob
        /// </summary>
        private bool _ob = false;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeTabcontrol" /> class.
        /// </summary>
        public ChromeTabcontrol()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(30, 115);
        }

        /// <summary>
        ///     Dieser Member hat für das genannte Steuerelement keine Bedeutung.
        /// </summary>
        protected override sealed bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }

        /// <summary>
        ///     Gets or sets the color of the square.
        /// </summary>
        /// <value>
        ///     The color of the square.
        /// </value>
        public Color SquareColor
        {
            get { return this._c1; }
            set
            {
                this._c1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [show outer borders].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show outer borders]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowOuterBorders
        {
            get { return this._ob; }
            set
            {
                this._ob = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Dieser Member überschreibt <see cref="M:System.Windows.Forms.Control.CreateHandle" />.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            this.Alignment = TabAlignment.Left;
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.Paint" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.PaintEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var B = new Bitmap(this.Width, this.Height);
            var G = Graphics.FromImage(B);
            try
            {
                this.SelectedTab.BackColor = Color.White;
            }
            catch (Exception) {}
            G.Clear(Color.White);
            for (var i = 0; i <= this.TabCount - 1; i++)
            {
                var x2 = new Rectangle(new Point(this.GetTabRect(i).Location.X - 2, this.GetTabRect(i).Location.Y - 2), new Size(this.GetTabRect(i).Width + 3, this.GetTabRect(i).Height - 1));
                var textrectangle = new Rectangle(x2.Location.X + 15, x2.Location.Y, x2.Width - 20, x2.Height);
                if (i == this.SelectedIndex)
                {
                    G.FillRectangle(new SolidBrush(this._c1), new Rectangle(x2.Location, new Size(9, x2.Height)));

                    if (this.ImageList != null)
                    {
                        try
                        {
                            G.DrawImage(this.ImageList.Images[this.TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                            G.DrawString("       " + this.TabPages[i].Text, this.Font, Brushes.Black, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                        catch
                        {
                            G.DrawString(this.TabPages[i].Text, this.Font, Brushes.Black, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                    }
                    else G.DrawString(this.TabPages[i].Text, this.Font, Brushes.Black, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                }
                else
                {
                    if (this.ImageList != null)
                    {
                        try
                        {
                            G.DrawImage(this.ImageList.Images[this.TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                            G.DrawString("       " + this.TabPages[i].Text, this.Font, Brushes.DimGray, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                        catch
                        {
                            G.DrawString(this.TabPages[i].Text, this.Font, Brushes.DimGray, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                    }
                    else G.DrawString(this.TabPages[i].Text, this.Font, Brushes.DimGray, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                }
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    /// <summary>
    /// </summary>
    internal class ChromeTabcontrolNormal : TabControl
    {
        /// <summary>
        ///     The _C1
        /// </summary>
        private Color _c1 = Color.FromArgb(78, 87, 100);

        /// <summary>
        ///     The _ob
        /// </summary>
        private bool _ob = false;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeTabcontrolNormal" /> class.
        /// </summary>
        public ChromeTabcontrolNormal()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(120, 28);
        }

        /// <summary>
        ///     Dieser Member hat für das genannte Steuerelement keine Bedeutung.
        /// </summary>
        protected override sealed bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }

        /// <summary>
        ///     Gets or sets the color of the square.
        /// </summary>
        /// <value>
        ///     The color of the square.
        /// </value>
        public Color SquareColor
        {
            get { return this._c1; }
            set
            {
                this._c1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether [show outer borders].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [show outer borders]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowOuterBorders
        {
            get { return this._ob; }
            set
            {
                this._ob = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Dieser Member überschreibt <see cref="M:System.Windows.Forms.Control.CreateHandle" />.
        /// </summary>
        protected override void CreateHandle()
        {
            base.CreateHandle();
            this.Alignment = TabAlignment.Top;
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.Paint" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.PaintEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var B = new Bitmap(this.Width, this.Height);
            var G = Graphics.FromImage(B);
            try
            {
                if (this.SelectedTab != null) this.SelectedTab.BackColor = Color.White;
            }
            catch (Exception) {}
            G.Clear(Color.White);
            for (var i = 0; i <= this.TabCount - 1; i++)
            {
                var x2 = new Rectangle(new Point(this.GetTabRect(i).Location.X + 2, this.GetTabRect(i).Location.Y + 17), new Size(this.GetTabRect(i).Width - 1, this.GetTabRect(i).Height - 1));
                var textrectangle = new Rectangle(x2.Location.X + 12, x2.Location.Y - 21, x2.Width - 20, x2.Height);
                if (i == this.SelectedIndex)
                {
                    G.FillRectangle(new SolidBrush(this._c1), new Rectangle(x2.Location, new Size(x2.Width, 9)));

                    if (this.ImageList != null)
                    {
                        try
                        {
                            G.DrawImage(this.ImageList.Images[this.TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 6, textrectangle.Location.Y + 3));
                            G.DrawString("       " + this.TabPages[i].Text, this.Font, Brushes.Black, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                        catch
                        {
                            G.DrawString(this.TabPages[i].Text, this.Font, Brushes.Black, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                    }
                    else G.DrawString(this.TabPages[i].Text, this.Font, Brushes.Black, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                }
                else
                {
                    if (this.ImageList != null)
                    {
                        try
                        {
                            G.DrawImage(this.ImageList.Images[this.TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 6, textrectangle.Location.Y + 3));
                            G.DrawString("       " + this.TabPages[i].Text, this.Font, Brushes.DimGray, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                        catch
                        {
                            G.DrawString(this.TabPages[i].Text, this.Font, Brushes.DimGray, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        }
                    }
                    else G.DrawString(this.TabPages[i].Text, this.Font, Brushes.DimGray, textrectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                }
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    /// <summary>
    /// </summary>
    internal class ChromeComboBoxLight : ComboBox
    {
        /// <summary>
        ///     The _x
        /// </summary>
        private int _x;

        /// <summary>
        ///     The _B2
        /// </summary>
        private readonly SolidBrush _b2;

        /// <summary>
        ///     The _B3
        /// </summary>
        private readonly SolidBrush _b3;

        /// <summary>
        ///     The _bottomgradientgrey
        /// </summary>
        private readonly Color _bottomgradientgrey = Color.FromArgb(230, 230, 230);

        /// <summary>
        ///     The _darkgrey
        /// </summary>
        private readonly Color _darkgrey = Color.FromArgb(78, 87, 100);

        /// <summary>
        ///     The _lightgrey
        /// </summary>
        private readonly Color _lightgrey = Color.FromArgb(167, 167, 167);

        /// <summary>
        ///     The _mediumgrey
        /// </summary>
        private readonly Color _mediumgrey = Color.FromArgb(105, 105, 105);

        /// <summary>
        ///     The _textnormal
        /// </summary>
        private readonly Color _textnormal = Color.FromArgb(60, 60, 60);

        /// <summary>
        ///     The _uppergradientgrey
        /// </summary>
        private readonly Color _uppergradientgrey = Color.FromArgb(237, 237, 237);

        /// <summary>
        ///     The _white
        /// </summary>
        private readonly Color _white = Color.FromArgb(255, 255, 255);

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeComboBoxLight" /> class.
        /// </summary>
        public ChromeComboBoxLight()
        {
            this.SetStyle((ControlStyles)139286, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.DrawMode = DrawMode.OwnerDrawFixed;

            /* BackColor - No idea what it does */
            //BackColor = Color.FromArgb(255, 0, 0);
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            /* Segoe UI; 9pt - Font */
            this.Font = new Font("Segoe UI", 9);

            /* B1 - No idea what it does */
            //B1 = new SolidBrush(Color.FromArgb(255, 0, 0));

            /* Dropdown background color */
            this._b2 = new SolidBrush(this._white);

            /* Arrow Color */
            this._b3 = new SolidBrush(this._mediumgrey);
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, Graphics G)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height, G);
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            /* Initial Border around Combobox */
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseMove" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this._x = e.X;
            base.OnMouseMove(e);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseLeave" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Eine <see cref="T:System.EventArgs" />-Klasse, die die Ereignisdaten enthält.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this._x = 0;
            base.OnMouseLeave(e);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseClick" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this._x = 0;
            base.OnMouseClick(e);
        }

        //private readonly SolidBrush _b1;

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.Paint" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.PaintEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            Point[] points = { new Point(this.Width - 15, 9), new Point(this.Width - 6, 9), new Point(this.Width - 11, 14) };
            G.Clear(this.BackColor);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            /* Combobox gradient - Upper and bottom - 2 Colors in this line */
            var lgb1 = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), this._uppergradientgrey, this._bottomgradientgrey, 90F);

            G.FillRectangle(lgb1, new Rectangle(0, 0, this.Width, this.Height));

            /* Horizontal Splitter between text and button */
            //G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(167, 167, 167))), new Point(Width - 21, 1), new Point(Width - 21, Height));

            /* Outer Border */
            this.DrawBorders(new Pen(new SolidBrush(this._lightgrey)), G);

            /* Inner Border */
            //DrawBorders(new Pen(new SolidBrush(Color.FromArgb(255, 0, 0))), 1, G);

            try
            {
                /* Text in combobox - When not dropdowned */
                G.DrawString(this.Items[this.SelectedIndex].ToString(), this.Font, new SolidBrush(this._textnormal), new Point(3, 4));
            }
            catch
            {
                /* Text in combobox - When not dropdowned */
                G.DrawString("Select Default", this.Font, new SolidBrush(this._textnormal), new Point(3, 4));
            }

            if (this._x >= 1)
            {
                /* Arrow mouse-over gradient - 2 Colors in this line */
                var lgb3 = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), this._uppergradientgrey, this._bottomgradientgrey, 90F);
                G.FillRectangle(lgb3, new Rectangle(this.Width - 20, 2, 18, 17));
                G.FillPolygon(this._b3, points);
            }
            else G.FillPolygon(this._b3, points);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.ComboBox.DrawItem" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.DrawItemEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            /* Gradient for actual dropdown - DROPDOWN SELECTION */
            var lgb1 = new LinearGradientBrush(e.Bounds, this._darkgrey, this._darkgrey, 90);

            /* Diagonal brushes to draw diagonal lines in the gradient - DROPDOWN SELECTION */
            var hb1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, this._darkgrey, this._darkgrey);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(lgb1, new Rectangle(1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.FillRectangle(hb1, e.Bounds);
                /* Dropdown text color when hovering through - selected */
                e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), e.Font, new SolidBrush(this._white), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(this._b2, e.Bounds);
                /* Regular dropdown text color */
                try
                {
                    e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), e.Font, new SolidBrush(this._mediumgrey), e.Bounds);
                }
                    // ReSharper disable once EmptyGeneralCatchClause
                catch {}
            }
        }
    }

    /// <summary>
    /// </summary>
    internal class ChromeComboBoxDark : ComboBox
    {
        /// <summary>
        ///     The _start index
        /// </summary>
        private int _startIndex = 0;

        /// <summary>
        ///     The _x
        /// </summary>
        private int _x;

        /// <summary>
        ///     The _B2
        /// </summary>
        private readonly SolidBrush _b2;

        /// <summary>
        ///     The _B3
        /// </summary>
        private readonly SolidBrush _b3;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeComboBoxDark" /> class.
        /// </summary>
        public ChromeComboBoxDark()
        {
            this.SetStyle((ControlStyles)139286, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.DrawMode = DrawMode.OwnerDrawFixed;

            /* BackColor - No idea what it does */
            //BackColor = Color.FromArgb(255, 0, 0);
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            /* Segoe UI; 9pt - Font */
            this.Font = new Font("Segoe UI", 9);

            /* B1 - No idea what it does */
            //B1 = new SolidBrush(Color.FromArgb(255, 0, 0));

            /* Dropdown background color */
            this._b2 = new SolidBrush(Color.FromArgb(255, 255, 255));

            /* Arrow Color */
            this._b3 = new SolidBrush(Color.FromArgb(105, 105, 105));
        }

        /// <summary>
        ///     Gets or sets the start index.
        /// </summary>
        /// <value>
        ///     The start index.
        /// </value>
        public int StartIndex
        {
            get { return this._startIndex; }
            set
            {
                this._startIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                    // ReSharper disable once EmptyGeneralCatchClause
                catch {}

                this.Invalidate();
            }
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, Graphics G)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height, G);
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int offset, Graphics G)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height, offset, G);
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            /* Initial Border around Combobox */
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="G">The g.</param>
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset, Graphics G)
        {
            /* Bordersize of right and down. */
            this.DrawBorders(p1, x + offset, y + offset, width - (offset * 1), height - (offset * 1), G);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseMove" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this._x = e.X;
            base.OnMouseMove(e);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseLeave" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Eine <see cref="T:System.EventArgs" />-Klasse, die die Ereignisdaten enthält.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this._x = 0;
            base.OnMouseLeave(e);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseClick" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this._x = 0;
            base.OnMouseClick(e);
        }

        //private readonly SolidBrush _b1;

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.Paint" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.PaintEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            Point[] points = { new Point(this.Width - 15, 9), new Point(this.Width - 6, 9), new Point(this.Width - 11, 14) };
            G.Clear(this.BackColor);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            /* Combobox gradient - Upper and bottom - 2 Colors in this line */
            var lgb1 = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255), 90F);

            G.FillRectangle(lgb1, new Rectangle(0, 0, this.Width, this.Height));

            /* Horizontal Splitter between text and button */
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(78, 87, 100))), new Point(this.Width - 21, 1), new Point(this.Width - 21, this.Height));

            /* Outer Border */
            this.DrawBorders(new Pen(new SolidBrush(Color.FromArgb(105, 105, 105))), G);

            /* Inner Border */
            //DrawBorders(new Pen(new SolidBrush(Color.FromArgb(255, 0, 0))), 1, G);

            try
            {
                /* Text in combobox - When not dropdowned */
                G.DrawString(this.Items[this.SelectedIndex].ToString(), this.Font, new SolidBrush(Color.FromArgb(78, 87, 100)), new Point(3, 4));
            }
            catch
            {
                /* Text in combobox - When not dropdowned */
                G.DrawString("Select Default", this.Font, new SolidBrush(Color.FromArgb(78, 87, 100)), new Point(3, 4));
            }

            if (this._x >= 1)
            {
                /* Arrow mouse-over gradient - 2 Colors in this line */
                var lgb3 = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255), 90F);
                G.FillRectangle(lgb3, new Rectangle(this.Width - 20, 2, 18, 17));
                G.FillPolygon(this._b3, points);
            }
            else G.FillPolygon(this._b3, points);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.ComboBox.DrawItem" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.DrawItemEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            /* Gradient for actual dropdown - DROPDOWN SELECTION */
            var lgb1 = new LinearGradientBrush(e.Bounds, Color.FromArgb(78, 87, 100), Color.FromArgb(78, 87, 100), 90);

            /* Diagonal brushes to draw diagonal lines in the gradient - DROPDOWN SELECTION */
            var hb1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(78, 87, 100), Color.FromArgb(78, 87, 100));

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(lgb1, new Rectangle(1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.FillRectangle(hb1, e.Bounds);
                /* Dropdown text color when hovering through - selected */
                e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(this._b2, e.Bounds);
                /* Regular dropdown text color */
                try
                {
                    e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(105, 105, 105)), e.Bounds);
                }
                    // ReSharper disable once EmptyGeneralCatchClause
                catch {}
            }
        }
    }

    /// <summary>
    /// </summary>
    internal sealed class ChromeComboBoxNormal : ComboBox
    {
        /// <summary>
        ///     The _ start index
        /// </summary>
        private int _startIndex;

        /// <summary>
        ///     The x
        /// </summary>
        private int X;

        /// <summary>
        ///     The b2
        /// </summary>
        private readonly SolidBrush _b2;

        /// <summary>
        ///     The b3
        /// </summary>
        private readonly SolidBrush _b3;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeComboBoxNormal" /> class.
        /// </summary>
        public ChromeComboBoxNormal()
        {
            this.SetStyle((ControlStyles)139286, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.DrawMode = DrawMode.OwnerDrawFixed;

            this.BackColor = Color.FromArgb(255, 0, 0); // ???
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Font = new Font("Segoe UI", 9); //Segoe UI; 9pt - Font

            new SolidBrush(Color.FromArgb(255, 0, 0)); // ???
            this._b2 = new SolidBrush(Color.FromArgb(255, 255, 255)); // dropdown background color
            this._b3 = new SolidBrush(Color.FromArgb(105, 105, 105)); // Arrow Color
        }

        /// <summary>
        ///     Gets or sets the start index.
        /// </summary>
        /// <value>
        ///     The start index.
        /// </value>
        public int StartIndex
        {
            get { return this._startIndex; }
            set
            {
                this._startIndex = value;
                try
                {
                    if (value != 0) base.SelectedIndex = value;
                }
                catch {}
                this.Invalidate();
            }
        }

        public override sealed Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="G">The g.</param>
        private void DrawBorders(Pen p1, Graphics G)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height, G);
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="G">The g.</param>
        private void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1); // Initial Border around Combobox
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseMove" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.X = e.X;
            base.OnMouseMove(e);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseLeave" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Eine <see cref="T:System.EventArgs" />-Klasse, die die Ereignisdaten enthält.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            this.X = 0;
            base.OnMouseLeave(e);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.MouseClick" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.MouseEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!this.Enabled) return;
            if (e.Button == MouseButtons.Left) this.X = 0;
            base.OnMouseClick(e);
        }

        // Dimgray = 105, 105, 105
        // Dark Color = 78, 87, 100

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.Control.Paint" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.PaintEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            var points = new Point[] { new Point(this.Width - 15, 9), new Point(this.Width - 6, 9), new Point(this.Width - 11, 14) };
            G.Clear(this.BackColor);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var lgb1 = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255), 90F); // Combobox gradient - Upper and bottom.

            G.FillRectangle(lgb1, new Rectangle(0, 0, this.Width, this.Height));

            //G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(78, 87, 100))), new Point(Width - 21, 1), new Point(Width - 21, Height)); // Horizontal Splitter between text and button

            this.DrawBorders(new Pen(new SolidBrush(Color.FromArgb(105, 105, 105))), G); // Outter Border
            //DrawBorders(new Pen(new SolidBrush(Color.FromArgb(255, 0, 0))), 1, G); // Inner Border - Disabled
            if (this.SelectedIndex == -1) G.DrawString(" . . . ", this.Font, new SolidBrush(Color.FromArgb(78, 87, 100)), new Point(3, 4));
            else
            {
                try
                {
                    G.DrawString((string)this.Items[this.SelectedIndex].ToString(), this.Font, new SolidBrush(Color.FromArgb(78, 87, 100)), new Point(3, 4));
                } // Text in combobox - When not dropdowned
                catch
                {
                    G.DrawString(" . . . ", this.Font, new SolidBrush(Color.FromArgb(78, 87, 100)), new Point(3, 4));
                } // Text in combobox - When not dropdowned
            }

            if (this.X >= 1)
            {
                var lgb3 = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255), 90F); // Arrow mouse-over GRADIENT
                G.FillRectangle(lgb3, new Rectangle(this.Width - 20, 2, 18, 17));
                G.FillPolygon(this._b3, points);
            }
            else G.FillPolygon(this._b3, points);
        }

        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Forms.ComboBox.DrawItem" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.Forms.DrawItemEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            var LGB1 = new LinearGradientBrush(e.Bounds, Color.FromArgb(78, 87, 100), Color.FromArgb(78, 87, 100), 90); // Gradient for actual dropdown - DROPDOWN SELECTION
            var HB1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(78, 87, 100), Color.FromArgb(78, 87, 100)); // Diagonal brushes to draw diagonal lines in the gradient - DROPDOWN SELECTION
            if (e.Index == -1) return;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(LGB1, new Rectangle(1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.FillRectangle(HB1, e.Bounds);
                e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds); // Text color when hovering through - selected
            }
            else
            {
                e.Graphics.FillRectangle(this._b2, e.Bounds);
                try
                {
                    e.Graphics.DrawString(this.GetItemText(this.Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(105, 105, 105)), e.Bounds);
                } // Regular text color
                catch {}
            }
        }
    }

    /// <summary>
    /// </summary>
    internal class ChromeLabel : Label
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeLabel" /> class.
        /// </summary>
        public ChromeLabel()
        {
            this.ForeColor = Color.FromArgb(78, 87, 100);
            this.BackColor = Color.Transparent;
            this.Font = new Font("Segoe", 9);
        }
    }

    /// <summary>
    /// </summary>
    [DefaultEvent("CheckedChanged")]
    internal class ChromeOnOff : ThemeControl154
    {
        #region Delegates

        /// <summary>
        /// </summary>
        /// <param name="sender">The sender.</param>
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion

        /// <summary>
        ///     The tb
        /// </summary>
        private Brush _tb;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChromeOnOff" /> class.
        /// </summary>
        public ChromeOnOff()
        {
            this.LockHeight = 24;
            this.LockWidth = 62;
            this.SetColor("Texts", Color.FromArgb(100, 100, 100));
            this.SetColor("border", Color.FromArgb(78, 87, 100));
        }

        /// <summary>
        ///     The _ checked
        /// </summary>
        private bool _checked { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ChromeOnOff" /> is checked.
        /// </summary>
        /// <value>
        ///     <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        public bool Checked
        {
            get { return this._checked; }
            set
            {
                this._checked = value;
                this.Invalidate();
            }
        }

        /// <summary>
        ///     Occurs when [checked changed].
        /// </summary>
        public event CheckedChangedEventHandler CheckedChanged;

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="G">The g.</param>
        private void DrawBorders(Pen p1, Graphics G)
        {
            this.DrawBorders(p1, 0, 0, this.Width, this.Height, G);
        }

        /// <summary>
        ///     Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="G">The g.</param>
        private void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }

        /// <summary>
        ///     Raises the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this._checked = !this._checked;
            if (this.CheckedChanged != null) this.CheckedChanged(this);
            base.OnMouseDown(e);
        }

        /// <summary>
        ///     Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            this._tb = this.GetBrush("Texts");
            this.GetPen("border");
        }

        /// <summary>
        ///     Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            new Rectangle();
            this.G.Clear(this.BackColor);
            var lgb1 = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(78, 87, 100), Color.FromArgb(78, 87, 100), 90);
            if (this._checked)
            {
                this.G.FillRectangle(lgb1, new Rectangle(0, 0, (this.Width / 2) - 0, this.Height - 0));
                this.G.DrawString("On", this.Font, this._tb, new Point(36, 6));
            }
            else if (!this._checked)
            {
                this.G.FillRectangle(lgb1, new Rectangle((this.Width / 2) - 0, 0, (this.Width / 2) - 0, this.Height - 0));
                this.G.DrawString("Off", this.Font, this._tb, new Point(5, 6));
            }
            this.DrawBorders(new Pen(new SolidBrush(Color.FromArgb(78, 87, 100))), this.G);
        }
    }

    internal class ChromeTrackbar : Control {}

    //------------------
    //Creator: aeonhack
    //Site: elitevs.net
    //Created: 08/02/2011
    //Changed: 12/06/2011
    //Version: 1.5.4
    //------------------
    internal abstract class ThemeContainer154 : ContainerControl
    {
        private bool _hasShown;

        private void DoAnimation(bool i)
        {
            this.OnAnimation();
            if (i) this.Invalidate();
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (this.Width == 0 || this.Height == 0) return;

            if (this._Transparent && this._ControlMode)
            {
                this.PaintHook();
                e.Graphics.DrawImage(this.B, 0, 0);
            }
            else
            {
                this.G = e.Graphics;
                this.PaintHook();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(this.DoAnimation);
            base.OnHandleDestroyed(e);
        }

        private void FormShown(object sender, EventArgs e)
        {
            if (this._ControlMode || this._hasShown) return;

            if (this._StartPosition == FormStartPosition.CenterParent || this._StartPosition == FormStartPosition.CenterScreen)
            {
                var SB = Screen.PrimaryScreen.Bounds;
                var CB = this.ParentForm.Bounds;
                this.ParentForm.Location = new Point(SB.Width / 2 - CB.Width / 2, SB.Height / 2 - CB.Width / 2);
            }

            this._hasShown = true;
        }

        #region " Initialization "

        private Bitmap B;

        protected Graphics G;

        private bool _doneCreation;

        protected ThemeContainer154()
        {
            this.SetStyle((ControlStyles)139270, true);

            this._ImageSize = Size.Empty;
            this.Font = new Font("Verdana", 8);

            this.MeasureBitmap = new Bitmap(1, 1);
            this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);

            this.DrawRadialPath = new GraphicsPath();

            this.InvalidateCustimization();
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            if (this._doneCreation) this.InitializeMessages();

            this.InvalidateCustimization();
            this.ColorHook();

            if (this._LockWidth != 0) this.Width = this._LockWidth;
            if (this._LockHeight != 0) this.Height = this._LockHeight;
            if (!this._ControlMode) base.Dock = DockStyle.Fill;

            this.Transparent = this._Transparent;
            if (this._Transparent && this._BackColor) this.BackColor = Color.Transparent;

            base.OnHandleCreated(e);
        }

        protected override sealed void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent == null) return;
            this._IsParentForm = this.Parent is Form;

            if (!this._ControlMode)
            {
                this.InitializeMessages();

                if (this._IsParentForm)
                {
                    if (this.ParentForm != null)
                    {
                        this.ParentForm.FormBorderStyle = this._BorderStyle;
                        this.ParentForm.TransparencyKey = this._TransparencyKey;

                        if (!this.DesignMode) this.ParentForm.Shown += this.FormShown;
                    }
                }

                this.Parent.BackColor = this.BackColor;
            }

            this.OnCreation();
            this._doneCreation = true;
            this.InvalidateTimer();
        }

        #endregion

        #region " Size Handling "

        private Rectangle _frame;

        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (this._Movable && !this._ControlMode) this._frame = new Rectangle(7, 7, this.Width - 14, this._Header - 7);

            this.InvalidateBitmap();
            this.Invalidate();

            base.OnSizeChanged(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this._LockWidth != 0) width = this._LockWidth;
            if (this._LockHeight != 0) height = this._LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion

        #region " State Handling "

        private readonly Message[] _messages = new Message[9];

        private MouseStateControl State;

        private bool _b1;

        private bool _b2;

        private bool _b3;

        private bool _b4;

        private int _current;

        private Point _getIndexPoint;

        private int _previous;

        private bool _wmLmbuttondown;

        private void SetState(MouseStateControl current)
        {
            this.State = current;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.ParentForm != null && !(this._IsParentForm && this.ParentForm.WindowState == FormWindowState.Maximized)) if (this._Sizable && !this._ControlMode) this.InvalidateMouse();

            base.OnMouseMove(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            this.SetState(this.Enabled ? MouseStateControl.None : MouseStateControl.Block);
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.SetState(MouseStateControl.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.SetState(MouseStateControl.Over);
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.SetState(MouseStateControl.None);

            if (this.GetChildAtPoint(this.PointToClient(MousePosition)) != null)
            {
                if (this._Sizable && !this._ControlMode)
                {
                    this.Cursor = Cursors.Default;
                    this._previous = 0;
                }
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.SetState(MouseStateControl.Down);

            if (this.ParentForm != null && !(this._IsParentForm && this.ParentForm.WindowState == FormWindowState.Maximized || this._ControlMode))
            {
                if (this._Movable && this._frame.Contains(e.Location))
                {
                    if (!new Rectangle(this.Width - 22, 5, 15, 15).Contains(e.Location)) this.Capture = false;
                    this._wmLmbuttondown = true;
                    this.DefWndProc(ref this._messages[0]);
                }
                else if (this._Sizable && this._previous != 0)
                {
                    this.Capture = false;
                    this._wmLmbuttondown = true;
                    this.DefWndProc(ref this._messages[this._previous]);
                }
            }

            base.OnMouseDown(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (this._wmLmbuttondown && m.Msg == 513)
            {
                this._wmLmbuttondown = false;

                this.SetState(MouseStateControl.Over);
                if (!this._SmartBounds) return;

                this.CorrectBounds(this.IsParentMdi ? new Rectangle(Point.Empty, this.Parent.Parent.Size) : Screen.FromControl(this.Parent).WorkingArea);
            }
        }

        private int GetIndex()
        {
            this._getIndexPoint = this.PointToClient(MousePosition);
            this._b1 = this._getIndexPoint.X < 7;
            this._b2 = this._getIndexPoint.X > this.Width - 7;
            this._b3 = this._getIndexPoint.Y < 7;
            this._b4 = this._getIndexPoint.Y > this.Height - 7;

            if (this._b1 && this._b3) return 4;
            if (this._b1 && this._b4) return 7;
            if (this._b2 && this._b3) return 5;
            if (this._b2 && this._b4) return 8;
            if (this._b1) return 1;
            if (this._b2) return 2;
            if (this._b3) return 3;
            return this._b4 ? 6 : 0;
        }

        private void InvalidateMouse()
        {
            this._current = this.GetIndex();
            if (this._current == this._previous) return;

            this._previous = this._current;
            switch (this._previous)
            {
                case 0:
                    this.Cursor = Cursors.Default;
                    break;
                case 1:
                case 2:
                    this.Cursor = Cursors.SizeWE;
                    break;
                case 3:
                case 6:
                    this.Cursor = Cursors.SizeNS;
                    break;
                case 4:
                case 8:
                    this.Cursor = Cursors.SizeNWSE;
                    break;
                case 5:
                case 7:
                    this.Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        private void InitializeMessages()
        {
            this._messages[0] = Message.Create(this.Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (var I = 1; I <= 8; I++)
            {
                this._messages[I] = Message.Create(this.Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
            }
        }

        private void CorrectBounds(Rectangle bounds)
        {
            if (this.Parent.Width > bounds.Width) this.Parent.Width = bounds.Width;
            if (this.Parent.Height > bounds.Height) this.Parent.Height = bounds.Height;

            var X = this.Parent.Location.X;
            var Y = this.Parent.Location.Y;

            if (X < bounds.X) X = bounds.X;
            if (Y < bounds.Y) Y = bounds.Y;

            var Width = bounds.X + bounds.Width;
            var Height = bounds.Y + bounds.Height;

            if (X + this.Parent.Width > Width) X = Width - this.Parent.Width;
            if (Y + this.Parent.Height > Height) Y = Height - this.Parent.Height;

            this.Parent.Location = new Point(X, Y);
        }

        #endregion

        #region " Base Properties "

        private bool _BackColor;

        public override DockStyle Dock
        {
            get { return base.Dock; }
            set
            {
                if (!this._ControlMode) return;
                base.Dock = value;
            }
        }

        [Category("Misc")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (value == base.BackColor) return;

                if (!this.IsHandleCreated && this._ControlMode && value == Color.Transparent)
                {
                    this._BackColor = true;
                    return;
                }

                base.BackColor = value;
                if (this.Parent != null)
                {
                    if (!this._ControlMode) this.Parent.BackColor = value;
                    this.ColorHook();
                }
            }
        }

        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set
            {
                base.MinimumSize = value;
                if (this.Parent != null) this.Parent.MinimumSize = value;
            }
        }

        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set
            {
                base.MaximumSize = value;
                if (this.Parent != null) this.Parent.MaximumSize = value;
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        public override sealed Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        #endregion

        #region " Public Properties "

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();

        private FormBorderStyle _BorderStyle;

        private string _Customization;

        private Image _Image;

        private bool _Movable = true;

        private bool _NoRounding;

        private bool _Sizable = true;

        private bool _SmartBounds = true;

        private FormStartPosition _StartPosition;

        private Color _TransparencyKey;

        private bool _Transparent;

        public bool SmartBounds
        {
            get { return this._SmartBounds; }
            set { this._SmartBounds = value; }
        }

        public bool Movable
        {
            get { return this._Movable; }
            set { this._Movable = value; }
        }

        public bool Sizable
        {
            get { return this._Sizable; }
            set { this._Sizable = value; }
        }

        public Color TransparencyKey
        {
            get
            {
                if (this._IsParentForm && !this._ControlMode) return this.ParentForm.TransparencyKey;
                return this._TransparencyKey;
            }
            set
            {
                if (value == this._TransparencyKey) return;
                this._TransparencyKey = value;

                if (this._IsParentForm && !this._ControlMode)
                {
                    this.ParentForm.TransparencyKey = value;
                    this.ColorHook();
                }
            }
        }

        public FormBorderStyle BorderStyle
        {
            get
            {
                if (this._IsParentForm && !this._ControlMode) return this.ParentForm.FormBorderStyle;
                return this._BorderStyle;
            }
            set
            {
                this._BorderStyle = value;

                if (this._IsParentForm && !this._ControlMode)
                {
                    this.ParentForm.FormBorderStyle = value;

                    if (!(value == FormBorderStyle.None))
                    {
                        this.Movable = false;
                        this.Sizable = false;
                    }
                }
            }
        }

        public FormStartPosition StartPosition
        {
            get
            {
                if (this._IsParentForm && !this._ControlMode) return this.ParentForm.StartPosition;
                return this._StartPosition;
            }
            set
            {
                this._StartPosition = value;

                if (this._IsParentForm && !this._ControlMode) if (this.ParentForm != null) this.ParentForm.StartPosition = value;
            }
        }

        public bool NoRounding
        {
            get { return this._NoRounding; }
            set
            {
                this._NoRounding = value;
                this.Invalidate();
            }
        }

        public Image Image
        {
            get { return this._Image; }
            set
            {
                if (value == null) this._ImageSize = Size.Empty;
                else this._ImageSize = value.Size;

                this._Image = value;
                this.Invalidate();
            }
        }

        public Bloom[] Colors
        {
            get
            {
                var T = new List<Bloom>();
                var E = this.Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (var B in value)
                {
                    if (this.Items.ContainsKey(B.Name)) this.Items[B.Name] = B.Value;
                }

                this.InvalidateCustimization();
                this.ColorHook();
                this.Invalidate();
            }
        }

        public string Customization
        {
            get { return this._Customization; }
            set
            {
                if (value == this._Customization) return;

                byte[] Data = null;
                var Items = this.Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (var I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                this._Customization = value;

                this.Colors = Items;
                this.ColorHook();
                this.Invalidate();
            }
        }

        public bool Transparent
        {
            get { return this._Transparent; }
            set
            {
                this._Transparent = value;
                if (!(this.IsHandleCreated || this._ControlMode)) return;

                if (!value && !(this.BackColor.A == 255)) throw new Exception("Unable to change value to false while a transparent BackColor is in use.");

                this.SetStyle(ControlStyles.Opaque, !value);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, value);

                this.InvalidateBitmap();
                this.Invalidate();
            }
        }

        #endregion

        #region " Private Properties "

        private bool _ControlMode;

        private int _Header = 24;

        private Size _ImageSize;

        private bool _IsAnimated;

        private bool _IsParentForm;

        private int _LockHeight;

        private int _LockWidth;

        protected Size ImageSize
        {
            get { return this._ImageSize; }
        }

        protected bool IsParentForm
        {
            get { return this._IsParentForm; }
        }

        protected bool IsParentMdi
        {
            get
            {
                if (this.Parent == null) return false;
                return this.Parent.Parent != null;
            }
        }

        protected int LockWidth
        {
            get { return this._LockWidth; }
            set
            {
                this._LockWidth = value;
                if (!(this.LockWidth == 0) && this.IsHandleCreated) this.Width = this.LockWidth;
            }
        }

        protected int LockHeight
        {
            get { return this._LockHeight; }
            set
            {
                this._LockHeight = value;
                if (!(this.LockHeight == 0) && this.IsHandleCreated) this.Height = this.LockHeight;
            }
        }

        protected int Header
        {
            get { return this._Header; }
            set
            {
                this._Header = value;

                if (!this._ControlMode)
                {
                    this._frame = new Rectangle(7, 7, this.Width - 14, value - 7);
                    this.Invalidate();
                }
            }
        }

        protected bool ControlMode
        {
            get { return this._ControlMode; }
            set
            {
                this._ControlMode = value;

                this.Transparent = this._Transparent;
                if (this._Transparent && this._BackColor) this.BackColor = Color.Transparent;

                this.InvalidateBitmap();
                this.Invalidate();
            }
        }

        protected bool IsAnimated
        {
            get { return this._IsAnimated; }
            set
            {
                this._IsAnimated = value;
                this.InvalidateTimer();
            }
        }

        #endregion

        #region " Property Helpers "

        protected Pen GetPen(string name) { return new Pen(this.Items[name]); }

        protected Pen GetPen(string name, float width) { return new Pen(this.Items[name], width); }

        protected SolidBrush GetBrush(string name) { return new SolidBrush(this.Items[name]); }

        protected Color GetColor(string name) { return this.Items[name]; }

        protected void SetColor(string name, Color value)
        {
            if (this.Items.ContainsKey(name)) this.Items[name] = value;
            else this.Items.Add(name, value);
        }

        protected void SetColor(string name, byte r, byte g, byte b) { this.SetColor(name, Color.FromArgb(r, g, b)); }

        protected void SetColor(string name, byte a, byte r, byte g, byte b) { this.SetColor(name, Color.FromArgb(a, r, g, b)); }

        protected void SetColor(string name, byte a, Color value) { this.SetColor(name, Color.FromArgb(a, value)); }

        private void InvalidateBitmap()
        {
            if (this._Transparent && this._ControlMode)
            {
                if (this.Width == 0 || this.Height == 0) return;
                this.B = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb);
                this.G = Graphics.FromImage(this.B);
            }
            else
            {
                this.G = null;
                this.B = null;
            }
        }

        private void InvalidateCustimization()
        {
            var M = new MemoryStream(this.Items.Count * 4);

            foreach (var B in this.Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            this._Customization = Convert.ToBase64String(M.ToArray());
        }

        private void InvalidateTimer()
        {
            if (this.DesignMode || !this._doneCreation) return;

            if (this._IsAnimated) ThemeShare.AddAnimationCallback(this.DoAnimation);
            else ThemeShare.RemoveAnimationCallback(this.DoAnimation);
        }

        #endregion

        #region " User Hooks "

        protected abstract void ColorHook();

        protected abstract void PaintHook();

        protected virtual void OnCreation() { }

        protected virtual void OnAnimation() { }

        #endregion

        #region " Offset "

        private Point OffsetReturnPoint;

        private Rectangle OffsetReturnRectangle;

        private Size OffsetReturnSize;

        protected Rectangle Offset(Rectangle r, int amount)
        {
            this.OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
            return this.OffsetReturnRectangle;
        }

        protected Size Offset(Size s, int amount)
        {
            this.OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
            return this.OffsetReturnSize;
        }

        protected Point Offset(Point p, int amount)
        {
            this.OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
            return this.OffsetReturnPoint;
        }

        #endregion

        #region " Center "

        private Point CenterReturn;

        protected Point Center(Rectangle p, Rectangle c)
        {
            this.CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
            return this.CenterReturn;
        }

        protected Point Center(Rectangle p, Size c)
        {
            this.CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
            return this.CenterReturn;
        }

        protected Point Center(Rectangle child) { return this.Center(this.Width, this.Height, child.Width, child.Height); }

        protected Point Center(Size child) { return this.Center(this.Width, this.Height, child.Width, child.Height); }

        protected Point Center(int childWidth, int childHeight) { return this.Center(this.Width, this.Height, childWidth, childHeight); }

        protected Point Center(Size p, Size c) { return this.Center(p.Width, p.Height, c.Width, c.Height); }

        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            this.CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
            return this.CenterReturn;
        }

        #endregion

        #region " Measure "

        private Bitmap MeasureBitmap;

        private Graphics MeasureGraphics;

        protected Size Measure()
        {
            lock (this.MeasureGraphics)
            {
                return this.MeasureGraphics.MeasureString(this.Text, this.Font, this.Width).ToSize();
            }
        }

        protected Size Measure(string text)
        {
            lock (this.MeasureGraphics)
            {
                return this.MeasureGraphics.MeasureString(text, this.Font, this.Width).ToSize();
            }
        }

        #endregion

        #region " DrawPixel "

        private SolidBrush DrawPixelBrush;

        protected void DrawPixel(Color c1, int x, int y)
        {
            if (this._Transparent) this.B.SetPixel(x, y, c1);
            else
            {
                this.DrawPixelBrush = new SolidBrush(c1);
                this.G.FillRectangle(this.DrawPixelBrush, x, y, 1, 1);
            }
        }

        #endregion

        #region " DrawCorners "

        private SolidBrush DrawCornersBrush;

        protected void DrawCorners(Color c1, int offset) { this.DrawCorners(c1, 0, 0, this.Width, this.Height, offset); }

        protected void DrawCorners(Color c1, Rectangle r1, int offset) { this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset); }

        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset) { this.DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2)); }

        protected void DrawCorners(Color c1) { this.DrawCorners(c1, 0, 0, this.Width, this.Height); }

        protected void DrawCorners(Color c1, Rectangle r1) { this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height); }

        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (this._NoRounding) return;

            if (this._Transparent)
            {
                this.B.SetPixel(x, y, c1);
                this.B.SetPixel(x + (width - 1), y, c1);
                this.B.SetPixel(x, y + (height - 1), c1);
                this.B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else
            {
                this.DrawCornersBrush = new SolidBrush(c1);
                this.G.FillRectangle(this.DrawCornersBrush, x, y, 1, 1);
                this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y, 1, 1);
                this.G.FillRectangle(this.DrawCornersBrush, x, y + (height - 1), 1, 1);
                this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion

        #region " DrawBorders "

        protected void DrawBorders(Pen p1, int offset) { this.DrawBorders(p1, 0, 0, this.Width, this.Height, offset); }

        protected void DrawBorders(Pen p1, Rectangle r, int offset) { this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset); }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset) { this.DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2)); }

        protected void DrawBorders(Pen p1) { this.DrawBorders(p1, 0, 0, this.Width, this.Height); }

        protected void DrawBorders(Pen p1, Rectangle r) { this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height); }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height) { this.G.DrawRectangle(p1, x, y, width - 1, height - 1); }

        #endregion

        #region " DrawText "

        private Point DrawTextPoint;

        private Size DrawTextSize;

        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y) { this.DrawText(b1, this.Text, a, x, y); }

        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0) return;

            this.DrawTextSize = this.Measure(text);
            this.DrawTextPoint = new Point(this.Width / 2 - this.DrawTextSize.Width / 2, this.Header / 2 - this.DrawTextSize.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    this.G.DrawString(text, this.Font, b1, x, this.DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    this.G.DrawString(text, this.Font, b1, this.DrawTextPoint.X + x, this.DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    this.G.DrawString(text, this.Font, b1, this.Width - this.DrawTextSize.Width - x, this.DrawTextPoint.Y + y);
                    break;
            }
        }

        protected void DrawText(Brush b1, Point p1)
        {
            if (this.Text.Length == 0) return;
            this.G.DrawString(this.Text, this.Font, b1, p1);
        }

        protected void DrawText(Brush b1, int x, int y)
        {
            if (this.Text.Length == 0) return;
            this.G.DrawString(this.Text, this.Font, b1, x, y);
        }

        #endregion

        #region " DrawImage "

        private Point DrawImagePoint;

        protected void DrawImage(HorizontalAlignment a, int x, int y) { this.DrawImage(this._Image, a, x, y); }

        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null) return;
            this.DrawImagePoint = new Point(this.Width / 2 - image.Width / 2, this.Header / 2 - image.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    this.G.DrawImage(image, x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Center:
                    this.G.DrawImage(image, this.DrawImagePoint.X + x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Right:
                    this.G.DrawImage(image, this.Width - image.Width - x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
            }
        }

        protected void DrawImage(Point p1) { this.DrawImage(this._Image, p1.X, p1.Y); }

        protected void DrawImage(int x, int y) { this.DrawImage(this._Image, x, y); }

        protected void DrawImage(Image image, Point p1) { this.DrawImage(image, p1.X, p1.Y); }

        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null) return;
            this.G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient "

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle);
        }

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r) { this.DrawGradient(blend, r, 90); }

        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            this.DrawGradientBrush.InterpolationColors = blend;
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle r) { this.DrawGradient(c1, c2, r, 90); }

        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }

        #endregion

        #region " DrawRadial "

        private PathGradientBrush DrawRadialBrush1;

        private LinearGradientBrush DrawRadialBrush2;

        private GraphicsPath DrawRadialPath;

        private Rectangle DrawRadialRectangle;

        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, width / 2, height / 2);
        }

        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, center.X, center.Y);
        }

        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, cx, cy);
        }

        public void DrawRadial(ColorBlend blend, Rectangle r) { this.DrawRadial(blend, r, r.Width / 2, r.Height / 2); }

        public void DrawRadial(ColorBlend blend, Rectangle r, Point center) { this.DrawRadial(blend, r, center.X, center.Y); }

        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            this.DrawRadialPath.Reset();
            this.DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

            this.DrawRadialBrush1 = new PathGradientBrush(this.DrawRadialPath);
            this.DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
            this.DrawRadialBrush1.InterpolationColors = blend;

            if (this.G.SmoothingMode == SmoothingMode.AntiAlias) this.G.FillEllipse(this.DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
            else this.G.FillEllipse(this.DrawRadialBrush1, r);
        }

        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawGradientRectangle);
        }

        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawGradientRectangle, angle);
        }

        protected void DrawRadial(Color c1, Color c2, Rectangle r)
        {
            this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }

        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillEllipse(this.DrawGradientBrush, r);
        }

        #endregion

        #region " CreateRound "

        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;

        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            this.CreateRoundRectangle = new Rectangle(x, y, width, height);
            return this.CreateRound(this.CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            this.CreateRoundPath = new GraphicsPath(FillMode.Winding);
            this.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            this.CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            this.CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            this.CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            this.CreateRoundPath.CloseFigure();
            return this.CreateRoundPath;
        }

        #endregion
    }

    internal abstract class ThemeControl154 : Control
    {
        private void DoAnimation(bool i)
        {
            this.OnAnimation();
            if (i) this.Invalidate();
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (this.Width == 0 || this.Height == 0) return;

            if (this._Transparent)
            {
                this.PaintHook();
                e.Graphics.DrawImage(this.B, 0, 0);
            }
            else
            {
                this.G = e.Graphics;
                this.PaintHook();
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            ThemeShare.RemoveAnimationCallback(this.DoAnimation);
            base.OnHandleDestroyed(e);
        }

        #region " Initialization "

        protected Bitmap B;

        private bool DoneCreation;

        protected Graphics G;

        public ThemeControl154()
        {
            this.SetStyle((ControlStyles)139270, true);

            this._ImageSize = Size.Empty;
            this.Font = new Font("Verdana", 8);

            this.MeasureBitmap = new Bitmap(1, 1);
            this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);

            this.DrawRadialPath = new GraphicsPath();

            this.InvalidateCustimization();
            //Remove?
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            this.InvalidateCustimization();
            this.ColorHook();

            if (!(this._LockWidth == 0)) this.Width = this._LockWidth;
            if (!(this._LockHeight == 0)) this.Height = this._LockHeight;

            this.Transparent = this._Transparent;
            if (this._Transparent && this._BackColor) this.BackColor = Color.Transparent;

            base.OnHandleCreated(e);
        }

        protected override sealed void OnParentChanged(EventArgs e)
        {
            if (this.Parent != null)
            {
                this.OnCreation();
                this.DoneCreation = true;
                this.InvalidateTimer();
            }

            base.OnParentChanged(e);
        }

        #endregion

        #region " Size Handling "

        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (this._Transparent) this.InvalidateBitmap();

            this.Invalidate();
            base.OnSizeChanged(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(this._LockWidth == 0)) width = this._LockWidth;
            if (!(this._LockHeight == 0)) height = this._LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion

        #region " State Handling "

        private bool InPosition;

        protected MouseStateControl State;

        protected override void OnMouseEnter(EventArgs e)
        {
            this.InPosition = true;
            this.SetState(MouseStateControl.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.InPosition) this.SetState(MouseStateControl.Over);
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) this.SetState(MouseStateControl.Down);
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.InPosition = false;
            this.SetState(MouseStateControl.None);
            base.OnMouseLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled) this.SetState(MouseStateControl.None);
            else this.SetState(MouseStateControl.Block);
            base.OnEnabledChanged(e);
        }

        private void SetState(MouseStateControl current)
        {
            this.State = current;
            this.Invalidate();
        }

        #endregion

        #region " Base Properties "

        private bool _BackColor;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }

        [Category("Misc")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (!this.IsHandleCreated && value == Color.Transparent)
                {
                    this._BackColor = true;
                    return;
                }

                base.BackColor = value;
                if (this.Parent != null) this.ColorHook();
            }
        }

        #endregion

        #region " Public Properties "

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();

        private string _Customization;

        private Image _Image;

        private bool _NoRounding;

        private bool _Transparent;

        public bool NoRounding
        {
            get { return this._NoRounding; }
            set
            {
                this._NoRounding = value;
                this.Invalidate();
            }
        }

        public Image Image
        {
            get { return this._Image; }
            set
            {
                if (value == null) this._ImageSize = Size.Empty;
                else this._ImageSize = value.Size;

                this._Image = value;
                this.Invalidate();
            }
        }

        public bool Transparent
        {
            get { return this._Transparent; }
            set
            {
                this._Transparent = value;
                if (!this.IsHandleCreated) return;

                if (!value && !(this.BackColor.A == 255)) throw new Exception("Unable to change value to false while a transparent BackColor is in use.");

                this.SetStyle(ControlStyles.Opaque, !value);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, value);

                if (value) this.InvalidateBitmap();
                else this.B = null;
                this.Invalidate();
            }
        }

        public Bloom[] Colors
        {
            get
            {
                var T = new List<Bloom>();
                var E = this.Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (var B in value)
                {
                    if (this.Items.ContainsKey(B.Name)) this.Items[B.Name] = B.Value;
                }

                this.InvalidateCustimization();
                this.ColorHook();
                this.Invalidate();
            }
        }

        public string Customization
        {
            get { return this._Customization; }
            set
            {
                if (value == this._Customization) return;

                byte[] Data = null;
                var Items = this.Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (var I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                this._Customization = value;

                this.Colors = Items;
                this.ColorHook();
                this.Invalidate();
            }
        }

        #endregion

        #region " Private Properties "

        private Size _ImageSize;

        private bool _IsAnimated;

        private int _LockHeight;

        private int _LockWidth;

        protected Size ImageSize
        {
            get { return this._ImageSize; }
        }

        protected int LockWidth
        {
            get { return this._LockWidth; }
            set
            {
                this._LockWidth = value;
                if (!(this.LockWidth == 0) && this.IsHandleCreated) this.Width = this.LockWidth;
            }
        }

        protected int LockHeight
        {
            get { return this._LockHeight; }
            set
            {
                this._LockHeight = value;
                if (!(this.LockHeight == 0) && this.IsHandleCreated) this.Height = this.LockHeight;
            }
        }

        protected bool IsAnimated
        {
            get { return this._IsAnimated; }
            set
            {
                this._IsAnimated = value;
                this.InvalidateTimer();
            }
        }

        #endregion

        #region " Property Helpers "

        protected Pen GetPen(string name) { return new Pen(this.Items[name]); }

        protected Pen GetPen(string name, float width) { return new Pen(this.Items[name], width); }

        protected SolidBrush GetBrush(string name) { return new SolidBrush(this.Items[name]); }

        protected Color GetColor(string name) { return this.Items[name]; }

        protected void SetColor(string name, Color value)
        {
            if (this.Items.ContainsKey(name)) this.Items[name] = value;
            else this.Items.Add(name, value);
        }

        protected void SetColor(string name, byte r, byte g, byte b) { this.SetColor(name, Color.FromArgb(r, g, b)); }

        protected void SetColor(string name, byte a, byte r, byte g, byte b) { this.SetColor(name, Color.FromArgb(a, r, g, b)); }

        protected void SetColor(string name, byte a, Color value) { this.SetColor(name, Color.FromArgb(a, value)); }

        private void InvalidateBitmap()
        {
            if (this.Width == 0 || this.Height == 0) return;
            this.B = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb);
            this.G = Graphics.FromImage(this.B);
        }

        private void InvalidateCustimization()
        {
            var M = new MemoryStream(this.Items.Count * 4);

            foreach (var B in this.Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            this._Customization = Convert.ToBase64String(M.ToArray());
        }

        private void InvalidateTimer()
        {
            if (this.DesignMode || !this.DoneCreation) return;

            if (this._IsAnimated) ThemeShare.AddAnimationCallback(this.DoAnimation);
            else ThemeShare.RemoveAnimationCallback(this.DoAnimation);
        }

        #endregion

        #region " User Hooks "

        protected abstract void ColorHook();

        protected abstract void PaintHook();

        protected virtual void OnCreation() { }

        protected virtual void OnAnimation() { }

        #endregion

        #region " Offset "

        private Point OffsetReturnPoint;

        private Rectangle OffsetReturnRectangle;

        private Size OffsetReturnSize;

        protected Rectangle Offset(Rectangle r, int amount)
        {
            this.OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
            return this.OffsetReturnRectangle;
        }

        protected Size Offset(Size s, int amount)
        {
            this.OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
            return this.OffsetReturnSize;
        }

        protected Point Offset(Point p, int amount)
        {
            this.OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
            return this.OffsetReturnPoint;
        }

        #endregion

        #region " Center "

        private Point CenterReturn;

        protected Point Center(Rectangle p, Rectangle c)
        {
            this.CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
            return this.CenterReturn;
        }

        protected Point Center(Rectangle p, Size c)
        {
            this.CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
            return this.CenterReturn;
        }

        protected Point Center(Rectangle child) { return this.Center(this.Width, this.Height, child.Width, child.Height); }

        protected Point Center(Size child) { return this.Center(this.Width, this.Height, child.Width, child.Height); }

        protected Point Center(int childWidth, int childHeight) { return this.Center(this.Width, this.Height, childWidth, childHeight); }

        protected Point Center(Size p, Size c) { return this.Center(p.Width, p.Height, c.Width, c.Height); }

        protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
        {
            this.CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
            return this.CenterReturn;
        }

        #endregion

        #region " Measure "

        private Bitmap MeasureBitmap;

        //TODO: Potential issues during multi-threading.
        private Graphics MeasureGraphics;

        protected Size Measure() { return this.MeasureGraphics.MeasureString(this.Text, this.Font, this.Width).ToSize(); }

        protected Size Measure(string text) { return this.MeasureGraphics.MeasureString(text, this.Font, this.Width).ToSize(); }

        #endregion

        #region " DrawPixel "

        private SolidBrush DrawPixelBrush;

        protected void DrawPixel(Color c1, int x, int y)
        {
            if (this._Transparent) this.B.SetPixel(x, y, c1);
            else
            {
                this.DrawPixelBrush = new SolidBrush(c1);
                this.G.FillRectangle(this.DrawPixelBrush, x, y, 1, 1);
            }
        }

        #endregion

        #region " DrawCorners "

        private SolidBrush DrawCornersBrush;

        protected void DrawCorners(Color c1, int offset) { this.DrawCorners(c1, 0, 0, this.Width, this.Height, offset); }

        protected void DrawCorners(Color c1, Rectangle r1, int offset) { this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset); }

        protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset) { this.DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2)); }

        protected void DrawCorners(Color c1) { this.DrawCorners(c1, 0, 0, this.Width, this.Height); }

        protected void DrawCorners(Color c1, Rectangle r1) { this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height); }

        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (this._NoRounding) return;

            if (this._Transparent)
            {
                this.B.SetPixel(x, y, c1);
                this.B.SetPixel(x + (width - 1), y, c1);
                this.B.SetPixel(x, y + (height - 1), c1);
                this.B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else
            {
                this.DrawCornersBrush = new SolidBrush(c1);
                this.G.FillRectangle(this.DrawCornersBrush, x, y, 1, 1);
                this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y, 1, 1);
                this.G.FillRectangle(this.DrawCornersBrush, x, y + (height - 1), 1, 1);
                this.G.FillRectangle(this.DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion

        #region " DrawBorders "

        protected void DrawBorders(Pen p1, int offset) { this.DrawBorders(p1, 0, 0, this.Width, this.Height, offset); }

        protected void DrawBorders(Pen p1, Rectangle r, int offset) { this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset); }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset) { this.DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2)); }

        protected void DrawBorders(Pen p1) { this.DrawBorders(p1, 0, 0, this.Width, this.Height); }

        protected void DrawBorders(Pen p1, Rectangle r) { this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height); }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height) { this.G.DrawRectangle(p1, x, y, width - 1, height - 1); }

        #endregion

        #region " DrawText "

        private Point DrawTextPoint;

        private Size DrawTextSize;

        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y) { this.DrawText(b1, this.Text, a, x, y); }

        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0) return;

            this.DrawTextSize = this.Measure(text);
            this.DrawTextPoint = this.Center(this.DrawTextSize);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    this.G.DrawString(text, this.Font, b1, x, this.DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    this.G.DrawString(text, this.Font, b1, this.DrawTextPoint.X + x, this.DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    this.G.DrawString(text, this.Font, b1, this.Width - this.DrawTextSize.Width - x, this.DrawTextPoint.Y + y);
                    break;
            }
        }

        protected void DrawText(Brush b1, Point p1)
        {
            if (this.Text.Length == 0) return;
            this.G.DrawString(this.Text, this.Font, b1, p1);
        }

        protected void DrawText(Brush b1, int x, int y)
        {
            if (this.Text.Length == 0) return;
            this.G.DrawString(this.Text, this.Font, b1, x, y);
        }

        #endregion

        #region " DrawImage "

        private Point DrawImagePoint;

        protected void DrawImage(HorizontalAlignment a, int x, int y) { this.DrawImage(this._Image, a, x, y); }

        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null) return;
            this.DrawImagePoint = this.Center(image.Size);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    this.G.DrawImage(image, x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Center:
                    this.G.DrawImage(image, this.DrawImagePoint.X + x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
                case HorizontalAlignment.Right:
                    this.G.DrawImage(image, this.Width - image.Width - x, this.DrawImagePoint.Y + y, image.Width, image.Height);
                    break;
            }
        }

        protected void DrawImage(Point p1) { this.DrawImage(this._Image, p1.X, p1.Y); }

        protected void DrawImage(int x, int y) { this.DrawImage(this._Image, x, y); }

        protected void DrawImage(Image image, Point p1) { this.DrawImage(image, p1.X, p1.Y); }

        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null) return;
            this.G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient "

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle);
        }

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(blend, this.DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r) { this.DrawGradient(blend, r, 90); }

        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            this.DrawGradientBrush.InterpolationColors = blend;
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawGradientRectangle = new Rectangle(x, y, width, height);
            this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
        }

        protected void DrawGradient(Color c1, Color c2, Rectangle r) { this.DrawGradient(c1, c2, r, 90); }

        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillRectangle(this.DrawGradientBrush, r);
        }

        #endregion

        #region " DrawRadial "

        private PathGradientBrush DrawRadialBrush1;

        private LinearGradientBrush DrawRadialBrush2;

        private GraphicsPath DrawRadialPath;

        private Rectangle DrawRadialRectangle;

        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, width / 2, height / 2);
        }

        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, center.X, center.Y);
        }

        public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(blend, this.DrawRadialRectangle, cx, cy);
        }

        public void DrawRadial(ColorBlend blend, Rectangle r) { this.DrawRadial(blend, r, r.Width / 2, r.Height / 2); }

        public void DrawRadial(ColorBlend blend, Rectangle r, Point center) { this.DrawRadial(blend, r, center.X, center.Y); }

        public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
        {
            this.DrawRadialPath.Reset();
            this.DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

            this.DrawRadialBrush1 = new PathGradientBrush(this.DrawRadialPath);
            this.DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
            this.DrawRadialBrush1.InterpolationColors = blend;

            if (this.G.SmoothingMode == SmoothingMode.AntiAlias) this.G.FillEllipse(this.DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
            else this.G.FillEllipse(this.DrawRadialBrush1, r);
        }

        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawRadialRectangle);
        }

        protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            this.DrawRadialRectangle = new Rectangle(x, y, width, height);
            this.DrawRadial(c1, c2, this.DrawRadialRectangle, angle);
        }

        protected void DrawRadial(Color c1, Color c2, Rectangle r) { this.DrawRadial(c1, c2, r, 90); }

        protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
        {
            this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
            this.G.FillEllipse(this.DrawRadialBrush2, r);
        }

        #endregion

        #region " CreateRound "

        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;

        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            this.CreateRoundRectangle = new Rectangle(x, y, width, height);
            return this.CreateRound(this.CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            this.CreateRoundPath = new GraphicsPath(FillMode.Winding);
            this.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            this.CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            this.CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            this.CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            this.CreateRoundPath.CloseFigure();
            return this.CreateRoundPath;
        }

        #endregion
    }

    internal static class ThemeShare
    {
        #region " Animation "

        #region Delegates

        public delegate void AnimationDelegate(bool invalidate);

        #endregion

        private const int FPS = 50;

        private const int Rate = 10;

        private static int Frames;

        private static bool Invalidate;

        public static PrecisionTimer ThemeTimer = new PrecisionTimer();

        //1000 / 50 = 20 FPS

        private static List<AnimationDelegate> Callbacks = new List<AnimationDelegate>();

        private static void HandleCallbacks(IntPtr state, bool reserve)
        {
            Invalidate = (Frames >= FPS);
            if (Invalidate) Frames = 0;

            lock (Callbacks)
            {
                for (var I = 0; I <= Callbacks.Count - 1; I++)
                {
                    Callbacks[I].Invoke(Invalidate);
                }
            }

            Frames += Rate;
        }

        private static void InvalidateThemeTimer()
        {
            if (Callbacks.Count == 0) ThemeTimer.Delete();
            else ThemeTimer.Create(0, Rate, HandleCallbacks);
        }

        public static void AddAnimationCallback(AnimationDelegate callback)
        {
            lock (Callbacks)
            {
                if (Callbacks.Contains(callback)) return;

                Callbacks.Add(callback);
                InvalidateThemeTimer();
            }
        }

        public static void RemoveAnimationCallback(AnimationDelegate callback)
        {
            lock (Callbacks)
            {
                if (!Callbacks.Contains(callback)) return;

                Callbacks.Remove(callback);
                InvalidateThemeTimer();
            }
        }

        #endregion
    }

    internal enum MouseStateControl : byte
    {
        None = 0,

        Over = 1,

        Down = 2,

        Block = 3
    }

    internal struct Bloom
    {
        public string _Name;

        private Color _Value;

        public Bloom(string name, Color value)
        {
            this._Name = name;
            this._Value = value;
        }

        public string Name
        {
            get { return this._Name; }
        }

        public Color Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }

        public string ValueHex
        {
            get { return string.Concat("#", this._Value.R.ToString("X2", null), this._Value.G.ToString("X2", null), this._Value.B.ToString("X2", null)); }
            set
            {
                try
                {
                    this._Value = ColorTranslator.FromHtml(value);
                }
                catch {}
            }
        }
    }

    //------------------
    //Creator: aeonhack
    //Site: elitevs.net
    //Created: 11/30/2011
    //Changed: 11/30/2011
    //Version: 1.0.0
    //------------------
    internal class PrecisionTimer : IDisposable
    {
        #region Delegates

        public delegate void TimerDelegate(IntPtr r1, bool r2);

        #endregion

        private bool _enabled;

        private IntPtr _handle;

        private TimerDelegate _timerCallback;

        public bool Enabled
        {
            get { return this._enabled; }
        }

        #region IDisposable Members

        public void Dispose() { this.Delete(); }

        #endregion

        [DllImport("kernel32.dll", EntryPoint = "CreateTimerQueueTimer")]
        private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);

        [DllImport("kernel32.dll", EntryPoint = "DeleteTimerQueueTimer")]
        private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

        public void Create(uint dueTime, uint period, TimerDelegate callback)
        {
            if (this._enabled) return;

            this._timerCallback = callback;
            var success = CreateTimerQueueTimer(ref this._handle, IntPtr.Zero, this._timerCallback, IntPtr.Zero, dueTime, period, 0);

            if (!success) this.ThrowNewException("CreateTimerQueueTimer");
            this._enabled = success;
        }

        public void Delete()
        {
            if (!this._enabled) return;
            var success = DeleteTimerQueueTimer(IntPtr.Zero, this._handle, IntPtr.Zero);

            if (!success && Marshal.GetLastWin32Error() != 997) this.ThrowNewException("DeleteTimerQueueTimer");

            this._enabled = !success;
        }

        private void ThrowNewException(string name) { throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error())); }
    }
}