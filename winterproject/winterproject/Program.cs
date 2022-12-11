using Raylib_cs;
/* logic */
Raylib.InitWindow(1024,768, "WinterProject");
Raylib.SetTargetFPS(60);
String CScene = "Start"; 
int Level = 1;
int LevelCheck = 0;
int Part = 1;
int Partcheck = 0;
/* ------------[Colours]------------*/
Color GREEN2 = new Color(35, 165, 70,255);
Color lvlPink = new Color(164, 35, 130,255);
Color Path = new Color(175,175,175,255);
Color Testhouse = new Color(160, 70, 0, 255);
/* ------------[Hitboxes and bases]------------*/
Rectangle blacksmith = new Rectangle(2000,2000,80,80);
Rectangle healer = new Rectangle(2000,2000,75,75);
Rectangle bozo = new Rectangle(0,0,50,70);
Rectangle atk1 = new Rectangle(bozo.x,bozo.y,100,100);
Rectangle enemyt1 = new Rectangle(400,400,50,50);
Rectangle partend = new Rectangle(2000,2000,50,50);
Rectangle levelend = new Rectangle(2000,2000,50,50);
Rectangle minuspart = new Rectangle(2000,2000,50,50);
/* ------------[Textures]------------*/
Texture2D stickfigure = Raylib.LoadTexture("stickfigure.png");
Texture2D ynowork = Raylib.LoadTexture("ynowork.png");
Texture2D background1 = Raylib.LoadTexture("rgfrgsg.png");
Texture2D testsmith = Raylib.LoadTexture("Testsmith.png");

bozo.x = Math.Max(0, Math.Min(974, bozo.x));
bozo.y = Math.Max(0, Math.Min(708, bozo.y));

void Reset(){
    Partcheck = 0;
    Part = 1;
    Level = 1;
    LevelCheck = 0;
    bozo.x = 0;
    bozo.y = 0;
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
    if(Raylib.CheckCollisionRecs(bozo, blacksmith) == true && Raylib.IsKeyDown(KeyboardKey.KEY_F)){
    CScene = "Smithmenu";
    }
}
while(Raylib.WindowShouldClose() == false)
{
 Raylib.BeginDrawing();

if(CScene == "Game")
{
       
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
     Raylib.DrawText("Press BACKSPACE to pause", 720, 15, 20, Color.BLACK);
    /* Raylib.DrawRectangle((int)bozo.x-15,(int)bozo.y-15, 100, 100, Color.LIGHTGRAY); */
     Raylib.DrawTexture(stickfigure, (int) bozo.x , (int) bozo.y ,Color.WHITE);
   
       /*Level 1 specific stuff */
  if(Level == 1 && CScene == "Game"){
    
    Raylib.ClearBackground(GREEN2);
    
    /* Raylib.DrawTexture(background1,500,500,Color.GREEN); bozo ass code doesnt wanna work :angy: */
    if(Part == 1){
   partend.y = 718;
   partend.x = 800;
   minuspart.x = 2000; 
   minuspart.y = 2000;  
   Raylib.DrawRectangle((int)partend.x,(int)partend.y,(int)partend.width,(int)partend.height, lvlPink);
   Raylib.DrawText("Fields",450,720,25,Color.BLACK);
   Partplusone();
   Partsminusone();
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
  /*Level 2 specific stuff */
  if(Level == 2 && CScene == "Game"){
   
  }
  /*Level 1 specific stuff */
  if(Level == 3 && CScene == "Game"){
   
  }
    
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
 if(CScene == "Smithmenu" && Raylib.IsKeyDown(KeyboardKey.KEY_H) == true){
     CScene = "Game";
  }
/* micro graphics */
 if(CScene == "Start"){
   Raylib.DrawText("Press ENTER to start", 300, 300, 32, Color.BLACK);
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
    Raylib.DrawText("Not coded yet",0,0,1,Color.BLACK);
    Raylib.DrawText("Not coded yet",0,0,1,Color.BLACK);
    Raylib.ClearBackground(Color.BLUE); 
  }
  if(CScene == "Help"){
    Raylib.DrawText("Not coded yet",0,0,20,Color.BLACK);
    Raylib.DrawText("Not coded yet",0,40,20,Color.BLACK);
    Raylib.ClearBackground(Color.BLUE); 
  }
   if(CScene == "Smithmenu"){
     Raylib.DrawRectangle(200,200,624,368,Color.DARKGRAY);
     Raylib.DrawRectangle(210,210,604,348,Color.LIGHTGRAY);
     Raylib.DrawText("Blacksmith",375,220,30,Color.BLACK);
     /*1024,768*/
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