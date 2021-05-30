using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class Bus
    {
        private int _id;
        private BusSize _size;

        public int Id => _id;
        public BusSize Size => _size;

        public Bus(int id, BusSize size)
        {
            _id = id;
            _size = size;
        }
    }
}