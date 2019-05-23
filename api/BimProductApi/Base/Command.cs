using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace BimProductApi.Base
{
    public class Command
    {

        /// <summary>
        /// base64编码的文本 转为   图片
        /// </summary>
        /// <param name="basestr">base64字符串</param>
        /// <returns>转换后的Bitmap对象</returns>
        public static string Base64StringToImage(string basestr)
        {
            string rootPath = "Upload/img/";
            string fileName = Guid.NewGuid().ToString() + ".png";

            basestr = basestr.Replace("data:image/png;base64,", "");
            byte[] arr = Convert.FromBase64String(basestr);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);

            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/" + rootPath)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + rootPath));
            }

            bmp.Save(HttpContext.Current.Server.MapPath("~/" + rootPath + fileName), System.Drawing.Imaging.ImageFormat.Png);
            ms.Close();

            return rootPath + fileName;
        }




        /// <summary>
        /// post提交方式上传文件
        /// </summary>
        /// <returns></returns>
        public static List<Dictionary<string,string>>  PostFiles(object files)
        {

            HttpFileCollection filelist = (HttpFileCollection)files;
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
          
            if (filelist != null && filelist.Count > 0)
            {
                for (int i = 0; i < filelist.Count; i++)
                {
                    string fullPath = string.Empty;
                    HttpPostedFile file = filelist[i];
                    String Tpath = HttpContext.Current.Server.MapPath("~/Upload/files/");

                    string FileName = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
                  
                    DirectoryInfo di = new DirectoryInfo(Tpath);
                    if (!di.Exists) { di.Create(); }
                    fullPath = Tpath + FileName;
                    file.SaveAs(fullPath);

                    Dictionary<string, string> curdi = new Dictionary<string, string>();

                    curdi.Add("fullPath", fullPath);
                    curdi.Add("fileName", file.FileName);

                    result.Add(curdi);

                }
            }
            else
            {
                throw new Exception("未选择上传文件！");
            }


            return result;
        }

    }
}