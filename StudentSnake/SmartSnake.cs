using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSnake
{
    public class SmartSnake : ISmartSnake
    {
        public Move Direction { get; set; }
        public bool Reverse { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }

        public void Startup(Size size, List<Point> stones)
        {
            Name = "SmartSnake";
            Color = Color.Aqua;
            
        }

        private int i = 0;
        private Point prevPosition = Point.Empty;

        public void Update(Snake snake, List<Snake> enemies, List<Point> food, List<Point> dead)
        {
            
            // Находим ближайшую еду
            Point closestFood = GetClosestFood(snake.Position, food);
            

            // Определяем направление к ближайшей еде
            if (closestFood != Point.Empty)
            {
                if (snake.Position.X < closestFood.X)
                {
                    
                    Direction = Move.Right;
                }
                else if (snake.Position.X > closestFood.X)
                {
                    
                    Direction = Move.Left;
                }
                else if (snake.Position.Y < closestFood.Y)
                {
                    
                    Direction = Move.Down;
                }
                else if (snake.Position.Y > closestFood.Y)
                {
                    
                    Direction = Move.Up;
                }
                // Проверяем, изменилась ли позиция змейки после шага
                if (snake.Position == prevPosition)
                {
                    Random rnd = new Random();
                    Direction = (Move)rnd.Next(1, 5);

                }
                
            }
            prevPosition = snake.Position;
        }

        // Метод для нахождения ближайшей еды
        private Point GetClosestFood(Point position, List<Point> food)
        {
            if (food.Count == 0)
            {
                return Point.Empty;
            }

            Point closestFood = food[0];
            double closestDistance = GetDistance(position, closestFood);

            foreach (Point f in food)
            {
                double distance = GetDistance(position, f);
                if (distance < closestDistance)
                {
                    closestFood = f;
                    closestDistance = distance;
                }
            }
            return closestFood;
        }

        //вычисление расстояния между двумя точками
        private double GetDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }

}
