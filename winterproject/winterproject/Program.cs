using Raylib_cs;
/*------------[logic]------------*/
Raylib.InitWindow(1024,768, "WinterProject");
Raylib.SetTargetFPS(60);
bool LongSword = false;
String CScene = "Start"; 
String Sword = "Not Owned";
int Potion5hp = 0;
int Potion10hp = 0;
int Level = 1;
int LevelCheck = 0;
int Part = 1;
int Partcheck = 0;
int Gold = 0;
float HP = 20;
float Speedmultiplier = 0.4f;
float meleecd = 0.2f;
/* ------------[Colours]------------*/
Color GREEN2 = new Color(35, 165, 70,255);
Color lvlPink = new Color(164, 35, 130,255);
Color Path = new Color(175,175,175,255);
Color Testhouse = new Color(160, 70, 0, 255);
Color TestRed = new Color(220,50,50,255);
/* ------------[Hitboxes and bases]------------*/
Rectangle blacksmith = new Rectangle(2000,2000,80,80);
Rectangle bozo = new Rectangle(100,100,50,70);
Rectangle atk1 = new Rectangle(bozo.x-30,bozo.y-30,110,130);
Rectangle atk2 = new Rectangle(bozo.x-50,bozo.y-50,150,180);
Rectangle enemyt1_0 = new Rectangle(1100,400,50,50);
Rectangle enemyt1_1 = new Rectangle(600,-100,50,50);
Rectangle enemyt1_2 = new Rectangle(275,800,50,50);
Rectangle partend = new Rectangle(2000,2000,50,50);
Rectangle levelend = new Rectangle(2000,2000,50,50);
Rectangle minuspart = new Rectangle(2000,2000,50,50);
Rectangle background0 = new Rectangle(0,0,1024,768);
/* ------------[Textures]------------*/
Texture2D stickfigure = Raylib.LoadTexture("stickfigure.png");
Texture2D ynowork = Raylib.LoadTexture("ynowork.png");
Texture2D background1 = Raylib.LoadTexture("rgfrgsg.png");
Texture2D testsmith = Raylib.LoadTexture("Testsmith.png");
/*------------[Void's, Vector's & Misc]------------*/
bozo.x = Math.Max(0, Math.Min(974, bozo.x));
bozo.y = Math.Max(0, Math.Min(708, bozo.y));


if(LongSword == true){
  
}

void MeleeCD(){
if(meleecd > 0f){
 meleecd -= 0.01f;
}
}
void Enemyt1_0Reset(){
  if(Partcheck == 1 || CScene == "End" || CScene == "Won" || Raylib.IsKeyPressed(KeyboardKey.KEY_H)){
  enemyt1_0.x = 1100;
  enemyt1_0.y = 600;
  enemyt1_1.x = 500;
  enemyt1_1.y = -200;
  enemyt1_2.x = 175;
  enemyt1_2.y = 900;
  }
}
void EnemyMovement(){
if(enemyt1_0.x > bozo.x){
enemyt1_0.x -= 2*Speedmultiplier;
}
else{
  enemyt1_0.x += 2*Speedmultiplier;
}
if(enemyt1_0.y > bozo.y){
  enemyt1_0.y -= 2*Speedmultiplier;
}
else{
  enemyt1_0.y += 2*Speedmultiplier;
}

if(enemyt1_1.x > bozo.x){
enemyt1_1.x -= 2*Speedmultiplier;
}
else{
  enemyt1_1.x += 2*Speedmultiplier;
}
if(enemyt1_1.y > bozo.y){
  enemyt1_1.y -= 2*Speedmultiplier;
}
else{
  enemyt1_1.y += 2*Speedmultiplier;
}

if(enemyt1_2.x > bozo.x){
enemyt1_2.x -= 2*Speedmultiplier;
}
else{
  enemyt1_2.x += 2*Speedmultiplier;
}
if(enemyt1_2.y > bozo.y){
  enemyt1_2.y -= 2*Speedmultiplier;
}
else{
  enemyt1_2.y += 2*Speedmultiplier;
}
}
void Potions(){
  if(CScene == "Game" && Potion10hp > 0 && Raylib.IsKeyReleased(KeyboardKey.KEY_TWO) == true){
  HP += 10;
  Potion10hp -= 1;
  } 
  if(CScene == "Game" && Potion5hp > 0 && Raylib.IsKeyReleased(KeyboardKey.KEY_ONE) == true){
  HP += 5;
  Potion5hp -= 1;
  } 
}
void HUD(){
     Raylib.DrawText($"HP: {(int)HP}",5,5,18,Color.BLACK); /*HP*/
     Raylib.DrawText($"Gold: {Gold}",5,25,18,Color.BLACK); /*gold. sidenote, i hate centering text lines*/
     Raylib.DrawText($"5hp potions: {Potion5hp} [1]",5,45,18,Color.BLACK); /*5hp potions*/
     Raylib.DrawText($"10hp potions: {Potion10hp} [2]",5,65,18,Color.BLACK); /*10hp potions*/
    /* Raylib.DrawText($"Longsword: {Sword}",0,0,18,Color.BLACK); Dunno if i'll leave this in the game, makes the HUD too tall imo and im too stupid to find a solution*/
}
void Reset(){
    Partcheck = 0;
    Part = 1;
    Level = 1;
    LevelCheck = 0;
    bozo.x = 100;
    bozo.y = 100;
    HP = 20;
    Potion10hp = 0;
    Potion5hp = 0;
    LongSword = false;
    Enemyt1_0Reset();
}
void Partplusone(){
    if(Raylib.CheckCollisionRecs(bozo, partend) == true){
    Partcheck = 1;
   }
}
void Partsminusone(){
    if(Raylib.CheckCollisionRecs(bozo, minuspart) == true){
    Partcheck = -1;
   }
}
void Smithmenu(){
    if(Raylib.CheckCollisionRecs(bozo, blacksmith) == true && Raylib.IsKeyPressed(KeyboardKey.KEY_F)){
    CScene = "Smithmenu";

    }
}
void EnemyCollision(){
  if(Raylib.CheckCollisionRecs(bozo,enemyt1_0) == true || Raylib.CheckCollisionRecs(bozo,enemyt1_1) == true || Raylib.CheckCollisionRecs(bozo,enemyt1_2) == true){
  HP -= 0.05f;
  }
  if(Raylib.CheckCollisionRecs(atk1,enemyt1_0) == true && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && meleecd <= 0f){
    Gold += 3;
    Speedmultiplier += 0.03f;
    enemyt1_0.x = 1100;
    enemyt1_0.y = 600;
    meleecd = 0.2f;
  }
  if(Raylib.CheckCollisionRecs(atk1,enemyt1_1) == true && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && meleecd <= 0f){
    Gold += 3;
    Speedmultiplier += 0.03f;
    enemyt1_1.x = 500;
    enemyt1_1.y = -200;
    meleecd = 0.2f;
  }
  if(Raylib.CheckCollisionRecs(atk2,enemyt1_2) == true && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && meleecd <= 0f){
    Gold += 3;
    Speedmultiplier += 0.03f;
    enemyt1_2.x = 175;
    enemyt1_2.y = 900;
    meleecd = 0.2f;
  }
  if(Raylib.CheckCollisionRecs(atk2,enemyt1_0) == true && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && meleecd <= 0f && LongSword == true){
    Gold += 3;
    Speedmultiplier += 0.03f;
    enemyt1_0.x = 1100;
    enemyt1_0.y = 600;
    meleecd = 0.2f;
  }
  if(Raylib.CheckCollisionRecs(atk2,enemyt1_1) == true && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && meleecd <= 0f && LongSword == true){
    Gold += 3;
    Speedmultiplier += 0.03f;
    enemyt1_1.x = 500;
    enemyt1_1.y = -200;
    meleecd = 0.2f;
  }
  if(Raylib.CheckCollisionRecs(atk2,enemyt1_2) == true && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && meleecd <= 0f && LongSword == true){
    Gold += 3;
    Speedmultiplier += 0.03f;
    enemyt1_2.x = 175;
    enemyt1_2.y = 900;
    meleecd = 0.2f;
  }

  
}
    void Enemytype1(){
       Raylib.DrawRectangle((int)enemyt1_0.x,(int)enemyt1_0.y,(int)enemyt1_0.width,(int)enemyt1_0.height,TestRed);
       Raylib.DrawRectangle((int)enemyt1_1.x,(int)enemyt1_1.y,(int)enemyt1_1.width,(int)enemyt1_1.height,TestRed);
       Raylib.DrawRectangle((int)enemyt1_2.x,(int)enemyt1_2.y,(int)enemyt1_2.width,(int)enemyt1_2.height,TestRed);
    }
    

while(Raylib.WindowShouldClose() == false)
{
 Raylib.BeginDrawing();

if(CScene == "Game")
{
atk1.x = bozo.x-30;
atk1.y = bozo.y-30;
  /*  Raylib.DrawText($"{CScene}", 0,0, 30,Color.BLACK); <-- thing used for testing too, i don't remove 'em cuz i feel like i'll someday have use for it but i prolly won't. */
if(Raylib.IsKeyDown(KeyboardKey.KEY_BACKSPACE)) 
{
    CScene = "Pause";
}     
if(Raylib.IsKeyDown(KeyboardKey.KEY_D) || Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
{
    bozo.x += 2f;
}
if(Raylib.IsKeyDown(KeyboardKey.KEY_A) || Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
{
    bozo.x -= 2f;
}
if(Raylib.IsKeyDown(KeyboardKey.KEY_S) || Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
{
    bozo.y += 2f;
}
if(Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_UP ))
{
    bozo.y -= 2f;
}
if(bozo.y < 0)
{
    bozo.y = 0;
}
if(bozo.x < 0)
{
    bozo.x = 0;
}
if(bozo.y > 700)
{
    bozo.y = 700;
}
if(bozo.x > 974)
{
    bozo.x = 974;
}
    /*------------[HUD and character (mostly)]------------*/
     Raylib.DrawText("Press BACKSPACE to pause", 720, 15, 20, Color.BLACK);
    /* Raylib.DrawRectangle((int)bozo.x-15,(int)bozo.y-15, 100, 100, Color.LIGHTGRAY); */
     Raylib.DrawTexture(stickfigure, (int) bozo.x , (int) bozo.y ,Color.WHITE);
    /* Raylib.DrawTexture(background1, (int)background0.x, (int)background0.y,Color.WHITE); */
       /*Level 1 specific stuff */
      
  if(Level == 1 && CScene == "Game"){
    Potions();
    if(HP > 20){
      HP = 20;
    }
    HUD();
    EnemyMovement();
    Raylib.ClearBackground(GREEN2);
   if(Raylib.IsKeyPressed(KeyboardKey.KEY_M)){Gold += 10;} /*test thing that i will leave in for presentation to simplify showing the game*/
  
    /* Raylib.DrawTexture(background1,500,500,Color.GREEN); bozo ass code doesnt wanna work :angy: */
    if(Part == 1){
   partend.y = 718;
   partend.x = 800;
   minuspart.x = 2000; 
   minuspart.y = 2000;  
   Raylib.DrawRectangle((int)partend.x,(int)partend.y,(int)partend.width,(int)partend.height, lvlPink);
   Raylib.DrawText("Fields",450,720,25,Color.BLACK);
   MeleeCD();
   Enemytype1();
   Partplusone();
   Partsminusone();
   EnemyMovement();
   EnemyCollision();
   Enemyt1_0Reset();
    }
     if(Part == 2){
       partend.y = 300;
       partend.x = 0;
       minuspart.x = 974;
       minuspart.y = 718;
       blacksmith.x = 300;
       blacksmith.y = 300;
       Raylib.DrawRectangle((int)partend.x,(int)partend.y,(int)partend.width,(int)partend.height,lvlPink);
       Raylib.DrawRectangle((int)minuspart.x,(int)minuspart.y,(int)minuspart.width,(int)minuspart.height,Color.DARKBLUE);
       Raylib.DrawText("Market",450,720,25,Color.BLACK);
       Raylib.DrawTexture(testsmith,(int)blacksmith.x,(int)blacksmith.y,Color.WHITE);
       Partplusone();
       Partsminusone();
       Smithmenu();
     }
      if(Part == 3){       
        partend.y = 600;
        partend.x = 75;
        minuspart.x = 600;
        minuspart.y = 400;
        Raylib.DrawRectangle((int)partend.x,(int)partend.y,(int)partend.width,(int)partend.height,lvlPink);
        Raylib.DrawRectangle((int)minuspart.x,(int)minuspart.y,(int)minuspart.width,(int)minuspart.height,Color.DARKBLUE);
        Partplusone();
        Partsminusone();
      }
  }
 
    
}

/*------------[Menu logic & trading logic]------------*/

/*potion10hp*/
if(CScene == "Smithmenu"){
  if(Raylib.IsKeyPressed(KeyboardKey.KEY_FOUR) && Gold >= 50){
    Gold -= 50;
    Potion10hp += 1;
  }
  /*LongSword*/
  if(CScene == "Smithmenu"){
  if(Raylib.IsKeyPressed(KeyboardKey.KEY_ONE) && Gold >= 100 && LongSword == false){
    Gold -= 100;
    LongSword = true;
   }
  }
  /*potion5hp*/
  if(CScene == "Smithmenu"){
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_THREE) && Gold >= 30){
      Gold -= 30;
      Potion5hp += 1;
    }
  }

}
if(HP <= 0){
  CScene = "End";
}
if(CScene == "Start" && Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)){
    CScene = "Game";
}
if(CScene == "Pause" && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)){
    CScene = "Game";
}
if(CScene == "Pause" && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)){
    Reset();
    CScene = "Start";
}
if(CScene == "Pause" && Raylib.IsKeyPressed(KeyboardKey.KEY_I)){
    CScene = "Help";
}
if(CScene == "Help" && Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE)){
    CScene = "Pause";
}
if(CScene == "End" && Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)){
    Reset();
    CScene = "Start";
}
if(CScene == "Won" && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)){
    Reset();
    CScene = "Start";
}
 if(CScene == "Smithmenu" && Raylib.IsKeyDown(KeyboardKey.KEY_ENTER) == true){
     CScene = "Game";
  }
/* micro graphics */
 if(CScene == "Start"){
  Raylib.DrawText("[Insert very creative name]",25,25,45,Color.BLACK);
   Raylib.DrawText("Press ENTER to start", 300, 300, 32, Color.BLACK);
   Raylib.DrawText("Kill the red enemies coming at you",300,355,24, Color.BLACK);
   Raylib.DrawText("The more you kill the faster they get!",275,380,24, Color.BLACK);
   Raylib.DrawText("Moving over the purple square takes you to another area",165,405,24, Color.BLACK);
   Raylib.ClearBackground(Color.BLUE); 
   
  }
  if(CScene == "Pause"){
   Raylib.DrawText("Press ENTER to resume game", 250, 300, 32, Color.BLACK); 
   Raylib.DrawText("Press SPACE to return to start page", 175, 350, 32, Color.BLACK); 
   Raylib.ClearBackground(Color.BLUE); 
  }
  if(CScene == "End"){
    Raylib.DrawText("Press SPACE to go back to start menu", 165, 350, 32, Color.BLACK);
    Raylib.DrawText("Game Over!", 410, 300, 32, Color.BLACK);
    Raylib.ClearBackground(Color.BLUE); 
  }
  if(CScene == "Won"){
    Raylib.DrawText("Not coded yet",0,0,5,Color.BLACK);
    Raylib.DrawText("Not coded yet",0,0,5,Color.BLACK);
    Raylib.ClearBackground(Color.BLUE); 
  }
  if(CScene == "Help"){
    Raylib.DrawText("Not coded yet",0,0,20,Color.BLACK);
    Raylib.DrawText("Not coded yet",0,40,20,Color.BLACK);
    Raylib.ClearBackground(Color.BLUE); 
  }
  /*------------[Shop Graphics]------------ */
   if(CScene == "Smithmenu"){
     Raylib.DrawRectangle(0,0,100,100,GREEN2);
     HUD();
     Raylib.DrawRectangle(200,200,624,368,Color.DARKGRAY);
     Raylib.DrawRectangle(210,210,604,348,Color.LIGHTGRAY);
     Raylib.DrawText("Blacksmith",400,220,30,Color.BLACK);
     Raylib.DrawText("ENTER to exit",600, 235,15,Color.BLACK);

     Raylib.DrawText("Revolver: 250GOLD",250,325,20,Color.RED);
     Raylib.DrawText("Press '2' to buy",250,350,10,Color.RED);
     Raylib.DrawText("potion 5hp: 30GOLD",560,275,20,Color.RED);
     Raylib.DrawText("Press '3' to buy",560,300,10,Color.RED);
     Raylib.DrawText("Large Sword: 100GOLD",250,275,20,Color.RED);
     Raylib.DrawText("Press '1' to buy",250,300,10,Color.RED);
     Raylib.DrawText("potion 10hp: 50GOLD",560,325,20,Color.RED);
     Raylib.DrawText("Press '4' to buy",560,350,10,Color.RED);

     /* Retexturing when you get enough gold */

     if(Gold >= 150){
      Raylib.DrawText("Revolver: 250GOLD",250,325,20,Color.BLACK);
      Raylib.DrawText("Press '2' to buy",250,350,10,Color.BLACK);
     }
      if(Gold >= 30){
       Raylib.DrawText("potion 5hp: 30GOLD",560,275,20,Color.BLACK);
       Raylib.DrawText("Press '3' to buy",560,300,10,Color.BLACK);
      }
       if(Gold >= 50){
        Raylib.DrawText("Large Sword: 100GOLD",250,275,20,Color.BLACK);
        Raylib.DrawText("Press '1' to buy",250,300,10,Color.BLACK);
        Raylib.DrawText("potion 10hp: 50GOLD",560,325,20,Color.BLACK);
        Raylib.DrawText("Press '4' to buy",560,350,10,Color.BLACK);
       }
     /*1024,768 just saving screen resolution here so i can use it for coordinates*/
   }
  /*Level scripts*/
  if (Partcheck == 1){
    Part += 1;
    Partcheck = 0;
   /* CScene = "End"; this was/is basically just to test if it worked as intended */
  }
  if(Partcheck == -1){
    Part -= 1;
    Partcheck = 0;
  }
  
  if(LevelCheck == 1){
    Level += 1;
    Part = 1;
    LevelCheck = 0;
  }
  else if(LevelCheck == 1 && Level == 3){
  Level = 1;
  Part = 1;
  LevelCheck = 0;
  CScene = "Won";
  }
 Raylib.EndDrawing();
}