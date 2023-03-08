float playerHP = 1000;
float playerAtk = 20;

List<string> enemies = new List<string>(){
   "goblin","slime","wolf"
};

List<float> enemiesHP = new List<float>(){
   100,
   30,
   50
};

List<float> enemiesAtk = new List<float>(){
   50,
   10,
   40
};

int turn = 1;
Random rand = new Random();

Console.Clear();
while (enemies.Count > 0 && playerHP > 0 && turn <= 100){
   // Tampilin semua status
   Console.WriteLine("Turn " + turn);
   Console.WriteLine("PLayerHP: " + playerHP);
   for (int i = 0; i < enemies.Count; i++){
      Console.WriteLine((i) + ". " + enemies[i] + " HP: " + enemiesHP[i]);
   };
   Console.WriteLine();

   // player turn
   Console.WriteLine("Please choose target enemy");
   string input = Console.ReadLine() ?? "";
   int target = 0;
   if(int.TryParse(input, out target) == false){
      Console.WriteLine("selection not valid!");
      continue;
   }
   Console.WriteLine("Player attack " + target + ". " + enemies[target] + "\n");

   float oldTargetHP = enemiesHP[target];
   float newTargetHP = enemiesHP[target] - playerAtk;
   if (newTargetHP <= 0){newTargetHP=0;}
   Console.WriteLine(target + ". " + enemies[target] + " HP: " + oldTargetHP + " => " + newTargetHP);
   enemiesHP[target] = newTargetHP;
   if(enemiesHP[target] <= 0){
      Console.WriteLine(target + ". " + enemies[target] + " Die");
      enemies.RemoveAt(target);
      enemiesHP.RemoveAt(target);
      enemiesAtk.RemoveAt(target);
   }

   // enemy turn
   if (enemies.Count > 0){
      int activateEnemy = rand.Next(enemies.Count);
      Console.WriteLine(activateEnemy + ". " + enemies[activateEnemy] + " attack player");
      float oldPlayerHp = playerHP;
      float newPlayerHp = playerHP - enemiesAtk[activateEnemy];
      if (newPlayerHp < 0){newPlayerHp=0;}
      Console.WriteLine("Player HP: "+oldPlayerHp+" => "+newPlayerHp);
      playerHP = newPlayerHp;
   }
   
   turn++;
}

Console.WriteLine("Battle ended");
if (enemies.Count == 0){
   Console.WriteLine("You Win!");
} else if (playerHP <= 0){
   Console.WriteLine("You Lose!");
} else{
   Console.WriteLine("100 turns. Times up!");
}