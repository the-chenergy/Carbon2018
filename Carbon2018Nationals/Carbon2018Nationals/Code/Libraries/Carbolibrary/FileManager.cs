using Carbon.Properties;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carbolibrary
{

	public class FileManager
	{

		#region ########################## PUBLIC PROPERTIES ############################



		#endregion

		#region ######################### PRIVATE PROPERTIES ############################

		static public string Url { get; protected set; }
		static public string PostAttachmentUrl { get; protected set; }
		static public string UserImageUrl { get; protected set; }
		static public bool IsConnected { get; protected set; }

		#endregion

		#region ########################### PUBLIC METHODS ##############################

		#region *************** BASIC ACTIONS ***************

		static public bool Connect(string url)
		{
			IsConnected = false;

			if (url[url.Length - 1] != '/' || url[url.Length - 1] != '\\')
				url += "/";

			Url = url;
			PostAttachmentUrl = url + "PostAtts/";
			UserImageUrl = url + "UserImgs/";

			if (!Directory.Exists(url)
				|| !Directory.Exists(url = PostAttachmentUrl)
				|| !Directory.Exists(url = UserImageUrl))
			{
				MessageBox.Show(
					$"DIRECTORY \"{url}\" DOES NOT EXIST!!",
					"Oh no!",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);

				return false;
			}

			return (IsConnected = true);
		}

		#endregion

		#region *************** POST ATTACHMENTS ***************

		static public List<PostAttachment> LoadPostAttchmentList(Post post, List<string> ids)
		{
			foreach (string p in ids)
			{
				string url = $"{PostAttachmentUrl}{post.Id}`{p}*.*";

				string[] matchedFiles = Directory.GetFiles(PostAttachmentUrl, $"{post.Id}`{p}`*.*");

				if (matchedFiles.Length == 0)
				{
					MessageBox.Show(
						$"FILE \"{url}\" HAS BEEN DELETED!!",
						"Oh heck!",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error
					);

					continue;
				}

				url = matchedFiles[0];

				// example (postID=1, index=2, extension="png"): ".../1-2.png"

				post.AddAttachment(new PostAttachment(
					url,
					Icon.ExtractAssociatedIcon(url).ToBitmap(),
					new FileInfo(url).Length,
					int.Parse(p)
				));
			}

			return post.Attachments;
		}

		static public PostAttachment CreatePostAttachment(Post post, string url)
		{
			int i = 0;
			for (; ; i++)
			{
				if (Directory.GetFiles(PostAttachmentUrl, $"{post.Id}`{i}`*.*").Length == 0)
					break;
			}

			string targetUrl = $"{PostAttachmentUrl}{post.Id}`{i}`{new FileInfo(url).Name}";

			File.Copy(url, targetUrl, true);

			return new PostAttachment(
				targetUrl,
				Icon.ExtractAssociatedIcon(url).ToBitmap(),
				new FileInfo(url).Length,
				i
			);
		}

		static public IEnumerable<PostAttachment> CreatePostAttachments(Post post, IEnumerable<string> urls)
		{
			return urls.Select(x => CreatePostAttachment(post, x));
		}

		static public void DeletePostAttachment(Post post, PostAttachment attachment)
		{
			File.Delete(Directory.GetFiles(PostAttachmentUrl, $"{post.Id}`{attachment.Id}`*.*")[0]);
		}

		static public void DeleteAllPostAttachmentsById(object id)
		{
			foreach (string p in Directory.GetFiles(PostAttachmentUrl, $"{id}`*.*"))
				File.Delete(p);
		}

		#endregion

		#region *************** USER IMAGES ***************

		static public bool LoadUserImage(User user)
		{
			string[] matchedFiles = Directory.GetFiles(UserImageUrl, $"{user.Id}.*");

			if (matchedFiles.Length == 0)
			{
				user.UserImage = Resources.DefaultUserImage;
				user.UserImage64 = Resources.DefaultUserImage64;

				return false;
			}

			Image temp = Image.FromFile(matchedFiles[0]);
			int length = (int)Math.Pow(2, (int)Math.Log(Math.Max(temp.Width, temp.Height), 2));
			// find the best square size

			user.UserImage = new Bitmap(temp, length, length);
			user.UserImage64 = new Bitmap(temp, 64, 64);

			return true;
		}

		#endregion

		#endregion

		#region ########################### PRIVATE METHODS #############################



		#endregion

	}

}
