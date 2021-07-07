//
//   Written by Patrik Forsberg 2021 <patrik.forsberg@coldmind.com>
//   This file is part of the TvMaze Work Sample Project
//

using System;

public static class StringUtils
{
	//TODO: Finish
	public static string ObjToStr(Object obj)
	{
		var result = string.Empty;
		
		if (obj is int || obj is double)
		{
			result = obj.ToString();
		}
		else if (obj is float)
		{
			result = ((float) obj).ToString();
		}

		return result;
	}
}