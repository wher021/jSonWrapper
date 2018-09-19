using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonParser
{
    public class User
    {
        public string FirstName;
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an object
            var user = new User { FirstName = "Sean" };
            // Serialize the object to JSON
            var jsonUser = JsonSerializer.ToJsonString(user, useCamelCase: true, ignoreNulls: true, indentJson: false);

            // Deserialize the object
            var parser = new JsonSerializer();
            var deserializedUser = parser.DeserializeObject33<User>(jsonUser);
            var shit = ((User)deserializedUser).FirstName;
                //JsonSerializer.FromJsonString(jsonUser);

            Console.WriteLine(shit);
            
            Console.ReadKey();
        }
    }
}


/// 
/// A little wrapper for JSON.Net. /// 

public class JsonSerializer : JsonParser.Interface2
{
    /// 
    /// To the json string. /// 

    ///The object to serialize.
    ///if set to true [use camel case].
    ///if set to true [ignore nulls].
    ///if set to true [indent json].
    /// 
    public static string ToJsonString(object objectToSerialize, bool useCamelCase = true, bool ignoreNulls = true,
        bool indentJson = false)
    {
        var settings = new JsonSerializerSettings();

        if (useCamelCase)
        {
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        if (ignoreNulls)
        {
            settings.NullValueHandling = NullValueHandling.Ignore;
        }

        if (indentJson)
        {
            settings.Formatting = Formatting.Indented;
        }

        return JsonConvert.SerializeObject(
            objectToSerialize,
            settings);
    }

/*    public object FromJsonString(string jsonString)
    {
        return JsonConvert.DeserializeObject(jsonString); 
        
    }*/

    public T DeserializeObject33<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }

} 