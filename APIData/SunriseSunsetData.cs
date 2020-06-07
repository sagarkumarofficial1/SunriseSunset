using Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIData
{
    public class SunriseSunsetData
    {
        public static async Task<SunriseSunsetModel> getData(string longitude,string latitude)
        {
            SunriseSunsetModel model = new SunriseSunsetModel();

            //not hit https://api.sunrise-sunset.org/ until longitude and latitude is empty
            if (!string.IsNullOrEmpty(longitude) && !string.IsNullOrEmpty(latitude))
            {
                string url = $"https://api.sunrise-sunset.org/json?lat={latitude}&lng={longitude}";

                using (HttpResponseMessage response = await APICommon.ClientAPI.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        model = await response.Content.ReadAsAsync<SunriseSunsetModel>();

                        //Converting Sunrise and sunset time to local time i.e. GMT+5:30
                        model.results.sunrise = Convert.ToDateTime(model.results.sunrise).AddMinutes(330).ToString();
                        model.results.sunset = Convert.ToDateTime(model.results.sunset).AddMinutes(330).ToString();

                    }
                    else
                    {
                        //if user enter incorrect values
                        model.status = "Please enter valid Longitude and Latitude";
                    }
                }
            }
            else
            { 
                //if longitude and atitude null or empty
                model.status = "Longitude and latitude Required!!";
            }

            return model;
        }
    }
}
