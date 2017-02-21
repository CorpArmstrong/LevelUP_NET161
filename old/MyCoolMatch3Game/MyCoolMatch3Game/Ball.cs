using System;

namespace MyCoolMatch3Game
{
    public struct Ball
    {
        public enum BallColor
        {
            Black,
            Yellow,
            Red,
            Magenta,
            Green,
            Cyan,
            Blue
        };

        public BallColor _color;    
        public bool _isDeleted;

        public static ConsoleColor GetConsoleColor(BallColor ballColor)
        {
            ConsoleColor consoleBallColor;

            switch (ballColor)
            {
                case BallColor.Yellow:
                    consoleBallColor = ConsoleColor.Yellow;
                    break;
                case BallColor.Red:
                    consoleBallColor = ConsoleColor.Red;
                    break;
                case BallColor.Magenta:
                    consoleBallColor = ConsoleColor.Magenta;
                    break;
                case BallColor.Green:
                    consoleBallColor = ConsoleColor.Green;
                    break;
                case BallColor.Cyan:
                    consoleBallColor = ConsoleColor.Cyan;
                    break;
                case BallColor.Blue:
                    consoleBallColor = ConsoleColor.Blue;
                    break;
                case BallColor.Black:
                default:
                    consoleBallColor = ConsoleColor.Black;                
                    break;
            }

            return consoleBallColor;
        }

        static BallColor SetRandomBallColor()
        {
            BallColor randomBallColor = (BallColor)Utils.randomNumber.Next((int)BallColor.Yellow, (int)BallColor.Blue);

            return randomBallColor;
        }
                
        public static Ball InitBall()
        {
            Ball newBall = new Ball();
            newBall._color = SetRandomBallColor();
            newBall._isDeleted = false;

            return newBall;
        }

        public static void CheckIsBallDeleted(ref Ball currentBall)
        {
            if (currentBall._isDeleted)
            {
                currentBall._color = BallColor.Black;
            }
        }

        public static BallColor GetBallColor(Ball currentBall)
        {
            return currentBall._color;
        }
    }
}