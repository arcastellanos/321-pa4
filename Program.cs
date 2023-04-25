using pa4;
using pa4.Interfaces;
using pa4.Models;

System.Console.WriteLine("Welcome to the Battle of Calypso's Maelstrom!");
System.Console.WriteLine("Lets get started!");

Character player1 = new Character();
player1 = InitializePlayer(); 
Character player2 = new Character();
player2 = InitializePlayer(); 



System.Threading.Thread.Sleep(2000);
Battle(player1,player2);






// static int Menu(){
//     System.Console.WriteLine("Choose your character: 1 - Jack Sparrow, 2 - Davy Jones, 3 - Will Turner");
//     int characterChoice = int.Parse(Console.ReadLine()); 
//     if(characterChoice == 1){
//         System.Console.WriteLine("You chose Jack Sparrow");
//         characterChoice = 1;

//     }
//     else if(characterChoice == 2){
//         System.Console.WriteLine("You chose Davy Jones");
//         characterChoice = 2;
//     }
//     else if(characterChoice == 3){
//         System.Console.WriteLine("You chose Will Turner");
//         characterChoice = 3;
//     }
//     else{
//         System.Console.WriteLine("Invalid choice. Please try again.");
//         Menu();
//     }
//     return characterChoice;
// }

static Character InitializePlayer(){
    Character newChar = new Character();

    System.Console.WriteLine("Enter the player's name.");
    string playerName = Console.ReadLine();
   
    Random randomNum = new Random();
    int maxPower = Character.GetMaxPower();
    
    beginning:
    System.Console.WriteLine("Choose your character: 1 - Jack Sparrow, 2 - Davy Jones, 3 - Will Turner");
    int characterChoice = int.Parse(Console.ReadLine()); 

    if(characterChoice == 1){
        System.Console.WriteLine("You chose Jack Sparrow");
        newChar = new JackSparrow(){ Name = playerName, MaxPower = maxPower, Health = 100, AttackStrength = Character.GetAttackStrength(maxPower), DefensivePower = Character.GetDefensivePower(maxPower)};
    }
    else if(characterChoice == 2){
        System.Console.WriteLine("You chose Davy Jones");
        newChar = new DavyJones(){Name = playerName, MaxPower = maxPower, Health = 100, AttackStrength = Character.GetAttackStrength(maxPower), DefensivePower = Character.GetDefensivePower(maxPower)};
    }
    else if(characterChoice == 3){
        System.Console.WriteLine("You chose Will Turner");
        newChar = new WillTurner(){Name = playerName, MaxPower = maxPower, Health = 100, AttackStrength = Character.GetAttackStrength(maxPower), DefensivePower = Character.GetDefensivePower(maxPower)};
    }
    else{
        System.Console.WriteLine("Invalid choice. Please try again.");
        goto beginning;
    }

    return newChar;
}


static void Battle(Character player1, Character player2)
{
    double player1bonus = 1;
    double player2bonus = 1;
    if(((player1.Name == "Jack Sparrow") && (player2.Name == "Will Turner")) || ((player1.Name == "Will Turner") && (player2.Name == "Davy Jones")) || ((player1.Name == "Davy Jones") && (player2.Name == "Jack Sparrow"))){
            System.Console.WriteLine($"{player1.Name} has a 20% boost");
            player1bonus = 1.2;
    }
    if(((player2.Name == "Jack Sparrow") && (player1.Name == "Will Turner")) || ((player2.Name == "Will Turner") && (player1.Name == "Davy Jones")) || ((player2.Name == "Davy Jones") && (player1.Name == "Jack Sparrow"))){
            System.Console.WriteLine($"{player2.Name}got a 20% boost");
            player2bonus = 1.2;
    }

    System.Console.WriteLine($"Let's flip a coin to see who attacks first. 1 - player 1 goes first and 2 - player 2 goes first");
    Random randomNum = new Random();
    int coinFlip = randomNum.Next(1,3);

    if(coinFlip == 1){
        System.Console.WriteLine($"{coinFlip} Nice! {player1.Name} attacks first");
        System.Console.WriteLine();
        ActualBattle(player1, player2, player1bonus, player2bonus);
    }
    else{
        System.Console.WriteLine($"{coinFlip} Cool! {player2.Name} attacks first");
        System.Console.WriteLine();
        ActualBattle(player2, player1, player1bonus, player2bonus);
    }
    
}


static void ActualBattle(Character player1, Character player2, double player1bonus, double player2bonus){
    bool complete = false;
    while(complete != true){
        player1.AttackStrength = Character.GetAttackStrength(player1.MaxPower);
        player2.AttackStrength = Character.GetAttackStrength(player2.MaxPower);
        player1.DefensivePower = Character.GetDefensivePower(player1.MaxPower);
        player2.DefensivePower = Character.GetDefensivePower(player2.MaxPower);
        double player1attack = player1.AttackStrength - player2.DefensivePower;
        double player2attack = player2.AttackStrength - player1.DefensivePower;
        if(player1attack > 0){
            System.Console.Write($"{player1.Name} attacked with ");
            player1.attackBehavior.Attack();
            System.Console.WriteLine($" for {Math.Round((player1attack), 2)} points");
            player2.Health -= player1attack;
            System.Threading.Thread.Sleep(2859);
        }else{
            System.Console.WriteLine($"{player1.Name}'s attack failed");
        }

        if(player2attack > 0){
            System.Console.Write($"{player2.Name} attacked with ");
            player2.attackBehavior.Attack();
            System.Console.WriteLine($" for {Math.Round((player2attack), 2)} points");
            player1.Health -= player2attack;
            System.Console.WriteLine();
            System.Threading.Thread.Sleep(2859);
        }else{
            System.Console.WriteLine($"{player2.Name}'s attack failed");
            System.Console.WriteLine();
        }
        System.Threading.Thread.Sleep(2000);

        if(player1.Health < 0){
            System.Console.WriteLine($"{player2.Name} has won");
            System.Environment.Exit(0);
        }
        else if(player2.Health < 0){
            System.Console.WriteLine($"{player1.Name} has won");
            System.Environment.Exit(0);
        }

        stats(player1, player2);
    }

}
static void stats(Character player1, Character player2){
    System.Console.WriteLine("Here are the current stats:");
    System.Threading.Thread.Sleep(2000);
    System.Console.WriteLine($"{player1.Name} Health : {Math.Round(player1.Health, 2)}");
    System.Console.WriteLine($"{player2.Name} Health : {Math.Round(player2.Health, 2)}");
    System.Console.WriteLine();
}

  


