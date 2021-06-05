using System;
using System.Collections.Generic;
using System.Text;
using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class AdvertisementComponent
    {
        private BusSize _busSize;
        private BusPart _busPart;
        private int _busCount;

        public BusSize BusSize => _busSize;
        public BusPart BusPart => _busPart;
        public int BusCount => _busCount;

        public AdvertisementComponent(BusSize busSize,
                                      BusPart busPart,
                                      int BusCount)
        {
            _busSize = busSize;
            _busPart = busPart;
            _busCount = BusCount;
        }
    }
}
