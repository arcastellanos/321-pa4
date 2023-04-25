namespace pa4.Models
{
    public class JackSparrow : Character
    {
        public JackSparrow(){
            attackBehavior = new DistractOpponent();
        }
    }
}