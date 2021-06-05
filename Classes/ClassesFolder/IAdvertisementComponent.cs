namespace ClassesFolder
{
    public interface IAdvertisementComponent
    {
        int BusCount { get; }
        Enums.BusPart BusPart { get; }
        Enums.BusSize BusSize { get; }
    }
}