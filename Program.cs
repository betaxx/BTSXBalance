using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetBTSBalance
{
    class Program
    {
        const string AddressesCommaSeparatedFileName = "addressesCommaSeparated.txt";
        const string GenesisJsonFileName = "genesis.json";
        const string AddressGroupingsFileName = "addressGroupings.txt";

        static void Main(string[] args)
        {
            var genesis = LoadGenesis();

            long runningTotal = 0;
            
            var addresses = new List<string>();

            LoadAddresesFromAddressGroupings(addresses);
            
            LoadAddressesFromCommaSeparatedFile(addresses);

            foreach (var address in addresses)
            {
                var found = genesis.balances.Where(x => x.GetAddress() == address.Trim());
                if (found.Count() > 0)
                {
                    runningTotal += found.First().GetBalance();
                }

            }

            Console.WriteLine(runningTotal * 0.00000001);
            Console.ReadLine();
        }

        private static Genesis LoadGenesis()
        {
            var jsonGenesis = "";
           
            using (var file = File.OpenText(GenesisJsonFileName))
            {
                jsonGenesis = file.ReadToEnd();
            }

            var genesis = JsonConvert.DeserializeObject<Genesis>(jsonGenesis);
            return genesis;
        }

        private static void LoadAddressesFromCommaSeparatedFile(List<string> addresses)
        {
           
            if (File.Exists(AddressesCommaSeparatedFileName))
            {
                var addressesCommaSeparated = "";
                using (var file = File.OpenText(AddressesCommaSeparatedFileName))
                {
                    addressesCommaSeparated = file.ReadToEnd();
                }
                ;

                var list = addressesCommaSeparated.Split(',');

                foreach (var addressString in list)
                {
                    addresses.Add(addressString);
                }
            }
        }

        private static void LoadAddresesFromAddressGroupings(List<string> addresses)
        {
            if (File.Exists(AddressGroupingsFileName))
            {
                var addressesjson = "";
                using (var file = File.OpenText(AddressGroupingsFileName))
                {
                    addressesjson = file.ReadToEnd();
                }

                var addressesPTS = JsonConvert.DeserializeObject<List<List<AddressGroupingBalance>>>(addressesjson);

                foreach (var addressGroup in addressesPTS)
                {
                    foreach (var address in addressGroup)
                    {
                        addresses.Add(address.GetAddress());
                    }
                }
            }
        }
    }


 

    public class AddressGroupingBalance : List<string>
    {
        public string GetAddress()
        {
            return this[0];
        }
    }


    public class Genesis
    {
        public decimal blocktime;
        public int blocknumber;
        public decimal moneysupply;
        public List<GenesisBalance> balances;
    }

    public class GenesisBalance : List<string>
    {
        public string GetAddress()
        {
            return this[0];
        }

        public long GetBalance()
        {
           return Convert.ToInt64(this[1]);
        }
    }
}
