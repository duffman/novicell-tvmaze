/**
 * Coldmind AB ("COMPANY") CONFIDENTIAL
 * Unpublished Copyright (c) 2020 Coldmind AB, All Rights Reserved.
 *
 * NOTICE:  All information contained herein is, and remains the property of COMPANY. The intellectual and technical concepts contained
 * herein are proprietary to COMPANY and may be covered by U.S. and Foreign Patents, patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material is strictly forbidden unless prior written permission is obtained
 * from COMPANY.  Access to the source code contained herein is hereby forbidden to anyone except current COMPANY employees, managers or contractors who have executed
 * Confidentiality and Non-disclosure agreements explicitly covering such access.
 *
 * The copyright notice above does not evidence any actual or intended publication or disclosure  of  this source code, which includes
 * information that is confidential and/or proprietary, and is a trade secret, of  COMPANY.   ANY REPRODUCTION, MODIFICATION, DISTRIBUTION, PUBLIC  PERFORMANCE,
 * OR PUBLIC DISPLAY OF OR THROUGH USE  OF THIS  SOURCE CODE  WITHOUT  THE EXPRESS WRITTEN CONSENT OF COMPANY IS STRICTLY PROHIBITED, AND IN VIOLATION OF APPLICABLE
 * LAWS AND INTERNATIONAL TREATIES.  THE RECEIPT OR POSSESSION OF  THIS SOURCE CODE AND/OR RELATED INFORMATION DOES NOT CONVEY OR IMPLY ANY RIGHTS
 * TO REPRODUCE, DISCLOSE OR DISTRIBUTE ITS CONTENTS, OR TO MANUFACTURE, USE, OR SELL ANYTHING THAT IT  MAY DESCRIBE, IN WHOLE OR IN PART.
 *
 * Created by Patrik Forsberg <patrik.forsberg@coldmind.com>
 * File Date: 2018-04-02 14:09
 */

using System.IO;
using System.Net;
using Coldmind.Utils;

namespace TvMazeWebApp.DataProvider.ColdmindRestIgniter
{
	public interface IHttpHandler
	{
	}

	public interface IColdmindRestClient
	{
		void HelloWorld();
		string Retrieve(string url, ColdmindRestClient.HttpMethod method);
	}


	public class ColdmindRestClient : IColdmindRestClient
	{
		public enum HttpMethod
		{
			Post,
			Get,
			Put,
			Patch,
			Delete
		}

		public void HelloWorld()
		{
			ColdmindQLog.LogGreen("Hello World!");
		}
		
		public string Retrieve(string url, HttpMethod method)
		{
			var request = (HttpWebRequest) WebRequest.Create(url);
			request.Method = method.ToString().ToUpper();
			request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:53.0) Gecko/20100101 Firefox/53.0";
			request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

			var content = string.Empty;

			using (var response = (HttpWebResponse) request.GetResponse())
			{
				using (var stream = response.GetResponseStream())
				{
					using (var sr = new StreamReader(stream))
					{
						content = sr.ReadToEnd();
					}
				}
			}

			return content;
		}
	}
}