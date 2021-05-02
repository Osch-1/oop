using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bodies
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string mainMenu = "Что вы хотите сделать?\n1.Создать сферу\n2.Создать параллелепипед\n3.Создать конус\n4.Создать цилиндр\n5.Создать составное тело\n6.Вывести информацию о телах\n7.Выйти из программы\n";
            const string exitCommand = "7";
            string command = "";
            BodyContrainer bodyContainer = new();

            while ( command != exitCommand )
            {
                Console.WriteLine( mainMenu );
                Console.WriteLine( "Выберите команду: " );
                command = Console.ReadLine();

                Body newBody;

                switch ( command )
                {
                    case "1":
                        newBody = ReadSphereFromInput();
                        break;
                    case "2":
                        newBody = ReadParallelepipedFromInput();
                        break;
                    case "3":
                        newBody = ReadConeFromInput();
                        break;
                    case "4":
                        newBody = ReadCylinderFromInput();
                        break;
                    case "5":
                        newBody = ReadCompoundBody();
                        break;
                    case "6":
                        bodyContainer.PrintInfo();
                        continue;
                    case "7":
                        continue;
                    default:
                        Console.WriteLine( "Неизвестная команда\n" );
                        continue;
                }

                bodyContainer.AddBody( newBody );
            }

            bodyContainer.PrintInfo();
        }

        public static Compound ReadCompoundBody()
        {
            const string menu = "Что вы хотите сделать?\n1.Добавить сферу\n2.Добавить параллелепипед\n3.Добавить конус\n4.Добавить цилиндр\n5.Добавить составное тело\n6.Вывести информацию о созданных телах\n7.Завершить создание составного тела\n";
            const string exitCommand = "7";
            string command = "";
            var listOfNewBodies = new List<InsertableBody>();

            while ( command != exitCommand )
            {
                Console.WriteLine( menu );
                Console.WriteLine( "Выберите команду: " );
                command = Console.ReadLine();

                InsertableBody newBody;
                switch ( command )
                {
                    case "1":
                        newBody = ReadSphereFromInput();
                        break;
                    case "2":
                        newBody = ReadParallelepipedFromInput();
                        break;
                    case "3":
                        newBody = ReadConeFromInput();
                        break;
                    case "4":
                        newBody = ReadCylinderFromInput();
                        break;
                    case "5":
                        newBody = ReadCompoundBody();
                        break;
                    case "6":
                        listOfNewBodies.ForEach( b => Console.WriteLine( $"{b}\n" ) );
                        continue;
                    case "7":
                        continue;
                    default:
                        Console.WriteLine( "Неизвестная команда\n" );
                        continue;
                }

                listOfNewBodies.Add( newBody );
            }

            return new Compound( listOfNewBodies );
        }

        public static Sphere ReadSphereFromInput()
        {
            Console.WriteLine( "Введите плотность и радиус сферы: " );

            var parameters = Console.ReadLine().Split( ' ' ).ToList().Select( s => Double.Parse( s ) ).ToList();

            return new Sphere( parameters[ 0 ], parameters[ 1 ] );
        }

        private static Parallelepiped ReadParallelepipedFromInput()
        {
            Console.WriteLine( "Введите плотность, ширину, высоту и глубину параллелепипеда: " );

            var parameters = Console.ReadLine().Split( ' ' ).ToList().Select( s => Double.Parse( s ) ).ToList();

            return new Parallelepiped( parameters[ 0 ], parameters[ 1 ], parameters[ 2 ], parameters[ 3 ] );
        }

        private static Cone ReadConeFromInput()
        {
            Console.WriteLine( "Введите плотность, высоту и радиус основания конуса: " );

            var parameters = Console.ReadLine().Split( ' ' ).ToList().Select( s => Double.Parse( s ) ).ToList();

            return new Cone( parameters[ 0 ], parameters[ 1 ], parameters[ 2 ] );
        }

        private static Cylinder ReadCylinderFromInput()
        {
            Console.WriteLine( "Введите плотность, высоту и радиус основания сферы цилиндра: " );

            var parameters = Console.ReadLine().Split( ' ' ).ToList().Select( s => Double.Parse( s ) ).ToList();

            return new Cylinder( parameters[ 0 ], parameters[ 1 ], parameters[ 2 ] );
        }
    }
}
