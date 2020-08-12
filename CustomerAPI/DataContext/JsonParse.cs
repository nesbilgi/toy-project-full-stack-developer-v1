using System.Collections.Generic;
using System.IO;
using Data.Models;
using Newtonsoft.Json;

namespace CustomerAPI.DataContext
{
    public class JsonParse
    {
        // Tüm data bu  liste üzerinde işlem görüyor
        // api çalışması durdurulursa liste sıfırlanır.
        // Yapılan kayıt veya güncelleme işlemleri etkili olmaz.
        public List<Customer> Customers { get; set; }
        public JsonParse()
        {
            this.Customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText("../MOCK_CUSTOMERS.json"));
        }
        
    }
}