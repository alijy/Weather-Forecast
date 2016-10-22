using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace WeatherForecast
{
    [DataContract]
    public class Response
    {
        /*coord:
         *      lon.
         *      lat.
         *weather:
         *      id.
         *      main.
         *      description.
         *      icon.
         *base.
         *main:
         *      temp.
         *      pressure.
         *      humidity.
         *      temp_min.
         *      temp_max.
         *      sea_level.
         *      grnd_level.
         *wind:
         *      speed.
         *      deg.
         *clouds:
         *      all.
         *rain:
         *      3h.
         *snow:
         *      3h.
         *dt.
         *sys:
         *      type.
         *      id.
         *      message.
         *      country.
         *      sunrise.
         *      sunset.
         *id.
         *name.            
         *cod.
         */ 
        [DataMember(Name = "coord")]
        public Coord Coord { get; set; }

        [DataMember(Name = "weather")]
        public Weather[] Weather { get; set; }

        [DataMember(Name = "base")]
        public string Base { get; set; }

        [DataMember(Name = "main")]
        public Main Main { get; set; }

        [DataMember(Name = "wind")]
        public Wind Wind { get; set; }

        [DataMember(Name = "clouds")]
        public Clouds Clouds { get; set; }

        [DataMember(Name = "rain")]
        public Rain Rain { get; set; }

        [DataMember(Name = "snow")]
        public Snow Snow { get; set; }

        [DataMember(Name = "dt")]
        public long Dt { get; set; }

        [DataMember(Name = "sys")]
        public Sys Sys { get; set; }

        [DataMember(Name = "id")]
        public long ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "cod")]
        public long Cod { get; set; }
    }


    [DataContract]
    public class Coord
    {
        [DataMember(Name = "lon")]
        public float Lon { get; set; }
        [DataMember(Name = "lat")]
        public float Lat { get; set; }
    }

    [DataContract]
    public class Weather
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "main")]
        public string Main { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember(Name = "temp")]
        public float Temp { get; set; }
        [DataMember(Name = "pressure")]
        public float Pressure { get; set; }
        [DataMember(Name = "humidity")]
        public int Humidity { get; set; }
        [DataMember(Name = "temp_min")]
        public float Temp_Min { get; set; }
        [DataMember(Name = "temp_max")]
        public float Temp_Max { get; set; }
        [DataMember(Name = "sea_level")]
        public float Sea_Level { get; set; }
        [DataMember(Name = "grnd_level")]
        public float Grnd_Level { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember(Name = "speed")]
        public float Speed { get; set; }
        [DataMember(Name = "deg")]
        public float Deg { get; set; }
    }

    [DataContract]
    public class Clouds
    {
        [DataMember(Name = "all")]
        public int All { get; set; }
    }

    [DataContract]
    public class Rain
    {
        [DataMember(Name = "3h")]
        public float R3h { get; set; }
    }

    [DataContract]
    public class Snow
    {
        [DataMember(Name = "3h")]
        public float S3h { get; set; }
    }

    [DataContract]
    public class Sys
    {
        [DataMember(Name = "type")]
        public float Type { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "message")]
        public float Message { get; set; }
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name = "sunrise")]
        public long Sunrise { get; set; }
        [DataMember(Name = "sunset")]
        public long Sunset { get; set; }
    }
}