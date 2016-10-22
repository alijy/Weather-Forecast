using System;
using System.Net;
using System.Runtime.Serialization.Json;

namespace WeatherForecast

{
    class Program
    {
        static string openWeatherKey = "49358f41afe98dcd54f0a7cca0fa0717";
        static void Main(string[] args)
        {
            Console.Write("Enter UK City Name:  ");
            string city = Console.ReadLine();
            try
            {
                string weatherRequest = CreateRequest(city);
                Response weatherResponse = MakeRequest(weatherRequest);
                ProcessResponse(weatherResponse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }

        }

        //Create the request URL
        public static string CreateRequest(string queryString)
        {
            string UrlRequest = "http://api.openweathermap.org/data/2.5/weather?q=" +
                                queryString + ",GB&units=metric&&APPID=" + openWeatherKey;
            return (UrlRequest);
        }

        public static Response MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Response jsonResponse
                    = objResponse as Response;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        static public void ProcessResponse(Response weatherResponse)
        {

            Console.WriteLine("\n");
            Console.WriteLine(weatherResponse.Name + ", " + weatherResponse.Sys.Country);
            Console.WriteLine("========================");
            Console.WriteLine("Temperature : " + Math.Round(weatherResponse.Main.Temp) + " °C");
            Console.WriteLine("Wind Speed : " + weatherResponse.Wind.Speed + " m/s");
            Console.WriteLine("Humidity : " + weatherResponse.Main.Humidity + "%");
            Console.WriteLine("Cloudiness : " + weatherResponse.Clouds.All + "%");
            Console.WriteLine("Sky : " + weatherResponse.Weather[0].Description);
            Console.WriteLine("\n");
            Console.WriteLine(UnixTimeStampToDateTime(weatherResponse.Dt));
            Console.WriteLine("========================");
            Console.WriteLine("\n\n\n");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();


        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}