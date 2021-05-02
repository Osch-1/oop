﻿using System.Collections.Generic;
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
            return _bodies.Where( b => WeightCounter.CountInWaterWeight( b ) == leastInWaterWeight ).ToList();
        }

        private double GetLeastInWaterWeight()
        {
            return _bodies.Min( b => WeightCounter.CountInWaterWeight( b ) );
        }

        private double GetGreatestMass()
        {
            return _bodies.Max( b => b.GetMass() );
        }
    }
}
