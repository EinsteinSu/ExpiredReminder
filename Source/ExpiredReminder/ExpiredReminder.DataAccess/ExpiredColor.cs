using System.Windows.Media;

namespace ExpiredReminder.DataAccess
{
    public enum ExpiredColor
    {
        红色, 黄色, 蓝色, 橙色, 紫色, 绿色, 粉红色, 白色, 无色
    }

    public static class ExpiredColorExtensions
    {
        public static Color ConvertToColor(this ExpiredColor color)
        {
            switch (color)
            {
                case ExpiredColor.无色:
                    return Colors.Transparent;
                case ExpiredColor.红色:
                    return Colors.Red;
                case ExpiredColor.橙色:
                    return Colors.Orange;
                case ExpiredColor.白色:
                    return Colors.White;
                case ExpiredColor.蓝色:
                    return Colors.Blue;
                case ExpiredColor.粉红色:
                    return Colors.Pink;
                case ExpiredColor.紫色:
                    return Colors.MediumPurple;
                case ExpiredColor.绿色:
                    return Colors.GreenYellow;
                case ExpiredColor.黄色:
                    return Colors.LightGoldenrodYellow;
                default:
                    return Colors.Black;
            }
        }
    }
}