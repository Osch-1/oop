using System;
using System.Linq;
using System.Text;

namespace Bodies
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string mainMenu = "Что вы хотите создать?\n1.Сфера\n2.Параллелепипед\n3.Конус\n4.Цилиндр\n5.Составное тело\n6.Выйти из программы\n";
            string command = "";
            BodyContrainer bodyContrainer = new();

            while ( command != "6" )
            {
                Console.WriteLine( mainMenu );
                Console.WriteLine( "Выберите команду: " );
                command = Console.ReadLine();

                switch ( command )
                {
                    case "1":
                        Console.WriteLine( "Введите плотность и радиус сферы: " );
                        break;
                    case "2":
                        Console.WriteLine( "Введите плотность, ширину, высоту и глубину параллелепипеда: " );
                        break;
                    case "3":
                        Console.WriteLine( "Введите плотность, высоту и радиус основания сферы конуса: " );
                        break;
                    case "4":
                        Console.WriteLine( "Введите плотность, высоту и радиус основания сферы цилиндра: " );
                        break;
                    case "5":
                        Console.WriteLine( "Выберите составляющие тела: " );
                        break;
                    case "6":
                        continue;
                    default:
                        Console.WriteLine( "Неизвестная команда\n" );
                        continue;
                }

                var parameters = Console.ReadLine().Split( ' ' ).ToList().Select( s => Double.Parse( s ) ).ToList();
                switch ( command )
                {
                    case "1":
                        Console.WriteLine( "Введите плотность и радиус сферы: " );
                        break;
                    case "2":
                        Console.WriteLine( "Введите плотность, ширину, высоту и глубину параллелепипеда: " );
                        break;
                    case "3":
                        Console.WriteLine( "Введите плотность, высоту и радиус основания сферы конуса: " );
                        break;
                    case "4":
                        Console.WriteLine( "Введите плотность, высоту и радиус основания сферы цилиндра: " );
                        break;
                    case "5":
                        Console.WriteLine( "Введите плотность и радиус сферы: " );
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
