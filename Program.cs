using Raylib_cs;
using static Raylib_cs.Raylib;
using Game.Core;
namespace Game;

class Program
{

    static void Main(string[] args)
    {
        string input1 = "";
        string input2 = "";
        bool input1Active = false;
        bool input2Active = false;

        Rectangle buttonRect = new Rectangle(0, 0, 200, 50);

        GameScreen currentScreen = GameScreen.Title;
        Raylib.InitWindow(Consts.Screen, Consts.Screen, "Insta game");
        Raylib.SetTargetFPS(60);
        GameHandler.Init(2);
        while (!Raylib.WindowShouldClose())
        {
            switch (currentScreen)
            {
                case GameScreen.Title:
                    {
                        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                        {
                            var mouse = Raylib.GetMousePosition();

                            Rectangle inputRect1 = new Rectangle((Consts.Screen / 2) - 150, (Consts.Screen / 2) - 100, 300, 40);
                            Rectangle inputRect2 = new Rectangle((Consts.Screen / 2) - 150, (Consts.Screen / 2) - 40, 300, 40);
                            if (Raylib.CheckCollisionPointRec(mouse, inputRect1))
                            {
                                input1Active = true;
                                input2Active = false;
                            }
                            else if (Raylib.CheckCollisionPointRec(mouse, inputRect2))
                            {
                                input2Active = true;
                                input1Active = false;
                            }
                            else if (Raylib.CheckCollisionPointRec(mouse, buttonRect))
                            {
                                int val1, val2;
                                bool ok1 = Int32.TryParse(input1, out val1);
                                bool ok2 = Int32.TryParse(input2, out val2);
                                if (ok1 && ok2)
                                {
                                    Console.WriteLine($"Играть: {val1}, {val2}");
                                }
                            }
                            else
                            {
                                input1Active = input2Active = false;
                            }
                        }

                        int c = Raylib.GetCharPressed();
                        while (c > 0)
                        {
                            if (input1Active)
                            {
                                if (c >= '0' && c <= '9')
                                {
                                    input1 += Char.ConvertFromUtf32(c);
                                }
                            }
                            else if (input2Active)
                            {
                                if (c >= '0' && c <= '9')
                                {
                                    input2 += Char.ConvertFromUtf32(c);
                                }
                            }

                            c = Raylib.GetCharPressed();
                        }

                        if (input1Active)
                        {
                            if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && input1.Length > 0)
                                input1 = input1.Substring(0, input1.Length - 1);
                        }
                        else if (input2Active)
                        {
                            if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && input2.Length > 0)
                                input2 = input2.Substring(0, input2.Length - 1);
                        }
                    }
                    break;

            }

            // DRAW
            // ---------
            BeginDrawing();

            ClearBackground(Color.White);

            switch (currentScreen)
            {
                case GameScreen.Title:
                    {
                        Rectangle inputRect1Draw = new Rectangle((Consts.Screen / 2) - 150, (Consts.Screen / 2) - 100, 300, 40);
                        Raylib.DrawRectangleRec(inputRect1Draw, input1Active ? Color.LightGray : Color.Gray);
                        Raylib.DrawRectangleLines((int)inputRect1Draw.X, (int)inputRect1Draw.Y, (int)inputRect1Draw.Width, (int)inputRect1Draw.Height, Color.Black);
                        Raylib.DrawText(input1 == "" ? "Number of players" : input1, (int)inputRect1Draw.X + 5, (int)inputRect1Draw.Y + 10, 20, Color.Black);

                        Rectangle inputRect2Draw = new Rectangle((Consts.Screen / 2) - 150, (Consts.Screen / 2) - 40, 300, 40);
                        Raylib.DrawRectangleRec(inputRect2Draw, input2Active ? Color.LightGray : Color.Gray);
                        Raylib.DrawRectangleLines((int)inputRect2Draw.X, (int)inputRect2Draw.Y, (int)inputRect2Draw.Width, (int)inputRect2Draw.Height, Color.Black);
                        Raylib.DrawText(input2 == "" ? "Введите число 2" : input2, (int)inputRect2Draw.X + 5, (int)inputRect2Draw.Y + 10, 20, Color.Black);

                        buttonRect.X = (Consts.Screen / 2) - (buttonRect.Width / 2);
                        buttonRect.Y = (Consts.Screen / 2) + 40;
                        Raylib.DrawRectangleRec(buttonRect, Color.Blue);
                        Raylib.DrawRectangleLines((int)buttonRect.X, (int)buttonRect.Y, (int)buttonRect.Width, (int)buttonRect.Height, Color.Black);
                        Raylib.DrawText("Играть", (int)(buttonRect.X + 50), (int)(buttonRect.Y + 15), 20, Color.White);
                    }
                    break;

                case GameScreen.Gameplay:
                    FrameHandler.GameLogic();
                    FrameHandler.GameDraw();
                    break;

            }
            EndDrawing();
            //-----------
        }
    }


    enum GameScreen
    {
        Title,
        Gameplay
    }
}
