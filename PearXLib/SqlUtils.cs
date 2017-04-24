using System;
using System.Collections.Generic;
using System.Data.Common;

namespace PearXLib
{
	/// <summary>
	/// PearXLib's SQLUtils.
	/// </summary>
	public static class SqlUtils
	{
		/// <summary>
		/// Escapes a prepared statement argument.
		/// </summary>
		/// <returns>Escaped preapred statement argument.</returns>
		/// <param name="prep">Prepared statement argument.</param>
		public static string EscapePrepared(string prep)
		{
			return prep.Replace("%", @"\%").Replace("_", @"\_");
		}

	    /// <summary>
	    /// Executes a command and gets a list of rows.
	    /// </summary>
	    /// <returns>A list of rows.</returns>
	    /// <param name="cmd">Command.</param>
	    /// <param name="autoclose">Autoclose SQL connection after request?</param>
	    public static List<Dictionary<string, object>> ExecuteListRows(this DbCommand cmd, bool autoclose = true)
	    {
	        var lst = new List<Dictionary<string, object>>();
	        using (var rdr = cmd.ExecuteReader())
	        {
	            while (rdr.Read())
	            {
	                var dict = new Dictionary<string, object>();
	                for (int i = 0; i < rdr.FieldCount; i++)
	                {
	                    try
	                    {
	                        var val = rdr.GetValue(i);
	                        if (val is DBNull)
	                            val = null;
	                        dict.Add(rdr.GetName(i), val);
	                    }
	                    catch
	                    {
	                        dict.Add(rdr.GetName(i), null);
	                    }
	                }
	                lst.Add(dict);
	            }
	            rdr.Close();
	        }
	        if (autoclose)
	            cmd.Connection.Close();
	        return lst;
	    }

	    /// <summary>
	    /// Executes a command and gets a list of columns.
	    /// </summary>
	    /// <returns>A list of columns.</returns>
	    /// <param name="cmd">Command.</param>
	    /// <param name="autoclose">Autoclose SQL connection after request?</param>
	    public static Dictionary<string, List<object>> ExecuteListColumns(this DbCommand cmd, bool autoclose = true)
	    {
	        var dict = new Dictionary<string, List<object>>();

	        using (var rdr = cmd.ExecuteReader())
	        {
	            for (int i = 0; i < rdr.FieldCount; i++)
	            {
	                dict.Add(rdr.GetName(i), new List<object>());
	            }
	            while (rdr.Read())
	            {
	                for (int i = 0; i < rdr.FieldCount; i++)
	                {
	                    try
	                    {
	                        var val = rdr.GetValue(i);
	                        if (val is DBNull)
	                            val = null;
	                        dict[rdr.GetName(i)].Add(val);
	                    }
	                    catch
	                    {
	                        dict[rdr.GetName(i)].Add(null);
	                    }
	                }
	            }
	            rdr.Close();
	        }
	        if (autoclose)
	            cmd.Connection.Close();
	        return dict;
	    }

	    /// <summary>
	    /// Executes a command and gets a single list.
	    /// </summary>
	    /// <returns>A single list.</returns>
	    /// <param name="cmd">Command.</param>
	    /// <param name="autoclose">Autoclose SQL connection after request?</param>
	    public static List<object> ExecuteSingleList(this DbCommand cmd, bool autoclose = true)
	    {
	        var lst = new List<object>();
	        using (var rdr = cmd.ExecuteReader())
	        {
	            while (rdr.Read())
	            {
	                try
	                {
	                    var val = rdr.GetValue(0);
	                    if (val is DBNull)
	                        val = null;
	                    lst.Add(val);
	                }
	                catch
	                {
	                    lst.Add(null);
	                }
	            }
	            rdr.Close();
	        }
	        if (autoclose)
	            cmd.Connection.Close();
	        return lst;
	    }

	    /// <summary>
	    /// Executes a count query.
	    /// </summary>
	    /// <returns>Count.</returns>
	    /// <param name="cmd">Command.</param>
	    /// <param name="autoclose">Autoclose SQL connection after request?</param>
	    public static long ExecuteCount(this DbCommand cmd, bool autoclose = true)
	    {
	        var resp = cmd.ExecuteSingleList(autoclose);
	        return (long)resp[0];
	    }
	}
}
