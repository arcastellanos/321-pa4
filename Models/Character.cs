using pa4.Interfaces;
namespace pa4
{
    public class Character
    {
        public string Name {get;set;}
        public int MaxPower {get;set;}
        public double Health {get;set;}
        public int AttackStrength {get;set;}
        public int DefensivePower {get;set;}
        public IAttack attackBehavior {get;set;}

    public Character(){

    }

    public void SetAttackBehavior(IAttack attackBehavior){
        this.attackBehavior = attackBehavior;
    }
    public static int GetMaxPower(){
    Random randomNum = new Random();
    int maxPower = randomNum.Next(1,101);
    return maxPower;
    }

    public static int GetAttackStrength(int MaxPower){
    Random randomNum = new Random();
    int attackStrength = randomNum.Next(1, MaxPower);
    return attackStrength;
    }

    public static int GetDefensivePower(int MaxPower){
    Random randomNum = new Random();
    int defensivePower = randomNum.Next(1, MaxPower);
    return defensivePower;
    }

    }

}