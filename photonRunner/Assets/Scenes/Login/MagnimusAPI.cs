using System.Net;
using System.IO;
using UnityEngine;
using TMPro;

using UnityEngine.Networking;
//using System
namespace Magnimus
{
    public static class MagnimusAPI 
    {
        //stores the username of the logged in user/registered
        public static string userEmail;
        //just a random placeholder for otp
        public static string otp = "xxx";
        //used to log user in
        public static JSONLoginOutput LoginUser(string jsonLoginData)
        {
            //the url from which API is to be taken
            string url = "https://www.magnimus.com/api/login";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //the type of content we are sending to the API, here we are sending JSON API
            request.ContentType = "application/json";
            //requesting API method
            request.Method = "POST";

            //writing the data to the stream
            //jsonLoginData is being written, which contains the login details
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonLoginData);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());

            string json;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                //sending data in form of string
                json = streamReader.ReadToEnd();
            }
            //converting the string on form of class defined
            return JsonUtility.FromJson<JSONLoginOutput>(json);

        }
        public static JSONRegisterOutput RegisterUser(string jsonRegisterData)
        {
            //the url from which API is to be taken
            string url = "https://www.magnimus.com/api/register";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //the type of content we are sending to the API, here we are sending JSON API
            request.ContentType = "application/json";
            //requesting API method
            request.Method = "POST";

            //writing the data to the stream
            //jsonLoginData is being written, which contains the login details
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonRegisterData);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());

            string json;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                //sending data in form of string
                json = streamReader.ReadToEnd();
            }
            //converting the string on form of class defined
            return JsonUtility.FromJson<JSONRegisterOutput>(json);

        }
        public static JSONUsers GetAllUsers()
        {
            //the url from which API is to be taken
            string url = "https://www.magnimus.com/api/getAllUsers";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //the type of content we are sending to the API, here we are sending JSON API
            request.ContentType = "application/json";
            //requesting API method
            request.Method = "POST";

            //writing the data to the stream
            //jsonLoginData is being written, which contains the login details
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write("");
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());

            string json;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                //sending data in form of string
                json = streamReader.ReadToEnd();
            }
            //converting the string on form of class defined
            //Debug.Log(JsonUtility.FromJson<JSONUsers>(json));
            return JsonUtility.FromJson<JSONUsers>(json);
        }
        //will send Otp to the email registered
        public static JSONSendOtpOutput GenerateOtp(string jsonOtp)
        {
            //the url from which API is to be taken
            string url = "https://www.magnimus.com/api/sendRegisterMail";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //the type of content we are sending to the API, here we are sending JSON API
            request.ContentType = "application/json";
            //requesting API method
            request.Method = "POST";

            //writing the data to the stream
            //jsonLoginData is being written, which contains the login details
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonOtp);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());

            string json;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                //sending data in form of string
                json = streamReader.ReadToEnd();
            }
            //converting the string on form of class defined
            return JsonUtility.FromJson<JSONSendOtpOutput>(json);
        }
        
    }
}
