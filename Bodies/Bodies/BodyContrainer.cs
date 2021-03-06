using System;
using System.Collections.Generic;
using System.Linq;

namespace Bodies
{
    public class BodyContrainer
    {
        private readonly List<Body> _bodies = new();

        public BodyContrainer()
        {
        }

        public void AddBody( Body body )
        {
            _bodies.Add( body );
        }

        public List<Body> GetBodiesWithGreatestMass()
        {
            double greatesWeight = GetGreatestMass();
            return _bodies.Where( b => b.GetMass() == greatesWeight ).ToList();
        }

        public List<Body> GetBodiesWithLeastInWaterWeight()
        {
            double leastInWaterWeight = GetLeastInWaterWeight();
            return _bodies.Where( b => WeightCounter.CalculateInWaterWeight( b ) == leastInWaterWeight ).ToList();
        }

        public void PrintInfo()
        {
            if ( _bodies.Any() )
            {
                _bodies.ForEach( b => Console.WriteLine( b ) );

                var greatestMassBodiesInfo = "";
                foreach ( var body in GetBodiesWithGreatestMass() )
                {
                    greatestMassBodiesInfo += body;
                }

                var leastInWaterWeightBodiesInfo = "";
                foreach ( var body in GetBodiesWithLeastInWaterWeight() )
                {
                    leastInWaterWeightBodiesInfo += body;
                }

                Console.WriteLine( $"\nТела с наибольшей массой: {greatestMassBodiesInfo}\n" );
                Console.WriteLine( $"Тела с наименьшим весом в воде: {leastInWaterWeightBodiesInfo}" );
            }
            else
            {
                Console.WriteLine( "Не добавлено ни одного тела:)\n" );
            }
        }

        private double GetLeastInWaterWeight()
        {
            return _bodies.Min( b => WeightCounter.CalculateInWaterWeight( b ) );
        }

        private double GetGreatestMass()
        {
            return _bodies.Max( b => b.GetMass() );
        }
    }
}
