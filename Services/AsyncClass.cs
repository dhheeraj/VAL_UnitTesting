using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AsyncClass
    {
        public AsyncClass() { }
        public async Task<string> GetTemperature(string cityName) {
            try
            {
                if (string.IsNullOrEmpty(cityName)) return "City Name is empty";
                await FetchTemperature(cityName);
                return cityName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task FetchTemperature(string cityName)
        {
                await Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        // intently casing exception to occur
                        Convert.ToInt16(cityName);
                        Task.Delay(5).Wait();
                    }
                });
            }
            
        }
    }

