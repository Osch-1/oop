using System;
using System.Collections.Generic;
using Vehicle.Interfaces.Passengers;
using Vehicle.Interfaces.Vehicles;

namespace Vehicle.Entities.Vehicles
{
    public abstract class AbstractVehicle<TPassenger> : IVehicle<TPassenger> where TPassenger : IPerson
    {
        private readonly int _placesCount = 0;
        private readonly List<TPassenger> _passengers = new();

        public AbstractVehicle( int placesCount )
        {
            _placesCount = placesCount;
        }

        public void AddPassenger( TPassenger passenger )
        {
            if ( _passengers.Count == _placesCount )
                throw new Exception( "Can't add another passenger, no places left" );
            _passengers.Add( passenger );
        }

        public TPassenger GetPassenger( int index )
        {
            if ( index > _passengers.Count )
                throw new IndexOutOfRangeException( "Passenger index is out of range" );

            return _passengers[ index ];
        }

        public int GetPassengersCount()
        {
            return _passengers.Count;
        }

        public int GetPlaceCount()
        {
            return _placesCount;
        }

        public bool IsEmpty()
        {
            return _passengers.Count == 0;
        }

        public bool IsFull()
        {
            return _passengers.Count == _placesCount;
        }

        public void RemoveAllPassangers()
        {
            _passengers.Clear();
        }

        public void RemovePassenger( int index )
        {
            if ( index > _passengers.Count )
                throw new IndexOutOfRangeException( "Passenger index is out of range" );

            _passengers.RemoveAt( index );
        }
    }
}