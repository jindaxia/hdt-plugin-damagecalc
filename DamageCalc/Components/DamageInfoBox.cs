﻿using Hearthstone_Deck_Tracker;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DamageCalc.Components
{
    class DamageInfoBox
    {
        private HearthstoneTextBlock _info;
        private Canvas _canvas = Hearthstone_Deck_Tracker.API.Core.OverlayCanvas;

        private int _health;
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (_health != value)
                {
                    _health = value;
                    updateInfo();
                }
            }
        }

        private int _dmg;
        public int Damage
        {
            get
            {
                return _dmg;
            }
            set
            {
                if (_dmg != value)
                {
                    _dmg = value;
                    updateInfo();
                }
            }
        }

        public string Name { get; set; }

        public DamageInfoBox(string name = "Untitled", int position=0)
        {
            _info = new HearthstoneTextBlock();
            _info.Text = "";
            _info.FontSize = 18;
            _info.Opacity = 0;


            _canvas.Children.Add(_info);
            
            Name = name;
            Damage = 0;
            Health = 0;

            fromTop(position);
        }

        public async void fromTop(int position)
        {
            await Task.Delay(1000);

            double fromLeft = _canvas.Width * .3;
            double fromTop = _canvas.Height * .75 + (position * _info.FontSize);
            Canvas.SetLeft(_info, fromLeft);
            Canvas.SetTop(_info, fromTop);
        }

        void updateInfo()
        {
            if (Health - Damage <= 0)
            {
                _info.Text = "* ";
                _info.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xff, 0x00, 0x10));
            }
            else
            {
                _info.Text = "";
                _info.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(0xff, 0xff, 0xff, 0xff));
            }

            _info.Text += string.Format("{0}: {1} ({2})\n", Name, Damage, Health - Damage);

        }

        public void hideInfo()
        {
            _info.Opacity = 0;
        }

        public void showInfo()
        {
            _info.Opacity = 1;
        }
    }
}
