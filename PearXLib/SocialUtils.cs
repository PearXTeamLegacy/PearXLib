using System;
using System.Diagnostics;

namespace PearXLib
{
    /// <summary>
    /// PearXLib Social Utilities.
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

        /// <summary>
        /// Shares via Twitter.
        /// </summary>
        /// <param name="text">Text.</param>
        public static void ShareTwitter(string text)
        {
            Process.Start(new Uri("https://twitter.com/intent/tweet?text=" + text).AbsoluteUri);
        }
    }
}
