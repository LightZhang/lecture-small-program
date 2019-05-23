using System;
using System.Xml.Serialization;
using System.Collections;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BimProductApi
{
	
	public class Cookies
    {

        /// <summary>
        /// …Ë÷√Cookie
        /// </summary>
        /// <param name="infoName"></param>
        /// <param name="infoValue"></param>
        public static void Set(string infoName, string infoValue)
        {
            HttpCookie cookie = new HttpCookie(infoName);
            cookie.Value = infoValue;
            cookie.HttpOnly = true;
           
            HttpContext.Current.Response.Cookies.Add(cookie);
        }



        /// <summary>
        /// ªÒµ√cookie
        /// </summary>
        /// <param name="infoName"></param>
        /// <returns></returns>
        public static string Get(string infoName)
        {
            string cookieVal = string.Empty;

            try
            {
                HttpCookieCollection cookie = HttpContext.Current.Request.Cookies;
                if (cookie != null && cookie.Count > 0)
                {
                    cookieVal = cookie[infoName].Value;
                }
            }

            catch (Exception e)
            {

            }

            return cookieVal;
        }





    }
}

