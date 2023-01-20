using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToe {
    public class Game {

        public int TimeRemaining = 0;
        public Button? LastPressedButton;

        public Task GameLoop() {
            while (TimeRemaining>0) {
                if (LastPressedButton != null) {
                     //MainWindow.OccupyField(LastPressedButton, player);
                }
            }
            //NextTurn
            
            return Task.CompletedTask;
        }
        
    }
}