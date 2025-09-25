using Raylib_cs;
using static Raylib_cs.Raylib;
using Game.Core;
using System.Numerics;

namespace Game;

class Program
{
    static void Main(string[] args)
    {
        const int screenW = 900;
        const int screenH = 900;

        string[] items = new string[] { "Sword", "Dagger", "Spear" };

        int colCount = 2;
        int colW = 360;
        int colH = 220;
        int gap = 40;
        int totalW = colW * colCount + gap;
        int startX = (screenW - totalW) / 2;
        int startY = (screenH - colH) / 2 - 30;

        string[] inputs = new string[] { "", "" };
        bool[] inputActive = new bool[] { false, false };
        int[] selectedIndex = new int[] { 0, 0 };

        Rectangle startRect = new Rectangle((screenW - 160) / 2f, startY + colH + 30f, 160f, 48f);

        string status = "";
        int statusTimer = 0;

        GameScreen currentScreen = GameScreen.Title;
        InitWindow(screenW, screenH, "Insta game");
        SetTargetFPS(60);

        while (!WindowShouldClose())
        {
            switch (currentScreen)
            {
                case GameScreen.Title:
                    {
                        Vector2 mouse = GetMousePosition();

                        if (IsMouseButtonPressed(MouseButton.Left))
                        {
                            bool clickedOnAny = false;

                            for (int col = 0; col < colCount; col++)
                            {
                                int cx = startX + col * (colW + gap);

                                Rectangle inputRect = new Rectangle(cx + 20, startY + 20, colW - 40, 46);
                                Rectangle selRect = new Rectangle(cx + 20, startY + 90, colW - 40, 80);
                                Rectangle leftRect = new Rectangle(selRect.X + 8, selRect.Y + (selRect.Height / 2f) - 18f, 36f, 36f);
                                Rectangle rightRect = new Rectangle(selRect.X + selRect.Width - 8f - 36f, selRect.Y + (selRect.Height / 2f) - 18f, 36f, 36f);

                                if (CheckCollisionPointRec(mouse, inputRect))
                                {
                                    for (int j = 0; j < colCount; j++) inputActive[j] = (j == col);
                                    clickedOnAny = true;
                                }
                                else if (CheckCollisionPointRec(mouse, leftRect))
                                {
                                    selectedIndex[col] = (selectedIndex[col] - 1 + items.Length) % items.Length;
                                    clickedOnAny = true;
                                }
                                else if (CheckCollisionPointRec(mouse, rightRect))
                                {
                                    selectedIndex[col] = (selectedIndex[col] + 1) % items.Length;
                                    clickedOnAny = true;
                                }
                                else if (CheckCollisionPointRec(mouse, selRect))
                                {
                                    for (int j = 0; j < colCount; j++) inputActive[j] = false;
                                    clickedOnAny = true;
                                }
                            }

                            if (CheckCollisionPointRec(mouse, startRect))
                            {
                                bool okAll = true;
                                int[] vals = new int[colCount];
                                for (int c = 0; c < colCount; c++)
                                {
                                    if (!Int32.TryParse(inputs[c], out vals[c]))
                                    {
                                        okAll = false;
                                        break;
                                    }
                                }

                                if (okAll)
                                {
                                    GameHandler.Init(vals, selectedIndex);
                                    currentScreen = GameScreen.Gameplay;
                                }
                                else
                                {
                                    status = "error: forget numbers.";
                                    statusTimer = 180;
                                }

                                for (int j = 0; j < colCount; j++) inputActive[j] = false;
                                clickedOnAny = true;
                            }

                            if (!clickedOnAny)
                            {
                                for (int j = 0; j < colCount; j++) inputActive[j] = false;
                            }
                        }

                        int ch = GetCharPressed();
                        while (ch > 0)
                        {
                            for (int col = 0; col < colCount; col++)
                            {
                                if (inputActive[col] && ch >= '0' && ch <= '9')
                                {
                                    if (inputs[col].Length < 9) inputs[col] += Char.ConvertFromUtf32(ch);
                                }
                            }
                            ch = GetCharPressed();
                        }

                        if (IsKeyPressed(KeyboardKey.Backspace))
                        {
                            for (int col = 0; col < colCount; col++)
                            {
                                if (inputActive[col] && inputs[col].Length > 0)
                                    inputs[col] = inputs[col].Substring(0, inputs[col].Length - 1);
                            }
                        }
                        break;
                    }
            }

            // DRAW
            BeginDrawing();
            ClearBackground(Color.RayWhite);

            switch (currentScreen)
            {
                case GameScreen.Title:
                    {
                        for (int col = 0; col < colCount; col++)
                        {
                            int cx = startX + col * (colW + gap);
                            Rectangle colRect = new Rectangle(cx, startY, colW, colH);

                            DrawRectangleRec(colRect, Color.LightGray);
                            DrawRectangleLines((int)colRect.X, (int)colRect.Y, (int)colRect.Width, (int)colRect.Height, Color.Gray);

                            DrawText($"Player {col + 1}", (int)(colRect.X + 14), (int)(colRect.Y + 6), 18, Color.DarkGray);

                            Rectangle inputRect = new Rectangle(cx + 20, startY + 20, colW - 40, 46);

                            DrawRectangleLines((int)inputRect.X, (int)inputRect.Y, (int)inputRect.Width, (int)inputRect.Height, Color.DarkGray);
                            string display = inputs[col] == "" ? "Health" : inputs[col];
                            DrawText(display, (int)inputRect.X + 8, (int)inputRect.Y + 12, 22, Color.Black);

                            Rectangle selRect = new Rectangle(cx + 20, startY + 90, colW - 40, 80);
                            DrawRectangleRec(selRect, Color.White);
                            DrawRectangleLines((int)selRect.X, (int)selRect.Y, (int)selRect.Width, (int)selRect.Height, Color.DarkGray);

                            Rectangle leftRect = new Rectangle(selRect.X + 8, selRect.Y + (selRect.Height / 2f) - 18f, 36f, 36f);
                            DrawRectangleRec(leftRect, Color.LightGray);
                            DrawRectangleLines((int)leftRect.X, (int)leftRect.Y, (int)leftRect.Width, (int)leftRect.Height, Color.DarkGray);
                            DrawText("<", (int)leftRect.X + 10, (int)leftRect.Y + 6, 22, Color.Black);

                            Rectangle rightRect = new Rectangle(selRect.X + selRect.Width - 8f - 36f, selRect.Y + (selRect.Height / 2f) - 18f, 36f, 36f);
                            DrawRectangleRec(rightRect, Color.LightGray);
                            DrawRectangleLines((int)rightRect.X, (int)rightRect.Y, (int)rightRect.Width, (int)rightRect.Height, Color.DarkGray);
                            DrawText(">", (int)rightRect.X + 10, (int)rightRect.Y + 6, 22, Color.Black);

                            string name = items[selectedIndex[col]];
                            int textW = MeasureText(name, 24);
                            DrawText(name, (int)(selRect.X + (selRect.Width - textW) / 2f), (int)(selRect.Y + (selRect.Height / 2f) - 12f), 24, Color.Black);
                        }

                        DrawRectangleRec(startRect, Color.Blue);
                        DrawRectangleLines((int)startRect.X, (int)startRect.Y, (int)startRect.Width, (int)startRect.Height, Color.Black);
                        int tw = MeasureText("Play", 22);
                        DrawText("Play", (int)(startRect.X + (startRect.Width - tw) / 2f), (int)(startRect.Y + 12f), 22, Color.White);

                        if (statusTimer > 0)
                        {
                            DrawText(status, (screenW - MeasureText(status, 20)) / 2, startY + colH + 90, 20, Color.DarkGreen);
                            statusTimer--;
                        }
                    }
                    break;

                case GameScreen.Gameplay:
                    FrameHandler.GameDraw();
                    FrameHandler.GameLogic();
                    break;
            }

            EndDrawing();
        }

        CloseWindow();
    }

    enum GameScreen
    {
        Title,
        Gameplay
    }
}
