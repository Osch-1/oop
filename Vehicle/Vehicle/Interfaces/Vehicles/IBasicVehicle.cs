namespace Vehicle.Interfaces.Vehicles
{
    public interface IBasicVehicle
    {
        public abstract bool IsEmpty();
        public abstract bool IsFull();
        public abstract int GetPlaceCount();
        public abstract int GetPassengersCount();
        public abstract void RemoveAllPassangers();
    }
}
