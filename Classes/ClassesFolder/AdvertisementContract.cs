using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesFolder
{
    public class AdvertisementContract
    {
        private int _duration;
        private DateTime _signDate;
        private string _enterprise;
        private List<AdvertisementComponent> _componentsList;
        private decimal _price;
        private bool _expired;

        public int Duration => _duration;
        public DateTime SignDate => _signDate;
        public string Enterprise => _enterprise;
        public List<AdvertisementComponent> ComponentsList => _componentsList;
        public decimal Price => _price;
        public bool Expired => _expired;

        public AdvertisementContract(int duration, 
                                      DateTime signDate,
                                      string enterprise,
                                      List<AdvertisementComponent> componentsList,
                                      decimal price,
                                      bool expired)
        {
            _duration = duration;
            _signDate = signDate;
            _enterprise = enterprise;
            _componentsList = componentsList;
            _price = price;
            _expired = expired;
        }
    }
}
