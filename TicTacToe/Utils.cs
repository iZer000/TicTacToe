using System.Windows.Media;

namespace TicTacToe
{
    public class Utils {
        private static BrushConverter _converter = new BrushConverter();
        public static Brush ColorBlue = (Brush)_converter.ConvertFromString("#FFFFFF");
        public static Brush ColorOrange = (Brush)_converter.ConvertFromString("#FFFFFF");
        
        
    }
}