using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows;

namespace BMS.Common
{
    public class Tool
    {
        #region 背景颜色动画

        public static void PlayBackgAnimation(Control b)
        {
            SolidColorBrush myBrush = new SolidColorBrush();

            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Colors.White;
            myColorAnimation.To = Colors.Pink;
            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3)); //播放时间间隔
            myColorAnimation.AutoReverse = true;
            myColorAnimation.RepeatBehavior = new RepeatBehavior(2); //播放次数

            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation, HandoffBehavior.Compose);
            b.Background = myBrush;
        }

        public static void PlayForegAnimation(TextBlock b)
        {
            SolidColorBrush myBrush = new SolidColorBrush();

            System.Windows.Media.Animation.
             ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Colors.White;
            myColorAnimation.To = Colors.Red;
            myColorAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.3)); //播放时间间隔
            myColorAnimation.AutoReverse = true;
            myColorAnimation.RepeatBehavior = new RepeatBehavior(2); //播放次数

            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation, HandoffBehavior.Compose);

            b.Foreground = myBrush;
        }
       


        #endregion
    }
}
