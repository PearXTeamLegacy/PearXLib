using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PearXLib
{
    /// <summary>
    /// PearXLib Social Utils.
    /// </summary>
    public class SocialUtils
    {
        /// <summary>
        /// Shares via VKontakte
        /// </summary>
        /// <param name="URL">URL.</param>
        public static void ShareVK(string URL)
        {
            Process.Start("https://vk.com/share.php?url=" + URL);
        }

        /// <summary>
        /// Shares via VKontakte
        /// </summary>
        /// <param name="URL">URL.</param>
        /// <param name="title">Site title.</param>
        public static void ShareVK(string URL, string title)
        {
            Process.Start("https://vk.com/share.php?url=" + URL + "&title=" + title);
        }

        /// <summary>
        /// Shares via VKontakte
        /// </summary>
        /// <param name="URL">URL.</param>
        /// <param name="title">Site title.</param>
        /// <param name="description">Site description.</param>
        public static void ShareVK(string URL, string title, string description)
        {
            Process.Start("https://vk.com/share.php?url=" + URL + "&title=" + title + "&description=" + description);
        }

        /// <summary>
        /// Shares via VKontakte
        /// </summary>
        /// <param name="URL">URL.</param>
        /// <param name="title">Site title.</param>
        /// <param name="description">Site description.</param>
        /// <param name="URL_img">Site image.</param>
        public static void ShareVK(string URL, string title, string description, string URL_img)
        {
            Process.Start("https://vk.com/share.php?url=" + URL + "&title=" + title + "&description=" + description + "&image=" + URL_img);
        }
    }
}
